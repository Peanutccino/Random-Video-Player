namespace RandomVideoPlayer.UserControls
{
    partial class TimerUserControl
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            lbl3 = new Label();
            cbEnableTimer = new RandomVideoPlayer.Controls.CustomCheckBox();
            panel1 = new Panel();
            cbResetTimerOnSeek = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbEnableTimeRange = new RandomVideoPlayer.Controls.CustomCheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            lblAfterTime = new Label();
            inputTimerValueEndPoint = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            lblBetweenTime = new Label();
            inputTimerValueStartPoint = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            tableLayoutPanel2 = new TableLayoutPanel();
            cbEnablePlayFully = new RandomVideoPlayer.Controls.CustomCheckBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblMaxDurationTime = new Label();
            label2 = new Label();
            label4 = new Label();
            inputTimerMaxVideoDuration = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            tableLayoutMain.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutMain.Controls.Add(panel1, 0, 2);
            tableLayoutMain.Controls.Add(tableLayoutPanel2, 0, 3);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 5;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
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
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 18;
            lblHeader.Text = "Timer";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.LightCoral;
            flowLayoutPanel1.Controls.Add(lbl3);
            flowLayoutPanel1.Controls.Add(cbEnableTimer);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 63);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(518, 100);
            flowLayoutPanel1.TabIndex = 19;
            flowLayoutPanel1.WrapContents = false;
            // 
            // lbl3
            // 
            lbl3.AutoSize = true;
            lbl3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl3.Location = new Point(3, 0);
            lbl3.Margin = new Padding(3, 0, 3, 3);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(392, 15);
            lbl3.TabIndex = 9;
            lbl3.Text = "Enable timer that auto plays next video in queue after set timeframe:";
            // 
            // cbEnableTimer
            // 
            cbEnableTimer.AutoSize = true;
            cbEnableTimer.BoxSize = 13;
            cbEnableTimer.Dock = DockStyle.Top;
            cbEnableTimer.HoverColor = Color.DeepSkyBlue;
            cbEnableTimer.Location = new Point(3, 21);
            cbEnableTimer.Name = "cbEnableTimer";
            cbEnableTimer.PaddingLeft = 12;
            cbEnableTimer.Size = new Size(392, 19);
            cbEnableTimer.TabIndex = 10;
            cbEnableTimer.Text = "Enable Timer";
            cbEnableTimer.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightYellow;
            panel1.Controls.Add(cbResetTimerOnSeek);
            panel1.Controls.Add(cbEnableTimeRange);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 169);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 157);
            panel1.TabIndex = 20;
            // 
            // cbResetTimerOnSeek
            // 
            cbResetTimerOnSeek.BoxSize = 13;
            cbResetTimerOnSeek.Dock = DockStyle.Top;
            cbResetTimerOnSeek.HoverColor = Color.DeepSkyBlue;
            cbResetTimerOnSeek.Location = new Point(0, 50);
            cbResetTimerOnSeek.Name = "cbResetTimerOnSeek";
            cbResetTimerOnSeek.PaddingLeft = 12;
            cbResetTimerOnSeek.Size = new Size(518, 24);
            cbResetTimerOnSeek.TabIndex = 23;
            cbResetTimerOnSeek.Text = "Reset timer when video is manually seeked";
            cbResetTimerOnSeek.UseVisualStyleBackColor = true;
            // 
            // cbEnableTimeRange
            // 
            cbEnableTimeRange.BoxSize = 13;
            cbEnableTimeRange.Dock = DockStyle.Top;
            cbEnableTimeRange.HoverColor = Color.DeepSkyBlue;
            cbEnableTimeRange.Location = new Point(0, 26);
            cbEnableTimeRange.Name = "cbEnableTimeRange";
            cbEnableTimeRange.PaddingLeft = 12;
            cbEnableTimeRange.Size = new Size(518, 24);
            cbEnableTimeRange.TabIndex = 22;
            cbEnableTimeRange.Text = "Enable random time range";
            cbEnableTimeRange.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Plum;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(lblAfterTime, 4, 0);
            tableLayoutPanel1.Controls.Add(inputTimerValueEndPoint, 3, 0);
            tableLayoutPanel1.Controls.Add(lblBetweenTime, 2, 0);
            tableLayoutPanel1.Controls.Add(inputTimerValueStartPoint, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(518, 26);
            tableLayoutPanel1.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 24;
            label1.Text = "Define timer duration: ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAfterTime
            // 
            lblAfterTime.AutoSize = true;
            lblAfterTime.Location = new Point(354, 1);
            lblAfterTime.Margin = new Padding(3, 1, 3, 3);
            lblAfterTime.Name = "lblAfterTime";
            lblAfterTime.Size = new Size(50, 15);
            lblAfterTime.TabIndex = 23;
            lblAfterTime.Text = "seconds";
            lblAfterTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputTimerValueEndPoint
            // 
            inputTimerValueEndPoint.BackColor = SystemColors.Window;
            inputTimerValueEndPoint.ForeColor = SystemColors.WindowText;
            inputTimerValueEndPoint.IconColor = Color.Indigo;
            inputTimerValueEndPoint.Location = new Point(273, 0);
            inputTimerValueEndPoint.Margin = new Padding(3, 0, 3, 3);
            inputTimerValueEndPoint.Maximum = 101;
            inputTimerValueEndPoint.Minimum = 4;
            inputTimerValueEndPoint.Name = "inputTimerValueEndPoint";
            inputTimerValueEndPoint.Size = new Size(75, 19);
            inputTimerValueEndPoint.TabIndex = 22;
            inputTimerValueEndPoint.Text = "customNumericUpDown1";
            inputTimerValueEndPoint.Value = 15;
            // 
            // lblBetweenTime
            // 
            lblBetweenTime.AutoSize = true;
            lblBetweenTime.Location = new Point(217, 1);
            lblBetweenTime.Margin = new Padding(3, 1, 3, 3);
            lblBetweenTime.Name = "lblBetweenTime";
            lblBetweenTime.Size = new Size(50, 15);
            lblBetweenTime.TabIndex = 21;
            lblBetweenTime.Text = "seconds";
            lblBetweenTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputTimerValueStartPoint
            // 
            inputTimerValueStartPoint.BackColor = SystemColors.Window;
            inputTimerValueStartPoint.ForeColor = SystemColors.WindowText;
            inputTimerValueStartPoint.IconColor = Color.Indigo;
            inputTimerValueStartPoint.Location = new Point(136, 0);
            inputTimerValueStartPoint.Margin = new Padding(3, 0, 3, 3);
            inputTimerValueStartPoint.Maximum = 100;
            inputTimerValueStartPoint.Minimum = 3;
            inputTimerValueStartPoint.Name = "inputTimerValueStartPoint";
            inputTimerValueStartPoint.Size = new Size(75, 19);
            inputTimerValueStartPoint.TabIndex = 20;
            inputTimerValueStartPoint.Text = "customNumericUpDown1";
            inputTimerValueStartPoint.Value = 15;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.YellowGreen;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(cbEnablePlayFully, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 332);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel2.Size = new Size(518, 157);
            tableLayoutPanel2.TabIndex = 21;
            // 
            // cbEnablePlayFully
            // 
            cbEnablePlayFully.BoxSize = 13;
            cbEnablePlayFully.Dock = DockStyle.Top;
            cbEnablePlayFully.HoverColor = Color.DeepSkyBlue;
            cbEnablePlayFully.Location = new Point(3, 35);
            cbEnablePlayFully.Name = "cbEnablePlayFully";
            cbEnablePlayFully.PaddingLeft = 12;
            cbEnablePlayFully.Size = new Size(512, 24);
            cbEnablePlayFully.TabIndex = 23;
            cbEnablePlayFully.Text = "Play videos shorter than defined fully, even when it should skip";
            cbEnablePlayFully.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.Plum;
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(lblMaxDurationTime, 3, 0);
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Controls.Add(label4, 2, 0);
            tableLayoutPanel3.Controls.Add(inputTimerMaxVideoDuration, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(512, 26);
            tableLayoutPanel3.TabIndex = 21;
            // 
            // lblMaxDurationTime
            // 
            lblMaxDurationTime.AutoSize = true;
            lblMaxDurationTime.Location = new Point(300, 1);
            lblMaxDurationTime.Margin = new Padding(3, 1, 3, 3);
            lblMaxDurationTime.Name = "lblMaxDurationTime";
            lblMaxDurationTime.Size = new Size(88, 15);
            lblMaxDurationTime.TabIndex = 25;
            lblMaxDurationTime.Text = "( 2:40 minutes )";
            lblMaxDurationTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(154, 15);
            label2.TabIndex = 24;
            label2.Text = "Define max video duration: ";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(244, 1);
            label4.Margin = new Padding(3, 1, 3, 3);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 21;
            label4.Text = "seconds";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputTimerMaxVideoDuration
            // 
            inputTimerMaxVideoDuration.BackColor = SystemColors.Window;
            inputTimerMaxVideoDuration.ForeColor = SystemColors.WindowText;
            inputTimerMaxVideoDuration.IconColor = Color.Indigo;
            inputTimerMaxVideoDuration.Location = new Point(163, 0);
            inputTimerMaxVideoDuration.Margin = new Padding(3, 0, 3, 3);
            inputTimerMaxVideoDuration.Maximum = 900;
            inputTimerMaxVideoDuration.Minimum = 10;
            inputTimerMaxVideoDuration.Name = "inputTimerMaxVideoDuration";
            inputTimerMaxVideoDuration.Size = new Size(75, 19);
            inputTimerMaxVideoDuration.TabIndex = 20;
            inputTimerMaxVideoDuration.Text = "customNumericUpDown1";
            inputTimerMaxVideoDuration.Value = 15;
            // 
            // TimerUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutMain);
            Name = "TimerUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lbl3;
        private Controls.CustomCheckBox cbEnableTimer;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblAfterTime;
        private Controls.CustomNumericUpDown inputTimerValueEndPoint;
        private Label lblBetweenTime;
        private Controls.CustomNumericUpDown inputTimerValueStartPoint;
        private Label label1;
        private Controls.CustomCheckBox cbEnableTimeRange;
        private Controls.CustomCheckBox cbResetTimerOnSeek;
        private TableLayoutPanel tableLayoutPanel2;
        private Controls.CustomCheckBox cbEnablePlayFully;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label2;
        private Label label4;
        private Controls.CustomNumericUpDown inputTimerMaxVideoDuration;
        private Label lblMaxDurationTime;
    }
}
