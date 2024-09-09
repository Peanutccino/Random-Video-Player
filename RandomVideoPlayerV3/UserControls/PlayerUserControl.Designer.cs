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
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            rbDateModified = new RadioButton();
            rbDateCreated = new RadioButton();
            label3 = new Label();
            cbShufflePlayer = new CheckBox();
            panel2 = new Panel();
            cbLeftMousePause = new CheckBox();
            label7 = new Label();
            panel3 = new Panel();
            lblAfterTime = new Label();
            cbEnableTimeRange = new CheckBox();
            inputTimerValueEndPoint = new Controls.CustomNumericUpDown();
            inputTimerValueStartPoint = new Controls.CustomNumericUpDown();
            lblBetweenTime = new Label();
            rbAutoTimer = new RadioButton();
            rbAutoNext = new RadioButton();
            rbRepeatVideo = new RadioButton();
            panel4 = new Panel();
            label5 = new Label();
            panel5 = new Panel();
            label4 = new Label();
            cbToggleMoveVerticalEffect = new CheckBox();
            cbToggleMoveHorizontalEffect = new CheckBox();
            cbToggleZoomEffect = new CheckBox();
            label12 = new Label();
            label11 = new Label();
            comboPanEffects = new Controls.ButtonComboBox();
            comboZoomEffects = new Controls.ButtonComboBox();
            btnRestoreDefaults = new Button();
            label10 = new Label();
            label9 = new Label();
            inputPanAmountValue = new Controls.CustomNumericUpDown();
            inputZoomAmountValue = new Controls.CustomNumericUpDown();
            cbKenBurnsEffect = new CheckBox();
            label8 = new Label();
            label6 = new Label();
            cbReshuffle = new CheckBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Indigo;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(507, 55);
            label1.TabIndex = 0;
            label1.Text = "Player";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 55);
            label2.Name = "label2";
            label2.Padding = new Padding(6, 0, 0, 0);
            label2.Size = new Size(507, 18);
            label2.TabIndex = 1;
            label2.Text = "Change the behavior of the recent filter:";
            // 
            // panel1
            // 
            panel1.Controls.Add(rbDateModified);
            panel1.Controls.Add(rbDateCreated);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 41);
            panel1.TabIndex = 2;
            // 
            // rbDateModified
            // 
            rbDateModified.AutoSize = true;
            rbDateModified.Location = new Point(162, 3);
            rbDateModified.Margin = new Padding(20, 3, 3, 3);
            rbDateModified.Name = "rbDateModified";
            rbDateModified.Size = new Size(139, 19);
            rbDateModified.TabIndex = 1;
            rbDateModified.TabStop = true;
            rbDateModified.Text = "Sort by date modified";
            rbDateModified.UseVisualStyleBackColor = true;
            // 
            // rbDateCreated
            // 
            rbDateCreated.AutoSize = true;
            rbDateCreated.Location = new Point(3, 3);
            rbDateCreated.Name = "rbDateCreated";
            rbDateCreated.Padding = new Padding(6, 0, 0, 0);
            rbDateCreated.Size = new Size(136, 19);
            rbDateCreated.TabIndex = 0;
            rbDateCreated.TabStop = true;
            rbDateCreated.Text = "Sort by date created";
            rbDateCreated.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 0, 0, 0);
            label3.Size = new Size(507, 23);
            label3.TabIndex = 3;
            label3.Text = "Switch playback behavior";
            // 
            // cbShufflePlayer
            // 
            cbShufflePlayer.AutoSize = true;
            cbShufflePlayer.Location = new Point(3, 29);
            cbShufflePlayer.Name = "cbShufflePlayer";
            cbShufflePlayer.Padding = new Padding(6, 0, 0, 0);
            cbShufflePlayer.Size = new Size(109, 19);
            cbShufflePlayer.TabIndex = 12;
            cbShufflePlayer.Text = "Shuffle Playlist";
            cbShufflePlayer.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbLeftMousePause);
            panel2.Controls.Add(label7);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 114);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(6, 0, 0, 0);
            panel2.Size = new Size(507, 70);
            panel2.TabIndex = 13;
            // 
            // cbLeftMousePause
            // 
            cbLeftMousePause.AutoSize = true;
            cbLeftMousePause.Location = new Point(3, 26);
            cbLeftMousePause.Name = "cbLeftMousePause";
            cbLeftMousePause.Padding = new Padding(6, 0, 0, 0);
            cbLeftMousePause.Size = new Size(193, 19);
            cbLeftMousePause.TabIndex = 1;
            cbLeftMousePause.Text = "Play/Pause on left mouse click";
            cbLeftMousePause.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Top;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(6, 0);
            label7.Name = "label7";
            label7.Size = new Size(501, 23);
            label7.TabIndex = 0;
            label7.Text = "Check to enable/disable Play/Pause with left mouse click on the player";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblAfterTime);
            panel3.Controls.Add(cbEnableTimeRange);
            panel3.Controls.Add(inputTimerValueEndPoint);
            panel3.Controls.Add(inputTimerValueStartPoint);
            panel3.Controls.Add(lblBetweenTime);
            panel3.Controls.Add(rbAutoTimer);
            panel3.Controls.Add(rbAutoNext);
            panel3.Controls.Add(rbRepeatVideo);
            panel3.Controls.Add(label3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 184);
            panel3.Name = "panel3";
            panel3.Size = new Size(507, 132);
            panel3.TabIndex = 14;
            // 
            // lblAfterTime
            // 
            lblAfterTime.AutoSize = true;
            lblAfterTime.Location = new Point(404, 78);
            lblAfterTime.Name = "lblAfterTime";
            lblAfterTime.Size = new Size(50, 15);
            lblAfterTime.TabIndex = 21;
            lblAfterTime.Text = "seconds";
            // 
            // cbEnableTimeRange
            // 
            cbEnableTimeRange.AutoSize = true;
            cbEnableTimeRange.Location = new Point(3, 107);
            cbEnableTimeRange.Name = "cbEnableTimeRange";
            cbEnableTimeRange.Padding = new Padding(6, 0, 0, 0);
            cbEnableTimeRange.Size = new Size(172, 19);
            cbEnableTimeRange.TabIndex = 20;
            cbEnableTimeRange.Text = "Enable random time range";
            cbEnableTimeRange.UseVisualStyleBackColor = true;
            // 
            // inputTimerValueEndPoint
            // 
            inputTimerValueEndPoint.Location = new Point(320, 76);
            inputTimerValueEndPoint.Maximum = 101;
            inputTimerValueEndPoint.Minimum = 4;
            inputTimerValueEndPoint.Name = "inputTimerValueEndPoint";
            inputTimerValueEndPoint.Size = new Size(78, 19);
            inputTimerValueEndPoint.TabIndex = 19;
            inputTimerValueEndPoint.Text = "customNumericUpDown1";
            inputTimerValueEndPoint.Value = 15;
            // 
            // inputTimerValueStartPoint
            // 
            inputTimerValueStartPoint.Location = new Point(180, 76);
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
            lblBetweenTime.Location = new Point(264, 78);
            lblBetweenTime.Name = "lblBetweenTime";
            lblBetweenTime.Size = new Size(50, 15);
            lblBetweenTime.TabIndex = 17;
            lblBetweenTime.Text = "seconds";
            // 
            // rbAutoTimer
            // 
            rbAutoTimer.AutoSize = true;
            rbAutoTimer.Location = new Point(3, 76);
            rbAutoTimer.Name = "rbAutoTimer";
            rbAutoTimer.Padding = new Padding(6, 0, 0, 0);
            rbAutoTimer.Size = new Size(171, 19);
            rbAutoTimer.TabIndex = 15;
            rbAutoTimer.TabStop = true;
            rbAutoTimer.Text = "Automatic next after timer";
            rbAutoTimer.UseVisualStyleBackColor = true;
            // 
            // rbAutoNext
            // 
            rbAutoNext.AutoSize = true;
            rbAutoNext.Location = new Point(3, 51);
            rbAutoNext.Name = "rbAutoNext";
            rbAutoNext.Padding = new Padding(6, 0, 0, 0);
            rbAutoNext.Size = new Size(225, 19);
            rbAutoNext.TabIndex = 14;
            rbAutoNext.TabStop = true;
            rbAutoNext.Text = "Automatic next (After video finishes)";
            rbAutoNext.UseVisualStyleBackColor = true;
            // 
            // rbRepeatVideo
            // 
            rbRepeatVideo.AutoSize = true;
            rbRepeatVideo.Location = new Point(3, 26);
            rbRepeatVideo.Name = "rbRepeatVideo";
            rbRepeatVideo.Padding = new Padding(6, 0, 0, 0);
            rbRepeatVideo.Size = new Size(99, 19);
            rbRepeatVideo.TabIndex = 13;
            rbRepeatVideo.TabStop = true;
            rbRepeatVideo.Text = "Repeat video";
            rbRepeatVideo.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(cbReshuffle);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(cbShufflePlayer);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 316);
            panel4.Name = "panel4";
            panel4.Size = new Size(507, 68);
            panel4.TabIndex = 15;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Padding = new Padding(6, 0, 0, 0);
            label5.Size = new Size(507, 26);
            label5.TabIndex = 0;
            label5.Text = "Toggle between random playback or simply parsing in order";
            // 
            // panel5
            // 
            panel5.BackColor = Color.LavenderBlush;
            panel5.Controls.Add(label4);
            panel5.Controls.Add(cbToggleMoveVerticalEffect);
            panel5.Controls.Add(cbToggleMoveHorizontalEffect);
            panel5.Controls.Add(cbToggleZoomEffect);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(comboPanEffects);
            panel5.Controls.Add(comboZoomEffects);
            panel5.Controls.Add(btnRestoreDefaults);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(inputPanAmountValue);
            panel5.Controls.Add(inputZoomAmountValue);
            panel5.Controls.Add(cbKenBurnsEffect);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label6);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 384);
            panel5.Name = "panel5";
            panel5.Size = new Size(507, 209);
            panel5.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(3, 158);
            label4.Name = "label4";
            label4.Size = new Size(84, 15);
            label4.TabIndex = 27;
            label4.Text = "Toggle effects:";
            // 
            // cbToggleMoveVerticalEffect
            // 
            cbToggleMoveVerticalEffect.AutoSize = true;
            cbToggleMoveVerticalEffect.Location = new Point(188, 176);
            cbToggleMoveVerticalEffect.Name = "cbToggleMoveVerticalEffect";
            cbToggleMoveVerticalEffect.Size = new Size(97, 19);
            cbToggleMoveVerticalEffect.TabIndex = 26;
            cbToggleMoveVerticalEffect.Text = "Move vertical";
            cbToggleMoveVerticalEffect.UseVisualStyleBackColor = true;
            // 
            // cbToggleMoveHorizontalEffect
            // 
            cbToggleMoveHorizontalEffect.AutoSize = true;
            cbToggleMoveHorizontalEffect.Location = new Point(70, 176);
            cbToggleMoveHorizontalEffect.Name = "cbToggleMoveHorizontalEffect";
            cbToggleMoveHorizontalEffect.Size = new Size(112, 19);
            cbToggleMoveHorizontalEffect.TabIndex = 25;
            cbToggleMoveHorizontalEffect.Text = "Move horizontal";
            cbToggleMoveHorizontalEffect.UseVisualStyleBackColor = true;
            // 
            // cbToggleZoomEffect
            // 
            cbToggleZoomEffect.AutoSize = true;
            cbToggleZoomEffect.Location = new Point(6, 176);
            cbToggleZoomEffect.Name = "cbToggleZoomEffect";
            cbToggleZoomEffect.Size = new Size(58, 19);
            cbToggleZoomEffect.TabIndex = 24;
            cbToggleZoomEffect.Text = "Zoom";
            cbToggleZoomEffect.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(184, 131);
            label12.Name = "label12";
            label12.Size = new Size(97, 15);
            label12.TabIndex = 23;
            label12.Text = "Move animation:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(184, 100);
            label11.Name = "label11";
            label11.Size = new Size(99, 15);
            label11.TabIndex = 22;
            label11.Text = "Zoom animation:";
            // 
            // comboPanEffects
            // 
            comboPanEffects.BackColor = Color.LightPink;
            comboPanEffects.DrawMode = DrawMode.OwnerDrawFixed;
            comboPanEffects.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPanEffects.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboPanEffects.FormattingEnabled = true;
            comboPanEffects.ItemHeight = 16;
            comboPanEffects.Location = new Point(289, 129);
            comboPanEffects.Name = "comboPanEffects";
            comboPanEffects.Size = new Size(121, 22);
            comboPanEffects.TabIndex = 21;
            // 
            // comboZoomEffects
            // 
            comboZoomEffects.BackColor = Color.LightPink;
            comboZoomEffects.DrawMode = DrawMode.OwnerDrawFixed;
            comboZoomEffects.DropDownStyle = ComboBoxStyle.DropDownList;
            comboZoomEffects.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            comboZoomEffects.FormattingEnabled = true;
            comboZoomEffects.ItemHeight = 16;
            comboZoomEffects.Location = new Point(289, 98);
            comboZoomEffects.Name = "comboZoomEffects";
            comboZoomEffects.Size = new Size(121, 22);
            comboZoomEffects.TabIndex = 20;
            // 
            // btnRestoreDefaults
            // 
            btnRestoreDefaults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRestoreDefaults.BackColor = Color.LightPink;
            btnRestoreDefaults.FlatAppearance.BorderSize = 0;
            btnRestoreDefaults.FlatStyle = FlatStyle.Flat;
            btnRestoreDefaults.Location = new Point(384, 176);
            btnRestoreDefaults.Name = "btnRestoreDefaults";
            btnRestoreDefaults.Size = new Size(120, 30);
            btnRestoreDefaults.TabIndex = 19;
            btnRestoreDefaults.Text = "Restore defaults";
            btnRestoreDefaults.UseVisualStyleBackColor = false;
            btnRestoreDefaults.Click += btnRestoreDefaults_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 131);
            label10.Margin = new Padding(3, 3, 3, 0);
            label10.Name = "label10";
            label10.Size = new Size(87, 15);
            label10.TabIndex = 18;
            label10.Text = "Move strength:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 100);
            label9.Margin = new Padding(3, 0, 3, 3);
            label9.Name = "label9";
            label9.Size = new Size(89, 15);
            label9.TabIndex = 17;
            label9.Text = "Zoom strength:";
            // 
            // inputPanAmountValue
            // 
            inputPanAmountValue.Location = new Point(101, 131);
            inputPanAmountValue.Maximum = 9;
            inputPanAmountValue.Minimum = 1;
            inputPanAmountValue.Name = "inputPanAmountValue";
            inputPanAmountValue.Size = new Size(76, 19);
            inputPanAmountValue.TabIndex = 16;
            inputPanAmountValue.Text = "customNumericUpDown2";
            inputPanAmountValue.Value = 2;
            // 
            // inputZoomAmountValue
            // 
            inputZoomAmountValue.Location = new Point(101, 100);
            inputZoomAmountValue.Maximum = 9;
            inputZoomAmountValue.Minimum = 1;
            inputZoomAmountValue.Name = "inputZoomAmountValue";
            inputZoomAmountValue.Size = new Size(76, 19);
            inputZoomAmountValue.TabIndex = 15;
            inputZoomAmountValue.Text = "customNumericUpDown1";
            inputZoomAmountValue.Value = 5;
            // 
            // cbKenBurnsEffect
            // 
            cbKenBurnsEffect.Dock = DockStyle.Top;
            cbKenBurnsEffect.Location = new Point(0, 67);
            cbKenBurnsEffect.Name = "cbKenBurnsEffect";
            cbKenBurnsEffect.Padding = new Padding(6, 0, 0, 0);
            cbKenBurnsEffect.Size = new Size(507, 26);
            cbKenBurnsEffect.TabIndex = 13;
            cbKenBurnsEffect.Text = "Enable effect";
            cbKenBurnsEffect.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Top;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(0, 19);
            label8.Name = "label8";
            label8.Padding = new Padding(6, 0, 0, 0);
            label8.Size = new Size(507, 48);
            label8.TabIndex = 14;
            label8.Text = "Activates random movements when playing images. Uses the automatic timer for duration (Best result 6-8 sec.).\r\nYou can fine adjust the values, though the outcome might not be great. ";
            // 
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(6, 0, 0, 0);
            label6.Size = new Size(507, 19);
            label6.TabIndex = 0;
            label6.Text = "(Experimental) Ken Burns effect - for static images";
            // 
            // cbReshuffle
            // 
            cbReshuffle.AutoSize = true;
            cbReshuffle.Location = new Point(119, 29);
            cbReshuffle.Name = "cbReshuffle";
            cbReshuffle.Padding = new Padding(6, 0, 0, 0);
            cbReshuffle.Size = new Size(196, 19);
            cbReshuffle.TabIndex = 13;
            cbReshuffle.Text = "Re-shuffle after playlist finishes";
            cbReshuffle.UseVisualStyleBackColor = true;
            // 
            // PlayerUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PlayerUserControl";
            Size = new Size(507, 593);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel1;
        private RadioButton rbDateModified;
        private RadioButton rbDateCreated;
        private Label label3;
        private CheckBox cbShufflePlayer;
        private Panel panel2;
        private CheckBox cbLeftMousePause;
        private Label label7;
        private Panel panel3;
        private RadioButton rbAutoTimer;
        private RadioButton rbAutoNext;
        private RadioButton rbRepeatVideo;
        private NumericUpDown timerValueInput;
        private Label lblBetweenTime;
        private Panel panel4;
        private Label label5;
        private Controls.CustomNumericUpDown inputTimerValueStartPoint;
        private Panel panel5;
        private CheckBox cbKenBurnsEffect;
        private Label label6;
        private Label label8;
        private Button btnRestoreDefaults;
        private Label label10;
        private Label label9;
        private Controls.CustomNumericUpDown inputPanAmountValue;
        private Controls.CustomNumericUpDown inputZoomAmountValue;
        private Controls.ButtonComboBox comboZoomEffects;
        private Controls.ButtonComboBox comboPanEffects;
        private Label label12;
        private Label label11;
        private Controls.CustomNumericUpDown inputTimerValueEndPoint;
        private CheckBox cbEnableTimeRange;
        private Label lblAfterTime;
        private CheckBox cbToggleMoveVerticalEffect;
        private CheckBox cbToggleMoveHorizontalEffect;
        private CheckBox cbToggleZoomEffect;
        private Label label4;
        private CheckBox cbReshuffle;
    }
}
