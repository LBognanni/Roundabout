using ReactiveUI;
using System.Reactive.Disposables;
using System.Runtime.InteropServices;

namespace Roundabout
{
    public partial class frmApp : Form, IViewFor<frmAppViewModel>
    {
        private bool showingChildForm = false;

        public frmAppViewModel? ViewModel { get; set; }
        object? IViewFor.ViewModel { get => this.ViewModel; set => ViewModel = value as frmAppViewModel; }

        public frmApp(frmAppViewModel model)
        {
            InitializeComponent();

            this.SuspendLayout();

            ViewModel = model;
            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel,
                    vm => vm.Url,
                    f => f.txtUrl.Text,
                    txtUrl.Events().TextChanged
                ).DisposeWith(disposable);

                this.OneWayBind(ViewModel, vm => vm.Url, f => f.Text)
                    .DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.Browsers,
                    frm => frm.flpButtons.Controls,
                    vmToViewConverterOverride: new BrowserListConverter(ViewModel)
                ).DisposeWith(disposable);
            });

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
            if (!showingChildForm)
            {
                Program.Log("closing.");
                this.Close();
            }
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

        private void aboutRoundaboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            showingChildForm = true;
            about.ShowDialog();
            showingChildForm = false;
        }

        private void llMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cmsMenu.Show(this.llMenu, new Point(0, this.llMenu.Height / 2));
        }

    }
}