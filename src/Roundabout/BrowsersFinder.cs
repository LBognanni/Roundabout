using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roundabout
{
    internal class BrowsersFinder
    {
        public static IEnumerable<Browser> FindBrowsers() => 
            FindBrowsers(Microsoft.Win32.Registry.CurrentUser)
            .Union(
                FindBrowsers(Microsoft.Win32.Registry.LocalMachine)
            );

        private static IEnumerable<Browser> FindBrowsers(Microsoft.Win32.RegistryKey rk)
        {
            Program.Log("Finding browsers in " + rk.Name);

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

                if(friendlyName == ProtocolHandling.AppName)
                    continue;   // this excludes Roundabout itself

                yield return new Browser(friendlyName, command, icon);
            }
        }
    }
}
