namespace RandomVideoPlayer.UserControls
{
    partial class SkipUserControl
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
            panel1 = new Panel();
            lbl1 = new Label();
            panel2 = new Panel();
            lbl2 = new Label();
            panel3 = new Panel();
            lbl3 = new Label();
            panel4 = new Panel();
            lbl6 = new Label();
            inputSkipGapLength = new Controls.CustomNumericUpDown();
            lbl4 = new Label();
            panel5 = new Panel();
            lbl5 = new Label();
            cbEnableSkip = new Controls.CustomCheckBox();
            cbSkipVideoStart = new Controls.CustomCheckBox();
            cbSkipAlways = new Controls.CustomCheckBox();
            cbRandomStartPoint = new Controls.CustomCheckBox();
            cbRandomVideoStartPointIgnoreScripts = new Controls.CustomCheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Margin = new Padding(3, 3, 3, 10);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(475, 55);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Skip";
            // 
            // panel1
            // 
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(475, 48);
            panel1.TabIndex = 2;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Location = new Point(0, 0);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(475, 35);
            lbl1.TabIndex = 0;
            lbl1.Text = "This function is used to automatically skip gaps in a funscript video or start at a random timestamp.";
            // 
            // panel2
            // 
            panel2.Controls.Add(cbEnableSkip);
            panel2.Controls.Add(lbl2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 103);
            panel2.Name = "panel2";
            panel2.Size = new Size(475, 81);
            panel2.TabIndex = 3;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 0, 0, 0);
            lbl2.Size = new Size(475, 24);
            lbl2.TabIndex = 1;
            lbl2.Text = "Activate auto skip:";
            // 
            // panel3
            // 
            panel3.Controls.Add(cbSkipAlways);
            panel3.Controls.Add(cbSkipVideoStart);
            panel3.Controls.Add(lbl3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 184);
            panel3.Name = "panel3";
            panel3.Size = new Size(475, 100);
            panel3.TabIndex = 4;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.Location = new Point(0, 0);
            lbl3.Name = "lbl3";
            lbl3.Padding = new Padding(6, 0, 0, 0);
            lbl3.Size = new Size(475, 24);
            lbl3.TabIndex = 2;
            lbl3.Text = "Change behavior for script videos:";
            // 
            // panel4
            // 
            panel4.Controls.Add(flowLayoutPanel1);
            panel4.Controls.Add(lbl4);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 284);
            panel4.Name = "panel4";
            panel4.Size = new Size(475, 76);
            panel4.TabIndex = 5;
            // 
            // lbl6
            // 
            lbl6.Location = new Point(97, 0);
            lbl6.Margin = new Padding(6, 0, 3, 0);
            lbl6.Name = "lbl6";
            lbl6.Size = new Size(100, 19);
            lbl6.TabIndex = 5;
            lbl6.Text = "seconds";
            // 
            // inputSkipGapLength
            // 
            inputSkipGapLength.Location = new Point(12, 0);
            inputSkipGapLength.Margin = new Padding(3, 0, 3, 3);
            inputSkipGapLength.Maximum = 1000;
            inputSkipGapLength.Minimum = 1;
            inputSkipGapLength.Name = "inputSkipGapLength";
            inputSkipGapLength.Size = new Size(76, 19);
            inputSkipGapLength.TabIndex = 4;
            inputSkipGapLength.Text = "customNumericUpDown1";
            inputSkipGapLength.Value = 1;
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl4.Location = new Point(0, 0);
            lbl4.Name = "lbl4";
            lbl4.Padding = new Padding(6, 0, 0, 0);
            lbl4.Size = new Size(475, 26);
            lbl4.TabIndex = 3;
            lbl4.Text = "Specify minimum length of gaps that should be skipped:";
            // 
            // panel5
            // 
            panel5.Controls.Add(cbRandomVideoStartPointIgnoreScripts);
            panel5.Controls.Add(cbRandomStartPoint);
            panel5.Controls.Add(lbl5);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 360);
            panel5.Name = "panel5";
            panel5.Size = new Size(475, 100);
            panel5.TabIndex = 6;
            // 
            // lbl5
            // 
            lbl5.Dock = DockStyle.Top;
            lbl5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl5.Location = new Point(0, 0);
            lbl5.Name = "lbl5";
            lbl5.Padding = new Padding(6, 0, 0, 0);
            lbl5.Size = new Size(475, 40);
            lbl5.TabIndex = 4;
            lbl5.Text = "Start videos at a random startpoint. It will override the \"skip gap on video start\" method unless you choose to ignore script videos.";
            // 
            // cbEnableSkip
            // 
            cbEnableSkip.AutoSize = true;
            cbEnableSkip.BoxSize = 13;
            cbEnableSkip.Dock = DockStyle.Top;
            cbEnableSkip.HoverColor = Color.DeepSkyBlue;
            cbEnableSkip.Location = new Point(0, 24);
            cbEnableSkip.Name = "cbEnableSkip";
            cbEnableSkip.PaddingLeft = 9;
            cbEnableSkip.Size = new Size(475, 19);
            cbEnableSkip.TabIndex = 7;
            cbEnableSkip.Text = "Enable auto skip";
            cbEnableSkip.UseVisualStyleBackColor = true;
            // 
            // cbSkipVideoStart
            // 
            cbSkipVideoStart.AutoSize = true;
            cbSkipVideoStart.BoxSize = 13;
            cbSkipVideoStart.Dock = DockStyle.Top;
            cbSkipVideoStart.HoverColor = Color.DeepSkyBlue;
            cbSkipVideoStart.Location = new Point(0, 24);
            cbSkipVideoStart.Name = "cbSkipVideoStart";
            cbSkipVideoStart.Padding = new Padding(0, 3, 0, 3);
            cbSkipVideoStart.PaddingLeft = 9;
            cbSkipVideoStart.Size = new Size(475, 25);
            cbSkipVideoStart.TabIndex = 8;
            cbSkipVideoStart.Text = "Skip gap on video start";
            cbSkipVideoStart.UseVisualStyleBackColor = true;
            // 
            // cbSkipAlways
            // 
            cbSkipAlways.AutoSize = true;
            cbSkipAlways.BoxSize = 13;
            cbSkipAlways.Dock = DockStyle.Top;
            cbSkipAlways.HoverColor = Color.DeepSkyBlue;
            cbSkipAlways.Location = new Point(0, 49);
            cbSkipAlways.Name = "cbSkipAlways";
            cbSkipAlways.Padding = new Padding(0, 3, 0, 3);
            cbSkipAlways.PaddingLeft = 9;
            cbSkipAlways.Size = new Size(475, 25);
            cbSkipAlways.TabIndex = 9;
            cbSkipAlways.Text = "Skip every gap greater than specified";
            cbSkipAlways.UseVisualStyleBackColor = true;
            // 
            // cbRandomStartPoint
            // 
            cbRandomStartPoint.AutoSize = true;
            cbRandomStartPoint.BoxSize = 13;
            cbRandomStartPoint.Dock = DockStyle.Top;
            cbRandomStartPoint.HoverColor = Color.DeepSkyBlue;
            cbRandomStartPoint.Location = new Point(0, 40);
            cbRandomStartPoint.Name = "cbRandomStartPoint";
            cbRandomStartPoint.Padding = new Padding(0, 3, 0, 3);
            cbRandomStartPoint.PaddingLeft = 9;
            cbRandomStartPoint.Size = new Size(475, 25);
            cbRandomStartPoint.TabIndex = 10;
            cbRandomStartPoint.Text = "Enable random video startpoint";
            cbRandomStartPoint.UseVisualStyleBackColor = true;
            // 
            // cbRandomVideoStartPointIgnoreScripts
            // 
            cbRandomVideoStartPointIgnoreScripts.AutoSize = true;
            cbRandomVideoStartPointIgnoreScripts.BoxSize = 13;
            cbRandomVideoStartPointIgnoreScripts.Dock = DockStyle.Top;
            cbRandomVideoStartPointIgnoreScripts.HoverColor = Color.DeepSkyBlue;
            cbRandomVideoStartPointIgnoreScripts.Location = new Point(0, 65);
            cbRandomVideoStartPointIgnoreScripts.Name = "cbRandomVideoStartPointIgnoreScripts";
            cbRandomVideoStartPointIgnoreScripts.Padding = new Padding(0, 3, 0, 3);
            cbRandomVideoStartPointIgnoreScripts.PaddingLeft = 9;
            cbRandomVideoStartPointIgnoreScripts.Size = new Size(475, 25);
            cbRandomVideoStartPointIgnoreScripts.TabIndex = 11;
            cbRandomVideoStartPointIgnoreScripts.Text = "Ignore random startpoint on script videos";
            cbRandomVideoStartPointIgnoreScripts.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(inputSkipGapLength);
            flowLayoutPanel1.Controls.Add(lbl6);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 26);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(9, 0, 0, 0);
            flowLayoutPanel1.Size = new Size(475, 50);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // SkipUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblHeader);
            Name = "SkipUserControl";
            Size = new Size(475, 603);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private Panel panel2;
        private Label lbl2;
        private Panel panel3;
        private Label lbl3;
        private Panel panel4;
        private Label lbl4;
        private Controls.CustomNumericUpDown inputSkipGapLength;
        private Label lbl6;
        private Panel panel5;
        private Label lbl5;
        private Controls.CustomCheckBox cbEnableSkip;
        private Controls.CustomCheckBox cbSkipVideoStart;
        private Controls.CustomCheckBox cbSkipAlways;
        private Controls.CustomCheckBox cbRandomStartPoint;
        private Controls.CustomCheckBox cbRandomVideoStartPointIgnoreScripts;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
