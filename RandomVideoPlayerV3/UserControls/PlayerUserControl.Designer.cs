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
            cbLoopPlayer = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            panelVideoExtensions = new Panel();
            btnDeselectVideoExt = new FontAwesome.Sharp.IconButton();
            btnSelectVideoExt = new FontAwesome.Sharp.IconButton();
            cbAVCHD = new CheckBox();
            cbF4V = new CheckBox();
            cbWMV = new CheckBox();
            cbWEBM = new CheckBox();
            cbMP4 = new CheckBox();
            cbMOV = new CheckBox();
            cbMKV = new CheckBox();
            cbM4V = new CheckBox();
            cbFLV = new CheckBox();
            cbAVI = new CheckBox();
            label6 = new Label();
            panelImageExtensions = new Panel();
            btnDeselectImageExt = new FontAwesome.Sharp.IconButton();
            btnSelectImageExt = new FontAwesome.Sharp.IconButton();
            cbAVIF = new CheckBox();
            cbWEBP = new CheckBox();
            cbBMP = new CheckBox();
            cbTIFF = new CheckBox();
            cbTIF = new CheckBox();
            cbGIF = new CheckBox();
            cbPNG = new CheckBox();
            cbJPEG = new CheckBox();
            cbJPG = new CheckBox();
            cbFilterApply = new CheckBox();
            cbShufflePlayer = new CheckBox();
            panel2 = new Panel();
            label7 = new Label();
            cbLeftMousePause = new CheckBox();
            panel1.SuspendLayout();
            panelVideoExtensions.SuspendLayout();
            panelImageExtensions.SuspendLayout();
            panel2.SuspendLayout();
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
            label3.Location = new Point(0, 114);
            label3.Name = "label3";
            label3.Padding = new Padding(6, 0, 0, 0);
            label3.Size = new Size(507, 72);
            label3.TabIndex = 3;
            label3.Text = "Loop playing media. Will automatically play next file in list, when disabled. Shuffle randomizes the playlist.";
            // 
            // cbLoopPlayer
            // 
            cbLoopPlayer.Location = new Point(3, 147);
            cbLoopPlayer.Name = "cbLoopPlayer";
            cbLoopPlayer.Padding = new Padding(6, 0, 0, 0);
            cbLoopPlayer.Size = new Size(120, 25);
            cbLoopPlayer.TabIndex = 4;
            cbLoopPlayer.Text = "Loop player";
            cbLoopPlayer.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(0, 186);
            label4.Name = "label4";
            label4.Padding = new Padding(6, 0, 0, 0);
            label4.Size = new Size(507, 26);
            label4.TabIndex = 5;
            label4.Text = "Choose which file types will be used for playback:";
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(0, 212);
            label5.Name = "label5";
            label5.Padding = new Padding(6, 0, 0, 0);
            label5.Size = new Size(507, 23);
            label5.TabIndex = 6;
            label5.Text = "Video extensions:";
            // 
            // panelVideoExtensions
            // 
            panelVideoExtensions.Controls.Add(btnDeselectVideoExt);
            panelVideoExtensions.Controls.Add(btnSelectVideoExt);
            panelVideoExtensions.Controls.Add(cbAVCHD);
            panelVideoExtensions.Controls.Add(cbF4V);
            panelVideoExtensions.Controls.Add(cbWMV);
            panelVideoExtensions.Controls.Add(cbWEBM);
            panelVideoExtensions.Controls.Add(cbMP4);
            panelVideoExtensions.Controls.Add(cbMOV);
            panelVideoExtensions.Controls.Add(cbMKV);
            panelVideoExtensions.Controls.Add(cbM4V);
            panelVideoExtensions.Controls.Add(cbFLV);
            panelVideoExtensions.Controls.Add(cbAVI);
            panelVideoExtensions.Dock = DockStyle.Top;
            panelVideoExtensions.Location = new Point(0, 235);
            panelVideoExtensions.Name = "panelVideoExtensions";
            panelVideoExtensions.Size = new Size(507, 85);
            panelVideoExtensions.TabIndex = 7;
            // 
            // btnDeselectVideoExt
            // 
            btnDeselectVideoExt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeselectVideoExt.BackColor = Color.Lavender;
            btnDeselectVideoExt.FlatAppearance.BorderSize = 0;
            btnDeselectVideoExt.FlatStyle = FlatStyle.Flat;
            btnDeselectVideoExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDeselectVideoExt.IconColor = Color.Black;
            btnDeselectVideoExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeselectVideoExt.Location = new Point(402, 50);
            btnDeselectVideoExt.Name = "btnDeselectVideoExt";
            btnDeselectVideoExt.Size = new Size(102, 32);
            btnDeselectVideoExt.TabIndex = 11;
            btnDeselectVideoExt.Text = "Deselect all";
            btnDeselectVideoExt.UseVisualStyleBackColor = false;
            btnDeselectVideoExt.Click += btnDeselectVideoExt_Click;
            // 
            // btnSelectVideoExt
            // 
            btnSelectVideoExt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectVideoExt.BackColor = Color.Lavender;
            btnSelectVideoExt.FlatAppearance.BorderSize = 0;
            btnSelectVideoExt.FlatStyle = FlatStyle.Flat;
            btnSelectVideoExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSelectVideoExt.IconColor = Color.Black;
            btnSelectVideoExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectVideoExt.Location = new Point(402, 3);
            btnSelectVideoExt.Name = "btnSelectVideoExt";
            btnSelectVideoExt.Size = new Size(102, 32);
            btnSelectVideoExt.TabIndex = 10;
            btnSelectVideoExt.Text = "Select all";
            btnSelectVideoExt.UseVisualStyleBackColor = false;
            btnSelectVideoExt.Click += btnSelectVideoExt_Click;
            // 
            // cbAVCHD
            // 
            cbAVCHD.AutoSize = true;
            cbAVCHD.Location = new Point(198, 3);
            cbAVCHD.Name = "cbAVCHD";
            cbAVCHD.Padding = new Padding(6, 0, 0, 0);
            cbAVCHD.Size = new Size(64, 19);
            cbAVCHD.TabIndex = 9;
            cbAVCHD.Text = "avchd";
            cbAVCHD.UseVisualStyleBackColor = true;
            // 
            // cbF4V
            // 
            cbF4V.AutoSize = true;
            cbF4V.Location = new Point(127, 53);
            cbF4V.Name = "cbF4V";
            cbF4V.Padding = new Padding(6, 0, 0, 0);
            cbF4V.Size = new Size(48, 19);
            cbF4V.TabIndex = 8;
            cbF4V.Text = "f4v";
            cbF4V.UseVisualStyleBackColor = true;
            // 
            // cbWMV
            // 
            cbWMV.AutoSize = true;
            cbWMV.Location = new Point(127, 28);
            cbWMV.Name = "cbWMV";
            cbWMV.Padding = new Padding(6, 0, 0, 0);
            cbWMV.Size = new Size(58, 19);
            cbWMV.TabIndex = 7;
            cbWMV.Text = "wmv";
            cbWMV.UseVisualStyleBackColor = true;
            // 
            // cbWEBM
            // 
            cbWEBM.AutoSize = true;
            cbWEBM.Location = new Point(127, 3);
            cbWEBM.Name = "cbWEBM";
            cbWEBM.Padding = new Padding(6, 0, 0, 0);
            cbWEBM.Size = new Size(65, 19);
            cbWEBM.TabIndex = 6;
            cbWEBM.Text = "webm";
            cbWEBM.UseVisualStyleBackColor = true;
            // 
            // cbMP4
            // 
            cbMP4.AutoSize = true;
            cbMP4.Location = new Point(65, 53);
            cbMP4.Name = "cbMP4";
            cbMP4.Padding = new Padding(6, 0, 0, 0);
            cbMP4.Size = new Size(56, 19);
            cbMP4.TabIndex = 5;
            cbMP4.Text = "mp4";
            cbMP4.UseVisualStyleBackColor = true;
            // 
            // cbMOV
            // 
            cbMOV.AutoSize = true;
            cbMOV.Location = new Point(65, 28);
            cbMOV.Name = "cbMOV";
            cbMOV.Padding = new Padding(6, 0, 0, 0);
            cbMOV.Size = new Size(56, 19);
            cbMOV.TabIndex = 4;
            cbMOV.Text = "mov";
            cbMOV.UseVisualStyleBackColor = true;
            // 
            // cbMKV
            // 
            cbMKV.AutoSize = true;
            cbMKV.Location = new Point(65, 3);
            cbMKV.Name = "cbMKV";
            cbMKV.Padding = new Padding(6, 0, 0, 0);
            cbMKV.Size = new Size(55, 19);
            cbMKV.TabIndex = 3;
            cbMKV.Text = "mkv";
            cbMKV.UseVisualStyleBackColor = true;
            // 
            // cbM4V
            // 
            cbM4V.AutoSize = true;
            cbM4V.Location = new Point(3, 53);
            cbM4V.Name = "cbM4V";
            cbM4V.Padding = new Padding(6, 0, 0, 0);
            cbM4V.Size = new Size(55, 19);
            cbM4V.TabIndex = 2;
            cbM4V.Text = "m4v";
            cbM4V.UseVisualStyleBackColor = true;
            // 
            // cbFLV
            // 
            cbFLV.AutoSize = true;
            cbFLV.Location = new Point(3, 28);
            cbFLV.Name = "cbFLV";
            cbFLV.Padding = new Padding(6, 0, 0, 0);
            cbFLV.Size = new Size(45, 19);
            cbFLV.TabIndex = 1;
            cbFLV.Text = "flv";
            cbFLV.UseVisualStyleBackColor = true;
            // 
            // cbAVI
            // 
            cbAVI.AutoSize = true;
            cbAVI.Location = new Point(3, 3);
            cbAVI.Name = "cbAVI";
            cbAVI.Padding = new Padding(6, 0, 0, 0);
            cbAVI.Size = new Size(47, 19);
            cbAVI.TabIndex = 0;
            cbAVI.Text = "avi";
            cbAVI.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(0, 320);
            label6.Name = "label6";
            label6.Padding = new Padding(6, 0, 0, 0);
            label6.Size = new Size(507, 23);
            label6.TabIndex = 9;
            label6.Text = "Image extensions:";
            // 
            // panelImageExtensions
            // 
            panelImageExtensions.Controls.Add(btnDeselectImageExt);
            panelImageExtensions.Controls.Add(btnSelectImageExt);
            panelImageExtensions.Controls.Add(cbAVIF);
            panelImageExtensions.Controls.Add(cbWEBP);
            panelImageExtensions.Controls.Add(cbBMP);
            panelImageExtensions.Controls.Add(cbTIFF);
            panelImageExtensions.Controls.Add(cbTIF);
            panelImageExtensions.Controls.Add(cbGIF);
            panelImageExtensions.Controls.Add(cbPNG);
            panelImageExtensions.Controls.Add(cbJPEG);
            panelImageExtensions.Controls.Add(cbJPG);
            panelImageExtensions.Dock = DockStyle.Top;
            panelImageExtensions.Location = new Point(0, 343);
            panelImageExtensions.Name = "panelImageExtensions";
            panelImageExtensions.Size = new Size(507, 85);
            panelImageExtensions.TabIndex = 10;
            // 
            // btnDeselectImageExt
            // 
            btnDeselectImageExt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDeselectImageExt.BackColor = Color.Lavender;
            btnDeselectImageExt.FlatAppearance.BorderSize = 0;
            btnDeselectImageExt.FlatStyle = FlatStyle.Flat;
            btnDeselectImageExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnDeselectImageExt.IconColor = Color.Black;
            btnDeselectImageExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDeselectImageExt.Location = new Point(402, 50);
            btnDeselectImageExt.Name = "btnDeselectImageExt";
            btnDeselectImageExt.Size = new Size(102, 32);
            btnDeselectImageExt.TabIndex = 12;
            btnDeselectImageExt.Text = "Deselect all";
            btnDeselectImageExt.UseVisualStyleBackColor = false;
            btnDeselectImageExt.Click += btnDeselectImageExt_Click;
            // 
            // btnSelectImageExt
            // 
            btnSelectImageExt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectImageExt.BackColor = Color.Lavender;
            btnSelectImageExt.FlatAppearance.BorderSize = 0;
            btnSelectImageExt.FlatStyle = FlatStyle.Flat;
            btnSelectImageExt.IconChar = FontAwesome.Sharp.IconChar.None;
            btnSelectImageExt.IconColor = Color.Black;
            btnSelectImageExt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSelectImageExt.Location = new Point(402, 3);
            btnSelectImageExt.Name = "btnSelectImageExt";
            btnSelectImageExt.Size = new Size(102, 32);
            btnSelectImageExt.TabIndex = 12;
            btnSelectImageExt.Text = "Select all";
            btnSelectImageExt.UseVisualStyleBackColor = false;
            btnSelectImageExt.Click += btnSelectImageExt_Click;
            // 
            // cbAVIF
            // 
            cbAVIF.AutoSize = true;
            cbAVIF.Location = new Point(127, 53);
            cbAVIF.Name = "cbAVIF";
            cbAVIF.Padding = new Padding(6, 0, 0, 0);
            cbAVIF.Size = new Size(51, 19);
            cbAVIF.TabIndex = 8;
            cbAVIF.Text = "avif";
            cbAVIF.UseVisualStyleBackColor = true;
            // 
            // cbWEBP
            // 
            cbWEBP.AutoSize = true;
            cbWEBP.Location = new Point(127, 28);
            cbWEBP.Name = "cbWEBP";
            cbWEBP.Padding = new Padding(6, 0, 0, 0);
            cbWEBP.Size = new Size(61, 19);
            cbWEBP.TabIndex = 7;
            cbWEBP.Text = "webp";
            cbWEBP.UseVisualStyleBackColor = true;
            // 
            // cbBMP
            // 
            cbBMP.AutoSize = true;
            cbBMP.Location = new Point(127, 3);
            cbBMP.Name = "cbBMP";
            cbBMP.Padding = new Padding(6, 0, 0, 0);
            cbBMP.Size = new Size(57, 19);
            cbBMP.TabIndex = 6;
            cbBMP.Text = "bmp";
            cbBMP.UseVisualStyleBackColor = true;
            // 
            // cbTIFF
            // 
            cbTIFF.AutoSize = true;
            cbTIFF.Location = new Point(65, 53);
            cbTIFF.Name = "cbTIFF";
            cbTIFF.Padding = new Padding(6, 0, 0, 0);
            cbTIFF.Size = new Size(47, 19);
            cbTIFF.TabIndex = 5;
            cbTIFF.Text = "tiff";
            cbTIFF.UseVisualStyleBackColor = true;
            // 
            // cbTIF
            // 
            cbTIF.AutoSize = true;
            cbTIF.Location = new Point(65, 28);
            cbTIF.Name = "cbTIF";
            cbTIF.Padding = new Padding(6, 0, 0, 0);
            cbTIF.Size = new Size(43, 19);
            cbTIF.TabIndex = 4;
            cbTIF.Text = "tif";
            cbTIF.UseVisualStyleBackColor = true;
            // 
            // cbGIF
            // 
            cbGIF.AutoSize = true;
            cbGIF.Location = new Point(65, 3);
            cbGIF.Name = "cbGIF";
            cbGIF.Padding = new Padding(6, 0, 0, 0);
            cbGIF.Size = new Size(46, 19);
            cbGIF.TabIndex = 3;
            cbGIF.Text = "gif";
            cbGIF.UseVisualStyleBackColor = true;
            // 
            // cbPNG
            // 
            cbPNG.AutoSize = true;
            cbPNG.Location = new Point(3, 53);
            cbPNG.Name = "cbPNG";
            cbPNG.Padding = new Padding(6, 0, 0, 0);
            cbPNG.Size = new Size(53, 19);
            cbPNG.TabIndex = 2;
            cbPNG.Text = "png";
            cbPNG.UseVisualStyleBackColor = true;
            // 
            // cbJPEG
            // 
            cbJPEG.AutoSize = true;
            cbJPEG.Location = new Point(3, 28);
            cbJPEG.Name = "cbJPEG";
            cbJPEG.Padding = new Padding(6, 0, 0, 0);
            cbJPEG.Size = new Size(55, 19);
            cbJPEG.TabIndex = 1;
            cbJPEG.Text = "jpeg";
            cbJPEG.UseVisualStyleBackColor = true;
            // 
            // cbJPG
            // 
            cbJPG.AutoSize = true;
            cbJPG.Location = new Point(3, 3);
            cbJPG.Name = "cbJPG";
            cbJPG.Padding = new Padding(6, 0, 0, 0);
            cbJPG.Size = new Size(49, 19);
            cbJPG.TabIndex = 0;
            cbJPG.Text = "jpg";
            cbJPG.UseVisualStyleBackColor = true;
            // 
            // cbFilterApply
            // 
            cbFilterApply.AutoSize = true;
            cbFilterApply.Dock = DockStyle.Top;
            cbFilterApply.Location = new Point(0, 428);
            cbFilterApply.Name = "cbFilterApply";
            cbFilterApply.Padding = new Padding(9, 0, 0, 8);
            cbFilterApply.Size = new Size(507, 27);
            cbFilterApply.TabIndex = 11;
            cbFilterApply.Text = "Also apply filter to custom list playback";
            cbFilterApply.UseVisualStyleBackColor = true;
            // 
            // cbShufflePlayer
            // 
            cbShufflePlayer.Location = new Point(162, 144);
            cbShufflePlayer.Name = "cbShufflePlayer";
            cbShufflePlayer.Size = new Size(120, 31);
            cbShufflePlayer.TabIndex = 12;
            cbShufflePlayer.Text = "Shuffle Playlist";
            cbShufflePlayer.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbLeftMousePause);
            panel2.Controls.Add(label7);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 455);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(6, 0, 0, 0);
            panel2.Size = new Size(507, 116);
            panel2.TabIndex = 13;
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
            // PlayerUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            Controls.Add(panel2);
            Controls.Add(cbShufflePlayer);
            Controls.Add(cbLoopPlayer);
            Controls.Add(cbFilterApply);
            Controls.Add(panelImageExtensions);
            Controls.Add(label6);
            Controls.Add(panelVideoExtensions);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PlayerUserControl";
            Size = new Size(507, 574);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelVideoExtensions.ResumeLayout(false);
            panelVideoExtensions.PerformLayout();
            panelImageExtensions.ResumeLayout(false);
            panelImageExtensions.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel1;
        private RadioButton rbDateModified;
        private RadioButton rbDateCreated;
        private Label label3;
        private CheckBox cbLoopPlayer;
        private Label label4;
        private Label label5;
        private Panel panelVideoExtensions;
        private CheckBox cbAVI;
        private CheckBox cbAVCHD;
        private CheckBox cbF4V;
        private CheckBox cbWMV;
        private CheckBox cbWEBM;
        private CheckBox cbMP4;
        private CheckBox cbMOV;
        private CheckBox cbMKV;
        private CheckBox cbM4V;
        private CheckBox cbFLV;
        private Label label6;
        private Panel panelImageExtensions;
        private CheckBox cbJPG;
        private CheckBox cbAVIF;
        private CheckBox cbWEBP;
        private CheckBox cbBMP;
        private CheckBox cbTIFF;
        private CheckBox cbTIF;
        private CheckBox cbGIF;
        private CheckBox cbPNG;
        private CheckBox cbJPEG;
        private FontAwesome.Sharp.IconButton btnSelectVideoExt;
        private FontAwesome.Sharp.IconButton btnDeselectVideoExt;
        private FontAwesome.Sharp.IconButton btnDeselectImageExt;
        private FontAwesome.Sharp.IconButton btnSelectImageExt;
        private CheckBox cbFilterApply;
        private CheckBox cbShufflePlayer;
        private Panel panel2;
        private CheckBox cbLeftMousePause;
        private Label label7;
    }
}
