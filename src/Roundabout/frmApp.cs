using System.Runtime.InteropServices;

namespace Roundabout
{
    public partial class frmApp : Form
    {
        public frmApp(string url)
        {
            InitializeComponent();

            this.SuspendLayout();


            var browsers = BrowsersFinder.FindBrowsers();
            this.txtUrl.Text = url;
            this.Text = string.Format(this.Text, url);
            foreach (var browser in browsers)
            {
                var button = new Button();
                button.Text = AddNewlines(browser.Name);
                button.Image = browser.GetImage();
                button.Size = new Size(120, 120);
                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.TextAlign = ContentAlignment.BottomCenter;
                button.AutoSizeMode = AutoSizeMode.GrowOnly;
                button.AutoSize = true;
                button.Tag = browser.Command;
                button.FlatStyle = FlatStyle.Flat;
                button.Cursor = Cursors.Hand;
                button.Click += Button_Click;
                this.flpButtons.Controls.Add(button);
            }
            this.txtUrl.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            };
            
            this.ResumeLayout();

            Program.Log("Main form ready.");
        }

        override protected void OnActivated(EventArgs e)
        {
            Program.Log("Main form active.");
            base.OnActivated(e);
            this.txtUrl.SelectAll();
            this.txtUrl.Focus();
            this.BringToFront();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            Program.Log("closing.");
            this.Close();
        }

        private string AddNewlines(string name)
        {
            if (name.Count(x => x == ' ') > 1)
            {
                var index = name.IndexOf(' ');
                index = name.IndexOf(' ', index + 1);
                return name.Substring(0, index) + "\r\n" + name.Substring(index + 1);
            }

            return name;
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            var button = sender as Button;
            var command = button?.Tag?.ToString();
            if (!string.IsNullOrEmpty(command))
            {
                var si = new STARTUPINFO();
                var _ = new PROCESS_INFORMATION();
                CreateProcess(
                    null!,
                    command.Replace("%1", this.txtUrl.Text),
                    IntPtr.Zero,
                    IntPtr.Zero,
                    false,
                    0,
                    IntPtr.Zero,
                    null!,
                    ref si,
                    out _);
            }
        }



        [DllImport("kernel32.dll")]
        static extern bool CreateProcess(
    string lpApplicationName,
    string lpCommandLine,
    IntPtr lpProcessAttributes,
    IntPtr lpThreadAttributes,
    bool bInheritHandles,
    uint dwCreationFlags,
    IntPtr lpEnvironment,
    string lpCurrentDirectory,
    ref STARTUPINFO lpStartupInfo,
    out PROCESS_INFORMATION lpProcessInformation);

        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }

        public struct STARTUPINFO
        {
            public uint cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
    }
}