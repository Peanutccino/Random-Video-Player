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
            fbDialog = new FolderBrowserDialog();
            tableLayoutPanelMain = new TableLayoutPanel();
            lblHeader = new Label();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tbDefaultPath = new TextBox();
            sbtnDefaultPath = new FontAwesome.Sharp.IconButton();
            lbl1 = new Label();
            panel2 = new Panel();
            cbIncludeScripts = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbDeleteToggle = new RandomVideoPlayer.Controls.CustomCheckBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            tbRemovalPath = new TextBox();
            sbtnRemovalPath = new FontAwesome.Sharp.IconButton();
            lbl2 = new Label();
            panel3 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tbListPath = new TextBox();
            sbtnListPath = new FontAwesome.Sharp.IconButton();
            lbl3 = new Label();
            panel4 = new Panel();
            cbFileMoveCopyToggle = new RandomVideoPlayer.Controls.CustomCheckBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            tbFileMovePath = new TextBox();
            sbtnFileMovePath = new FontAwesome.Sharp.IconButton();
            lbl4 = new Label();
            tableLayoutPanelMain.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.BackColor = Color.PowderBlue;
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutPanelMain.Controls.Add(panel1, 0, 1);
            tableLayoutPanelMain.Controls.Add(panel2, 0, 2);
            tableLayoutPanelMain.Controls.Add(panel3, 0, 3);
            tableLayoutPanelMain.Controls.Add(panel4, 0, 4);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 5;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanelMain.Size = new Size(524, 656);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 13;
            lblHeader.Text = "Paths";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 113);
            panel1.TabIndex = 14;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Aquamarine;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(tbDefaultPath, 0, 0);
            tableLayoutPanel2.Controls.Add(sbtnDefaultPath, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 23);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(518, 35);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // tbDefaultPath
            // 
            tbDefaultPath.BorderStyle = BorderStyle.FixedSingle;
            tbDefaultPath.Dock = DockStyle.Fill;
            tbDefaultPath.Location = new Point(9, 3);
            tbDefaultPath.Margin = new Padding(9, 3, 3, 3);
            tbDefaultPath.Name = "tbDefaultPath";
            tbDefaultPath.PlaceholderText = "No path set";
            tbDefaultPath.ReadOnly = true;
            tbDefaultPath.Size = new Size(466, 23);
            tbDefaultPath.TabIndex = 15;
            // 
            // sbtnDefaultPath
            // 
            sbtnDefaultPath.FlatAppearance.BorderSize = 0;
            sbtnDefaultPath.FlatStyle = FlatStyle.Flat;
            sbtnDefaultPath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            sbtnDefaultPath.IconColor = Color.Black;
            sbtnDefaultPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnDefaultPath.IconSize = 24;
            sbtnDefaultPath.Location = new Point(481, 3);
            sbtnDefaultPath.Name = "sbtnDefaultPath";
            sbtnDefaultPath.Size = new Size(34, 23);
            sbtnDefaultPath.TabIndex = 16;
            sbtnDefaultPath.UseVisualStyleBackColor = true;
            sbtnDefaultPath.Click += sbtnDefaultPath_Click;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 23);
            lbl1.TabIndex = 14;
            lbl1.Text = "Define default path that is used on application startup:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Lavender;
            panel2.Controls.Add(cbIncludeScripts);
            panel2.Controls.Add(cbDeleteToggle);
            panel2.Controls.Add(tableLayoutPanel3);
            panel2.Controls.Add(lbl2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 182);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 143);
            panel2.TabIndex = 15;
            // 
            // cbIncludeScripts
            // 
            cbIncludeScripts.BoxSize = 13;
            cbIncludeScripts.Dock = DockStyle.Top;
            cbIncludeScripts.HoverColor = Color.DeepSkyBlue;
            cbIncludeScripts.Location = new Point(0, 101);
            cbIncludeScripts.Name = "cbIncludeScripts";
            cbIncludeScripts.Padding = new Padding(0, 0, 0, 6);
            cbIncludeScripts.PaddingLeft = 12;
            cbIncludeScripts.Size = new Size(518, 25);
            cbIncludeScripts.TabIndex = 20;
            cbIncludeScripts.Text = "Include scripts for the video file when deleting/moving";
            cbIncludeScripts.UseVisualStyleBackColor = true;
            // 
            // cbDeleteToggle
            // 
            cbDeleteToggle.BoxSize = 13;
            cbDeleteToggle.Dock = DockStyle.Top;
            cbDeleteToggle.HoverColor = Color.DeepSkyBlue;
            cbDeleteToggle.Location = new Point(0, 76);
            cbDeleteToggle.Name = "cbDeleteToggle";
            cbDeleteToggle.PaddingLeft = 12;
            cbDeleteToggle.Size = new Size(518, 25);
            cbDeleteToggle.TabIndex = 19;
            cbDeleteToggle.Text = "Move to folder above instead of deleting file";
            cbDeleteToggle.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.Salmon;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(tbRemovalPath, 0, 0);
            tableLayoutPanel3.Controls.Add(sbtnRemovalPath, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(0, 41);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(518, 35);
            tableLayoutPanel3.TabIndex = 18;
            // 
            // tbRemovalPath
            // 
            tbRemovalPath.BorderStyle = BorderStyle.FixedSingle;
            tbRemovalPath.Dock = DockStyle.Fill;
            tbRemovalPath.Location = new Point(9, 3);
            tbRemovalPath.Margin = new Padding(9, 3, 3, 3);
            tbRemovalPath.Name = "tbRemovalPath";
            tbRemovalPath.PlaceholderText = "No path set";
            tbRemovalPath.ReadOnly = true;
            tbRemovalPath.Size = new Size(466, 23);
            tbRemovalPath.TabIndex = 17;
            // 
            // sbtnRemovalPath
            // 
            sbtnRemovalPath.FlatAppearance.BorderSize = 0;
            sbtnRemovalPath.FlatStyle = FlatStyle.Flat;
            sbtnRemovalPath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            sbtnRemovalPath.IconColor = Color.Black;
            sbtnRemovalPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnRemovalPath.IconSize = 24;
            sbtnRemovalPath.Location = new Point(481, 3);
            sbtnRemovalPath.Name = "sbtnRemovalPath";
            sbtnRemovalPath.Size = new Size(34, 23);
            sbtnRemovalPath.TabIndex = 18;
            sbtnRemovalPath.UseVisualStyleBackColor = true;
            sbtnRemovalPath.Click += sbtnRemovalPath_Click;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 41);
            lbl2.TabIndex = 16;
            lbl2.Text = "Define removal folder. When using the delete function, files get moved to this folder instead of being deleted from the disk.";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Thistle;
            panel3.Controls.Add(tableLayoutPanel4);
            panel3.Controls.Add(lbl3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 331);
            panel3.Name = "panel3";
            panel3.Size = new Size(518, 113);
            panel3.TabIndex = 16;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.Salmon;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.Controls.Add(tbListPath, 0, 0);
            tableLayoutPanel4.Controls.Add(sbtnListPath, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Top;
            tableLayoutPanel4.Location = new Point(0, 28);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(518, 35);
            tableLayoutPanel4.TabIndex = 23;
            // 
            // tbListPath
            // 
            tbListPath.BorderStyle = BorderStyle.FixedSingle;
            tbListPath.Dock = DockStyle.Fill;
            tbListPath.Location = new Point(9, 3);
            tbListPath.Margin = new Padding(9, 3, 3, 3);
            tbListPath.Name = "tbListPath";
            tbListPath.PlaceholderText = "No path set";
            tbListPath.ReadOnly = true;
            tbListPath.Size = new Size(466, 23);
            tbListPath.TabIndex = 21;
            // 
            // sbtnListPath
            // 
            sbtnListPath.FlatAppearance.BorderSize = 0;
            sbtnListPath.FlatStyle = FlatStyle.Flat;
            sbtnListPath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            sbtnListPath.IconColor = Color.Black;
            sbtnListPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnListPath.IconSize = 24;
            sbtnListPath.Location = new Point(481, 3);
            sbtnListPath.Name = "sbtnListPath";
            sbtnListPath.Size = new Size(34, 23);
            sbtnListPath.TabIndex = 22;
            sbtnListPath.UseVisualStyleBackColor = true;
            sbtnListPath.Click += sbtnListPath_Click;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl3.Location = new Point(0, 0);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(518, 28);
            lbl3.TabIndex = 20;
            lbl3.Text = "Define default path, where custom lists will be saved to:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Pink;
            panel4.Controls.Add(cbFileMoveCopyToggle);
            panel4.Controls.Add(tableLayoutPanel5);
            panel4.Controls.Add(lbl4);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 450);
            panel4.Name = "panel4";
            panel4.Size = new Size(518, 203);
            panel4.TabIndex = 17;
            // 
            // cbFileMoveCopyToggle
            // 
            cbFileMoveCopyToggle.BoxSize = 13;
            cbFileMoveCopyToggle.Dock = DockStyle.Top;
            cbFileMoveCopyToggle.HoverColor = Color.DeepSkyBlue;
            cbFileMoveCopyToggle.Location = new Point(0, 72);
            cbFileMoveCopyToggle.Name = "cbFileMoveCopyToggle";
            cbFileMoveCopyToggle.Padding = new Padding(0, 0, 0, 6);
            cbFileMoveCopyToggle.PaddingLeft = 12;
            cbFileMoveCopyToggle.Size = new Size(518, 25);
            cbFileMoveCopyToggle.TabIndex = 18;
            cbFileMoveCopyToggle.Text = "Check to copy the file, uncheck to move it to chosen location";
            cbFileMoveCopyToggle.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = Color.Salmon;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.Controls.Add(tbFileMovePath, 0, 0);
            tableLayoutPanel5.Controls.Add(sbtnFileMovePath, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Top;
            tableLayoutPanel5.Location = new Point(0, 37);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(518, 35);
            tableLayoutPanel5.TabIndex = 21;
            // 
            // tbFileMovePath
            // 
            tbFileMovePath.BorderStyle = BorderStyle.FixedSingle;
            tbFileMovePath.Dock = DockStyle.Fill;
            tbFileMovePath.Location = new Point(9, 3);
            tbFileMovePath.Margin = new Padding(9, 3, 3, 3);
            tbFileMovePath.Name = "tbFileMovePath";
            tbFileMovePath.PlaceholderText = "No path set";
            tbFileMovePath.ReadOnly = true;
            tbFileMovePath.Size = new Size(466, 23);
            tbFileMovePath.TabIndex = 19;
            // 
            // sbtnFileMovePath
            // 
            sbtnFileMovePath.FlatAppearance.BorderSize = 0;
            sbtnFileMovePath.FlatStyle = FlatStyle.Flat;
            sbtnFileMovePath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            sbtnFileMovePath.IconColor = Color.Black;
            sbtnFileMovePath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            sbtnFileMovePath.IconSize = 24;
            sbtnFileMovePath.Location = new Point(481, 3);
            sbtnFileMovePath.Name = "sbtnFileMovePath";
            sbtnFileMovePath.Size = new Size(34, 23);
            sbtnFileMovePath.TabIndex = 20;
            sbtnFileMovePath.UseVisualStyleBackColor = true;
            sbtnFileMovePath.Click += sbtnFileMovePath_Click;
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl4.Location = new Point(0, 0);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(518, 37);
            lbl4.TabIndex = 17;
            lbl4.Text = "Define folder where files will be either moved or copied to when using the according button in the player";
            // 
            // PathsUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(tableLayoutPanelMain);
            Name = "PathsUserControl";
            Size = new Size(524, 656);
            tableLayoutPanelMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            panel4.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FolderBrowserDialog fbDialog;
        private TableLayoutPanel tableLayoutPanelMain;
        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private TextBox tbDefaultPath;
        private FontAwesome.Sharp.IconButton sbtnDefaultPath;
        private Panel panel2;
        private Label lbl2;
        private TextBox tbRemovalPath;
        private FontAwesome.Sharp.IconButton sbtnRemovalPath;
        private Panel panel3;
        private Controls.CustomCheckBox cbDeleteToggle;
        private Controls.CustomCheckBox cbIncludeScripts;
        private Label lbl3;
        private TextBox tbListPath;
        private FontAwesome.Sharp.IconButton sbtnListPath;
        private Panel panel4;
        private Label lbl4;
        private Controls.CustomCheckBox cbFileMoveCopyToggle;
        private TextBox tbFileMovePath;
        private FontAwesome.Sharp.IconButton sbtnFileMovePath;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
    }
}
