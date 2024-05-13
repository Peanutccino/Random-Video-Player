namespace RandomVideoPlayer.View
{
    partial class HelpWindow
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
            panelBody = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnGit = new FontAwesome.Sharp.IconButton();
            btnInfo = new FontAwesome.Sharp.IconButton();
            btnClose = new FontAwesome.Sharp.IconButton();
            lblVersion = new Label();
            lblTitle = new Label();
            panelBody.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.FromArgb(38, 0, 77);
            panelBody.Controls.Add(tableLayoutPanel1);
            panelBody.Controls.Add(btnClose);
            panelBody.Controls.Add(lblVersion);
            panelBody.Controls.Add(lblTitle);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 0);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(474, 181);
            panelBody.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnGit, 0, 0);
            tableLayoutPanel1.Controls.Add(btnInfo, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 110);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(474, 71);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // btnGit
            // 
            btnGit.Anchor = AnchorStyles.None;
            btnGit.BackColor = Color.FromArgb(38, 0, 77);
            btnGit.FlatAppearance.BorderColor = Color.Lavender;
            btnGit.FlatAppearance.BorderSize = 2;
            btnGit.FlatStyle = FlatStyle.Flat;
            btnGit.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnGit.ForeColor = Color.LightCyan;
            btnGit.IconChar = FontAwesome.Sharp.IconChar.Github;
            btnGit.IconColor = Color.LightCyan;
            btnGit.IconFont = FontAwesome.Sharp.IconFont.Brands;
            btnGit.IconSize = 42;
            btnGit.ImageAlign = ContentAlignment.TopLeft;
            btnGit.Location = new Point(31, 10);
            btnGit.Name = "btnGit";
            btnGit.Size = new Size(175, 50);
            btnGit.TabIndex = 2;
            btnGit.Text = "GitHub  ";
            btnGit.TextAlign = ContentAlignment.MiddleRight;
            btnGit.UseVisualStyleBackColor = false;
            btnGit.Click += btnGit_Click;
            // 
            // btnInfo
            // 
            btnInfo.Anchor = AnchorStyles.None;
            btnInfo.BackColor = Color.FromArgb(38, 0, 77);
            btnInfo.FlatAppearance.BorderColor = Color.Lavender;
            btnInfo.FlatAppearance.BorderSize = 2;
            btnInfo.FlatStyle = FlatStyle.Flat;
            btnInfo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            btnInfo.ForeColor = Color.LightCyan;
            btnInfo.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            btnInfo.IconColor = Color.LightCyan;
            btnInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInfo.IconSize = 42;
            btnInfo.ImageAlign = ContentAlignment.TopLeft;
            btnInfo.Location = new Point(268, 10);
            btnInfo.Name = "btnInfo";
            btnInfo.Size = new Size(175, 50);
            btnInfo.TabIndex = 3;
            btnInfo.Text = "Shortcuts";
            btnInfo.TextAlign = ContentAlignment.MiddleRight;
            btnInfo.UseVisualStyleBackColor = false;
            btnInfo.Click += btnInfo_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            btnClose.IconColor = Color.LightCyan;
            btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClose.IconSize = 20;
            btnClose.ImageAlign = ContentAlignment.TopCenter;
            btnClose.Location = new Point(446, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(25, 25);
            btnClose.TabIndex = 4;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblVersion
            // 
            lblVersion.Dock = DockStyle.Top;
            lblVersion.Font = new Font("Trebuchet MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblVersion.ForeColor = SystemColors.ButtonHighlight;
            lblVersion.Location = new Point(0, 75);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(474, 35);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "v1.34 by Peanutccino";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Trebuchet MS", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = SystemColors.ButtonHighlight;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(474, 75);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Random Video Player";
            lblTitle.TextAlign = ContentAlignment.BottomCenter;
            // 
            // HelpWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 181);
            Controls.Add(panelBody);
            MaximumSize = new Size(490, 220);
            MinimumSize = new Size(490, 220);
            Name = "HelpWindow";
            Text = "HelpWindow";
            Resize += HelpWindow_Resize;
            panelBody.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panelBody;
        private Label lblVersion;
        private Label lblTitle;
        private FontAwesome.Sharp.IconButton btnGit;
        private FontAwesome.Sharp.IconButton btnInfo;
        private FontAwesome.Sharp.IconButton btnClose;
        private TableLayoutPanel tableLayoutPanel1;
    }
}