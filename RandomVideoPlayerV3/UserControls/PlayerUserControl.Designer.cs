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
            cbLeftMousePause = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl1 = new Label();
            panel3 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel9 = new Panel();
            label10 = new Label();
            inputVideoThreshold = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label9 = new Label();
            panel8 = new Panel();
            label8 = new Label();
            inputSBL = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label7 = new Label();
            panel7 = new Panel();
            label6 = new Label();
            inputSBS = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label5 = new Label();
            panel6 = new Panel();
            label4 = new Label();
            inputSFL = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label3 = new Label();
            label1 = new Label();
            panel5 = new Panel();
            label2 = new Label();
            inputSFS = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label11 = new Label();
            lbl7 = new Label();
            cbEnableTimeRange = new RandomVideoPlayer.Controls.CustomCheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            rbAutoTimer = new RandomVideoPlayer.Controls.CustomRadioButton();
            inputTimerValueStartPoint = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            lblBetweenTime = new Label();
            inputTimerValueEndPoint = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            lblAfterTime = new Label();
            rbAutoNext = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbRepeatVideo = new RandomVideoPlayer.Controls.CustomRadioButton();
            panel4 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            cbShufflePlayer = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbReshuffle = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl3 = new Label();
            panel1 = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            lbl5 = new Label();
            btnRTXHelp = new FontAwesome.Sharp.IconButton();
            cbEnableRTXVSR = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl4 = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
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
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
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
            lbl2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
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
            lbl1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
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
            panel3.Controls.Add(tableLayoutPanel1);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(lbl7);
            panel3.Controls.Add(cbEnableTimeRange);
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Controls.Add(rbAutoNext);
            panel3.Controls.Add(rbRepeatVideo);
            panel3.Controls.Add(lbl2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 110);
            panel3.Name = "panel3";
            panel3.Size = new Size(507, 284);
            panel3.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.Controls.Add(panel9, 1, 4);
            tableLayoutPanel1.Controls.Add(label9, 0, 4);
            tableLayoutPanel1.Controls.Add(panel8, 1, 3);
            tableLayoutPanel1.Controls.Add(label7, 0, 3);
            tableLayoutPanel1.Controls.Add(panel7, 1, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(panel6, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel5, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 153);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(507, 125);
            tableLayoutPanel1.TabIndex = 24;
            // 
            // panel9
            // 
            panel9.Controls.Add(label10);
            panel9.Controls.Add(inputVideoThreshold);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(177, 103);
            panel9.Margin = new Padding(0, 3, 0, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(330, 19);
            panel9.TabIndex = 29;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Left;
            label10.Location = new Point(75, 0);
            label10.Name = "label10";
            label10.Padding = new Padding(2, 1, 0, 0);
            label10.Size = new Size(76, 19);
            label10.TabIndex = 20;
            label10.Text = "minutes";
            // 
            // inputVideoThreshold
            // 
            inputVideoThreshold.Dock = DockStyle.Left;
            inputVideoThreshold.Location = new Point(0, 0);
            inputVideoThreshold.Margin = new Padding(0);
            inputVideoThreshold.Maximum = 120;
            inputVideoThreshold.Minimum = 1;
            inputVideoThreshold.Name = "inputVideoThreshold";
            inputVideoThreshold.Size = new Size(75, 19);
            inputVideoThreshold.TabIndex = 19;
            inputVideoThreshold.Text = "customNumericUpDown5";
            inputVideoThreshold.Value = 15;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(0, 100);
            label9.Margin = new Padding(0);
            label9.Name = "label9";
            label9.Padding = new Padding(18, 4, 0, 0);
            label9.Size = new Size(177, 25);
            label9.TabIndex = 28;
            label9.Text = "Video length threshold";
            // 
            // panel8
            // 
            panel8.Controls.Add(label8);
            panel8.Controls.Add(inputSBL);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(177, 78);
            panel8.Margin = new Padding(0, 3, 0, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(330, 19);
            panel8.TabIndex = 27;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Left;
            label8.Location = new Point(75, 0);
            label8.Name = "label8";
            label8.Padding = new Padding(2, 1, 0, 0);
            label8.Size = new Size(76, 19);
            label8.TabIndex = 20;
            label8.Text = "seconds";
            // 
            // inputSBL
            // 
            inputSBL.Dock = DockStyle.Left;
            inputSBL.Location = new Point(0, 0);
            inputSBL.Margin = new Padding(0);
            inputSBL.Maximum = 100;
            inputSBL.Minimum = 1;
            inputSBL.Name = "inputSBL";
            inputSBL.Size = new Size(75, 19);
            inputSBL.TabIndex = 19;
            inputSBL.Text = "customNumericUpDown4";
            inputSBL.Value = 15;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(0, 75);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Padding = new Padding(18, 4, 0, 0);
            label7.Size = new Size(177, 25);
            label7.TabIndex = 26;
            label7.Text = "Seek backward long";
            // 
            // panel7
            // 
            panel7.Controls.Add(label6);
            panel7.Controls.Add(inputSBS);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(177, 53);
            panel7.Margin = new Padding(0, 3, 0, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(330, 19);
            panel7.TabIndex = 25;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Left;
            label6.Location = new Point(75, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(2, 1, 0, 0);
            label6.Size = new Size(76, 19);
            label6.TabIndex = 20;
            label6.Text = "seconds";
            // 
            // inputSBS
            // 
            inputSBS.Dock = DockStyle.Left;
            inputSBS.Location = new Point(0, 0);
            inputSBS.Margin = new Padding(0);
            inputSBS.Maximum = 100;
            inputSBS.Minimum = 1;
            inputSBS.Name = "inputSBS";
            inputSBS.Size = new Size(75, 19);
            inputSBS.TabIndex = 19;
            inputSBS.Text = "customNumericUpDown3";
            inputSBS.Value = 15;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(0, 50);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(18, 4, 0, 0);
            label5.Size = new Size(177, 25);
            label5.TabIndex = 24;
            label5.Text = "Seek backward short";
            // 
            // panel6
            // 
            panel6.Controls.Add(label4);
            panel6.Controls.Add(inputSFL);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(177, 28);
            panel6.Margin = new Padding(0, 3, 0, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(330, 19);
            panel6.TabIndex = 23;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Location = new Point(75, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(2, 1, 0, 0);
            label4.Size = new Size(76, 19);
            label4.TabIndex = 20;
            label4.Text = "seconds";
            // 
            // inputSFL
            // 
            inputSFL.Dock = DockStyle.Left;
            inputSFL.Location = new Point(0, 0);
            inputSFL.Margin = new Padding(0);
            inputSFL.Maximum = 100;
            inputSFL.Minimum = 1;
            inputSFL.Name = "inputSFL";
            inputSFL.Size = new Size(75, 19);
            inputSFL.TabIndex = 19;
            inputSFL.Text = "customNumericUpDown2";
            inputSFL.Value = 15;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(0, 25);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Padding = new Padding(18, 4, 0, 0);
            label3.Size = new Size(177, 25);
            label3.TabIndex = 22;
            label3.Text = "Seek forward long";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(18, 4, 0, 0);
            label1.Size = new Size(177, 25);
            label1.TabIndex = 0;
            label1.Text = "Seek forward short";
            // 
            // panel5
            // 
            panel5.Controls.Add(label2);
            panel5.Controls.Add(inputSFS);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(177, 3);
            panel5.Margin = new Padding(0, 3, 0, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(330, 19);
            panel5.TabIndex = 21;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Location = new Point(75, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(2, 1, 0, 0);
            label2.Size = new Size(76, 19);
            label2.TabIndex = 20;
            label2.Text = "seconds";
            // 
            // inputSFS
            // 
            inputSFS.Dock = DockStyle.Left;
            inputSFS.Location = new Point(0, 0);
            inputSFS.Margin = new Padding(0);
            inputSFS.Maximum = 100;
            inputSFS.Minimum = 1;
            inputSFS.Name = "inputSFS";
            inputSFS.Size = new Size(75, 19);
            inputSFS.TabIndex = 19;
            inputSFS.Text = "customNumericUpDown1";
            inputSFS.Value = 15;
            // 
            // label11
            // 
            label11.Dock = DockStyle.Top;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(0, 128);
            label11.Name = "label11";
            label11.Padding = new Padding(8, 5, 0, 0);
            label11.Size = new Size(507, 25);
            label11.TabIndex = 25;
            label11.Text = "Short = Videos under threshold, Long = Videos over threshold";
            // 
            // lbl7
            // 
            lbl7.Dock = DockStyle.Top;
            lbl7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl7.Location = new Point(0, 106);
            lbl7.Name = "lbl7";
            lbl7.Padding = new Padding(6, 5, 0, 0);
            lbl7.Size = new Size(507, 22);
            lbl7.TabIndex = 23;
            lbl7.Text = "Change seek length:";
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
            inputTimerValueStartPoint.Size = new Size(75, 19);
            inputTimerValueStartPoint.TabIndex = 18;
            inputTimerValueStartPoint.Text = "customNumericUpDown1";
            inputTimerValueStartPoint.Value = 15;
            // 
            // lblBetweenTime
            // 
            lblBetweenTime.AutoSize = true;
            lblBetweenTime.Location = new Point(287, 1);
            lblBetweenTime.Margin = new Padding(3, 1, 3, 3);
            lblBetweenTime.Name = "lblBetweenTime";
            lblBetweenTime.Size = new Size(50, 15);
            lblBetweenTime.TabIndex = 17;
            lblBetweenTime.Text = "seconds";
            lblBetweenTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // inputTimerValueEndPoint
            // 
            inputTimerValueEndPoint.Location = new Point(343, 0);
            inputTimerValueEndPoint.Margin = new Padding(3, 0, 3, 3);
            inputTimerValueEndPoint.Maximum = 101;
            inputTimerValueEndPoint.Minimum = 4;
            inputTimerValueEndPoint.Name = "inputTimerValueEndPoint";
            inputTimerValueEndPoint.Size = new Size(75, 19);
            inputTimerValueEndPoint.TabIndex = 19;
            inputTimerValueEndPoint.Text = "customNumericUpDown1";
            inputTimerValueEndPoint.Value = 15;
            // 
            // lblAfterTime
            // 
            lblAfterTime.AutoSize = true;
            lblAfterTime.Location = new Point(424, 1);
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
            panel4.Location = new Point(0, 394);
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
            lbl3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
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
            panel1.Location = new Point(0, 454);
            panel1.Margin = new Padding(3, 6, 3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(507, 87);
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
            lbl4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
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
            tableLayoutPanel1.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
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
        private Label lbl7;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Panel panel5;
        private Controls.CustomNumericUpDown inputSFS;
        private Label label2;
        private Panel panel9;
        private Label label10;
        private Controls.CustomNumericUpDown inputVideoThreshold;
        private Label label9;
        private Panel panel8;
        private Label label8;
        private Controls.CustomNumericUpDown inputSBL;
        private Label label7;
        private Panel panel7;
        private Label label6;
        private Controls.CustomNumericUpDown inputSBS;
        private Label label5;
        private Panel panel6;
        private Label label4;
        private Controls.CustomNumericUpDown inputSFL;
        private Label label3;
        private Label label11;
    }
}
