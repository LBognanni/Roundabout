namespace Roundabout
{
    partial class frmAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            lblCurrentVersion = new Label();
            lblNewVersion = new LinkLabel();
            label2 = new Label();
            picDonate = new PictureBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            linkLabel1 = new LinkLabel();
            ilLinks = new ImageList(components);
            label4 = new Label();
            lnkCodeMade = new LinkLabel();
            label3 = new Label();
            linkLabel3 = new LinkLabel();
            cmdClose = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDonate).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 0);
            tableLayoutPanel1.Controls.Add(cmdClose, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.3333359F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(531, 267);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources._128;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(3, 0, 3, 0);
            pictureBox1.Size = new Size(134, 238);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.Window;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(lblCurrentVersion);
            flowLayoutPanel1.Controls.Add(lblNewVersion);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(picDonate);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(134, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(8, 4, 0, 0);
            flowLayoutPanel1.Size = new Size(397, 238);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(11, 4);
            label1.Margin = new Padding(3, 0, 3, 8);
            label1.Name = "label1";
            label1.Size = new Size(140, 30);
            label1.TabIndex = 2;
            label1.Text = "Roundabout";
            // 
            // lblCurrentVersion
            // 
            lblCurrentVersion.AutoSize = true;
            lblCurrentVersion.Location = new Point(11, 42);
            lblCurrentVersion.Name = "lblCurrentVersion";
            lblCurrentVersion.Size = new Size(62, 15);
            lblCurrentVersion.TabIndex = 6;
            lblCurrentVersion.Text = "Version {0}";
            // 
            // lblNewVersion
            // 
            lblNewVersion.AutoSize = true;
            lblNewVersion.Location = new Point(11, 57);
            lblNewVersion.Margin = new Padding(3, 0, 3, 8);
            lblNewVersion.Name = "lblNewVersion";
            lblNewVersion.Size = new Size(288, 15);
            lblNewVersion.TabIndex = 7;
            lblNewVersion.TabStop = true;
            lblNewVersion.Tag = "https://codemade.net";
            lblNewVersion.Text = "A new version is available! Download version {0} here!";
            lblNewVersion.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 80);
            label2.Name = "label2";
            label2.Size = new Size(377, 30);
            label2.TabIndex = 9;
            label2.Text = "Roundabout is free software distributed under the GPL license. If you find this useful, please consider donating by clicking the button below";
            // 
            // picDonate
            // 
            picDonate.Cursor = Cursors.Hand;
            picDonate.Image = Properties.Resources.bmc_button_128;
            picDonate.Location = new Point(11, 113);
            picDonate.Name = "picDonate";
            picDonate.Size = new Size(128, 36);
            picDonate.SizeMode = PictureBoxSizeMode.AutoSize;
            picDonate.TabIndex = 8;
            picDonate.TabStop = false;
            picDonate.Tag = "https://www.buymeacoffee.com/codemade";
            picDonate.Click += OpenLink;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(linkLabel1);
            flowLayoutPanel2.Controls.Add(label4);
            flowLayoutPanel2.Controls.Add(lnkCodeMade);
            flowLayoutPanel2.Controls.Add(label3);
            flowLayoutPanel2.Controls.Add(linkLabel3);
            flowLayoutPanel2.Location = new Point(8, 160);
            flowLayoutPanel2.Margin = new Padding(0, 8, 0, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(326, 33);
            flowLayoutPanel2.TabIndex = 10;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.ImageAlign = ContentAlignment.MiddleLeft;
            linkLabel1.ImageIndex = 0;
            linkLabel1.ImageList = ilLinks;
            linkLabel1.Location = new Point(3, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Padding = new Padding(17, 0, 0, 0);
            linkLabel1.Size = new Size(60, 15);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Tag = "https://github.com/LBognanni/Roundabout";
            linkLabel1.Text = "Github";
            linkLabel1.Click += OpenLink;
            // 
            // ilLinks
            // 
            ilLinks.ColorDepth = ColorDepth.Depth8Bit;
            ilLinks.ImageStream = (ImageListStreamer)resources.GetObject("ilLinks.ImageStream");
            ilLinks.TransparentColor = Color.Transparent;
            ilLinks.Images.SetKeyName(0, "github-icon.png");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 0);
            label4.Name = "label4";
            label4.Size = new Size(10, 15);
            label4.TabIndex = 4;
            label4.Text = "|";
            // 
            // lnkCodeMade
            // 
            lnkCodeMade.AutoSize = true;
            flowLayoutPanel2.SetFlowBreak(lnkCodeMade, true);
            lnkCodeMade.Location = new Point(85, 0);
            lnkCodeMade.Name = "lnkCodeMade";
            lnkCodeMade.Size = new Size(178, 15);
            lnkCodeMade.TabIndex = 1;
            lnkCodeMade.TabStop = true;
            lnkCodeMade.Tag = "https://codemade.net";
            lnkCodeMade.Text = "More software @ CodeMade.net";
            lnkCodeMade.Click += OpenLink;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 18);
            label3.Margin = new Padding(3, 3, 0, 0);
            label3.Name = "label3";
            label3.Size = new Size(222, 15);
            label3.TabIndex = 2;
            label3.Text = "Found a bug? Looking for a new feature?";
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.ImageAlign = ContentAlignment.MiddleLeft;
            linkLabel3.ImageIndex = 0;
            linkLabel3.ImageList = ilLinks;
            linkLabel3.Location = new Point(225, 18);
            linkLabel3.Margin = new Padding(0, 3, 3, 0);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Padding = new Padding(17, 0, 0, 0);
            linkLabel3.Size = new Size(98, 15);
            linkLabel3.TabIndex = 3;
            linkLabel3.TabStop = true;
            linkLabel3.Tag = "https://github.com/LBognanni/Roundabout/issues";
            linkLabel3.Text = "Open an issue";
            linkLabel3.Click += OpenLink;
            // 
            // cmdClose
            // 
            cmdClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cmdClose.Location = new Point(453, 241);
            cmdClose.Name = "cmdClose";
            cmdClose.Size = new Size(75, 23);
            cmdClose.TabIndex = 4;
            cmdClose.Text = "&Close";
            cmdClose.UseVisualStyleBackColor = true;
            cmdClose.Click += cmdClose_Click;
            // 
            // frmAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cmdClose;
            ClientSize = new Size(531, 267);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "About Roundabout";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDonate).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private Label lblCurrentVersion;
        private LinkLabel lblNewVersion;
        private Label label2;
        private PictureBox picDonate;
        private FlowLayoutPanel flowLayoutPanel2;
        private LinkLabel linkLabel1;
        private ImageList ilLinks;
        private Label label4;
        private LinkLabel lnkCodeMade;
        private Label label3;
        private LinkLabel linkLabel3;
        private Button cmdClose;
    }
}