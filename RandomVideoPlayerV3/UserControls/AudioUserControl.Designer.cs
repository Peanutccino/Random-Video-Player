namespace RandomVideoPlayer.UserControls
{
    partial class AudioUserControl
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
            tableLayoutSlider = new TableLayoutPanel();
            lblInfoAltBound = new Label();
            sliderAltBound = new RandomVideoPlayer.Controls.FlatSlider();
            label12 = new Label();
            label11 = new Label();
            lblInfoTargetRMS = new Label();
            sliderTargetRMS = new RandomVideoPlayer.Controls.FlatSlider();
            label10 = new Label();
            label9 = new Label();
            lblInfoMaxGain = new Label();
            sliderMaxGain = new RandomVideoPlayer.Controls.FlatSlider();
            label8 = new Label();
            label7 = new Label();
            lblInfoPeak = new Label();
            sliderPeak = new RandomVideoPlayer.Controls.FlatSlider();
            label6 = new Label();
            label3 = new Label();
            lblInfoGaussSize = new Label();
            sliderGaussSize = new RandomVideoPlayer.Controls.FlatSlider();
            label5 = new Label();
            label4 = new Label();
            lblInfoFrameLen = new Label();
            label1 = new Label();
            label2 = new Label();
            sliderFrameLen = new RandomVideoPlayer.Controls.FlatSlider();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label13 = new Label();
            cbAudioNormalization = new RandomVideoPlayer.Controls.CustomCheckBox();
            label14 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnRestoreDefaults = new FontAwesome.Sharp.IconButton();
            tableLayoutMain.SuspendLayout();
            tableLayoutSlider.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.BackColor = Color.SandyBrown;
            tableLayoutMain.ColumnCount = 1;
            tableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutMain.Controls.Add(lblHeader, 0, 0);
            tableLayoutMain.Controls.Add(tableLayoutSlider, 0, 2);
            tableLayoutMain.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutMain.Controls.Add(flowLayoutPanel2, 0, 3);
            tableLayoutMain.Dock = DockStyle.Fill;
            tableLayoutMain.Location = new Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 4;
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 42.8571434F));
            tableLayoutMain.RowStyles.Add(new RowStyle());
            tableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 57.1428566F));
            tableLayoutMain.Size = new Size(524, 656);
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
            lblHeader.Text = "Audio";
            // 
            // tableLayoutSlider
            // 
            tableLayoutSlider.BackColor = Color.GreenYellow;
            tableLayoutSlider.ColumnCount = 3;
            tableLayoutSlider.ColumnStyles.Add(new ColumnStyle());
            tableLayoutSlider.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutSlider.ColumnStyles.Add(new ColumnStyle());
            tableLayoutSlider.Controls.Add(lblInfoAltBound, 2, 11);
            tableLayoutSlider.Controls.Add(sliderAltBound, 1, 11);
            tableLayoutSlider.Controls.Add(label12, 0, 11);
            tableLayoutSlider.Controls.Add(label11, 0, 10);
            tableLayoutSlider.Controls.Add(lblInfoTargetRMS, 2, 9);
            tableLayoutSlider.Controls.Add(sliderTargetRMS, 1, 9);
            tableLayoutSlider.Controls.Add(label10, 0, 9);
            tableLayoutSlider.Controls.Add(label9, 0, 8);
            tableLayoutSlider.Controls.Add(lblInfoMaxGain, 2, 7);
            tableLayoutSlider.Controls.Add(sliderMaxGain, 1, 7);
            tableLayoutSlider.Controls.Add(label8, 0, 7);
            tableLayoutSlider.Controls.Add(label7, 0, 6);
            tableLayoutSlider.Controls.Add(lblInfoPeak, 2, 5);
            tableLayoutSlider.Controls.Add(sliderPeak, 1, 5);
            tableLayoutSlider.Controls.Add(label6, 0, 5);
            tableLayoutSlider.Controls.Add(label3, 0, 4);
            tableLayoutSlider.Controls.Add(lblInfoGaussSize, 2, 3);
            tableLayoutSlider.Controls.Add(sliderGaussSize, 1, 3);
            tableLayoutSlider.Controls.Add(label5, 0, 3);
            tableLayoutSlider.Controls.Add(label4, 0, 2);
            tableLayoutSlider.Controls.Add(lblInfoFrameLen, 2, 1);
            tableLayoutSlider.Controls.Add(label1, 0, 0);
            tableLayoutSlider.Controls.Add(label2, 0, 1);
            tableLayoutSlider.Controls.Add(sliderFrameLen, 1, 1);
            tableLayoutSlider.Dock = DockStyle.Fill;
            tableLayoutSlider.Location = new Point(3, 148);
            tableLayoutSlider.Name = "tableLayoutSlider";
            tableLayoutSlider.RowCount = 12;
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.RowStyles.Add(new RowStyle(SizeType.Percent, 8.333335F));
            tableLayoutSlider.Size = new Size(518, 391);
            tableLayoutSlider.TabIndex = 14;
            // 
            // lblInfoAltBound
            // 
            lblInfoAltBound.Dock = DockStyle.Fill;
            lblInfoAltBound.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoAltBound.Location = new Point(415, 352);
            lblInfoAltBound.Name = "lblInfoAltBound";
            lblInfoAltBound.Size = new Size(100, 39);
            lblInfoAltBound.TabIndex = 23;
            lblInfoAltBound.Text = "Enabled";
            lblInfoAltBound.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sliderAltBound
            // 
            sliderAltBound.Dock = DockStyle.Fill;
            sliderAltBound.ElapsedColor = Color.DeepSkyBlue;
            sliderAltBound.HighlightColor = Color.DodgerBlue;
            sliderAltBound.Location = new Point(109, 355);
            sliderAltBound.Maximum = 1;
            sliderAltBound.Minimum = 0;
            sliderAltBound.Name = "sliderAltBound";
            sliderAltBound.RemainingColor = Color.Gray;
            sliderAltBound.Size = new Size(300, 33);
            sliderAltBound.TabIndex = 22;
            sliderAltBound.Text = "flatSlider4";
            sliderAltBound.ThumbColor = Color.White;
            sliderAltBound.ThumbSize = new Size(12, 12);
            sliderAltBound.Value = 1;
            // 
            // label12
            // 
            label12.Dock = DockStyle.Fill;
            label12.Location = new Point(3, 352);
            label12.Name = "label12";
            label12.Size = new Size(100, 39);
            label12.TabIndex = 21;
            label12.Text = "On / Off";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            tableLayoutSlider.SetColumnSpan(label11, 3);
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(3, 320);
            label11.Name = "label11";
            label11.Size = new Size(512, 32);
            label11.TabIndex = 20;
            label11.Text = "Alt boundary mode: Stabilizes normalizer with extra processing, disable if artifacts occur";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoTargetRMS
            // 
            lblInfoTargetRMS.Dock = DockStyle.Fill;
            lblInfoTargetRMS.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoTargetRMS.Location = new Point(415, 288);
            lblInfoTargetRMS.Name = "lblInfoTargetRMS";
            lblInfoTargetRMS.Size = new Size(100, 32);
            lblInfoTargetRMS.TabIndex = 19;
            lblInfoTargetRMS.Text = "90%";
            lblInfoTargetRMS.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sliderTargetRMS
            // 
            sliderTargetRMS.Dock = DockStyle.Fill;
            sliderTargetRMS.ElapsedColor = Color.DeepSkyBlue;
            sliderTargetRMS.HighlightColor = Color.DodgerBlue;
            sliderTargetRMS.Location = new Point(109, 291);
            sliderTargetRMS.Maximum = 100;
            sliderTargetRMS.Minimum = 0;
            sliderTargetRMS.Name = "sliderTargetRMS";
            sliderTargetRMS.RemainingColor = Color.Gray;
            sliderTargetRMS.Size = new Size(300, 26);
            sliderTargetRMS.TabIndex = 18;
            sliderTargetRMS.Text = "flatSlider4";
            sliderTargetRMS.ThumbColor = Color.White;
            sliderTargetRMS.ThumbSize = new Size(12, 12);
            sliderTargetRMS.Value = 90;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Fill;
            label10.Location = new Point(3, 288);
            label10.Name = "label10";
            label10.Size = new Size(100, 32);
            label10.TabIndex = 17;
            label10.Text = "0 - 100%";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            tableLayoutSlider.SetColumnSpan(label9, 3);
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 256);
            label9.Name = "label9";
            label9.Size = new Size(512, 32);
            label9.TabIndex = 16;
            label9.Text = "Target RMS: Average loudness target; Higher = louder avg but may sound more processed";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoMaxGain
            // 
            lblInfoMaxGain.Dock = DockStyle.Fill;
            lblInfoMaxGain.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoMaxGain.Location = new Point(415, 224);
            lblInfoMaxGain.Name = "lblInfoMaxGain";
            lblInfoMaxGain.Size = new Size(100, 32);
            lblInfoMaxGain.TabIndex = 15;
            lblInfoMaxGain.Text = "6%";
            lblInfoMaxGain.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sliderMaxGain
            // 
            sliderMaxGain.Dock = DockStyle.Fill;
            sliderMaxGain.ElapsedColor = Color.DeepSkyBlue;
            sliderMaxGain.HighlightColor = Color.DodgerBlue;
            sliderMaxGain.Location = new Point(109, 227);
            sliderMaxGain.Maximum = 100;
            sliderMaxGain.Minimum = 0;
            sliderMaxGain.Name = "sliderMaxGain";
            sliderMaxGain.RemainingColor = Color.Gray;
            sliderMaxGain.Size = new Size(300, 26);
            sliderMaxGain.TabIndex = 14;
            sliderMaxGain.Text = "flatSlider4";
            sliderMaxGain.ThumbColor = Color.White;
            sliderMaxGain.ThumbSize = new Size(12, 12);
            sliderMaxGain.Value = 6;
            // 
            // label8
            // 
            label8.Dock = DockStyle.Fill;
            label8.Location = new Point(3, 224);
            label8.Name = "label8";
            label8.Size = new Size(100, 32);
            label8.TabIndex = 13;
            label8.Text = "0 - 100%";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            tableLayoutSlider.SetColumnSpan(label7, 3);
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(3, 192);
            label7.Name = "label7";
            label7.Size = new Size(512, 32);
            label7.TabIndex = 12;
            label7.Text = "Max gain factor: Lower = more conservative/less risk of noise; Higher = lift quiet dialogue more";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoPeak
            // 
            lblInfoPeak.Dock = DockStyle.Fill;
            lblInfoPeak.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoPeak.Location = new Point(415, 160);
            lblInfoPeak.Name = "lblInfoPeak";
            lblInfoPeak.Size = new Size(100, 32);
            lblInfoPeak.TabIndex = 11;
            lblInfoPeak.Text = "50%";
            lblInfoPeak.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sliderPeak
            // 
            sliderPeak.Dock = DockStyle.Fill;
            sliderPeak.ElapsedColor = Color.DeepSkyBlue;
            sliderPeak.HighlightColor = Color.DodgerBlue;
            sliderPeak.Location = new Point(109, 163);
            sliderPeak.Maximum = 95;
            sliderPeak.Minimum = 50;
            sliderPeak.Name = "sliderPeak";
            sliderPeak.RemainingColor = Color.Gray;
            sliderPeak.Size = new Size(300, 26);
            sliderPeak.TabIndex = 10;
            sliderPeak.Text = "flatSlider3";
            sliderPeak.ThumbColor = Color.White;
            sliderPeak.ThumbSize = new Size(12, 12);
            sliderPeak.Value = 50;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(3, 160);
            label6.Name = "label6";
            label6.Size = new Size(100, 32);
            label6.TabIndex = 9;
            label6.Text = "50 - 95%";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            tableLayoutSlider.SetColumnSpan(label3, 3);
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 128);
            label3.Name = "label3";
            label3.Size = new Size(512, 32);
            label3.TabIndex = 8;
            label3.Text = "Target peak: Loudness headroom; Lower = less harsh/safer but quieter";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoGaussSize
            // 
            lblInfoGaussSize.Dock = DockStyle.Fill;
            lblInfoGaussSize.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoGaussSize.Location = new Point(415, 96);
            lblInfoGaussSize.Name = "lblInfoGaussSize";
            lblInfoGaussSize.Size = new Size(100, 32);
            lblInfoGaussSize.TabIndex = 7;
            lblInfoGaussSize.Text = "31 frames";
            lblInfoGaussSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sliderGaussSize
            // 
            sliderGaussSize.Dock = DockStyle.Fill;
            sliderGaussSize.ElapsedColor = Color.DeepSkyBlue;
            sliderGaussSize.HighlightColor = Color.DodgerBlue;
            sliderGaussSize.Location = new Point(109, 99);
            sliderGaussSize.Maximum = 301;
            sliderGaussSize.Minimum = 3;
            sliderGaussSize.Name = "sliderGaussSize";
            sliderGaussSize.RemainingColor = Color.Gray;
            sliderGaussSize.Size = new Size(300, 26);
            sliderGaussSize.TabIndex = 6;
            sliderGaussSize.Text = "flatSlider2";
            sliderGaussSize.ThumbColor = Color.White;
            sliderGaussSize.ThumbSize = new Size(12, 12);
            sliderGaussSize.Value = 31;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 96);
            label5.Name = "label5";
            label5.Size = new Size(100, 32);
            label5.TabIndex = 5;
            label5.Text = "3 to 301";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            tableLayoutSlider.SetColumnSpan(label4, 3);
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 64);
            label4.Name = "label4";
            label4.Size = new Size(512, 32);
            label4.TabIndex = 4;
            label4.Text = "Gaussian smoothing window size; Larger = smoother, but slower to adapt";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInfoFrameLen
            // 
            lblInfoFrameLen.Dock = DockStyle.Fill;
            lblInfoFrameLen.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInfoFrameLen.Location = new Point(415, 32);
            lblInfoFrameLen.Name = "lblInfoFrameLen";
            lblInfoFrameLen.Size = new Size(100, 32);
            lblInfoFrameLen.TabIndex = 3;
            lblInfoFrameLen.Text = "250ms";
            lblInfoFrameLen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            tableLayoutSlider.SetColumnSpan(label1, 3);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(512, 32);
            label1.TabIndex = 0;
            label1.Text = "Frame length in ms; Smaller = faster/more aggressive; Larger = smoother/slower";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 32);
            label2.Name = "label2";
            label2.Size = new Size(100, 32);
            label2.TabIndex = 1;
            label2.Text = "100 to 2000 ms";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sliderFrameLen
            // 
            sliderFrameLen.Dock = DockStyle.Fill;
            sliderFrameLen.ElapsedColor = Color.DeepSkyBlue;
            sliderFrameLen.HighlightColor = Color.DodgerBlue;
            sliderFrameLen.Location = new Point(109, 35);
            sliderFrameLen.Maximum = 2000;
            sliderFrameLen.Minimum = 100;
            sliderFrameLen.Name = "sliderFrameLen";
            sliderFrameLen.RemainingColor = Color.Gray;
            sliderFrameLen.Size = new Size(300, 26);
            sliderFrameLen.TabIndex = 2;
            sliderFrameLen.Text = "flatSlider1";
            sliderFrameLen.ThumbColor = Color.White;
            sliderFrameLen.ThumbSize = new Size(12, 12);
            sliderFrameLen.Value = 250;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.LawnGreen;
            flowLayoutPanel1.BackgroundImageLayout = ImageLayout.None;
            flowLayoutPanel1.Controls.Add(label13);
            flowLayoutPanel1.Controls.Add(cbAudioNormalization);
            flowLayoutPanel1.Controls.Add(label14);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 63);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(518, 79);
            flowLayoutPanel1.TabIndex = 15;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(3, 0);
            label13.Name = "label13";
            label13.Size = new Size(156, 15);
            label13.TabIndex = 0;
            label13.Text = "Toggle audio normalization:";
            // 
            // cbAudioNormalization
            // 
            cbAudioNormalization.BoxSize = 13;
            cbAudioNormalization.Dock = DockStyle.Top;
            cbAudioNormalization.HoverColor = Color.DeepSkyBlue;
            cbAudioNormalization.Location = new Point(3, 18);
            cbAudioNormalization.Name = "cbAudioNormalization";
            cbAudioNormalization.PaddingLeft = 12;
            cbAudioNormalization.Size = new Size(477, 24);
            cbAudioNormalization.TabIndex = 2;
            cbAudioNormalization.Text = "Audio normalization";
            cbAudioNormalization.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(3, 45);
            label14.Name = "label14";
            label14.Size = new Size(477, 30);
            label14.TabIndex = 3;
            label14.Text = "You can fine tune the normalization settings below; Check ffmpeg documentation under \"dynaudnorm\" for more details";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Cyan;
            flowLayoutPanel2.Controls.Add(btnRestoreDefaults);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(3, 545);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(518, 108);
            flowLayoutPanel2.TabIndex = 16;
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
            btnRestoreDefaults.TabIndex = 6;
            btnRestoreDefaults.Text = "Restore Defaults";
            btnRestoreDefaults.UseVisualStyleBackColor = false;
            // 
            // AudioUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutMain);
            Name = "AudioUserControl";
            Size = new Size(524, 656);
            tableLayoutMain.ResumeLayout(false);
            tableLayoutSlider.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutMain;
        private Label lblHeader;
        private TableLayoutPanel tableLayoutSlider;
        private Label label1;
        private Label label2;
        private Label lblInfoFrameLen;
        private Controls.FlatSlider sliderFrameLen;
        private Label label4;
        private Label lblInfoGaussSize;
        private Controls.FlatSlider sliderGaussSize;
        private Label label5;
        private Label label3;
        private Label lblInfoPeak;
        private Controls.FlatSlider sliderPeak;
        private Label label6;
        private Label label7;
        private Controls.FlatSlider sliderMaxGain;
        private Label label8;
        private Controls.FlatSlider sliderTargetRMS;
        private Label label10;
        private Label label9;
        private Label lblInfoMaxGain;
        private Label lblInfoTargetRMS;
        private Label label11;
        private Label lblInfoAltBound;
        private Controls.FlatSlider sliderAltBound;
        private Label label12;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label13;
        private Controls.CustomCheckBox cbAudioNormalization;
        private Label label14;
        private FlowLayoutPanel flowLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnRestoreDefaults;
    }
}
