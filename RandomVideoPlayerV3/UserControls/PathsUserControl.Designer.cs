namespace RandomVideoPlayer.UserControls
{
    partial class PathsUserControl
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
            tbDefaultPath = new TextBox();
            sbtnDefaultPath = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            cbIncludeScripts = new CheckBox();
            cbDeleteToggle = new CheckBox();
            sbtnRemovalPath = new FontAwesome.Sharp.IconButton();
            tbRemovalPath = new TextBox();
            label4 = new Label();
            panel3 = new Panel();
            sbtnListPath = new FontAwesome.Sharp.IconButton();
            tbListPath = new TextBox();
            fbDialog = new FolderBrowserDialog();
            panel4 = new Panel();
            label5 = new Label();
            cbFileMoveCopyToggle = new CheckBox();
            sbtnFileMovePath = new FontAwesome.Sharp.IconButton();
            tbFileMovePath = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 0, 0, 8);
            label1.Size = new Size(462, 55);
            label1.TabIndex = 0;
            label1.Text = "Paths";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 55);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 0, 0, 0);
            label2.Size = new Size(462, 23);
            label2.TabIndex = 1;
            label2.Text = "Define default path that is used on application startup:";
            // 
            // tbDefaultPath
            // 
            tbDefaultPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDefaultPath.Location = new Point(9, 4);
            tbDefaultPath.Margin = new Padding(9, 3, 3, 3);
            tbDefaultPath.Name = "tbDefaultPath";
            tbDefaultPath.PlaceholderText = "No path set";
            tbDefaultPath.ReadOnly = true;
            tbDefaultPath.Size = new Size(410, 23);
            tbDefaultPath.TabIndex = 2;
            // 
            // sbtnDefaultPath
            // 
            sbtnDefaultPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbtnDefaultPath.FlatAppearance.BorderSize = 0;
            sbtnDefaultPath.FlatStyle = FlatStyle.Flat;
            sbtnDefaultPath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            sbtnDefaultPath.IconColor = Color.Black;
            sbtnDefaultPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnDefaultPath.IconSize = 24;
            sbtnDefaultPath.Location = new Point(425, 3);
            sbtnDefaultPath.Name = "sbtnDefaultPath";
            sbtnDefaultPath.Size = new Size(34, 23);
            sbtnDefaultPath.TabIndex = 5;
            sbtnDefaultPath.UseVisualStyleBackColor = true;
            sbtnDefaultPath.Click += sbtnDefaultPath_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tbDefaultPath);
            panel1.Controls.Add(sbtnDefaultPath);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 78);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 53);
            panel1.TabIndex = 7;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 131);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 0, 0, 0);
            label3.Size = new Size(462, 41);
            label3.TabIndex = 8;
            label3.Text = "Define removal folder. When using the delete function, files get moved to this folder instead of being deleted from the disk.";
            // 
            // panel2
            // 
            panel2.Controls.Add(cbIncludeScripts);
            panel2.Controls.Add(cbDeleteToggle);
            panel2.Controls.Add(sbtnRemovalPath);
            panel2.Controls.Add(tbRemovalPath);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 172);
            panel2.Name = "panel2";
            panel2.Size = new Size(462, 99);
            panel2.TabIndex = 9;
            // 
            // cbIncludeScripts
            // 
            cbIncludeScripts.AutoSize = true;
            cbIncludeScripts.Location = new Point(3, 58);
            cbIncludeScripts.Name = "cbIncludeScripts";
            cbIncludeScripts.Padding = new Padding(9, 0, 0, 0);
            cbIncludeScripts.Size = new Size(324, 19);
            cbIncludeScripts.TabIndex = 8;
            cbIncludeScripts.Text = "Include scripts for the video file when deleting/moving";
            cbIncludeScripts.UseVisualStyleBackColor = true;
            // 
            // cbDeleteToggle
            // 
            cbDeleteToggle.AutoSize = true;
            cbDeleteToggle.Location = new Point(3, 33);
            cbDeleteToggle.Name = "cbDeleteToggle";
            cbDeleteToggle.Padding = new Padding(9, 0, 0, 0);
            cbDeleteToggle.Size = new Size(268, 19);
            cbDeleteToggle.TabIndex = 7;
            cbDeleteToggle.Text = "Move to folder above instead of deleting file";
            cbDeleteToggle.UseVisualStyleBackColor = true;
            // 
            // sbtnRemovalPath
            // 
            sbtnRemovalPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbtnRemovalPath.FlatAppearance.BorderSize = 0;
            sbtnRemovalPath.FlatStyle = FlatStyle.Flat;
            sbtnRemovalPath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            sbtnRemovalPath.IconColor = Color.Black;
            sbtnRemovalPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnRemovalPath.IconSize = 24;
            sbtnRemovalPath.Location = new Point(425, 4);
            sbtnRemovalPath.Name = "sbtnRemovalPath";
            sbtnRemovalPath.Size = new Size(34, 23);
            sbtnRemovalPath.TabIndex = 6;
            sbtnRemovalPath.UseVisualStyleBackColor = true;
            sbtnRemovalPath.Click += sbtnRemovalPath_Click;
            // 
            // tbRemovalPath
            // 
            tbRemovalPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbRemovalPath.Location = new Point(9, 5);
            tbRemovalPath.Margin = new Padding(9, 3, 3, 3);
            tbRemovalPath.Name = "tbRemovalPath";
            tbRemovalPath.PlaceholderText = "No path set";
            tbRemovalPath.ReadOnly = true;
            tbRemovalPath.Size = new Size(410, 23);
            tbRemovalPath.TabIndex = 0;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 271);
            label4.Name = "label4";
            label4.Padding = new Padding(6, 0, 0, 0);
            label4.Size = new Size(462, 28);
            label4.TabIndex = 10;
            label4.Text = "Define default path, where custom lists will be saved to:";
            // 
            // panel3
            // 
            panel3.Controls.Add(sbtnListPath);
            panel3.Controls.Add(tbListPath);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 299);
            panel3.Name = "panel3";
            panel3.Size = new Size(462, 55);
            panel3.TabIndex = 11;
            // 
            // sbtnListPath
            // 
            sbtnListPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbtnListPath.FlatAppearance.BorderSize = 0;
            sbtnListPath.FlatStyle = FlatStyle.Flat;
            sbtnListPath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            sbtnListPath.IconColor = Color.Black;
            sbtnListPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnListPath.IconSize = 24;
            sbtnListPath.Location = new Point(425, 3);
            sbtnListPath.Name = "sbtnListPath";
            sbtnListPath.Size = new Size(34, 23);
            sbtnListPath.TabIndex = 7;
            sbtnListPath.UseVisualStyleBackColor = true;
            sbtnListPath.Click += sbtnListPath_Click;
            // 
            // tbListPath
            // 
            tbListPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbListPath.Location = new Point(9, 3);
            tbListPath.Margin = new Padding(9, 3, 3, 3);
            tbListPath.Name = "tbListPath";
            tbListPath.PlaceholderText = "No path set";
            tbListPath.ReadOnly = true;
            tbListPath.Size = new Size(410, 23);
            tbListPath.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(label5);
            panel4.Controls.Add(cbFileMoveCopyToggle);
            panel4.Controls.Add(sbtnFileMovePath);
            panel4.Controls.Add(tbFileMovePath);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 354);
            panel4.Name = "panel4";
            panel4.Size = new Size(462, 116);
            panel4.TabIndex = 10;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(6, 0, 0, 0);
            label5.Size = new Size(462, 37);
            label5.TabIndex = 9;
            label5.Text = "Define folder where files will be either moved or copied to when using the according button in the player";
            // 
            // cbFileMoveCopyToggle
            // 
            cbFileMoveCopyToggle.AutoSize = true;
            cbFileMoveCopyToggle.Location = new Point(3, 69);
            cbFileMoveCopyToggle.Name = "cbFileMoveCopyToggle";
            cbFileMoveCopyToggle.Padding = new Padding(9, 0, 0, 0);
            cbFileMoveCopyToggle.Size = new Size(359, 19);
            cbFileMoveCopyToggle.TabIndex = 7;
            cbFileMoveCopyToggle.Text = "Check to copy the file, uncheck to move it to chosen location";
            cbFileMoveCopyToggle.UseVisualStyleBackColor = true;
            // 
            // sbtnFileMovePath
            // 
            sbtnFileMovePath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sbtnFileMovePath.FlatAppearance.BorderSize = 0;
            sbtnFileMovePath.FlatStyle = FlatStyle.Flat;
            sbtnFileMovePath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            sbtnFileMovePath.IconColor = Color.Black;
            sbtnFileMovePath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnFileMovePath.IconSize = 24;
            sbtnFileMovePath.Location = new Point(425, 40);
            sbtnFileMovePath.Name = "sbtnFileMovePath";
            sbtnFileMovePath.Size = new Size(34, 23);
            sbtnFileMovePath.TabIndex = 6;
            sbtnFileMovePath.UseVisualStyleBackColor = true;
            sbtnFileMovePath.Click += sbtnFileMovePath_Click;
            // 
            // tbFileMovePath
            // 
            tbFileMovePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFileMovePath.Location = new Point(9, 40);
            tbFileMovePath.Margin = new Padding(9, 3, 3, 3);
            tbFileMovePath.Name = "tbFileMovePath";
            tbFileMovePath.PlaceholderText = "No path set";
            tbFileMovePath.ReadOnly = true;
            tbFileMovePath.Size = new Size(410, 23);
            tbFileMovePath.TabIndex = 0;
            // 
            // PathsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PathsUserControl";
            Size = new Size(462, 501);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbDefaultPath;
        private FontAwesome.Sharp.IconButton sbtnDefaultPath;
        private Panel panel1;
        private Label label3;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton sbtnRemovalPath;
        private TextBox tbRemovalPath;
        private Label label4;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton sbtnListPath;
        private TextBox tbListPath;
        private FolderBrowserDialog fbDialog;
        private CheckBox cbDeleteToggle;
        private CheckBox cbIncludeScripts;
        private Panel panel4;
        private CheckBox cbFileMoveCopyToggle;
        private FontAwesome.Sharp.IconButton sbtnFileMovePath;
        private TextBox tbFileMovePath;
        private Label label5;
    }
}
