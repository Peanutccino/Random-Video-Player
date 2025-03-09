namespace RandomVideoPlayer.UserControls
{
    partial class PlayerUserControl
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
            lbl2 = new Label();
            panel2 = new Panel();
            cbLeftMousePause = new Controls.CustomCheckBox();
            lbl1 = new Label();
            panel3 = new Panel();
            cbEnableTimeRange = new Controls.CustomCheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            rbAutoTimer = new Controls.CustomRadioButton();
            inputTimerValueStartPoint = new Controls.CustomNumericUpDown();
            lblBetweenTime = new Label();
            inputTimerValueEndPoint = new Controls.CustomNumericUpDown();
            lblAfterTime = new Label();
            rbAutoNext = new Controls.CustomRadioButton();
            rbRepeatVideo = new Controls.CustomRadioButton();
            panel4 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            cbShufflePlayer = new Controls.CustomCheckBox();
            cbReshuffle = new Controls.CustomCheckBox();
            lbl3 = new Label();
            panel1 = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            lbl5 = new Label();
            btnRTXHelp = new FontAwesome.Sharp.IconButton();
            cbEnableRTXVSR = new Controls.CustomCheckBox();
            lbl4 = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(507, 55);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Player";
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Padding = new Padding(6, 0, 0, 0);
            lbl2.Size = new Size(507, 23);
            lbl2.TabIndex = 3;
            lbl2.Text = "Switch playback behavior";
            // 
            // panel2
            // 
            panel2.Controls.Add(cbLeftMousePause);
            panel2.Controls.Add(lbl1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(507, 55);
            panel2.TabIndex = 13;
            // 
            // cbLeftMousePause
            // 
            cbLeftMousePause.AutoSize = true;
            cbLeftMousePause.BoxSize = 13;
            cbLeftMousePause.Dock = DockStyle.Top;
            cbLeftMousePause.HoverColor = Color.DeepSkyBlue;
            cbLeftMousePause.Location = new Point(0, 27);
            cbLeftMousePause.Name = "cbLeftMousePause";
            cbLeftMousePause.PaddingLeft = 9;
            cbLeftMousePause.Size = new Size(507, 19);
            cbLeftMousePause.TabIndex = 19;
            cbLeftMousePause.Text = "Play/Pause on left mouse click";
            cbLeftMousePause.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl1.Location = new Point(0, 0);
            lbl1.Margin = new Padding(0);
            lbl1.Name = "lbl1";
            lbl1.Padding = new Padding(6, 0, 0, 0);
            lbl1.Size = new Size(507, 27);
            lbl1.TabIndex = 0;
            lbl1.Text = "Check to enable/disable Play/Pause with left mouse click on the player";
            // 
            // panel3
            // 
            panel3.Controls.Add(cbEnableTimeRange);
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Controls.Add(rbAutoNext);
            panel3.Controls.Add(rbRepeatVideo);
            panel3.Controls.Add(lbl2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 110);
            panel3.Name = "panel3";
            panel3.Size = new Size(507, 120);
            panel3.TabIndex = 14;
            // 
            // cbEnableTimeRange
            // 
            cbEnableTimeRange.BoxSize = 13;
            cbEnableTimeRange.Dock = DockStyle.Top;
            cbEnableTimeRange.HoverColor = Color.DeepSkyBlue;
            cbEnableTimeRange.Location = new Point(0, 87);
            cbEnableTimeRange.Name = "cbEnableTimeRange";
            cbEnableTimeRange.PaddingLeft = 9;
            cbEnableTimeRange.Size = new Size(507, 19);
            cbEnableTimeRange.TabIndex = 20;
            cbEnableTimeRange.Text = "Enable random time range";
            cbEnableTimeRange.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(rbAutoTimer);
            flowLayoutPanel1.Controls.Add(inputTimerValueStartPoint);
            flowLayoutPanel1.Controls.Add(lblBetweenTime);
            flowLayoutPanel1.Controls.Add(inputTimerValueEndPoint);
            flowLayoutPanel1.Controls.Add(lblAfterTime);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 61);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(507, 26);
            flowLayoutPanel1.TabIndex = 22;
            // 
            // rbAutoTimer
            // 
            rbAutoTimer.CircleSize = 12;
            rbAutoTimer.HoverColor = Color.DeepSkyBlue;
            rbAutoTimer.Location = new Point(0, 0);
            rbAutoTimer.Margin = new Padding(0, 0, 3, 3);
            rbAutoTimer.Name = "rbAutoTimer";
            rbAutoTimer.PaddingLeft = 9;
            rbAutoTimer.Size = new Size(200, 19);
            rbAutoTimer.TabIndex = 18;
            rbAutoTimer.TabStop = true;
            rbAutoTimer.Text = "Automatic next after timer";
            rbAutoTimer.UseVisualStyleBackColor = true;
            // 
            // inputTimerValueStartPoint
            // 
            inputTimerValueStartPoint.Location = new Point(206, 0);
            inputTimerValueStartPoint.Margin = new Padding(3, 0, 3, 3);
            inputTimerValueStartPoint.Maximum = 100;
            inputTimerValueStartPoint.Minimum = 3;
            inputTimerValueStartPoint.Name = "inputTimerValueStartPoint";
            inputTimerValueStartPoint.Size = new Size(78, 19);
            inputTimerValueStartPoint.TabIndex = 18;
            inputTimerValueStartPoint.Text = "customNumericUpDown1";
            inputTimerValueStartPoint.Value = 15;
            // 
            // lblBetweenTime
            // 
            lblBetweenTime.AutoSize = true;
            lblBetweenTime.Location = new Point(290, 1);
            lblBetweenTime.Margin = new Padding(3, 1, 3, 3);
            lblBetweenTime.Name = "lblBetweenTime";
            lblBetweenTime.Size = new Size(50, 15);
            lblBetweenTime.TabIndex = 17;
            lblBetweenTime.Text = "seconds";
            lblBetweenTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputTimerValueEndPoint
            // 
            inputTimerValueEndPoint.Location = new Point(346, 0);
            inputTimerValueEndPoint.Margin = new Padding(3, 0, 3, 3);
            inputTimerValueEndPoint.Maximum = 101;
            inputTimerValueEndPoint.Minimum = 4;
            inputTimerValueEndPoint.Name = "inputTimerValueEndPoint";
            inputTimerValueEndPoint.Size = new Size(78, 19);
            inputTimerValueEndPoint.TabIndex = 19;
            inputTimerValueEndPoint.Text = "customNumericUpDown1";
            inputTimerValueEndPoint.Value = 15;
            // 
            // lblAfterTime
            // 
            lblAfterTime.AutoSize = true;
            lblAfterTime.Location = new Point(430, 1);
            lblAfterTime.Margin = new Padding(3, 1, 3, 3);
            lblAfterTime.Name = "lblAfterTime";
            lblAfterTime.Size = new Size(50, 15);
            lblAfterTime.TabIndex = 21;
            lblAfterTime.Text = "seconds";
            lblAfterTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rbAutoNext
            // 
            rbAutoNext.CircleSize = 12;
            rbAutoNext.Dock = DockStyle.Top;
            rbAutoNext.HoverColor = Color.DeepSkyBlue;
            rbAutoNext.Location = new Point(0, 42);
            rbAutoNext.Name = "rbAutoNext";
            rbAutoNext.PaddingLeft = 9;
            rbAutoNext.Size = new Size(507, 19);
            rbAutoNext.TabIndex = 17;
            rbAutoNext.TabStop = true;
            rbAutoNext.Text = "Automatic next (After video finishes)";
            rbAutoNext.UseVisualStyleBackColor = true;
            // 
            // rbRepeatVideo
            // 
            rbRepeatVideo.CircleSize = 12;
            rbRepeatVideo.Dock = DockStyle.Top;
            rbRepeatVideo.HoverColor = Color.DeepSkyBlue;
            rbRepeatVideo.Location = new Point(0, 23);
            rbRepeatVideo.Name = "rbRepeatVideo";
            rbRepeatVideo.PaddingLeft = 9;
            rbRepeatVideo.Size = new Size(507, 19);
            rbRepeatVideo.TabIndex = 16;
            rbRepeatVideo.TabStop = true;
            rbRepeatVideo.Text = "Repeat video";
            rbRepeatVideo.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(flowLayoutPanel2);
            panel4.Controls.Add(lbl3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 230);
            panel4.Name = "panel4";
            panel4.Size = new Size(507, 60);
            panel4.TabIndex = 15;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(cbShufflePlayer);
            flowLayoutPanel2.Controls.Add(cbReshuffle);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 23);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(507, 23);
            flowLayoutPanel2.TabIndex = 15;
            // 
            // cbShufflePlayer
            // 
            cbShufflePlayer.BoxSize = 13;
            cbShufflePlayer.HoverColor = Color.DeepSkyBlue;
            cbShufflePlayer.Location = new Point(0, 3);
            cbShufflePlayer.Margin = new Padding(0, 3, 3, 3);
            cbShufflePlayer.Name = "cbShufflePlayer";
            cbShufflePlayer.PaddingLeft = 9;
            cbShufflePlayer.Size = new Size(166, 19);
            cbShufflePlayer.TabIndex = 21;
            cbShufflePlayer.Text = "Shuffle Playlist";
            cbShufflePlayer.UseVisualStyleBackColor = true;
            // 
            // cbReshuffle
            // 
            cbReshuffle.BoxSize = 13;
            cbReshuffle.HoverColor = Color.DeepSkyBlue;
            cbReshuffle.Location = new Point(172, 3);
            cbReshuffle.Name = "cbReshuffle";
            cbReshuffle.PaddingLeft = 6;
            cbReshuffle.Size = new Size(230, 19);
            cbReshuffle.TabIndex = 22;
            cbReshuffle.Text = "Re-shuffle after playlist finishes";
            cbReshuffle.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl3.Location = new Point(0, 0);
            lbl3.Name = "lbl3";
            lbl3.Padding = new Padding(6, 0, 0, 0);
            lbl3.Size = new Size(507, 23);
            lbl3.TabIndex = 0;
            lbl3.Text = "Toggle between random playback or simply parsing in order";
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel3);
            panel1.Controls.Add(cbEnableRTXVSR);
            panel1.Controls.Add(lbl4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 290);
            panel1.Margin = new Padding(3, 6, 3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 75);
            panel1.TabIndex = 14;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(lbl5);
            flowLayoutPanel3.Controls.Add(btnRTXHelp);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.Location = new Point(0, 42);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(507, 30);
            flowLayoutPanel3.TabIndex = 24;
            // 
            // lbl5
            // 
            lbl5.Location = new Point(3, 3);
            lbl5.Margin = new Padding(3);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(292, 23);
            lbl5.TabIndex = 3;
            lbl5.Text = "Needs to be enabled in Nvidia driver settings, see:";
            lbl5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRTXHelp
            // 
            btnRTXHelp.FlatAppearance.BorderSize = 0;
            btnRTXHelp.FlatStyle = FlatStyle.Flat;
            btnRTXHelp.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            btnRTXHelp.IconColor = Color.Blue;
            btnRTXHelp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRTXHelp.IconSize = 23;
            btnRTXHelp.Location = new Point(301, 3);
            btnRTXHelp.Name = "btnRTXHelp";
            btnRTXHelp.Size = new Size(23, 23);
            btnRTXHelp.TabIndex = 4;
            btnRTXHelp.UseVisualStyleBackColor = true;
            btnRTXHelp.Click += btnRTXHelp_Click;
            // 
            // cbEnableRTXVSR
            // 
            cbEnableRTXVSR.BoxSize = 13;
            cbEnableRTXVSR.Dock = DockStyle.Top;
            cbEnableRTXVSR.HoverColor = Color.DeepSkyBlue;
            cbEnableRTXVSR.Location = new Point(0, 23);
            cbEnableRTXVSR.Name = "cbEnableRTXVSR";
            cbEnableRTXVSR.PaddingLeft = 9;
            cbEnableRTXVSR.Size = new Size(507, 19);
            cbEnableRTXVSR.TabIndex = 23;
            cbEnableRTXVSR.Text = "Enable RTX VSR";
            cbEnableRTXVSR.UseVisualStyleBackColor = true;
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl4.Location = new Point(0, 0);
            lbl4.Name = "lbl4";
            lbl4.Padding = new Padding(6, 0, 0, 0);
            lbl4.Size = new Size(507, 23);
            lbl4.TabIndex = 1;
            lbl4.Text = "Activate RTX VSR compatibility (Nvidia only)";
            // 
            // PlayerUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panel1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(lblHeader);
            Name = "PlayerUserControl";
            Size = new Size(507, 609);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel4.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblHeader;
        private Label lbl2;
        private Panel panel2;
        private Label lbl1;
        private Panel panel3;
        private NumericUpDown timerValueInput;
        private Label lblBetweenTime;
        private Panel panel4;
        private Label lbl3;
        private Controls.CustomNumericUpDown inputTimerValueStartPoint;
        private Controls.CustomNumericUpDown inputTimerValueEndPoint;
        private Label lblAfterTime;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnRTXHelp;
        private Label lbl5;
        private Label lbl4;
        private Controls.CustomRadioButton rbRepeatVideo;
        private Controls.CustomRadioButton rbAutoNext;
        private Controls.CustomRadioButton rbAutoTimer;
        private Controls.CustomCheckBox cbLeftMousePause;
        private Controls.CustomCheckBox cbEnableTimeRange;
        private Controls.CustomCheckBox cbShufflePlayer;
        private Controls.CustomCheckBox cbReshuffle;
        private Controls.CustomCheckBox cbEnableRTXVSR;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
    }
}
