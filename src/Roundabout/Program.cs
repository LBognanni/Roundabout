namespace Roundabout;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        using var log = new LoggerConfiguration()
            .WriteTo.File(
                Path.Combine(Path.GetTempPath(), "Roundabout_log.txt"), 
                retainedFileCountLimit: 1, 
                fileSizeLimitBytes: 1024*1024, // 1mb
                rollOnFileSizeLimit: true)
            .CreateLogger();

        log.Information("Args: " + String.Join(" ", args));

        if(args.Length > 0 && args[0] == "--register")
        {
            log.Information("Registering protocol handler");
            ProtocolHandling.Register();
            return;
        }
        if (args.Length > 0 && args[0] == "--unregister")
        {
            log.Information("Unregistering protocol handler");
            ProtocolHandling.UnRegister();
            return;
        }
        string url = "https://codemade.net";
        if(args.Length > 0)
        {
            url = args[0];
        }
        log.Information("URL: " + url);

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        try
        {
            var parent = GetParentAndCreateSacrificalForm(log);


            log.Debug("Starting application");

            var model = new frmAppViewModel(url, parent, new BrowsersFinder(log), new Settings(), new WindowsInterop());

            var mainForm = new frmApp(model, log);
            log.Debug("Showing form");
            Application.ThreadException += (s, e) => log.Error(e.Exception.ToString());
            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            log.Error(ex.ToString());
        }
    }
    
    [DllImport("user32.dll")]
    static extern IntPtr WindowFromPoint(Point p);
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    /// <summary>
    /// Slack "Swallows" Roundabout when first launched.
    /// This hack creates a sacrifical form to be swallowed instead.
    /// </summary>
    private static string GetParentAndCreateSacrificalForm(ILogger logger)
    {
        var parent = GetParentWindow(logger);
        var hungryApps = new string[] { "Slack" };

        if (hungryApps.Contains(parent, StringComparer.OrdinalIgnoreCase))
        {
            CreateSacrificalForm();
        }

        return parent;
    }

    public static void CreateSacrificalForm()
    {
        Form form = new Form();
        form.Show();
        form.Close();
    }

    private static string GetParentWindow(ILogger logger)
    {
        var pos = Cursor.Position;
        var hwnd = WindowFromPoint(pos);
        if (hwnd == IntPtr.Zero)
            return "";

        GetWindowThreadProcessId(hwnd, out uint pid);
        var parent = Process.GetProcessById((int)pid).ProcessName;
        
        logger.Information($"Parent process: {parent}");
        return parent;
    }
}