namespace Roundabout;

internal class BrowsersFinder : IBrowsersFinder
{
    private readonly ILogger _logger;

    public BrowsersFinder(ILogger logger)
    {
        _logger = logger;
    }

    public IEnumerable<Browser> FindBrowsers() =>
        FindBrowsers(Microsoft.Win32.Registry.CurrentUser, _logger)
        .Union(
            FindBrowsers(Microsoft.Win32.Registry.LocalMachine, _logger)
        );

    private static IEnumerable<Browser> FindBrowsers(Microsoft.Win32.RegistryKey rk, ILogger logger)
    {
        logger.Debug("Finding browsers in " + rk.Name);

        var hkcu_registeredapps = rk.OpenSubKey("SOFTWARE\\RegisteredApplications");
        if (hkcu_registeredapps == null)
            yield break;

        var keys = hkcu_registeredapps.GetValueNames();
        foreach (var key in keys)
        {
            var appId = hkcu_registeredapps.GetValue(key)?.ToString();
            var urls = rk.OpenSubKey(appId + "\\URLAssociations\\");
            if (urls == null)
                continue;

            var classes = urls.GetValue("https");
            if (classes == null)
                continue;

            var command = rk.OpenSubKey($"Software\\Classes\\{classes}\\shell\\open\\command")?.GetValue(null)?.ToString();
            if (command == null)
                continue;

            var appKey = rk.OpenSubKey(appId);
            var friendlyName = appKey.GetValue("ApplicationName")?.ToString() ?? "Unknown Browser";
            var icon = appKey?.GetValue("ApplicationIcon")?.ToString();

            if (icon == null)
                continue;   // this excludes IE and an extra Edge

            if (friendlyName == ProtocolHandling.AppName)
                continue;   // this excludes Roundabout itself

            yield return new Browser(friendlyName, command, icon);
        }
    }
}
