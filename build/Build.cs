using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using Octokit;
using static System.Net.Mime.MediaTypeNames;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build")]
    readonly Configuration Configuration = Configuration.Release;

    [Solution] readonly Solution Solution;

    [GitVersion(Framework = "net8.0", UpdateAssemblyInfo = true, UpdateBuildNumber = true)]
    readonly GitVersion GitVersion;
    private readonly string GIT_OWNER = "LBognanni";
    private readonly string GIT_REPO = "Roundabout";

    AbsolutePath OutputDirectory => RootDirectory / "output";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            OutputDirectory.CreateOrCleanDirectory();
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetAssemblyVersion(GitVersion.AssemblySemVer)
                .SetFileVersion(GitVersion.AssemblySemFileVer)
                .SetInformationalVersion(GitVersion.InformationalVersion)
                .SetVerbosity(DotNetVerbosity.Minimal)
                .SetNoRestore(true)
            );

            DotNetPublish(s => s
                .SetProject(Solution.GetProject("Roundabout"))
                .SetConfiguration(Configuration)
                .SetAssemblyVersion(GitVersion.AssemblySemVer)
                .SetFileVersion(GitVersion.AssemblySemFileVer)
                .SetInformationalVersion(GitVersion.InformationalVersion)
                .SetVerbosity(DotNetVerbosity.Minimal)
                .SetNoRestore(true)
                .SetOutput(OutputDirectory)
            );
        });


    Target Setup => _ => _
        .DependsOn(Compile)
        .Executes(() => {
            var innoLocation = Environment.ExpandEnvironmentVariables(@"%userprofile%\.nuget\packages\tools.innosetup");
            if (!Directory.Exists(innoLocation))
            {
                throw new Exception("InnoSetup location not found");
            }
            var folders = Directory.GetDirectories(innoLocation);
            if (!folders.Any())
            {
                throw new Exception("No version of InnoSetup found");
            }
            var latestVersion = folders.OrderByDescending(f => f).First();
            var isccPath = Path.Combine(latestVersion, "tools", "ISCC.exe");
            if (!File.Exists(isccPath))
            {
                throw new Exception("InnoSetup executable not found");
            }
            var process = System.Diagnostics.Process.Start(isccPath, $"setup.iss /DAppVersion={GitVersion.AssemblySemVer}");
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                throw new Exception("Setup build did not run successfully :(");
            }
        });

    Target Release => _ => _
        .DependsOn(Setup)
        .Executes(async () =>
        {
            var githubToken = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
            var tokenAuth = new Credentials(githubToken);
            var client = new GitHubClient(new ProductHeaderValue("build"));
            client.Credentials = tokenAuth;

            var tag = $"{GitVersion.AssemblySemVer}";
            var release = await CreateRelease(client, tag);
            await UploadRelease(client, release, tag);
        });

    Target ReleaseBeta => _ => _
        .DependsOn(Setup)
        .Executes(async () =>
        {
            var githubToken = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
            var tokenAuth = new Credentials(githubToken);
            var client = new GitHubClient(new ProductHeaderValue("build"));
            client.Credentials = tokenAuth;

            var tag = $"{GitVersion.AssemblySemVer}-beta";
            var release = await CreateRelease(client, tag, true);
            await UploadRelease(client, release, tag);
        });

    private async Task<Release> CreateRelease(GitHubClient client, string version, bool isBeta = false)
    {
        var newRelease = new NewRelease(version)
        {
            Name = $"Version {version}",
            Body = "Please see [the official page](https://www.codemade.co.uk/roundabout) for release notes.",
            Draft = true,
            Prerelease = isBeta
        };

        Serilog.Log.Information($"Creating release {version}");
        return await client.Repository.Release.Create(GIT_OWNER, GIT_REPO, newRelease);
    }

    private async Task UploadRelease(GitHubClient client, Release release, string version)
    {
        await UploadAsset(client, release, "roundabout-setup.exe");
        //await UploadAsset(client, release, "Roundabout.exe");
    }

    private async Task UploadAsset(GitHubClient client, Release release, string fileName)
    {
        using (var archiveContents = File.OpenRead($@"output\{fileName}"))
        {
            var assetUpload = new ReleaseAssetUpload()
            {
                FileName = fileName,
                ContentType = "application/vnd.microsoft.portable-executable",
                RawData = archiveContents
            };
            Serilog.Log.Information($"Uploading {fileName}...");
            var asset = await client.Repository.Release.UploadAsset(release, assetUpload);
        }
    }

}
