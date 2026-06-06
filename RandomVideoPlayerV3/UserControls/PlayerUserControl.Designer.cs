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
            tableLayoutPanelMain = new TableLayoutPanel();
            lblHeader = new Label();
            panel1 = new Panel();
            cbLeftMousePause = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl1 = new Label();
            panel2 = new Panel();
            rbAutoNext = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbRepeatVideo = new RandomVideoPlayer.Controls.CustomRadioButton();
            lbl2 = new Label();
            panel3 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label10 = new Label();
            inputVideoThreshold = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label9 = new Label();
            label8 = new Label();
            inputSBL = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label7 = new Label();
            label6 = new Label();
            inputSBS = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label5 = new Label();
            label4 = new Label();
            inputSFL = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label3 = new Label();
            label2 = new Label();
            inputSFS = new RandomVideoPlayer.Controls.CustomNumericUpDown();
            label1 = new Label();
            label11 = new Label();
            lbl7 = new Label();
            panel4 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            cbReshuffle = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbShufflePlayer = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl3 = new Label();
            panel5 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnRTXHelp = new FontAwesome.Sharp.IconButton();
            lbl5 = new Label();
            cbEnableRTXVSR = new RandomVideoPlayer.Controls.CustomCheckBox();
            lbl4 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label12 = new Label();
            btnLogLevel = new FontAwesome.Sharp.IconButton();
            tableLayoutPanelMain.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.BackColor = Color.Lavender;
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutPanelMain.Controls.Add(panel1, 0, 1);
            tableLayoutPanelMain.Controls.Add(panel2, 0, 2);
            tableLayoutPanelMain.Controls.Add(panel3, 0, 3);
            tableLayoutPanelMain.Controls.Add(panel4, 0, 4);
            tableLayoutPanelMain.Controls.Add(panel5, 0, 5);
            tableLayoutPanelMain.Controls.Add(flowLayoutPanel1, 0, 6);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 7;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
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
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 17;
            lblHeader.Text = "Player";
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(cbLeftMousePause);
            panel1.Controls.Add(lbl1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 60);
            panel1.TabIndex = 18;
            // 
            // cbLeftMousePause
            // 
            cbLeftMousePause.AutoSize = true;
            cbLeftMousePause.BoxSize = 13;
            cbLeftMousePause.Dock = DockStyle.Top;
            cbLeftMousePause.HoverColor = Color.DeepSkyBlue;
            cbLeftMousePause.Location = new Point(0, 24);
            cbLeftMousePause.Name = "cbLeftMousePause";
            cbLeftMousePause.PaddingLeft = 12;
            cbLeftMousePause.Size = new Size(518, 19);
            cbLeftMousePause.TabIndex = 20;
            cbLeftMousePause.Text = "Play/Pause on left mouse click";
            cbLeftMousePause.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            lbl1.Dock = DockStyle.Top;
            lbl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl1.Location = new Point(0, 0);
            lbl1.Margin = new Padding(0);
            lbl1.Name = "lbl1";
            lbl1.Size = new Size(518, 24);
            lbl1.TabIndex = 1;
            lbl1.Text = "Check to enable/disable Play/Pause with left mouse click on the player";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Thistle;
            panel2.Controls.Add(rbAutoNext);
            panel2.Controls.Add(rbRepeatVideo);
            panel2.Controls.Add(lbl2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 129);
            panel2.Name = "panel2";
            panel2.Size = new Size(518, 71);
            panel2.TabIndex = 19;
            // 
            // rbAutoNext
            // 
            rbAutoNext.CircleSize = 12;
            rbAutoNext.Dock = DockStyle.Top;
            rbAutoNext.HoverColor = Color.DeepSkyBlue;
            rbAutoNext.Location = new Point(0, 43);
            rbAutoNext.Name = "rbAutoNext";
            rbAutoNext.PaddingLeft = 9;
            rbAutoNext.Size = new Size(518, 19);
            rbAutoNext.TabIndex = 18;
            rbAutoNext.TabStop = true;
            rbAutoNext.Text = "Automatic next (After video finishes)";
            rbAutoNext.UseVisualStyleBackColor = true;
            // 
            // rbRepeatVideo
            // 
            rbRepeatVideo.CircleSize = 12;
            rbRepeatVideo.Dock = DockStyle.Top;
            rbRepeatVideo.HoverColor = Color.DeepSkyBlue;
            rbRepeatVideo.Location = new Point(0, 24);
            rbRepeatVideo.Name = "rbRepeatVideo";
            rbRepeatVideo.PaddingLeft = 9;
            rbRepeatVideo.Size = new Size(518, 19);
            rbRepeatVideo.TabIndex = 17;
            rbRepeatVideo.TabStop = true;
            rbRepeatVideo.Text = "Repeat video";
            rbRepeatVideo.UseVisualStyleBackColor = true;
            // 
            // lbl2
            // 
            lbl2.Dock = DockStyle.Top;
            lbl2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl2.Location = new Point(0, 0);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(518, 24);
            lbl2.TabIndex = 4;
            lbl2.Text = "Switch playback behavior";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Pink;
            panel3.Controls.Add(tableLayoutPanel2);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(lbl7);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 206);
            panel3.Name = "panel3";
            panel3.Size = new Size(518, 173);
            panel3.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Fuchsia;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(label10, 2, 4);
            tableLayoutPanel2.Controls.Add(inputVideoThreshold, 1, 4);
            tableLayoutPanel2.Controls.Add(label9, 0, 4);
            tableLayoutPanel2.Controls.Add(label8, 2, 3);
            tableLayoutPanel2.Controls.Add(inputSBL, 1, 3);
            tableLayoutPanel2.Controls.Add(label7, 0, 3);
            tableLayoutPanel2.Controls.Add(label6, 2, 2);
            tableLayoutPanel2.Controls.Add(inputSBS, 1, 2);
            tableLayoutPanel2.Controls.Add(label5, 0, 2);
            tableLayoutPanel2.Controls.Add(label4, 2, 1);
            tableLayoutPanel2.Controls.Add(inputSFL, 1, 1);
            tableLayoutPanel2.Controls.Add(label3, 0, 1);
            tableLayoutPanel2.Controls.Add(label2, 2, 0);
            tableLayoutPanel2.Controls.Add(inputSFS, 1, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 48);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(518, 117);
            tableLayoutPanel2.TabIndex = 27;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Left;
            label10.Location = new Point(323, 94);
            label10.Margin = new Padding(3, 2, 3, 0);
            label10.Name = "label10";
            label10.Padding = new Padding(2, 1, 0, 0);
            label10.Size = new Size(76, 23);
            label10.TabIndex = 34;
            label10.Text = "minutes";
            // 
            // inputVideoThreshold
            // 
            inputVideoThreshold.BackColor = SystemColors.Window;
            inputVideoThreshold.Dock = DockStyle.Left;
            inputVideoThreshold.ForeColor = SystemColors.WindowText;
            inputVideoThreshold.IconColor = Color.Indigo;
            inputVideoThreshold.Location = new Point(245, 94);
            inputVideoThreshold.Margin = new Padding(0, 2, 0, 2);
            inputVideoThreshold.Maximum = 120;
            inputVideoThreshold.Minimum = 10;
            inputVideoThreshold.Name = "inputVideoThreshold";
            inputVideoThreshold.Size = new Size(75, 21);
            inputVideoThreshold.TabIndex = 33;
            inputVideoThreshold.Text = "customNumericUpDown5";
            inputVideoThreshold.Value = 15;
            // 
            // label9
            // 
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(0, 92);
            label9.Margin = new Padding(0);
            label9.Name = "label9";
            label9.Padding = new Padding(18, 4, 0, 0);
            label9.Size = new Size(245, 25);
            label9.TabIndex = 32;
            label9.Text = "Video length threshold";
            // 
            // label8
            // 
            label8.Dock = DockStyle.Left;
            label8.Location = new Point(323, 71);
            label8.Margin = new Padding(3, 2, 3, 0);
            label8.Name = "label8";
            label8.Padding = new Padding(2, 1, 0, 0);
            label8.Size = new Size(76, 21);
            label8.TabIndex = 31;
            label8.Text = "seconds";
            // 
            // inputSBL
            // 
            inputSBL.BackColor = SystemColors.Window;
            inputSBL.Dock = DockStyle.Left;
            inputSBL.ForeColor = SystemColors.WindowText;
            inputSBL.IconColor = Color.Indigo;
            inputSBL.Location = new Point(245, 71);
            inputSBL.Margin = new Padding(0, 2, 0, 2);
            inputSBL.Maximum = 100;
            inputSBL.Minimum = 1;
            inputSBL.Name = "inputSBL";
            inputSBL.Size = new Size(75, 19);
            inputSBL.TabIndex = 30;
            inputSBL.Text = "customNumericUpDown4";
            inputSBL.Value = 15;
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(0, 69);
            label7.Margin = new Padding(0);
            label7.Name = "label7";
            label7.Padding = new Padding(18, 4, 0, 0);
            label7.Size = new Size(245, 23);
            label7.TabIndex = 29;
            label7.Text = "Seek backward long";
            // 
            // label6
            // 
            label6.Dock = DockStyle.Left;
            label6.Location = new Point(323, 48);
            label6.Margin = new Padding(3, 2, 3, 0);
            label6.Name = "label6";
            label6.Padding = new Padding(2, 1, 0, 0);
            label6.Size = new Size(76, 21);
            label6.TabIndex = 28;
            label6.Text = "seconds";
            // 
            // inputSBS
            // 
            inputSBS.BackColor = SystemColors.Window;
            inputSBS.Dock = DockStyle.Left;
            inputSBS.ForeColor = SystemColors.WindowText;
            inputSBS.IconColor = Color.Indigo;
            inputSBS.Location = new Point(245, 48);
            inputSBS.Margin = new Padding(0, 2, 0, 2);
            inputSBS.Maximum = 100;
            inputSBS.Minimum = 1;
            inputSBS.Name = "inputSBS";
            inputSBS.Size = new Size(75, 19);
            inputSBS.TabIndex = 27;
            inputSBS.Text = "customNumericUpDown3";
            inputSBS.Value = 15;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(0, 46);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Padding = new Padding(18, 4, 0, 0);
            label5.Size = new Size(245, 23);
            label5.TabIndex = 26;
            label5.Text = "Seek backward short";
            // 
            // label4
            // 
            label4.Dock = DockStyle.Left;
            label4.Location = new Point(323, 25);
            label4.Margin = new Padding(3, 2, 3, 0);
            label4.Name = "label4";
            label4.Padding = new Padding(2, 1, 0, 0);
            label4.Size = new Size(76, 21);
            label4.TabIndex = 25;
            label4.Text = "seconds";
            // 
            // inputSFL
            // 
            inputSFL.BackColor = SystemColors.Window;
            inputSFL.Dock = DockStyle.Left;
            inputSFL.ForeColor = SystemColors.WindowText;
            inputSFL.IconColor = Color.Indigo;
            inputSFL.Location = new Point(245, 25);
            inputSFL.Margin = new Padding(0, 2, 0, 2);
            inputSFL.Maximum = 100;
            inputSFL.Minimum = 1;
            inputSFL.Name = "inputSFL";
            inputSFL.Size = new Size(75, 19);
            inputSFL.TabIndex = 24;
            inputSFL.Text = "customNumericUpDown2";
            inputSFL.Value = 15;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(0, 23);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Padding = new Padding(18, 4, 0, 0);
            label3.Size = new Size(245, 23);
            label3.TabIndex = 23;
            label3.Text = "Seek forward long";
            // 
            // label2
            // 
            label2.Dock = DockStyle.Left;
            label2.Location = new Point(323, 2);
            label2.Margin = new Padding(3, 2, 3, 0);
            label2.Name = "label2";
            label2.Padding = new Padding(2, 1, 0, 0);
            label2.Size = new Size(76, 21);
            label2.TabIndex = 21;
            label2.Text = "seconds";
            // 
            // inputSFS
            // 
            inputSFS.BackColor = Color.Purple;
            inputSFS.Dock = DockStyle.Left;
            inputSFS.ForeColor = SystemColors.WindowText;
            inputSFS.IconColor = Color.Indigo;
            inputSFS.Location = new Point(245, 2);
            inputSFS.Margin = new Padding(0, 2, 0, 2);
            inputSFS.Maximum = 100;
            inputSFS.Minimum = 1;
            inputSFS.Name = "inputSFS";
            inputSFS.Size = new Size(75, 19);
            inputSFS.TabIndex = 20;
            inputSFS.Text = "customNumericUpDown1";
            inputSFS.Value = 15;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(18, 4, 0, 0);
            label1.Size = new Size(245, 23);
            label1.TabIndex = 1;
            label1.Text = "Seek forward short";
            // 
            // label11
            // 
            label11.Dock = DockStyle.Top;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(0, 24);
            label11.Name = "label11";
            label11.Padding = new Padding(8, 5, 0, 0);
            label11.Size = new Size(518, 24);
            label11.TabIndex = 26;
            label11.Text = "Short = Videos under threshold, Long = Videos over threshold";
            // 
            // lbl7
            // 
            lbl7.Dock = DockStyle.Top;
            lbl7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl7.Location = new Point(0, 0);
            lbl7.Name = "lbl7";
            lbl7.Size = new Size(518, 24);
            lbl7.TabIndex = 24;
            lbl7.Text = "Change seek length:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.PowderBlue;
            panel4.Controls.Add(tableLayoutPanel3);
            panel4.Controls.Add(lbl3);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 385);
            panel4.Name = "panel4";
            panel4.Size = new Size(518, 70);
            panel4.TabIndex = 21;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.LightCyan;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(cbReshuffle, 1, 0);
            tableLayoutPanel3.Controls.Add(cbShufflePlayer, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Top;
            tableLayoutPanel3.Location = new Point(0, 24);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(518, 31);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // cbReshuffle
            // 
            cbReshuffle.BoxSize = 13;
            cbReshuffle.Dock = DockStyle.Top;
            cbReshuffle.HoverColor = Color.DeepSkyBlue;
            cbReshuffle.Location = new Point(172, 3);
            cbReshuffle.Name = "cbReshuffle";
            cbReshuffle.PaddingLeft = 6;
            cbReshuffle.Size = new Size(343, 19);
            cbReshuffle.TabIndex = 23;
            cbReshuffle.Text = "Re-shuffle after playlist finishes";
            cbReshuffle.UseVisualStyleBackColor = true;
            // 
            // cbShufflePlayer
            // 
            cbShufflePlayer.BoxSize = 13;
            cbShufflePlayer.Dock = DockStyle.Top;
            cbShufflePlayer.HoverColor = Color.DeepSkyBlue;
            cbShufflePlayer.Location = new Point(0, 3);
            cbShufflePlayer.Margin = new Padding(0, 3, 3, 3);
            cbShufflePlayer.Name = "cbShufflePlayer";
            cbShufflePlayer.PaddingLeft = 9;
            cbShufflePlayer.Size = new Size(166, 19);
            cbShufflePlayer.TabIndex = 22;
            cbShufflePlayer.Text = "Shuffle Playlist";
            cbShufflePlayer.UseVisualStyleBackColor = true;
            // 
            // lbl3
            // 
            lbl3.Dock = DockStyle.Top;
            lbl3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl3.Location = new Point(0, 0);
            lbl3.Name = "lbl3";
            lbl3.Size = new Size(518, 24);
            lbl3.TabIndex = 1;
            lbl3.Text = "Toggle between random playback or simply parsing in order";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Beige;
            panel5.Controls.Add(tableLayoutPanel4);
            panel5.Controls.Add(cbEnableRTXVSR);
            panel5.Controls.Add(lbl4);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 461);
            panel5.Name = "panel5";
            panel5.Size = new Size(518, 95);
            panel5.TabIndex = 22;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.PapayaWhip;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.Controls.Add(btnRTXHelp, 1, 0);
            tableLayoutPanel4.Controls.Add(lbl5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Top;
            tableLayoutPanel4.Location = new Point(0, 42);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(518, 30);
            tableLayoutPanel4.TabIndex = 25;
            // 
            // btnRTXHelp
            // 
            btnRTXHelp.Dock = DockStyle.Left;
            btnRTXHelp.FlatAppearance.BorderSize = 0;
            btnRTXHelp.FlatStyle = FlatStyle.Flat;
            btnRTXHelp.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            btnRTXHelp.IconColor = Color.Blue;
            btnRTXHelp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRTXHelp.IconSize = 23;
            btnRTXHelp.Location = new Point(301, 3);
            btnRTXHelp.Name = "btnRTXHelp";
            btnRTXHelp.Size = new Size(23, 24);
            btnRTXHelp.TabIndex = 5;
            btnRTXHelp.UseVisualStyleBackColor = true;
            // 
            // lbl5
            // 
            lbl5.Dock = DockStyle.Fill;
            lbl5.Location = new Point(3, 3);
            lbl5.Margin = new Padding(3);
            lbl5.Name = "lbl5";
            lbl5.Size = new Size(292, 24);
            lbl5.TabIndex = 4;
            lbl5.Text = "Needs to be enabled in Nvidia driver settings, see:";
            lbl5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbEnableRTXVSR
            // 
            cbEnableRTXVSR.BoxSize = 13;
            cbEnableRTXVSR.Dock = DockStyle.Top;
            cbEnableRTXVSR.HoverColor = Color.DeepSkyBlue;
            cbEnableRTXVSR.Location = new Point(0, 23);
            cbEnableRTXVSR.Name = "cbEnableRTXVSR";
            cbEnableRTXVSR.PaddingLeft = 9;
            cbEnableRTXVSR.Size = new Size(518, 19);
            cbEnableRTXVSR.TabIndex = 24;
            cbEnableRTXVSR.Text = "Enable RTX VSR";
            cbEnableRTXVSR.UseVisualStyleBackColor = true;
            // 
            // lbl4
            // 
            lbl4.Dock = DockStyle.Top;
            lbl4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl4.Location = new Point(0, 0);
            lbl4.Name = "lbl4";
            lbl4.Size = new Size(518, 23);
            lbl4.TabIndex = 2;
            lbl4.Text = "Activate RTX VSR compatibility (Nvidia only)";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.DodgerBlue;
            flowLayoutPanel1.Controls.Add(label12);
            flowLayoutPanel1.Controls.Add(btnLogLevel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 562);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(518, 91);
            flowLayoutPanel1.TabIndex = 23;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(3, 0);
            label12.Name = "label12";
            label12.Size = new Size(254, 15);
            label12.TabIndex = 3;
            label12.Text = "Choose minimum log level to log in Error.log:";
            // 
            // btnLogLevel
            // 
            btnLogLevel.BackColor = Color.LightSteelBlue;
            btnLogLevel.FlatAppearance.BorderSize = 0;
            btnLogLevel.FlatStyle = FlatStyle.Flat;
            btnLogLevel.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            btnLogLevel.IconColor = Color.Black;
            btnLogLevel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLogLevel.IconSize = 20;
            btnLogLevel.ImageAlign = ContentAlignment.MiddleRight;
            btnLogLevel.Location = new Point(6, 21);
            btnLogLevel.Margin = new Padding(6);
            btnLogLevel.Name = "btnLogLevel";
            btnLogLevel.Size = new Size(170, 24);
            btnLogLevel.TabIndex = 25;
            btnLogLevel.Text = "Error";
            btnLogLevel.TextAlign = ContentAlignment.MiddleLeft;
            btnLogLevel.UseVisualStyleBackColor = false;
            // 
            // PlayerUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(tableLayoutPanelMain);
            Name = "PlayerUserControl";
            Size = new Size(524, 656);
            tableLayoutPanelMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private NumericUpDown timerValueInput;
        private TableLayoutPanel tableLayoutPanelMain;
        private Label lblHeader;
        private Panel panel1;
        private Label lbl1;
        private Controls.CustomCheckBox cbLeftMousePause;
        private Panel panel2;
        private Label lbl2;
        private Controls.CustomRadioButton rbRepeatVideo;
        private Controls.CustomRadioButton rbAutoNext;
        private Panel panel3;
        private Label lbl7;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label11;
        private Label label1;
        private Controls.CustomNumericUpDown inputSFS;
        private Label label2;
        private Label label3;
        private Controls.CustomNumericUpDown inputSFL;
        private Label label4;
        private Label label5;
        private Controls.CustomNumericUpDown inputSBS;
        private Label label6;
        private Label label7;
        private Controls.CustomNumericUpDown inputSBL;
        private Label label8;
        private Label label9;
        private Controls.CustomNumericUpDown inputVideoThreshold;
        private Label label10;
        private Panel panel4;
        private Label lbl3;
        private TableLayoutPanel tableLayoutPanel3;
        private Controls.CustomCheckBox cbShufflePlayer;
        private Controls.CustomCheckBox cbReshuffle;
        private Panel panel5;
        private Label lbl4;
        private Controls.CustomCheckBox cbEnableRTXVSR;
        private TableLayoutPanel tableLayoutPanel4;
        private Label lbl5;
        private FontAwesome.Sharp.IconButton btnRTXHelp;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label12;
        private FontAwesome.Sharp.IconButton btnLogLevel;
    }
}
