using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roundabout
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            this.lblCurrentVersion.Text = string.Format(this.lblCurrentVersion.Text, 
                Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString());
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OpenLink(object sender, EventArgs e)
        {
            if (sender is Control ctl)
            {
                string url = ctl.Tag?.ToString();
                if (!string.IsNullOrWhiteSpace(url))
                {
                    try
                    {
                        ProcessStartInfo psi = new ProcessStartInfo(url);
                        psi.UseShellExecute = true;
                        System.Diagnostics.Process.Start(psi);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening link: {ex.Message}.\r\n Visit {url}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void OpenLinkLabelLink(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenLink(sender, EventArgs.Empty);
        }
    }
}
