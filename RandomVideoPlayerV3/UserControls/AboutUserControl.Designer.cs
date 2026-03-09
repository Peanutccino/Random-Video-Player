namespace RandomVideoPlayer.UserControls
{
    partial class AboutUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutMain = new TableLayoutPanel();
            cbUpdateAlwaysCheck = new RandomVideoPlayer.Controls.CustomCheckBox();
            rtbConsole = new RichTextBox();
            lblHeader = new Label();
            panel1 = new Panel();
            lblSubtitle = new Label();
            lblBanner = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblLatestVersion = new Label();
            btnSync = new FontAwesome.Sharp.IconButton();
            lblCurrentVersion = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnCancel = new FontAwesome.Sharp.IconButton();
            btnGitHub = new FontAwesome.Sharp.IconButton();
            tableLayoutMain.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.Thistle;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(cbUpdateAlwaysCheck, 0, 3);
            tableLayoutMain.Controls.Add(rtbConsole, 0, 5);
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 1);
            tableLayoutMain.Controls.Add(tableLayoutPanel1, 0, 2);
            tableLayoutMain.Controls.Add(tableLayoutPanel2, 0, 4);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 6;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 57F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // cbUpdateAlwaysCheck
            // 
            cbUpdateAlwaysCheck.BoxSize = 13;
            cbUpdateAlwaysCheck.Dock = DockStyle.Fill;
            cbUpdateAlwaysCheck.HoverColor = Color.DeepSkyBlue;
            cbUpdateAlwaysCheck.Location = new Point(3, 181);
            cbUpdateAlwaysCheck.Name = "cbUpdateAlwaysCheck";
            cbUpdateAlwaysCheck.PaddingLeft = 12;
            cbUpdateAlwaysCheck.Size = new Size(518, 23);
            cbUpdateAlwaysCheck.TabIndex = 10;
            cbUpdateAlwaysCheck.Text = "Always check on startup";
            cbUpdateAlwaysCheck.UseVisualStyleBackColor = true;
            // 
            // rtbConsole
            // 
            rtbConsole.BackColor = Color.GhostWhite;
            rtbConsole.BorderStyle = BorderStyle.None;
            rtbConsole.Dock = DockStyle.Fill;
            rtbConsole.Font = new Font("Courier New", 9F);
            rtbConsole.HideSelection = false;
            rtbConsole.Location = new Point(3, 317);
            rtbConsole.Name = "rtbConsole";
            rtbConsole.ReadOnly = true;
            rtbConsole.ScrollBars = RichTextBoxScrollBars.None;
            rtbConsole.Size = new Size(518, 336);
            rtbConsole.TabIndex = 9;
            rtbConsole.Text = "";
            rtbConsole.Visible = false;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 6;
            lblHeader.Text = "About";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSteelBlue;
            panel1.Controls.Add(lblSubtitle);
            panel1.Controls.Add(lblBanner);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 65);
            panel1.TabIndex = 7;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Dock = DockStyle.Top;
            lblSubtitle.Location = new Point(0, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(518, 32);
            lblSubtitle.TabIndex = 8;
            lblSubtitle.Text = "by Peanutccino";
            lblSubtitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblBanner
            // 
            lblBanner.Dock = DockStyle.Top;
            lblBanner.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBanner.ForeColor = Color.DarkMagenta;
            lblBanner.Location = new Point(0, 0);
            lblBanner.Name = "lblBanner";
            lblBanner.Size = new Size(518, 50);
            lblBanner.TabIndex = 7;
            lblBanner.Text = "Random Video Player";
            lblBanner.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.GreenYellow;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(lblLatestVersion, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSync, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCurrentVersion, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 134);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(518, 41);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // lblLatestVersion
            // 
            lblLatestVersion.AutoEllipsis = true;
            lblLatestVersion.Dock = DockStyle.Top;
            lblLatestVersion.Location = new Point(3, 20);
            lblLatestVersion.Name = "lblLatestVersion";
            lblLatestVersion.Size = new Size(453, 20);
            lblLatestVersion.TabIndex = 12;
            lblLatestVersion.Text = "Latest Version:      -";
            // 
            // btnSync
            // 
            btnSync.Dock = DockStyle.Right;
            btnSync.FlatAppearance.BorderSize = 0;
            btnSync.FlatStyle = FlatStyle.Flat;
            btnSync.IconChar = FontAwesome.Sharp.IconChar.Refresh;
            btnSync.IconColor = Color.Indigo;
            btnSync.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSync.IconSize = 34;
            btnSync.Location = new Point(462, 5);
            btnSync.Margin = new Padding(3, 5, 3, 5);
            btnSync.Name = "btnSync";
            tableLayoutPanel1.SetRowSpan(btnSync, 2);
            btnSync.Size = new Size(53, 31);
            btnSync.TabIndex = 11;
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += btnSync_Click;
            // 
            // lblCurrentVersion
            // 
            lblCurrentVersion.AutoEllipsis = true;
            lblCurrentVersion.Dock = DockStyle.Top;
            lblCurrentVersion.Location = new Point(3, 0);
            lblCurrentVersion.Name = "lblCurrentVersion";
            lblCurrentVersion.Size = new Size(453, 20);
            lblCurrentVersion.TabIndex = 9;
            lblCurrentVersion.Text = "Current Version: 1.57";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnCancel, 0, 1);
            tableLayoutPanel2.Controls.Add(btnGitHub, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 210);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.Size = new Size(518, 101);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top;
            btnCancel.BackColor = Color.LightPink;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = Color.Black;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 24;
            btnCancel.ImageAlign = ContentAlignment.TopLeft;
            btnCancel.Location = new Point(207, 68);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(6, 0, 8, 0);
            btnCancel.Size = new Size(104, 24);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.TextAlign = ContentAlignment.BottomCenter;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnGitHub
            // 
            btnGitHub.Anchor = AnchorStyles.Top;
            btnGitHub.BackColor = Color.Lavender;
            btnGitHub.FlatAppearance.BorderSize = 0;
            btnGitHub.FlatStyle = FlatStyle.Flat;
            btnGitHub.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            btnGitHub.IconChar = FontAwesome.Sharp.IconChar.Github;
            btnGitHub.IconColor = Color.Black;
            btnGitHub.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGitHub.IconSize = 42;
            btnGitHub.ImageAlign = ContentAlignment.MiddleLeft;
            btnGitHub.Location = new Point(169, 3);
            btnGitHub.Name = "btnGitHub";
            btnGitHub.Size = new Size(180, 55);
            btnGitHub.TabIndex = 5;
            btnGitHub.Text = "GitHub";
            btnGitHub.TextAlign = ContentAlignment.TopRight;
            btnGitHub.UseVisualStyleBackColor = false;
            btnGitHub.Click += btnGitHub_Click;
            // 
            // AboutUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(tableLayoutMain);
            Name = "AboutUserControl";
            Size = new Size(524, 656);
            Leave += AboutUserControl_Leave;
            tableLayoutMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Panel panel1;
        private Label lblBanner;
        private Label lblSubtitle;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblCurrentVersion;
        private FontAwesome.Sharp.IconButton btnSync;
        private Label lblLatestVersion;
        private RichTextBox rtbConsole;
        private Controls.CustomCheckBox cbUpdateAlwaysCheck;
        private TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnGitHub;
        private FontAwesome.Sharp.IconButton btnCancel;
    }
}
