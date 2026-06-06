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
            tableLayoutMain = new TableLayoutPanel();
            lbl1 = new Label();
            lblHeader = new Label();
            panel1 = new Panel();
            cbEnableSkip = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl2 = new Label();
            panel2 = new Panel();
            cbSkipAlways = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbSkipVideoStart = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl3 = new Label();
            panel3 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            inputSkipGapLength = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            lbl6 = new Label();
            lbl4 = new Label();
            panel4 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            inputThresholdStartPoint = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            cbIgnoreStartPointThreshold = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbRandomVideoStartPointIgnoreScripts = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbRandomStartPoint = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl5 = new Label();
            panel5 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblEnd = new Label();
            sliderTimeRange = new RandomVideoPlayer.Controls.FlatRangeSlider();
            lblStart = new Label();
            label1 = new Label();
            tableLayoutMain.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.LightCoral;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lbl1, 0, 1);
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(panel1, 0, 2);
            tableLayoutMain.Controls.Add(panel2, 0, 3);
            tableLayoutMain.Controls.Add(panel3, 0, 4);
            tableLayoutMain.Controls.Add(panel4, 0, 5);
            tableLayoutMain.Controls.Add(panel5, 0, 6);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 7;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutMain.Size = new Size(524, 656);
            tableLayoutMain.TabIndex = 0;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Fill;
            lbl1.Location = new Point(3, 73);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 36);
            lbl1.TabIndex = 9;
            lbl1.Text = "This function is used to automatically skip gaps in a funscript video or start at a random timestamp.";
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 3);
            lblHeader.Margin = new Padding(3, 3, 3, 10);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 8;
            lblHeader.Text = "Skip";
            // 
            // panel1
            // 
            panel1.BackColor = Color.PeachPuff;
            panel1.Controls.Add(cbEnableSkip);
            panel1.Controls.Add(lbl2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 112);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 72);
            panel1.TabIndex = 10;
            // 
            // cbEnableSkip
            // 
            cbEnableSkip.AutoSize = true;
            cbEnableSkip.BoxSize = 13;
            cbEnableSkip.Dock = DockStyle.Top;
            cbEnableSkip.HoverColor = Color.DeepSkyBlue;
            cbEnableSkip.Location = new Point(0, 24);
            cbEnableSkip.Name = "cbEnableSkip";
            cbEnableSkip.PaddingLeft = 12;
            cbEnableSkip.Size = new Size(518, 19);
            cbEnableSkip.TabIndex = 8;
            cbEnableSkip.Text = "Enable auto skip";
            cbEnableSkip.UseVisualStyleBackColor = true;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 24);
            lbl2.TabIndex = 2;
            lbl2.Text = "Activate auto skip:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Beige;
            panel2.Controls.Add(cbSkipAlways);
            panel2.Controls.Add(cbSkipVideoStart);
            panel2.Controls.Add(lbl3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 190);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 98);
            panel2.TabIndex = 11;
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
            cbSkipAlways.PaddingLeft = 12;
            cbSkipAlways.Size = new Size(518, 25);
            cbSkipAlways.TabIndex = 10;
            cbSkipAlways.Text = "Skip every gap greater than specified";
            cbSkipAlways.UseVisualStyleBackColor = true;
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
            cbSkipVideoStart.PaddingLeft = 12;
            cbSkipVideoStart.Size = new Size(518, 25);
            cbSkipVideoStart.TabIndex = 9;
            cbSkipVideoStart.Text = "Skip gap on video start";
            cbSkipVideoStart.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl3.Location = new Point(0, 0);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(518, 24);
            lbl3.TabIndex = 3;
            lbl3.Text = "Change behavior for script videos:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGreen;
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Controls.Add(lbl4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 294);
            panel3.Name = "panel3";
            panel3.Size = new Size(518, 72);
            panel3.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Honeydew;
            flowLayoutPanel1.Controls.Add(inputSkipGapLength);
            flowLayoutPanel1.Controls.Add(lbl6);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 24);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(12, 0, 0, 0);
            flowLayoutPanel1.Size = new Size(518, 31);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // inputSkipGapLength
            // 
            inputSkipGapLength.BackColor = SystemColors.Window;
            inputSkipGapLength.ForeColor = SystemColors.WindowText;
            inputSkipGapLength.IconColor = Color.Indigo;
            inputSkipGapLength.Location = new Point(15, 0);
            inputSkipGapLength.Margin = new Padding(3, 0, 3, 3);
            inputSkipGapLength.Maximum = 1000;
            inputSkipGapLength.Minimum = 1;
            inputSkipGapLength.Name = "inputSkipGapLength";
            inputSkipGapLength.Size = new Size(76, 19);
            inputSkipGapLength.TabIndex = 5;
            inputSkipGapLength.Text = "customNumericUpDown1";
            inputSkipGapLength.Value = 1;
            // 
            // lbl6
            // 
            lbl6.Dock = DockStyle.Left;
            lbl6.Location = new Point(100, 0);
            lbl6.Margin = new Padding(6, 0, 3, 0);
            lbl6.Name = "lbl6";
            lbl6.Padding = new Padding(0, 2, 0, 0);
            lbl6.Size = new Size(100, 22);
            lbl6.TabIndex = 6;
            lbl6.Text = "seconds";
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl4.Location = new Point(0, 0);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(518, 24);
            lbl4.TabIndex = 4;
            lbl4.Text = "Specify minimum length of gaps that should be skipped:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.LightCyan;
            panel4.Controls.Add(tableLayoutPanel2);
            panel4.Controls.Add(cbRandomVideoStartPointIgnoreScripts);
            panel4.Controls.Add(cbRandomStartPoint);
            panel4.Controls.Add(lbl5);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 372);
            panel4.Name = "panel4";
            panel4.Size = new Size(518, 137);
            panel4.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.PaleTurquoise;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label2, 2, 0);
            tableLayoutPanel2.Controls.Add(inputThresholdStartPoint, 1, 0);
            tableLayoutPanel2.Controls.Add(cbIgnoreStartPointThreshold, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 90);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(518, 26);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(396, 5);
            label2.Margin = new Padding(3, 5, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 29;
            label2.Text = "seconds";
            // 
            // inputThresholdStartPoint
            // 
            inputThresholdStartPoint.BackColor = SystemColors.Window;
            inputThresholdStartPoint.ForeColor = SystemColors.WindowText;
            inputThresholdStartPoint.IconColor = Color.Indigo;
            inputThresholdStartPoint.Location = new Point(315, 3);
            inputThresholdStartPoint.Maximum = 999;
            inputThresholdStartPoint.Minimum = 5;
            inputThresholdStartPoint.Name = "inputThresholdStartPoint";
            inputThresholdStartPoint.Size = new Size(75, 19);
            inputThresholdStartPoint.TabIndex = 21;
            inputThresholdStartPoint.Text = "customNumericUpDown1";
            inputThresholdStartPoint.Value = 15;
            // 
            // cbIgnoreStartPointThreshold
            // 
            cbIgnoreStartPointThreshold.BoxSize = 13;
            cbIgnoreStartPointThreshold.Dock = DockStyle.Fill;
            cbIgnoreStartPointThreshold.HoverColor = Color.DeepSkyBlue;
            cbIgnoreStartPointThreshold.Location = new Point(0, 3);
            cbIgnoreStartPointThreshold.Margin = new Padding(0, 3, 3, 3);
            cbIgnoreStartPointThreshold.Name = "cbIgnoreStartPointThreshold";
            cbIgnoreStartPointThreshold.Padding = new Padding(0, 3, 0, 3);
            cbIgnoreStartPointThreshold.PaddingLeft = 12;
            cbIgnoreStartPointThreshold.Size = new Size(309, 20);
            cbIgnoreStartPointThreshold.TabIndex = 13;
            cbIgnoreStartPointThreshold.Text = "Ignore random startpoint on videos shorter than:";
            cbIgnoreStartPointThreshold.UseVisualStyleBackColor = true;
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
            cbRandomVideoStartPointIgnoreScripts.PaddingLeft = 12;
            cbRandomVideoStartPointIgnoreScripts.Size = new Size(518, 25);
            cbRandomVideoStartPointIgnoreScripts.TabIndex = 12;
            cbRandomVideoStartPointIgnoreScripts.Text = "Ignore random startpoint on script videos";
            cbRandomVideoStartPointIgnoreScripts.UseVisualStyleBackColor = true;
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
            cbRandomStartPoint.PaddingLeft = 12;
            cbRandomStartPoint.Size = new Size(518, 25);
            cbRandomStartPoint.TabIndex = 11;
            cbRandomStartPoint.Text = "Enable random video startpoint";
            cbRandomStartPoint.UseVisualStyleBackColor = true;
            // 
            // lbl5
            // 
            lbl5.Dock = DockStyle.Top;
            lbl5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl5.Location = new Point(0, 0);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(518, 40);
            lbl5.TabIndex = 5;
            lbl5.Text = "Start videos at a random startpoint. It will override the \"skip gap on video start\" method unless you choose to ignore script videos.";
            // 
            // panel5
            // 
            panel5.BackColor = Color.PeachPuff;
            panel5.Controls.Add(tableLayoutPanel1);
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 515);
            panel5.Name = "panel5";
            panel5.Size = new Size(518, 138);
            panel5.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.LightSalmon;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(lblEnd, 2, 0);
            tableLayoutPanel1.Controls.Add(sliderTimeRange, 1, 0);
            tableLayoutPanel1.Controls.Add(lblStart, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 27);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(518, 44);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEnd.Location = new Point(468, 7);
            lblEnd.Margin = new Padding(3, 7, 3, 0);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(36, 15);
            lblEnd.TabIndex = 28;
            lblEnd.Text = "100%";
            // 
            // sliderTimeRange
            // 
            sliderTimeRange.ElapsedColor = Color.DeepSkyBlue;
            sliderTimeRange.EndValue = 80;
            sliderTimeRange.HighlightColor = Color.DodgerBlue;
            sliderTimeRange.Location = new Point(54, 3);
            sliderTimeRange.MinimumRange = 10;
            sliderTimeRange.Name = "sliderTimeRange";
            sliderTimeRange.RemainingColor = Color.Gray;
            sliderTimeRange.Size = new Size(408, 23);
            sliderTimeRange.StartValue = 10;
            sliderTimeRange.TabIndex = 27;
            sliderTimeRange.Text = "flatRangeSlider1";
            sliderTimeRange.ThumbColor = Color.White;
            sliderTimeRange.ThumbSize = new Size(14, 14);
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStart.Location = new Point(3, 7);
            lblStart.Margin = new Padding(3, 7, 3, 0);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(24, 15);
            lblStart.TabIndex = 26;
            lblStart.Text = "0%";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(518, 27);
            label1.TabIndex = 6;
            label1.Text = "You can customize the time range for a random startpoint:";
            // 
            // SkipUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutMain);
            Name = "SkipUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel5.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Label lbl1;
        private Panel panel1;
        private Label lbl2;
        private Controls.CustomCheckBox cbEnableSkip;
        private Panel panel2;
        private Label lbl3;
        private Controls.CustomCheckBox cbSkipVideoStart;
        private Controls.CustomCheckBox cbSkipAlways;
        private Panel panel3;
        private Label lbl4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Controls.CustomNumericUpDown inputSkipGapLength;
        private Label lbl6;
        private Panel panel4;
        private Label lbl5;
        private Controls.CustomCheckBox cbRandomStartPoint;
        private Controls.CustomCheckBox cbRandomVideoStartPointIgnoreScripts;
        private Panel panel5;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label lblStart;
        private Controls.FlatRangeSlider sliderTimeRange;
        private Label lblEnd;
        private TableLayoutPanel tableLayoutPanel2;
        private Controls.CustomCheckBox cbIgnoreStartPointThreshold;
        private Controls.CustomNumericUpDown inputThresholdStartPoint;
        private Label label2;
    }
}
