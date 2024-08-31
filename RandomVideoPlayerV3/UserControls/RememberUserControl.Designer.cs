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
            label1 = new Label();
            label2 = new Label();
            cbWindowSize = new CheckBox();
            cbPlayRecent = new CheckBox();
            cbRecentCount = new CheckBox();
            cbVolume = new CheckBox();
            panel1 = new Panel();
            rbAllDirectories = new RadioButton();
            rbSingleDirectory = new RadioButton();
            label4 = new Label();
            cbAlwaysAsk = new CheckBox();
            label3 = new Label();
            panel1.SuspendLayout();
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
            label1.Size = new Size(451, 55);
            label1.TabIndex = 0;
            label1.Text = "Remember";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 55);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 6, 0, 8);
            label2.Size = new Size(451, 33);
            label2.TabIndex = 1;
            label2.Text = "Check to remember state for next application start:";
            // 
            // cbWindowSize
            // 
            cbWindowSize.AutoSize = true;
            cbWindowSize.Dock = DockStyle.Top;
            cbWindowSize.Location = new Point(0, 88);
            cbWindowSize.Name = "cbWindowSize";
            cbWindowSize.Padding = new Padding(9, 0, 0, 8);
            cbWindowSize.Size = new Size(451, 27);
            cbWindowSize.TabIndex = 2;
            cbWindowSize.Text = "Window size";
            cbWindowSize.UseVisualStyleBackColor = true;
            // 
            // cbPlayRecent
            // 
            cbPlayRecent.AutoSize = true;
            cbPlayRecent.Dock = DockStyle.Top;
            cbPlayRecent.Location = new Point(0, 115);
            cbPlayRecent.Name = "cbPlayRecent";
            cbPlayRecent.Padding = new Padding(9, 0, 0, 8);
            cbPlayRecent.Size = new Size(451, 27);
            cbPlayRecent.TabIndex = 3;
            cbPlayRecent.Text = "Play only latest files setting";
            cbPlayRecent.UseVisualStyleBackColor = true;
            // 
            // cbRecentCount
            // 
            cbRecentCount.AutoSize = true;
            cbRecentCount.Dock = DockStyle.Top;
            cbRecentCount.Location = new Point(0, 142);
            cbRecentCount.Name = "cbRecentCount";
            cbRecentCount.Padding = new Padding(9, 0, 0, 8);
            cbRecentCount.Size = new Size(451, 27);
            cbRecentCount.TabIndex = 4;
            cbRecentCount.Text = "Recent count number";
            cbRecentCount.UseVisualStyleBackColor = true;
            // 
            // cbVolume
            // 
            cbVolume.AutoSize = true;
            cbVolume.Dock = DockStyle.Top;
            cbVolume.Location = new Point(0, 169);
            cbVolume.Name = "cbVolume";
            cbVolume.Padding = new Padding(9, 0, 0, 8);
            cbVolume.Size = new Size(451, 27);
            cbVolume.TabIndex = 5;
            cbVolume.Text = "Volume";
            cbVolume.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(rbAllDirectories);
            panel1.Controls.Add(rbSingleDirectory);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbAlwaysAsk);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 196);
            panel1.Name = "panel1";
            panel1.Size = new Size(451, 159);
            panel1.TabIndex = 6;
            // 
            // rbAllDirectories
            // 
            rbAllDirectories.AutoSize = true;
            rbAllDirectories.Location = new Point(0, 120);
            rbAllDirectories.Name = "rbAllDirectories";
            rbAllDirectories.Padding = new Padding(9, 0, 0, 0);
            rbAllDirectories.Size = new Size(279, 19);
            rbAllDirectories.TabIndex = 4;
            rbAllDirectories.TabStop = true;
            rbAllDirectories.Text = "Load file's directory and include subdirectories";
            rbAllDirectories.UseVisualStyleBackColor = true;
            // 
            // rbSingleDirectory
            // 
            rbSingleDirectory.AutoSize = true;
            rbSingleDirectory.Location = new Point(0, 95);
            rbSingleDirectory.Name = "rbSingleDirectory";
            rbSingleDirectory.Padding = new Padding(9, 0, 0, 0);
            rbSingleDirectory.Size = new Size(163, 19);
            rbSingleDirectory.TabIndex = 3;
            rbSingleDirectory.TabStop = true;
            rbSingleDirectory.Text = "Load file's directory only";
            rbSingleDirectory.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 60);
            label4.Name = "label4";
            label4.Padding = new Padding(6, 6, 0, 0);
            label4.Size = new Size(451, 33);
            label4.TabIndex = 2;
            label4.Text = "If not, what should be the default behavior:";
            // 
            // cbAlwaysAsk
            // 
            cbAlwaysAsk.AutoSize = true;
            cbAlwaysAsk.Dock = DockStyle.Top;
            cbAlwaysAsk.Location = new Point(0, 33);
            cbAlwaysAsk.Name = "cbAlwaysAsk";
            cbAlwaysAsk.Padding = new Padding(9, 0, 0, 8);
            cbAlwaysAsk.Size = new Size(451, 27);
            cbAlwaysAsk.TabIndex = 1;
            cbAlwaysAsk.Text = "Always ask";
            cbAlwaysAsk.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 6, 0, 0);
            label3.Size = new Size(451, 33);
            label3.TabIndex = 0;
            label3.Text = "Should RVP always ask what to do when started directly by mediafile?";
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
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RememberUserControl";
            Size = new Size(451, 409);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox cbWindowSize;
        private CheckBox cbPlayRecent;
        private CheckBox cbRecentCount;
        private CheckBox cbVolume;
        private Panel panel1;
        private Label label4;
        private CheckBox cbAlwaysAsk;
        private Label label3;
        private RadioButton rbAllDirectories;
        private RadioButton rbSingleDirectory;
    }
}
