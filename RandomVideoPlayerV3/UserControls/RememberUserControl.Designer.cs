namespace RandomVideoPlayer.UserControls
{
    partial class RememberUserControl
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
            panel1 = new Panel();
            rbAllDirectories = new Controls.CustomRadioButton();
            rbSingleDirectory = new Controls.CustomRadioButton();
            lbl3 = new Label();
            cbAlwaysAsk = new Controls.CustomCheckBox();
            lbl2 = new Label();
            cbWindowSize = new Controls.CustomCheckBox();
            cbPlayRecent = new Controls.CustomCheckBox();
            cbRecentCount = new Controls.CustomCheckBox();
            cbVolume = new Controls.CustomCheckBox();
            panel1.SuspendLayout();
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
            lblHeader.Size = new Size(451, 55);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Remember";
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(0, 55);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 6, 0, 8);
            lbl1.Size = new Size(451, 47);
            lbl1.TabIndex = 1;
            lbl1.Text = "Check to remember state for next application start:";
            // 
            // panel1
            // 
            panel1.Controls.Add(rbAllDirectories);
            panel1.Controls.Add(rbSingleDirectory);
            panel1.Controls.Add(lbl3);
            panel1.Controls.Add(cbAlwaysAsk);
            panel1.Controls.Add(lbl2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 202);
            panel1.Name = "panel1";
            panel1.Size = new Size(451, 180);
            panel1.TabIndex = 6;
            // 
            // rbAllDirectories
            // 
            rbAllDirectories.AutoSize = true;
            rbAllDirectories.CircleSize = 12;
            rbAllDirectories.Dock = DockStyle.Top;
            rbAllDirectories.HoverColor = Color.DeepSkyBlue;
            rbAllDirectories.Location = new Point(0, 114);
            rbAllDirectories.Name = "rbAllDirectories";
            rbAllDirectories.Padding = new Padding(0, 3, 0, 3);
            rbAllDirectories.PaddingLeft = 9;
            rbAllDirectories.Size = new Size(451, 25);
            rbAllDirectories.TabIndex = 12;
            rbAllDirectories.TabStop = true;
            rbAllDirectories.Text = "Load file's directory and include subdirectories";
            rbAllDirectories.UseVisualStyleBackColor = true;
            // 
            // rbSingleDirectory
            // 
            rbSingleDirectory.AutoSize = true;
            rbSingleDirectory.CircleSize = 12;
            rbSingleDirectory.Dock = DockStyle.Top;
            rbSingleDirectory.HoverColor = Color.DeepSkyBlue;
            rbSingleDirectory.Location = new Point(0, 89);
            rbSingleDirectory.Name = "rbSingleDirectory";
            rbSingleDirectory.Padding = new Padding(0, 3, 0, 3);
            rbSingleDirectory.PaddingLeft = 9;
            rbSingleDirectory.Size = new Size(451, 25);
            rbSingleDirectory.TabIndex = 11;
            rbSingleDirectory.TabStop = true;
            rbSingleDirectory.Text = "Load file's directory only";
            rbSingleDirectory.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.Location = new Point(0, 62);
            lbl3.Name = "lbl3";
            lbl3.Padding = new Padding(6, 6, 0, 0);
            lbl3.Size = new Size(451, 27);
            lbl3.TabIndex = 2;
            lbl3.Text = "If not, what should be the default behavior:";
            // 
            // cbAlwaysAsk
            // 
            cbAlwaysAsk.AutoSize = true;
            cbAlwaysAsk.BoxSize = 13;
            cbAlwaysAsk.Dock = DockStyle.Top;
            cbAlwaysAsk.HoverColor = Color.DeepSkyBlue;
            cbAlwaysAsk.Location = new Point(0, 40);
            cbAlwaysAsk.Name = "cbAlwaysAsk";
            cbAlwaysAsk.Padding = new Padding(0, 0, 0, 3);
            cbAlwaysAsk.PaddingLeft = 9;
            cbAlwaysAsk.Size = new Size(451, 22);
            cbAlwaysAsk.TabIndex = 11;
            cbAlwaysAsk.Text = "Always ask";
            cbAlwaysAsk.UseVisualStyleBackColor = true;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 6, 0, 0);
            lbl2.Size = new Size(451, 40);
            lbl2.TabIndex = 0;
            lbl2.Text = "Should RVP always ask what to do when started directly by mediafile?";
            // 
            // cbWindowSize
            // 
            cbWindowSize.AutoSize = true;
            cbWindowSize.BoxSize = 13;
            cbWindowSize.Dock = DockStyle.Top;
            cbWindowSize.HoverColor = Color.DeepSkyBlue;
            cbWindowSize.Location = new Point(0, 102);
            cbWindowSize.Name = "cbWindowSize";
            cbWindowSize.Padding = new Padding(0, 3, 0, 3);
            cbWindowSize.PaddingLeft = 9;
            cbWindowSize.Size = new Size(451, 25);
            cbWindowSize.TabIndex = 7;
            cbWindowSize.Text = "Window size";
            cbWindowSize.UseVisualStyleBackColor = true;
            // 
            // cbPlayRecent
            // 
            cbPlayRecent.AutoSize = true;
            cbPlayRecent.BoxSize = 13;
            cbPlayRecent.Dock = DockStyle.Top;
            cbPlayRecent.HoverColor = Color.DeepSkyBlue;
            cbPlayRecent.Location = new Point(0, 127);
            cbPlayRecent.Name = "cbPlayRecent";
            cbPlayRecent.Padding = new Padding(0, 3, 0, 3);
            cbPlayRecent.PaddingLeft = 9;
            cbPlayRecent.Size = new Size(451, 25);
            cbPlayRecent.TabIndex = 8;
            cbPlayRecent.Text = "Play only latest files setting";
            cbPlayRecent.UseVisualStyleBackColor = true;
            // 
            // cbRecentCount
            // 
            cbRecentCount.AutoSize = true;
            cbRecentCount.BoxSize = 13;
            cbRecentCount.Dock = DockStyle.Top;
            cbRecentCount.HoverColor = Color.DeepSkyBlue;
            cbRecentCount.Location = new Point(0, 152);
            cbRecentCount.Name = "cbRecentCount";
            cbRecentCount.Padding = new Padding(0, 3, 0, 3);
            cbRecentCount.PaddingLeft = 9;
            cbRecentCount.Size = new Size(451, 25);
            cbRecentCount.TabIndex = 9;
            cbRecentCount.Text = "Recent count number";
            cbRecentCount.UseVisualStyleBackColor = true;
            // 
            // cbVolume
            // 
            cbVolume.AutoSize = true;
            cbVolume.BoxSize = 13;
            cbVolume.Dock = DockStyle.Top;
            cbVolume.HoverColor = Color.DeepSkyBlue;
            cbVolume.Location = new Point(0, 177);
            cbVolume.Name = "cbVolume";
            cbVolume.Padding = new Padding(0, 3, 0, 3);
            cbVolume.PaddingLeft = 9;
            cbVolume.Size = new Size(451, 25);
            cbVolume.TabIndex = 10;
            cbVolume.Text = "Volume";
            cbVolume.UseVisualStyleBackColor = true;
            // 
            // RememberUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panel1);
            Controls.Add(cbVolume);
            Controls.Add(cbRecentCount);
            Controls.Add(cbPlayRecent);
            Controls.Add(cbWindowSize);
            Controls.Add(lbl1);
            Controls.Add(lblHeader);
            Name = "RememberUserControl";
            Size = new Size(451, 482);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHeader;
        private Label lbl1;
        private Panel panel1;
        private Label lbl3;
        private Label lbl2;
        private Controls.CustomCheckBox cbWindowSize;
        private Controls.CustomCheckBox cbPlayRecent;
        private Controls.CustomCheckBox cbRecentCount;
        private Controls.CustomCheckBox cbVolume;
        private Controls.CustomCheckBox cbAlwaysAsk;
        private Controls.CustomRadioButton rbSingleDirectory;
        private Controls.CustomRadioButton rbAllDirectories;
    }
}
