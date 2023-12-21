namespace Roundabout;

public static class ProtocolHandling
{
    public const string AppName = "RoundaboutBrowser";
    const string appURL = "RoundaboutBrowserURL";

    public static void Register()
    {
        string exe = Application.ExecutablePath;// System.Reflection.Assembly.GetExecutingAssembly().Location;
        
        CreateKeys($@"SOFTWARE\{AppName}\Capabilities", new Dictionary<string, string>()
        {
            { "ApplicationName", AppName },
            { "ApplicationDescription", "Roundabout browser selector" },
            { "ApplicationIcon", $"{exe},0" },
        }); 
        
        CreateKeys($@"SOFTWARE\{AppName}\Capabilities\URLAssociations", new Dictionary<string, string>()
        {
            { "http", appURL },
            { "https", appURL },
        });


        CreateKeys($@"SOFTWARE\RegisteredApplications", new Dictionary<string, string>()
        {
            { AppName, $@"SOFTWARE\{AppName}\Capabilities" },
        });

        CreateKeyWithValue(@"SOFTWARE\Classes\{appURL}", "http opener");
        CreateKeyWithValue($@"SOFTWARE\Classes\{appURL}\shell\open\command", $"\"{exe}\" \"%1\"");
    }

    public static void UnRegister()
    {
        DeleteSubKeyTree($@"SOFTWARE\{AppName}");
        DeleteKey($@"SOFTWARE\RegisteredApplications", AppName);
        DeleteSubKeyTree($@"SOFTWARE\Classes\{appURL}");
    }

    private static void DeleteKey(string key, string name)
    {
        var registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(key, true);
        registryKey?.DeleteValue(name);
    }

    private static void DeleteSubKeyTree(string v) => 
        Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree(v);

    private static void CreateKeyWithValue(string key, string value) => 
        Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key).SetValue(null, value);

    private static void CreateKeys(string key, Dictionary<string, string> values)
    {
        var subKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key);
        foreach (var value in values)
        {
            subKey.SetValue(value.Key, value.Value);
        }
    }
}
