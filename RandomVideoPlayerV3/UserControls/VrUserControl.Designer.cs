namespace RandomVideoPlayer.UserControls
{
    partial class VrUserControl
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
            tableLayoutConfidenceSlider = new TableLayoutPanel();
            label2 = new Label();
            lblInfoConfidence = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label3 = new Label();
            rbToleranceLow = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbToleranceMed = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbToleranceHigh = new RandomVideoPlayer.Controls.CustomRadioButton();
            label1 = new Label();
            sliderConfidence = new RandomVideoPlayer.Controls.FlatSlider();
            flowLayoutPanel1 = new FlowLayoutPanel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            label5 = new Label();
            flowLayoutPanel5 = new FlowLayoutPanel();
            btnRestoreDefaults = new FontAwesome.Sharp.IconButton();
            btnClearSetups = new FontAwesome.Sharp.IconButton();
            tableLayoutQuality = new TableLayoutPanel();
            label6 = new Label();
            label7 = new Label();
            label4 = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            rbInterpLine = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbInterpCubic = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbInterpLanc = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbInterpSpline = new RandomVideoPlayer.Controls.CustomRadioButton();
            flowLayoutPanel3 = new FlowLayoutPanel();
            rbQualityPerformance = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbQualityBalanced = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbQualityHigh = new RandomVideoPlayer.Controls.CustomRadioButton();
            rbQualityUltra = new RandomVideoPlayer.Controls.CustomRadioButton();
            panel1 = new Panel();
            label14 = new Label();
            tableLayoutTop = new TableLayoutPanel();
            cbEnableAutoDetectDebug = new RandomVideoPlayer.Controls.CustomCheckBox();
            cbToggleDetection = new RandomVideoPlayer.Controls.CustomCheckBox();
            label13 = new Label();
            tableLayoutMain.SuspendLayout();
            tableLayoutConfidenceSlider.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            flowLayoutPanel5.SuspendLayout();
            tableLayoutQuality.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutTop.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.LightCoral;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(tableLayoutConfidenceSlider, 0, 2);
            tableLayoutMain.Controls.Add(flowLayoutPanel5, 0, 6);
            tableLayoutMain.Controls.Add(tableLayoutQuality, 0, 3);
            tableLayoutMain.Controls.Add(panel1, 0, 5);
            tableLayoutMain.Controls.Add(tableLayoutTop, 0, 1);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 7;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 46.6666641F));
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 53.33334F));
            tableLayoutMain.Size = new Size(524, 718);
            tableLayoutMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = SystemColors.Control;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.Indigo;
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(0, 0, 0, 8);
            lblHeader.Size = new Size(518, 60);
            lblHeader.TabIndex = 13;
            lblHeader.Text = "VR";
            // 
            // tableLayoutConfidenceSlider
            // 
            tableLayoutConfidenceSlider.BackColor = Color.YellowGreen;
            tableLayoutConfidenceSlider.ColumnCount = 3;
            tableLayoutConfidenceSlider.ColumnStyles.Add(new ColumnStyle());
            tableLayoutConfidenceSlider.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutConfidenceSlider.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutConfidenceSlider.Controls.Add(label2, 1, 2);
            tableLayoutConfidenceSlider.Controls.Add(lblInfoConfidence, 2, 1);
            tableLayoutConfidenceSlider.Controls.Add(flowLayoutPanel2, 0, 0);
            tableLayoutConfidenceSlider.Controls.Add(label1, 1, 0);
            tableLayoutConfidenceSlider.Controls.Add(sliderConfidence, 1, 1);
            tableLayoutConfidenceSlider.Controls.Add(flowLayoutPanel1, 0, 3);
            tableLayoutConfidenceSlider.Dock = DockStyle.Fill;
            tableLayoutConfidenceSlider.Location = new Point(3, 139);
            tableLayoutConfidenceSlider.Name = "tableLayoutConfidenceSlider";
            tableLayoutConfidenceSlider.RowCount = 4;
            tableLayoutConfidenceSlider.RowStyles.Add(new RowStyle());
            tableLayoutConfidenceSlider.RowStyles.Add(new RowStyle());
            tableLayoutConfidenceSlider.RowStyles.Add(new RowStyle());
            tableLayoutConfidenceSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutConfidenceSlider.Size = new Size(518, 160);
            tableLayoutConfidenceSlider.TabIndex = 15;
            // 
            // label2
            // 
            tableLayoutConfidenceSlider.SetColumnSpan(label2, 2);
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(218, 48);
            label2.Name = "label2";
            label2.Size = new Size(297, 62);
            label2.TabIndex = 17;
            label2.Text = "Higher confidence / Lower tolerance = lower risk of false positives but lower detection rate";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoConfidence
            // 
            lblInfoConfidence.Dock = DockStyle.Left;
            lblInfoConfidence.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoConfidence.Location = new Point(420, 22);
            lblInfoConfidence.Name = "lblInfoConfidence";
            lblInfoConfidence.Size = new Size(95, 26);
            lblInfoConfidence.TabIndex = 4;
            lblInfoConfidence.Text = "80%";
            lblInfoConfidence.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Aquamarine;
            flowLayoutPanel2.Controls.Add(label3);
            flowLayoutPanel2.Controls.Add(rbToleranceLow);
            flowLayoutPanel2.Controls.Add(rbToleranceMed);
            flowLayoutPanel2.Controls.Add(rbToleranceHigh);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            tableLayoutConfidenceSlider.SetRowSpan(flowLayoutPanel2, 3);
            flowLayoutPanel2.Size = new Size(215, 110);
            flowLayoutPanel2.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 0);
            label3.Margin = new Padding(3, 0, 3, 3);
            label3.Name = "label3";
            label3.Size = new Size(194, 15);
            label3.TabIndex = 2;
            label3.Text = "Deviation tolerance for detection";
            // 
            // rbToleranceLow
            // 
            rbToleranceLow.CircleSize = 12;
            rbToleranceLow.HoverColor = Color.DeepSkyBlue;
            rbToleranceLow.Location = new Point(3, 21);
            rbToleranceLow.Name = "rbToleranceLow";
            rbToleranceLow.PaddingLeft = 12;
            rbToleranceLow.Size = new Size(168, 19);
            rbToleranceLow.TabIndex = 3;
            rbToleranceLow.TabStop = true;
            rbToleranceLow.Text = "Low";
            rbToleranceLow.UseVisualStyleBackColor = true;
            // 
            // rbToleranceMed
            // 
            rbToleranceMed.CircleSize = 12;
            rbToleranceMed.HoverColor = Color.DeepSkyBlue;
            rbToleranceMed.Location = new Point(3, 46);
            rbToleranceMed.Name = "rbToleranceMed";
            rbToleranceMed.PaddingLeft = 12;
            rbToleranceMed.Size = new Size(168, 19);
            rbToleranceMed.TabIndex = 4;
            rbToleranceMed.TabStop = true;
            rbToleranceMed.Text = "Medium (Default)";
            rbToleranceMed.UseVisualStyleBackColor = true;
            // 
            // rbToleranceHigh
            // 
            rbToleranceHigh.CircleSize = 12;
            rbToleranceHigh.HoverColor = Color.DeepSkyBlue;
            rbToleranceHigh.Location = new Point(3, 71);
            rbToleranceHigh.Name = "rbToleranceHigh";
            rbToleranceHigh.PaddingLeft = 12;
            rbToleranceHigh.Size = new Size(168, 19);
            rbToleranceHigh.TabIndex = 5;
            rbToleranceHigh.TabStop = true;
            rbToleranceHigh.Text = "High";
            rbToleranceHigh.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            tableLayoutConfidenceSlider.SetColumnSpan(label1, 2);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(218, 0);
            label1.Name = "label1";
            label1.Size = new Size(297, 22);
            label1.TabIndex = 1;
            label1.Text = "Confidence required for auto switching modes";
            // 
            // sliderConfidence
            // 
            sliderConfidence.Dock = DockStyle.Fill;
            sliderConfidence.ElapsedColor = Color.DeepSkyBlue;
            sliderConfidence.HighlightColor = Color.DodgerBlue;
            sliderConfidence.Location = new Point(218, 25);
            sliderConfidence.Maximum = 90;
            sliderConfidence.Minimum = 60;
            sliderConfidence.Name = "sliderConfidence";
            sliderConfidence.RemainingColor = Color.Gray;
            sliderConfidence.Size = new Size(196, 20);
            sliderConfidence.TabIndex = 3;
            sliderConfidence.Text = "flatSlider1";
            sliderConfidence.ThumbColor = Color.White;
            sliderConfidence.ThumbSize = new Size(12, 12);
            sliderConfidence.Value = 80;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Khaki;
            tableLayoutConfidenceSlider.SetColumnSpan(flowLayoutPanel1, 3);
            flowLayoutPanel1.Controls.Add(iconPictureBox1);
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 110);
            flowLayoutPanel1.Margin = new Padding(3, 0, 3, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(512, 50);
            flowLayoutPanel1.TabIndex = 18;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.Khaki;
            iconPictureBox1.ForeColor = SystemColors.ControlText;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Info;
            iconPictureBox1.IconColor = SystemColors.ControlText;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 28;
            iconPictureBox1.Location = new Point(12, 3);
            iconPictureBox1.Margin = new Padding(12, 3, 3, 3);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(32, 32);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox1.TabIndex = 0;
            iconPictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.Location = new Point(50, 3);
            label5.Margin = new Padding(3, 3, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(390, 47);
            label5.TabIndex = 18;
            label5.Text = "Suggested to leave as is but can be adjusted optionally. Some false positives will always occur.";
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.BackColor = Color.Yellow;
            flowLayoutPanel5.Controls.Add(btnRestoreDefaults);
            flowLayoutPanel5.Controls.Add(btnClearSetups);
            flowLayoutPanel5.Dock = DockStyle.Fill;
            flowLayoutPanel5.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel5.Location = new Point(3, 598);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.RightToLeft = RightToLeft.No;
            flowLayoutPanel5.Size = new Size(518, 117);
            flowLayoutPanel5.TabIndex = 21;
            // 
            // btnRestoreDefaults
            // 
            btnRestoreDefaults.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRestoreDefaults.BackColor = Color.FromArgb(230, 230, 255);
            btnRestoreDefaults.FlatAppearance.BorderSize = 0;
            btnRestoreDefaults.FlatStyle = FlatStyle.Flat;
            btnRestoreDefaults.IconChar = FontAwesome.Sharp.IconChar.None;
            btnRestoreDefaults.IconColor = Color.Black;
            btnRestoreDefaults.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRestoreDefaults.Location = new Point(369, 3);
            btnRestoreDefaults.Name = "btnRestoreDefaults";
            btnRestoreDefaults.Size = new Size(146, 27);
            btnRestoreDefaults.TabIndex = 7;
            btnRestoreDefaults.Text = "Restore Defaults";
            btnRestoreDefaults.UseVisualStyleBackColor = false;
            btnRestoreDefaults.Click += btnRestoreDefaults_Click;
            // 
            // btnClearSetups
            // 
            btnClearSetups.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearSetups.BackColor = Color.FromArgb(230, 230, 255);
            btnClearSetups.FlatAppearance.BorderSize = 0;
            btnClearSetups.FlatStyle = FlatStyle.Flat;
            btnClearSetups.IconChar = FontAwesome.Sharp.IconChar.None;
            btnClearSetups.IconColor = Color.Black;
            btnClearSetups.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClearSetups.Location = new Point(217, 3);
            btnClearSetups.Name = "btnClearSetups";
            btnClearSetups.Size = new Size(146, 27);
            btnClearSetups.TabIndex = 8;
            btnClearSetups.Text = "Delete VR setup";
            btnClearSetups.UseVisualStyleBackColor = false;
            btnClearSetups.Click += btnClearSetups_Click;
            // 
            // tableLayoutQuality
            // 
            tableLayoutQuality.BackColor = Color.Orange;
            tableLayoutQuality.ColumnCount = 2;
            tableLayoutQuality.ColumnStyles.Add(new ColumnStyle());
            tableLayoutQuality.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutQuality.Controls.Add(label6, 0, 2);
            tableLayoutQuality.Controls.Add(label7, 1, 0);
            tableLayoutQuality.Controls.Add(label4, 0, 0);
            tableLayoutQuality.Controls.Add(flowLayoutPanel4, 1, 1);
            tableLayoutQuality.Controls.Add(flowLayoutPanel3, 0, 1);
            tableLayoutQuality.Dock = DockStyle.Fill;
            tableLayoutQuality.Location = new Point(3, 305);
            tableLayoutQuality.Name = "tableLayoutQuality";
            tableLayoutQuality.RowCount = 3;
            tableLayoutQuality.RowStyles.Add(new RowStyle());
            tableLayoutQuality.RowStyles.Add(new RowStyle());
            tableLayoutQuality.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutQuality.Size = new Size(518, 180);
            tableLayoutQuality.TabIndex = 22;
            // 
            // label6
            // 
            tableLayoutQuality.SetColumnSpan(label6, 2);
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 136);
            label6.Name = "label6";
            label6.Size = new Size(512, 44);
            label6.TabIndex = 20;
            label6.Text = "Use lower values if you experience stuttering during playback. ";
            // 
            // label7
            // 
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(218, 0);
            label7.Margin = new Padding(3, 0, 3, 3);
            label7.Name = "label7";
            label7.Size = new Size(297, 15);
            label7.TabIndex = 19;
            label7.Text = "Interpolation method";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 0);
            label4.Margin = new Padding(3, 0, 3, 3);
            label4.Name = "label4";
            label4.Size = new Size(209, 15);
            label4.TabIndex = 18;
            label4.Text = "Quality preset (Output resolution)";
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BackColor = Color.LightSkyBlue;
            flowLayoutPanel4.Controls.Add(rbInterpLine);
            flowLayoutPanel4.Controls.Add(rbInterpCubic);
            flowLayoutPanel4.Controls.Add(rbInterpLanc);
            flowLayoutPanel4.Controls.Add(rbInterpSpline);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel4.Location = new Point(215, 18);
            flowLayoutPanel4.Margin = new Padding(0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(303, 118);
            flowLayoutPanel4.TabIndex = 4;
            // 
            // rbInterpLine
            // 
            rbInterpLine.CircleSize = 12;
            rbInterpLine.HoverColor = Color.DeepSkyBlue;
            rbInterpLine.Location = new Point(3, 3);
            rbInterpLine.Name = "rbInterpLine";
            rbInterpLine.PaddingLeft = 12;
            rbInterpLine.Size = new Size(185, 19);
            rbInterpLine.TabIndex = 4;
            rbInterpLine.TabStop = true;
            rbInterpLine.Text = "Bilinear";
            rbInterpLine.UseVisualStyleBackColor = true;
            // 
            // rbInterpCubic
            // 
            rbInterpCubic.CircleSize = 12;
            rbInterpCubic.HoverColor = Color.DeepSkyBlue;
            rbInterpCubic.Location = new Point(3, 28);
            rbInterpCubic.Name = "rbInterpCubic";
            rbInterpCubic.PaddingLeft = 12;
            rbInterpCubic.Size = new Size(185, 19);
            rbInterpCubic.TabIndex = 5;
            rbInterpCubic.TabStop = true;
            rbInterpCubic.Text = "Bicubic (Default)";
            rbInterpCubic.UseVisualStyleBackColor = true;
            // 
            // rbInterpLanc
            // 
            rbInterpLanc.CircleSize = 12;
            rbInterpLanc.HoverColor = Color.DeepSkyBlue;
            rbInterpLanc.Location = new Point(3, 53);
            rbInterpLanc.Name = "rbInterpLanc";
            rbInterpLanc.PaddingLeft = 12;
            rbInterpLanc.Size = new Size(168, 19);
            rbInterpLanc.TabIndex = 6;
            rbInterpLanc.TabStop = true;
            rbInterpLanc.Text = "Lanczos";
            rbInterpLanc.UseVisualStyleBackColor = true;
            // 
            // rbInterpSpline
            // 
            rbInterpSpline.CircleSize = 12;
            rbInterpSpline.HoverColor = Color.DeepSkyBlue;
            rbInterpSpline.Location = new Point(3, 78);
            rbInterpSpline.Name = "rbInterpSpline";
            rbInterpSpline.PaddingLeft = 12;
            rbInterpSpline.Size = new Size(168, 19);
            rbInterpSpline.TabIndex = 3;
            rbInterpSpline.TabStop = true;
            rbInterpSpline.Text = "Spline16";
            rbInterpSpline.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.PaleTurquoise;
            flowLayoutPanel3.Controls.Add(rbQualityPerformance);
            flowLayoutPanel3.Controls.Add(rbQualityBalanced);
            flowLayoutPanel3.Controls.Add(rbQualityHigh);
            flowLayoutPanel3.Controls.Add(rbQualityUltra);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(0, 18);
            flowLayoutPanel3.Margin = new Padding(0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(215, 118);
            flowLayoutPanel3.TabIndex = 17;
            flowLayoutPanel3.WrapContents = false;
            // 
            // rbQualityPerformance
            // 
            rbQualityPerformance.CircleSize = 12;
            rbQualityPerformance.HoverColor = Color.DeepSkyBlue;
            rbQualityPerformance.Location = new Point(3, 3);
            rbQualityPerformance.Name = "rbQualityPerformance";
            rbQualityPerformance.PaddingLeft = 12;
            rbQualityPerformance.Size = new Size(181, 19);
            rbQualityPerformance.TabIndex = 3;
            rbQualityPerformance.TabStop = true;
            rbQualityPerformance.Text = "Performance";
            rbQualityPerformance.UseVisualStyleBackColor = true;
            // 
            // rbQualityBalanced
            // 
            rbQualityBalanced.CircleSize = 12;
            rbQualityBalanced.HoverColor = Color.DeepSkyBlue;
            rbQualityBalanced.Location = new Point(3, 28);
            rbQualityBalanced.Name = "rbQualityBalanced";
            rbQualityBalanced.PaddingLeft = 12;
            rbQualityBalanced.Size = new Size(181, 19);
            rbQualityBalanced.TabIndex = 4;
            rbQualityBalanced.TabStop = true;
            rbQualityBalanced.Text = "Balanced (Default)";
            rbQualityBalanced.UseVisualStyleBackColor = true;
            // 
            // rbQualityHigh
            // 
            rbQualityHigh.CircleSize = 12;
            rbQualityHigh.HoverColor = Color.DeepSkyBlue;
            rbQualityHigh.Location = new Point(3, 53);
            rbQualityHigh.Name = "rbQualityHigh";
            rbQualityHigh.PaddingLeft = 12;
            rbQualityHigh.Size = new Size(185, 19);
            rbQualityHigh.TabIndex = 5;
            rbQualityHigh.TabStop = true;
            rbQualityHigh.Text = "High";
            rbQualityHigh.UseVisualStyleBackColor = true;
            // 
            // rbQualityUltra
            // 
            rbQualityUltra.CircleSize = 12;
            rbQualityUltra.HoverColor = Color.DeepSkyBlue;
            rbQualityUltra.Location = new Point(3, 78);
            rbQualityUltra.Name = "rbQualityUltra";
            rbQualityUltra.PaddingLeft = 12;
            rbQualityUltra.Size = new Size(181, 19);
            rbQualityUltra.TabIndex = 6;
            rbQualityUltra.TabStop = true;
            rbQualityUltra.Text = "Ultra";
            rbQualityUltra.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gold;
            panel1.Controls.Add(label14);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 491);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 101);
            panel1.TabIndex = 23;
            // 
            // label14
            // 
            label14.Dock = DockStyle.Fill;
            label14.Location = new Point(0, 0);
            label14.Name = "label14";
            label14.Size = new Size(518, 101);
            label14.TabIndex = 4;
            label14.Text = "In VR mode, hold your left mouse button on the player panel to pan the projected view. While holding down the mouse button, adjust the scroll wheel to zoom in and out.";
            // 
            // tableLayoutTop
            // 
            tableLayoutTop.BackColor = Color.Thistle;
            tableLayoutTop.ColumnCount = 2;
            tableLayoutTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutTop.Controls.Add(cbEnableAutoDetectDebug, 1, 1);
            tableLayoutTop.Controls.Add(cbToggleDetection, 0, 1);
            tableLayoutTop.Controls.Add(label13, 0, 0);
            tableLayoutTop.Dock = DockStyle.Fill;
            tableLayoutTop.Location = new Point(3, 63);
            tableLayoutTop.Name = "tableLayoutTop";
            tableLayoutTop.RowCount = 2;
            tableLayoutTop.RowStyles.Add(new RowStyle());
            tableLayoutTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutTop.Size = new Size(518, 70);
            tableLayoutTop.TabIndex = 24;
            // 
            // cbEnableAutoDetectDebug
            // 
            cbEnableAutoDetectDebug.BoxSize = 13;
            cbEnableAutoDetectDebug.Dock = DockStyle.Top;
            cbEnableAutoDetectDebug.HoverColor = Color.DeepSkyBlue;
            cbEnableAutoDetectDebug.Location = new Point(175, 25);
            cbEnableAutoDetectDebug.Name = "cbEnableAutoDetectDebug";
            cbEnableAutoDetectDebug.PaddingLeft = 12;
            cbEnableAutoDetectDebug.Size = new Size(340, 17);
            cbEnableAutoDetectDebug.TabIndex = 4;
            cbEnableAutoDetectDebug.Text = "Show detection results in player";
            cbEnableAutoDetectDebug.UseVisualStyleBackColor = true;
            // 
            // cbToggleDetection
            // 
            cbToggleDetection.BoxSize = 13;
            cbToggleDetection.Dock = DockStyle.Top;
            cbToggleDetection.HoverColor = Color.DeepSkyBlue;
            cbToggleDetection.Location = new Point(3, 25);
            cbToggleDetection.Name = "cbToggleDetection";
            cbToggleDetection.PaddingLeft = 12;
            cbToggleDetection.Size = new Size(166, 17);
            cbToggleDetection.TabIndex = 3;
            cbToggleDetection.Text = "Enable auto-detection";
            cbToggleDetection.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            tableLayoutTop.SetColumnSpan(label13, 2);
            label13.Dock = DockStyle.Fill;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(3, 0);
            label13.Name = "label13";
            label13.Size = new Size(512, 22);
            label13.TabIndex = 1;
            label13.Text = "Toggle VR auto-detection";
            // 
            // VrUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutMain);
            Name = "VrUserControl";
            Size = new Size(524, 718);
            tableLayoutMain.ResumeLayout(false);
            tableLayoutConfidenceSlider.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            flowLayoutPanel5.ResumeLayout(false);
            tableLayoutQuality.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private Label label13;
        private Controls.CustomCheckBox cbToggleDetection;
        private TableLayoutPanel tableLayoutConfidenceSlider;
        private Label label1;
        private Controls.FlatSlider sliderConfidence;
        private Label lblInfoConfidence;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label3;
        private Controls.CustomRadioButton rbToleranceLow;
        private Controls.CustomRadioButton rbToleranceMed;
        private Controls.CustomRadioButton rbToleranceHigh;
        private FlowLayoutPanel flowLayoutPanel3;
        private Controls.CustomRadioButton rbQualityPerformance;
        private Controls.CustomRadioButton rbQualityBalanced;
        private Controls.CustomRadioButton rbQualityHigh;
        private Controls.CustomRadioButton rbInterpSpline;
        private Controls.CustomRadioButton rbInterpLanc;
        private Controls.CustomRadioButton rbInterpLine;
        private Controls.CustomRadioButton rbInterpCubic;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FontAwesome.Sharp.IconButton btnRestoreDefaults;
        private FontAwesome.Sharp.IconButton btnClearSetups;
        private TableLayoutPanel tableLayoutQuality;
        private Panel panel1;
        private Label label14;
        private TableLayoutPanel tableLayoutTop;
        private Label label2;
        private Controls.CustomCheckBox cbEnableAutoDetectDebug;
        private Controls.CustomRadioButton rbQualityUltra;
        private Label label4;
        private Label label7;
        private Label label5;
        private Label label6;
        private FlowLayoutPanel flowLayoutPanel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}
