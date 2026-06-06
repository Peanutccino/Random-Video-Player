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
            tableLayoutMain = new TableLayoutPanel();
            lblHeader = new Label();
            panel1 = new Panel();
            cbVolume = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbRecentCount = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbPlayRecent = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbLbWindowSize = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbFbWindowSize = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbWindowSize = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl1 = new Label();
            panel2 = new Panel();
            cbAlwaysAsk = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl2 = new Label();
            panel3 = new Panel();
            rbAllDirectories = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbSingleDirectory = new RandomVideoPlayer.Controls.CustomRadioButton();
            lbl3 = new Label();
            tableLayoutMain.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.LightSteelBlue;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 1);
            tableLayoutMain.Controls.Add(panel2, 0, 2);
            tableLayoutMain.Controls.Add(panel3, 0, 3);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 4;
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
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
            lblHeader.TabIndex = 14;
            lblHeader.Text = "Remember";
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(cbVolume);
            panel1.Controls.Add(cbRecentCount);
            panel1.Controls.Add(cbPlayRecent);
            panel1.Controls.Add(cbLbWindowSize);
            panel1.Controls.Add(cbFbWindowSize);
            panel1.Controls.Add(cbWindowSize);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 200);
            panel1.TabIndex = 15;
            // 
            // cbVolume
            // 
            cbVolume.AutoSize = true;
            cbVolume.BoxSize = 13;
            cbVolume.Dock = DockStyle.Top;
            cbVolume.HoverColor = Color.DeepSkyBlue;
            cbVolume.Location = new Point(0, 149);
            cbVolume.Name = "cbVolume";
            cbVolume.Padding = new Padding(0, 3, 0, 3);
            cbVolume.PaddingLeft = 12;
            cbVolume.Size = new Size(518, 25);
            cbVolume.TabIndex = 25;
            cbVolume.Text = "Volume";
            cbVolume.UseVisualStyleBackColor = true;
            // 
            // cbRecentCount
            // 
            cbRecentCount.AutoSize = true;
            cbRecentCount.BoxSize = 13;
            cbRecentCount.Dock = DockStyle.Top;
            cbRecentCount.HoverColor = Color.DeepSkyBlue;
            cbRecentCount.Location = new Point(0, 124);
            cbRecentCount.Name = "cbRecentCount";
            cbRecentCount.Padding = new Padding(0, 3, 0, 3);
            cbRecentCount.PaddingLeft = 12;
            cbRecentCount.Size = new Size(518, 25);
            cbRecentCount.TabIndex = 24;
            cbRecentCount.Text = "\"Latest X files\" count number";
            cbRecentCount.UseVisualStyleBackColor = true;
            // 
            // cbPlayRecent
            // 
            cbPlayRecent.AutoSize = true;
            cbPlayRecent.BoxSize = 13;
            cbPlayRecent.Dock = DockStyle.Top;
            cbPlayRecent.HoverColor = Color.DeepSkyBlue;
            cbPlayRecent.Location = new Point(0, 99);
            cbPlayRecent.Name = "cbPlayRecent";
            cbPlayRecent.Padding = new Padding(0, 3, 0, 3);
            cbPlayRecent.PaddingLeft = 12;
            cbPlayRecent.Size = new Size(518, 25);
            cbPlayRecent.TabIndex = 23;
            cbPlayRecent.Text = "\"Latest X files\" setting in Folderbrowser";
            cbPlayRecent.UseVisualStyleBackColor = true;
            // 
            // cbLbWindowSize
            // 
            cbLbWindowSize.AutoSize = true;
            cbLbWindowSize.BoxSize = 13;
            cbLbWindowSize.Dock = DockStyle.Top;
            cbLbWindowSize.HoverColor = Color.DeepSkyBlue;
            cbLbWindowSize.Location = new Point(0, 74);
            cbLbWindowSize.Name = "cbLbWindowSize";
            cbLbWindowSize.Padding = new Padding(0, 3, 0, 3);
            cbLbWindowSize.PaddingLeft = 12;
            cbLbWindowSize.Size = new Size(518, 25);
            cbLbWindowSize.TabIndex = 22;
            cbLbWindowSize.Text = "List browser window size";
            cbLbWindowSize.UseVisualStyleBackColor = true;
            // 
            // cbFbWindowSize
            // 
            cbFbWindowSize.AutoSize = true;
            cbFbWindowSize.BoxSize = 13;
            cbFbWindowSize.Dock = DockStyle.Top;
            cbFbWindowSize.HoverColor = Color.DeepSkyBlue;
            cbFbWindowSize.Location = new Point(0, 49);
            cbFbWindowSize.Name = "cbFbWindowSize";
            cbFbWindowSize.Padding = new Padding(0, 3, 0, 3);
            cbFbWindowSize.PaddingLeft = 12;
            cbFbWindowSize.Size = new Size(518, 25);
            cbFbWindowSize.TabIndex = 21;
            cbFbWindowSize.Text = "File browser window size";
            cbFbWindowSize.UseVisualStyleBackColor = true;
            // 
            // cbWindowSize
            // 
            cbWindowSize.AutoSize = true;
            cbWindowSize.BoxSize = 13;
            cbWindowSize.Dock = DockStyle.Top;
            cbWindowSize.HoverColor = Color.DeepSkyBlue;
            cbWindowSize.Location = new Point(0, 24);
            cbWindowSize.Name = "cbWindowSize";
            cbWindowSize.Padding = new Padding(0, 3, 0, 3);
            cbWindowSize.PaddingLeft = 12;
            cbWindowSize.Size = new Size(518, 25);
            cbWindowSize.TabIndex = 17;
            cbWindowSize.Text = "Main window size";
            cbWindowSize.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 24);
            lbl1.TabIndex = 15;
            lbl1.Text = "Check to remember state for next application start:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Thistle;
            panel2.Controls.Add(cbAlwaysAsk);
            panel2.Controls.Add(lbl2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 269);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 80);
            panel2.TabIndex = 16;
            // 
            // cbAlwaysAsk
            // 
            cbAlwaysAsk.AutoSize = true;
            cbAlwaysAsk.BoxSize = 13;
            cbAlwaysAsk.Dock = DockStyle.Top;
            cbAlwaysAsk.HoverColor = Color.DeepSkyBlue;
            cbAlwaysAsk.Location = new Point(0, 24);
            cbAlwaysAsk.Name = "cbAlwaysAsk";
            cbAlwaysAsk.Padding = new Padding(0, 0, 0, 3);
            cbAlwaysAsk.PaddingLeft = 12;
            cbAlwaysAsk.Size = new Size(518, 22);
            cbAlwaysAsk.TabIndex = 12;
            cbAlwaysAsk.Text = "Always ask";
            cbAlwaysAsk.UseVisualStyleBackColor = true;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 24);
            lbl2.TabIndex = 1;
            lbl2.Text = "Should RVP always ask what to do when started directly by mediafile?";
            // 
            // panel3
            // 
            panel3.BackColor = Color.PaleGoldenrod;
            panel3.Controls.Add(rbAllDirectories);
            panel3.Controls.Add(rbSingleDirectory);
            panel3.Controls.Add(lbl3);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 355);
            panel3.Name = "panel3";
            panel3.Size = new Size(518, 298);
            panel3.TabIndex = 17;
            // 
            // rbAllDirectories
            // 
            rbAllDirectories.AutoSize = true;
            rbAllDirectories.CircleSize = 12;
            rbAllDirectories.Dock = DockStyle.Top;
            rbAllDirectories.HoverColor = Color.DeepSkyBlue;
            rbAllDirectories.Location = new Point(0, 49);
            rbAllDirectories.Name = "rbAllDirectories";
            rbAllDirectories.Padding = new Padding(0, 3, 0, 3);
            rbAllDirectories.PaddingLeft = 12;
            rbAllDirectories.Size = new Size(518, 25);
            rbAllDirectories.TabIndex = 13;
            rbAllDirectories.TabStop = true;
            rbAllDirectories.Text = "Load file's directory and include subdirectories";
            rbAllDirectories.UseVisualStyleBackColor = true;
            // 
            // rbSingleDirectory
            // 
            rbSingleDirectory.AutoSize = true;
            rbSingleDirectory.BackColor = Color.PaleGoldenrod;
            rbSingleDirectory.CircleSize = 12;
            rbSingleDirectory.Dock = DockStyle.Top;
            rbSingleDirectory.ForeColor = SystemColors.ControlText;
            rbSingleDirectory.HoverColor = Color.DeepSkyBlue;
            rbSingleDirectory.Location = new Point(0, 24);
            rbSingleDirectory.Name = "rbSingleDirectory";
            rbSingleDirectory.Padding = new Padding(0, 3, 0, 3);
            rbSingleDirectory.PaddingLeft = 12;
            rbSingleDirectory.Size = new Size(518, 25);
            rbSingleDirectory.TabIndex = 12;
            rbSingleDirectory.TabStop = true;
            rbSingleDirectory.Text = "Load file's directory only";
            rbSingleDirectory.UseVisualStyleBackColor = false;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl3.Location = new Point(0, 0);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(518, 24);
            lbl3.TabIndex = 3;
            lbl3.Text = "If not, what should be the default behavior:";
            // 
            // RememberUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(tableLayoutMain);
            Name = "RememberUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private Controls.CustomCheckBox cbWindowSize;
        private Controls.CustomCheckBox cbFbWindowSize;
        private Controls.CustomCheckBox cbLbWindowSize;
        private Controls.CustomCheckBox cbPlayRecent;
        private Controls.CustomCheckBox cbRecentCount;
        private Controls.CustomCheckBox cbVolume;
        private Panel panel2;
        private Label lbl2;
        private Controls.CustomCheckBox cbAlwaysAsk;
        private Panel panel3;
        private Label lbl3;
        private Controls.CustomRadioButton rbSingleDirectory;
        private Controls.CustomRadioButton rbAllDirectories;
    }
}
