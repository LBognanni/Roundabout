using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Roundabout
{
    internal static class Program
    {
        public static void Log(params string[] message)
        {
            File.AppendAllLines(Path.Combine(Path.GetTempPath(), "Roundabout_log.txt"), message);
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Log("", "---");
            Log(DateTime.Now.ToString());
            Log(args);

            if(args.Length > 0 && args[0] == "--register")
            {
                Log("Registering protocol handler");
                ProtocolHandling.Register();
                return;
            }
            if (args.Length > 0 && args[0] == "--unregister")
            {
                Log("Unregistering protocol handler");
                ProtocolHandling.UnRegister();
                return;
            }
            string url = "https://codemade.net";
            if(args.Length > 0)
            {
                url = args[0];
            }
            Log("URL: " + url);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            try
            {
                CreateSacrificalForm();


                Log("Starting application");

                var model = new frmAppViewModel(url, "", new BrowsersFinder(), new Settings(), new WindowsInterop());

                var mainForm = new frmApp(model);
                Log("Showing form");
                Application.ThreadException += (s, e) => Log(e.Exception.ToString());
                Application.Run(mainForm);
                //mainForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
        }
        
        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(System.Drawing.Point p);
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        /// <summary>
        /// Slack "Swallows" Roundabout when first launched.
        /// This hack creates a sacrifical form to be swallowed instead.
        /// </summary>
        private static void CreateSacrificalForm()
        {
            var pos = Cursor.Position;
            var hwnd = WindowFromPoint(pos);
            if(hwnd == IntPtr.Zero)
                return;
            GetWindowThreadProcessId(hwnd, out uint pid);
            var parent = Process.GetProcessById((int)pid).ProcessName;
            Log($"Parent process: {parent}");

            if (parent.Equals("Slack", StringComparison.OrdinalIgnoreCase))
            {
                Form form = new Form();
                form.Show();
                form.Close();
            }
        }
    }
}