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
            lblHeader = new Label();
            lbl1 = new Label();
            tbDefaultPath = new TextBox();
            sbtnDefaultPath = new FontAwesome.Sharp.IconButton();
            panelDefault = new Panel();
            lbl2 = new Label();
            panelRemoval = new Panel();
            panel1 = new Panel();
            cbIncludeScripts = new Controls.CustomCheckBox();
            cbDeleteToggle = new Controls.CustomCheckBox();
            sbtnRemovalPath = new FontAwesome.Sharp.IconButton();
            tbRemovalPath = new TextBox();
            lbl3 = new Label();
            panelList = new Panel();
            sbtnListPath = new FontAwesome.Sharp.IconButton();
            tbListPath = new TextBox();
            fbDialog = new FolderBrowserDialog();
            panelMove = new Panel();
            cbFileMoveCopyToggle = new Controls.CustomCheckBox();
            sbtnFileMovePath = new FontAwesome.Sharp.IconButton();
            tbFileMovePath = new TextBox();
            lbl4 = new Label();
            panelDefault.SuspendLayout();
            panelRemoval.SuspendLayout();
            panel1.SuspendLayout();
            panelList.SuspendLayout();
            panelMove.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(462, 55);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Paths";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(0, 55);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(462, 23);
            lbl1.TabIndex = 1;
            lbl1.Text = "Define default path that is used on application startup:";
            // 
            // tbDefaultPath
            // 
            tbDefaultPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbDefaultPath.Location = new Point(9, 3);
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
            // panelDefault
            // 
            panelDefault.Controls.Add(tbDefaultPath);
            panelDefault.Controls.Add(sbtnDefaultPath);
            panelDefault.Dock = DockStyle.Top;
            panelDefault.Location = new Point(0, 78);
            panelDefault.Name = "panelDefault";
            panelDefault.Size = new Size(462, 53);
            panelDefault.TabIndex = 7;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.Location = new Point(0, 131);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 0, 0, 0);
            lbl2.Size = new Size(462, 41);
            lbl2.TabIndex = 8;
            lbl2.Text = "Define removal folder. When using the delete function, files get moved to this folder instead of being deleted from the disk.";
            // 
            // panelRemoval
            // 
            panelRemoval.Controls.Add(panel1);
            panelRemoval.Controls.Add(sbtnRemovalPath);
            panelRemoval.Controls.Add(tbRemovalPath);
            panelRemoval.Dock = DockStyle.Top;
            panelRemoval.Location = new Point(0, 172);
            panelRemoval.Name = "panelRemoval";
            panelRemoval.Size = new Size(462, 99);
            panelRemoval.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbIncludeScripts);
            panel1.Controls.Add(cbDeleteToggle);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 62);
            panel1.TabIndex = 11;
            // 
            // cbIncludeScripts
            // 
            cbIncludeScripts.AutoSize = true;
            cbIncludeScripts.BoxSize = 13;
            cbIncludeScripts.Dock = DockStyle.Top;
            cbIncludeScripts.HoverColor = Color.DeepSkyBlue;
            cbIncludeScripts.Location = new Point(0, 25);
            cbIncludeScripts.Name = "cbIncludeScripts";
            cbIncludeScripts.Padding = new Padding(0, 0, 0, 6);
            cbIncludeScripts.PaddingLeft = 12;
            cbIncludeScripts.Size = new Size(462, 25);
            cbIncludeScripts.TabIndex = 10;
            cbIncludeScripts.Text = "Include scripts for the video file when deleting/moving";
            cbIncludeScripts.UseVisualStyleBackColor = true;
            // 
            // cbDeleteToggle
            // 
            cbDeleteToggle.AutoSize = true;
            cbDeleteToggle.BoxSize = 13;
            cbDeleteToggle.Dock = DockStyle.Top;
            cbDeleteToggle.HoverColor = Color.DeepSkyBlue;
            cbDeleteToggle.Location = new Point(0, 0);
            cbDeleteToggle.Name = "cbDeleteToggle";
            cbDeleteToggle.Padding = new Padding(0, 0, 0, 6);
            cbDeleteToggle.PaddingLeft = 12;
            cbDeleteToggle.Size = new Size(462, 25);
            cbDeleteToggle.TabIndex = 9;
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
            tbRemovalPath.Location = new Point(9, 3);
            tbRemovalPath.Margin = new Padding(9, 3, 3, 3);
            tbRemovalPath.Name = "tbRemovalPath";
            tbRemovalPath.PlaceholderText = "No path set";
            tbRemovalPath.ReadOnly = true;
            tbRemovalPath.Size = new Size(410, 23);
            tbRemovalPath.TabIndex = 0;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.Location = new Point(0, 271);
            lbl3.Name = "lbl3";
            lbl3.Padding = new Padding(6, 0, 0, 0);
            lbl3.Size = new Size(462, 28);
            lbl3.TabIndex = 10;
            lbl3.Text = "Define default path, where custom lists will be saved to:";
            // 
            // panelList
            // 
            panelList.Controls.Add(sbtnListPath);
            panelList.Controls.Add(tbListPath);
            panelList.Dock = DockStyle.Top;
            panelList.Location = new Point(0, 299);
            panelList.Name = "panelList";
            panelList.Size = new Size(462, 55);
            panelList.TabIndex = 11;
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
            // panelMove
            // 
            panelMove.Controls.Add(cbFileMoveCopyToggle);
            panelMove.Controls.Add(sbtnFileMovePath);
            panelMove.Controls.Add(tbFileMovePath);
            panelMove.Dock = DockStyle.Top;
            panelMove.Location = new Point(0, 391);
            panelMove.Name = "panelMove";
            panelMove.Size = new Size(462, 57);
            panelMove.TabIndex = 10;
            // 
            // cbFileMoveCopyToggle
            // 
            cbFileMoveCopyToggle.AutoSize = true;
            cbFileMoveCopyToggle.BoxSize = 13;
            cbFileMoveCopyToggle.Dock = DockStyle.Bottom;
            cbFileMoveCopyToggle.HoverColor = Color.DeepSkyBlue;
            cbFileMoveCopyToggle.Location = new Point(0, 32);
            cbFileMoveCopyToggle.Name = "cbFileMoveCopyToggle";
            cbFileMoveCopyToggle.Padding = new Padding(0, 0, 0, 6);
            cbFileMoveCopyToggle.PaddingLeft = 12;
            cbFileMoveCopyToggle.Size = new Size(462, 25);
            cbFileMoveCopyToggle.TabIndex = 10;
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
            sbtnFileMovePath.Location = new Point(425, 3);
            sbtnFileMovePath.Name = "sbtnFileMovePath";
            sbtnFileMovePath.Size = new Size(34, 23);
            sbtnFileMovePath.TabIndex = 6;
            sbtnFileMovePath.UseVisualStyleBackColor = true;
            sbtnFileMovePath.Click += sbtnFileMovePath_Click;
            // 
            // tbFileMovePath
            // 
            tbFileMovePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFileMovePath.Location = new Point(9, 3);
            tbFileMovePath.Margin = new Padding(9, 3, 3, 3);
            tbFileMovePath.Name = "tbFileMovePath";
            tbFileMovePath.PlaceholderText = "No path set";
            tbFileMovePath.ReadOnly = true;
            tbFileMovePath.Size = new Size(410, 23);
            tbFileMovePath.TabIndex = 0;
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl4.Location = new Point(0, 354);
            lbl4.Name = "lbl4";
            lbl4.Padding = new Padding(6, 0, 0, 0);
            lbl4.Size = new Size(462, 37);
            lbl4.TabIndex = 9;
            lbl4.Text = "Define folder where files will be either moved or copied to when using the according button in the player";
            // 
            // PathsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panelMove);
            Controls.Add(lbl4);
            Controls.Add(panelList);
            Controls.Add(lbl3);
            Controls.Add(panelRemoval);
            Controls.Add(lbl2);
            Controls.Add(panelDefault);
            Controls.Add(lbl1);
            Controls.Add(lblHeader);
            Name = "PathsUserControl";
            Size = new Size(462, 501);
            panelDefault.ResumeLayout(false);
            panelDefault.PerformLayout();
            panelRemoval.ResumeLayout(false);
            panelRemoval.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelList.ResumeLayout(false);
            panelList.PerformLayout();
            panelMove.ResumeLayout(false);
            panelMove.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Label lbl1;
        private TextBox tbDefaultPath;
        private FontAwesome.Sharp.IconButton sbtnDefaultPath;
        private Panel panelDefault;
        private Label lbl2;
        private Panel panelRemoval;
        private FontAwesome.Sharp.IconButton sbtnRemovalPath;
        private TextBox tbRemovalPath;
        private Label lbl3;
        private Panel panelList;
        private FontAwesome.Sharp.IconButton sbtnListPath;
        private TextBox tbListPath;
        private FolderBrowserDialog fbDialog;
        private Panel panelMove;
        private FontAwesome.Sharp.IconButton sbtnFileMovePath;
        private TextBox tbFileMovePath;
        private Label lbl4;
        private Controls.CustomCheckBox cbIncludeScripts;
        private Controls.CustomCheckBox cbDeleteToggle;
        private Panel panel1;
        private Controls.CustomCheckBox cbFileMoveCopyToggle;
    }
}
