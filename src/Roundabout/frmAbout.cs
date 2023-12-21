namespace Roundabout;

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
            var url = ctl.Tag?.ToString();
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
