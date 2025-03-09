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
            lblHeader = new Label();
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelVersion = new Panel();
            lblLatestVersion = new Label();
            lblCurrentVersion = new Label();
            btnSync = new FontAwesome.Sharp.IconButton();
            btnGitHub = new FontAwesome.Sharp.IconButton();
            panelBody = new Panel();
            cbUpdateAlwaysCheck = new Controls.CustomCheckBox();
            btnCancel = new FontAwesome.Sharp.IconButton();
            rtbConsole = new RichTextBox();
            panelVersion.SuspendLayout();
            panelBody.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(482, 55);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "About";
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.DarkMagenta;
            lblTitle.Location = new Point(0, 55);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(482, 50);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Random Video Player";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Dock = DockStyle.Top;
            lblSubtitle.Location = new Point(0, 105);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(482, 32);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "by Peanutccino";
            lblSubtitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // panelVersion
            // 
            panelVersion.Controls.Add(lblLatestVersion);
            panelVersion.Controls.Add(lblCurrentVersion);
            panelVersion.Controls.Add(btnSync);
            panelVersion.Dock = DockStyle.Top;
            panelVersion.Location = new Point(0, 137);
            panelVersion.Name = "panelVersion";
            panelVersion.Size = new Size(482, 47);
            panelVersion.TabIndex = 3;
            // 
            // lblLatestVersion
            // 
            lblLatestVersion.AutoEllipsis = true;
            lblLatestVersion.Dock = DockStyle.Top;
            lblLatestVersion.Location = new Point(0, 20);
            lblLatestVersion.Name = "lblLatestVersion";
            lblLatestVersion.Padding = new Padding(3);
            lblLatestVersion.Size = new Size(429, 20);
            lblLatestVersion.TabIndex = 3;
            lblLatestVersion.Text = "Latest Version:      -";
            // 
            // lblCurrentVersion
            // 
            lblCurrentVersion.AutoEllipsis = true;
            lblCurrentVersion.Dock = DockStyle.Top;
            lblCurrentVersion.Location = new Point(0, 0);
            lblCurrentVersion.Name = "lblCurrentVersion";
            lblCurrentVersion.Padding = new Padding(3);
            lblCurrentVersion.Size = new Size(429, 20);
            lblCurrentVersion.TabIndex = 2;
            lblCurrentVersion.Text = "Current Version: 1.57";
            // 
            // btnSync
            // 
            btnSync.Dock = DockStyle.Right;
            btnSync.FlatAppearance.BorderSize = 0;
            btnSync.FlatStyle = FlatStyle.Flat;
            btnSync.IconChar = FontAwesome.Sharp.IconChar.Sync;
            btnSync.IconColor = Color.Indigo;
            btnSync.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSync.IconSize = 34;
            btnSync.Location = new Point(429, 0);
            btnSync.Margin = new Padding(3, 5, 3, 5);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(53, 47);
            btnSync.TabIndex = 4;
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += btnSync_Click;
            // 
            // btnGitHub
            // 
            btnGitHub.Anchor = AnchorStyles.Top;
            btnGitHub.BackColor = Color.Lavender;
            btnGitHub.FlatAppearance.BorderSize = 0;
            btnGitHub.FlatStyle = FlatStyle.Flat;
            btnGitHub.Font = new Font("Segoe UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            btnGitHub.IconChar = FontAwesome.Sharp.IconChar.Github;
            btnGitHub.IconColor = Color.Black;
            btnGitHub.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGitHub.IconSize = 42;
            btnGitHub.ImageAlign = ContentAlignment.MiddleLeft;
            btnGitHub.Location = new Point(151, 28);
            btnGitHub.Name = "btnGitHub";
            btnGitHub.Size = new Size(180, 55);
            btnGitHub.TabIndex = 4;
            btnGitHub.Text = "GitHub";
            btnGitHub.TextAlign = ContentAlignment.TopRight;
            btnGitHub.UseVisualStyleBackColor = false;
            btnGitHub.Click += btnGitHub_Click;
            // 
            // panelBody
            // 
            panelBody.Controls.Add(cbUpdateAlwaysCheck);
            panelBody.Controls.Add(btnCancel);
            panelBody.Controls.Add(rtbConsole);
            panelBody.Controls.Add(btnGitHub);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 184);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(482, 376);
            panelBody.TabIndex = 4;
            // 
            // cbUpdateAlwaysCheck
            // 
            cbUpdateAlwaysCheck.BoxSize = 13;
            cbUpdateAlwaysCheck.Dock = DockStyle.Top;
            cbUpdateAlwaysCheck.HoverColor = Color.DeepSkyBlue;
            cbUpdateAlwaysCheck.Location = new Point(0, 0);
            cbUpdateAlwaysCheck.Name = "cbUpdateAlwaysCheck";
            cbUpdateAlwaysCheck.PaddingLeft = 6;
            cbUpdateAlwaysCheck.Size = new Size(482, 19);
            cbUpdateAlwaysCheck.TabIndex = 9;
            cbUpdateAlwaysCheck.Text = "Always check on startup";
            cbUpdateAlwaysCheck.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top;
            btnCancel.BackColor = Color.LightPink;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCancel.IconColor = Color.Black;
            btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCancel.IconSize = 24;
            btnCancel.ImageAlign = ContentAlignment.TopLeft;
            btnCancel.Location = new Point(189, 88);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(6, 0, 8, 0);
            btnCancel.Size = new Size(104, 24);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.TextAlign = ContentAlignment.BottomCenter;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // rtbConsole
            // 
            rtbConsole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbConsole.BackColor = Color.GhostWhite;
            rtbConsole.BorderStyle = BorderStyle.None;
            rtbConsole.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rtbConsole.HideSelection = false;
            rtbConsole.Location = new Point(3, 118);
            rtbConsole.Name = "rtbConsole";
            rtbConsole.ReadOnly = true;
            rtbConsole.ScrollBars = RichTextBoxScrollBars.None;
            rtbConsole.Size = new Size(476, 255);
            rtbConsole.TabIndex = 6;
            rtbConsole.Text = "";
            rtbConsole.Visible = false;
            // 
            // AboutUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panelBody);
            Controls.Add(panelVersion);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Controls.Add(lblHeader);
            Name = "AboutUserControl";
            Size = new Size(482, 560);
            Leave += AboutUserControl_Leave;
            panelVersion.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel panelVersion;
        private FontAwesome.Sharp.IconButton btnSync;
        private Label lblLatestVersion;
        private Label lblCurrentVersion;
        private FontAwesome.Sharp.IconButton btnGitHub;
        private Panel panelBody;
        private RichTextBox rtbConsole;
        private FontAwesome.Sharp.IconButton btnCancel;
        private Controls.CustomCheckBox cbUpdateAlwaysCheck;
    }
}
