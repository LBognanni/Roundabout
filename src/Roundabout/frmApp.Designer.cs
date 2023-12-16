namespace Roundabout
{
    partial class frmApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApp));
            flpButtons = new FlowLayoutPanel();
            tlpBottom = new TableLayoutPanel();
            llMenu = new LinkLabel();
            txtUrl = new TextBox();
            tlpBottom.SuspendLayout();
            SuspendLayout();
            // 
            // flpButtons
            // 
            flpButtons.AutoSize = true;
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Location = new Point(0, 0);
            flpButtons.Name = "flpButtons";
            flpButtons.Size = new Size(402, 156);
            flpButtons.TabIndex = 0;
            // 
            // tlpBottom
            // 
            tlpBottom.AutoSize = true;
            tlpBottom.ColumnCount = 2;
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle());
            tlpBottom.Controls.Add(llMenu, 1, 0);
            tlpBottom.Controls.Add(txtUrl, 0, 0);
            tlpBottom.Dock = DockStyle.Bottom;
            tlpBottom.Location = new Point(0, 127);
            tlpBottom.Name = "tlpBottom";
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBottom.Size = new Size(402, 29);
            tlpBottom.TabIndex = 1;
            // 
            // llMenu
            // 
            llMenu.Anchor = AnchorStyles.Right;
            llMenu.AutoSize = true;
            llMenu.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold);
            llMenu.LinkBehavior = LinkBehavior.NeverUnderline;
            llMenu.LinkColor = SystemColors.ActiveCaptionText;
            llMenu.Location = new Point(376, 7);
            llMenu.Name = "llMenu";
            llMenu.Size = new Size(23, 15);
            llMenu.TabIndex = 0;
            llMenu.TabStop = true;
            llMenu.Text = "";
            // 
            // txtUrl
            // 
            txtUrl.Dock = DockStyle.Fill;
            txtUrl.Location = new Point(3, 3);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(367, 23);
            txtUrl.TabIndex = 1;
            // 
            // frmApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(402, 156);
            Controls.Add(tlpBottom);
            Controls.Add(flpButtons);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Open {0} in...";
            tlpBottom.ResumeLayout(false);
            tlpBottom.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpButtons;
        private TableLayoutPanel tlpBottom;
        private LinkLabel llMenu;
        private TextBox txtUrl;
    }
}