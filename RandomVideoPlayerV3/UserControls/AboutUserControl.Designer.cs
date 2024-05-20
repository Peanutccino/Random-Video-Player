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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            btnSync = new FontAwesome.Sharp.IconButton();
            lblLatestVersion = new Label();
            lblCurrentVersion = new Label();
            label5 = new Label();
            label4 = new Label();
            btnGitHub = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(482, 55);
            label1.TabIndex = 0;
            label1.Text = "About";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkMagenta;
            label2.Location = new Point(0, 55);
            label2.Name = "label2";
            label2.Size = new Size(482, 54);
            label2.TabIndex = 1;
            label2.Text = "Random Video Player";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 109);
            label3.Name = "label3";
            label3.Size = new Size(482, 84);
            label3.TabIndex = 2;
            label3.Text = "by Peanutccino";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSync);
            panel1.Controls.Add(lblLatestVersion);
            panel1.Controls.Add(lblCurrentVersion);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 193);
            panel1.Name = "panel1";
            panel1.Size = new Size(482, 53);
            panel1.TabIndex = 3;
            // 
            // btnSync
            // 
            btnSync.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSync.FlatAppearance.BorderSize = 0;
            btnSync.FlatStyle = FlatStyle.Flat;
            btnSync.IconChar = FontAwesome.Sharp.IconChar.Sync;
            btnSync.IconColor = Color.Black;
            btnSync.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSync.IconSize = 25;
            btnSync.Location = new Point(451, 20);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(28, 23);
            btnSync.TabIndex = 4;
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += btnSync_Click;
            // 
            // lblLatestVersion
            // 
            lblLatestVersion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblLatestVersion.AutoEllipsis = true;
            lblLatestVersion.Location = new Point(112, 24);
            lblLatestVersion.Name = "lblLatestVersion";
            lblLatestVersion.Size = new Size(333, 15);
            lblLatestVersion.TabIndex = 3;
            lblLatestVersion.Text = "-";
            // 
            // lblCurrentVersion
            // 
            lblCurrentVersion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCurrentVersion.AutoEllipsis = true;
            lblCurrentVersion.Location = new Point(112, 3);
            lblCurrentVersion.Name = "lblCurrentVersion";
            lblCurrentVersion.Size = new Size(367, 15);
            lblCurrentVersion.TabIndex = 2;
            lblCurrentVersion.Text = "1.34";
            // 
            // label5
            // 
            label5.Location = new Point(3, 24);
            label5.Margin = new Padding(3);
            label5.Name = "label5";
            label5.Padding = new Padding(6, 0, 0, 0);
            label5.Size = new Size(100, 23);
            label5.TabIndex = 1;
            label5.Text = "Latest Version:";
            // 
            // label4
            // 
            label4.Location = new Point(3, 3);
            label4.Margin = new Padding(3);
            label4.Name = "label4";
            label4.Padding = new Padding(6, 0, 0, 0);
            label4.Size = new Size(100, 23);
            label4.TabIndex = 0;
            label4.Text = "Current Version:";
            // 
            // btnGitHub
            // 
            btnGitHub.BackColor = Color.Lavender;
            btnGitHub.FlatAppearance.BorderSize = 0;
            btnGitHub.FlatStyle = FlatStyle.Flat;
            btnGitHub.Font = new Font("Segoe UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            btnGitHub.IconChar = FontAwesome.Sharp.IconChar.Github;
            btnGitHub.IconColor = Color.Black;
            btnGitHub.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGitHub.IconSize = 42;
            btnGitHub.ImageAlign = ContentAlignment.MiddleLeft;
            btnGitHub.Location = new Point(155, 45);
            btnGitHub.Name = "btnGitHub";
            btnGitHub.Size = new Size(173, 55);
            btnGitHub.TabIndex = 4;
            btnGitHub.Text = "GitHub";
            btnGitHub.TextAlign = ContentAlignment.TopRight;
            btnGitHub.UseVisualStyleBackColor = false;
            btnGitHub.Click += btnGitHub_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnGitHub);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 246);
            panel2.Name = "panel2";
            panel2.Size = new Size(482, 149);
            panel2.TabIndex = 4;
            // 
            // AboutUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AboutUserControl";
            Size = new Size(482, 395);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnSync;
        private Label lblLatestVersion;
        private Label lblCurrentVersion;
        private Label label5;
        private Label label4;
        private FontAwesome.Sharp.IconButton btnGitHub;
        private Panel panel2;
    }
}
