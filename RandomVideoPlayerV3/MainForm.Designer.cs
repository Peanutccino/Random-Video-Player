using RandomVideoPlayer.Controls;

namespace RandomVideoPlayer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelBottom = new Panel();
            tableLayoutBottomPanel = new TableLayoutPanel();
            tableLayoutButtons = new TableLayoutPanel();
            btnTimer = new FontAwesome.Sharp.IconButton();
            pbVolume = new FlatProgressBar();
            btnMuteToggle = new FontAwesome.Sharp.IconButton();
            btnSettings = new FontAwesome.Sharp.IconButton();
            btnStartFromFile = new FontAwesome.Sharp.IconButton();
            btnAddToQueue = new FontAwesome.Sharp.IconButton();
            btnTouch = new FontAwesome.Sharp.IconButton();
            btnAutoSkip = new FontAwesome.Sharp.IconButton();
            btnSourceSelector = new Button();
            btnRepeat = new FontAwesome.Sharp.IconButton();
            btnShuffle = new FontAwesome.Sharp.IconButton();
            btnMoveTo = new FontAwesome.Sharp.IconButton();
            btnAddToFav = new FontAwesome.Sharp.IconButton();
            btnListAdd = new Button();
            btnRemove = new FontAwesome.Sharp.IconButton();
            btnListBrowser = new FontAwesome.Sharp.IconButton();
            btnFileBrowse = new FontAwesome.Sharp.IconButton();
            btnNext = new FontAwesome.Sharp.IconButton();
            btnPrevious = new FontAwesome.Sharp.IconButton();
            btnPlay = new FontAwesome.Sharp.IconButton();
            tableLayoutBottomLabel = new TableLayoutPanel();
            lblDurationInfo = new Label();
            lblSpeed = new Label();
            lblCurrentInfo = new EllipsisAlignedLabel();
            panelProgresBar = new Panel();
            pbPlayerProgress = new FlatProgressBar();
            panelTop = new Panel();
            tableLayoutPanelTop = new TableLayoutPanel();
            btnVrMenu = new Button();
            btnExitForm = new FontAwesome.Sharp.IconButton();
            btnMaximizeForm = new FontAwesome.Sharp.IconButton();
            btnMinimizeForm = new FontAwesome.Sharp.IconButton();
            lblTitleBar = new Label();
            btnScriptMenu = new Button();
            btnAudioTrackMenu = new Button();
            btnSubtitleMenu = new Button();
            panelPlayerMPV = new Panel();
            timerProgressUpdate = new System.Windows.Forms.Timer(components);
            toolTipInfo = new ToolTip(components);
            fbDialog = new FolderBrowserDialog();
            timeVolumeCheck = new System.Windows.Forms.Timer(components);
            toolTipUI = new ToolTip(components);
            timerAutoSkipCheck = new System.Windows.Forms.Timer(components);
            timerScriptProgressionUpdate = new System.Windows.Forms.Timer(components);
            panelBottom.SuspendLayout();
            tableLayoutBottomPanel.SuspendLayout();
            tableLayoutButtons.SuspendLayout();
            tableLayoutBottomLabel.SuspendLayout();
            panelProgresBar.SuspendLayout();
            panelTop.SuspendLayout();
            tableLayoutPanelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(253, 83, 146);
            panelBottom.Controls.Add(tableLayoutBottomPanel);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 311);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1015, 80);
            panelBottom.TabIndex = 0;
            // 
            // tableLayoutBottomPanel
            // 
            tableLayoutBottomPanel.BackColor = Color.Yellow;
            tableLayoutBottomPanel.ColumnCount = 1;
            tableLayoutBottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutBottomPanel.Controls.Add(tableLayoutButtons, 0, 1);
            tableLayoutBottomPanel.Controls.Add(tableLayoutBottomLabel, 0, 2);
            tableLayoutBottomPanel.Controls.Add(panelProgresBar, 0, 0);
            tableLayoutBottomPanel.Dock = DockStyle.Fill;
            tableLayoutBottomPanel.Location = new Point(0, 0);
            tableLayoutBottomPanel.Margin = new Padding(0, 0, 0, 3);
            tableLayoutBottomPanel.Name = "tableLayoutBottomPanel";
            tableLayoutBottomPanel.RowCount = 3;
            tableLayoutBottomPanel.RowStyles.Add(new RowStyle());
            tableLayoutBottomPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutBottomPanel.RowStyles.Add(new RowStyle());
            tableLayoutBottomPanel.Size = new Size(1015, 80);
            tableLayoutBottomPanel.TabIndex = 0;
            // 
            // tableLayoutButtons
            // 
            tableLayoutButtons.BackColor = Color.Gold;
            tableLayoutButtons.ColumnCount = 21;
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.ColumnStyles.Add(new ColumnStyle());
            tableLayoutButtons.Controls.Add(btnTimer, 12, 0);
            tableLayoutButtons.Controls.Add(pbVolume, 20, 0);
            tableLayoutButtons.Controls.Add(btnMuteToggle, 19, 0);
            tableLayoutButtons.Controls.Add(btnSettings, 18, 0);
            tableLayoutButtons.Controls.Add(btnStartFromFile, 17, 0);
            tableLayoutButtons.Controls.Add(btnAddToQueue, 16, 0);
            tableLayoutButtons.Controls.Add(btnTouch, 14, 0);
            tableLayoutButtons.Controls.Add(btnAutoSkip, 13, 0);
            tableLayoutButtons.Controls.Add(btnSourceSelector, 11, 0);
            tableLayoutButtons.Controls.Add(btnRepeat, 10, 0);
            tableLayoutButtons.Controls.Add(btnShuffle, 9, 0);
            tableLayoutButtons.Controls.Add(btnMoveTo, 8, 0);
            tableLayoutButtons.Controls.Add(btnAddToFav, 7, 0);
            tableLayoutButtons.Controls.Add(btnListAdd, 6, 0);
            tableLayoutButtons.Controls.Add(btnRemove, 5, 0);
            tableLayoutButtons.Controls.Add(btnListBrowser, 4, 0);
            tableLayoutButtons.Controls.Add(btnFileBrowse, 3, 0);
            tableLayoutButtons.Controls.Add(btnNext, 2, 0);
            tableLayoutButtons.Controls.Add(btnPrevious, 1, 0);
            tableLayoutButtons.Controls.Add(btnPlay, 0, 0);
            tableLayoutButtons.Dock = DockStyle.Fill;
            tableLayoutButtons.Location = new Point(0, 23);
            tableLayoutButtons.Margin = new Padding(0);
            tableLayoutButtons.Name = "tableLayoutButtons";
            tableLayoutButtons.RowCount = 1;
            tableLayoutButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutButtons.Size = new Size(1015, 37);
            tableLayoutButtons.TabIndex = 2;
            // 
            // btnTimer
            // 
            btnTimer.Dock = DockStyle.Fill;
            btnTimer.FlatAppearance.BorderSize = 0;
            btnTimer.FlatStyle = FlatStyle.Flat;
            btnTimer.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            btnTimer.IconColor = Color.Black;
            btnTimer.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnTimer.IconSize = 29;
            btnTimer.Location = new Point(596, 3);
            btnTimer.Margin = new Padding(10, 3, 10, 3);
            btnTimer.Name = "btnTimer";
            btnTimer.Size = new Size(30, 31);
            btnTimer.TabIndex = 35;
            btnTimer.UseVisualStyleBackColor = true;
            btnTimer.Click += btnTimer_Click;
            // 
            // pbVolume
            // 
            pbVolume.BorderColor = Color.Black;
            pbVolume.BorderThickness = 5;
            pbVolume.CompletedBrush = Color.Black;
            pbVolume.Dock = DockStyle.Fill;
            pbVolume.Location = new Point(904, 8);
            pbVolume.Margin = new Padding(3, 8, 3, 9);
            pbVolume.Maximum = 100;
            pbVolume.Minimum = 0;
            pbVolume.MouseoverBrush = Color.Black;
            pbVolume.Name = "pbVolume";
            pbVolume.RemainingBrush = Color.FromArgb(253, 83, 146);
            pbVolume.SeekIndicatorAlpha = 80;
            pbVolume.SeekValue = null;
            pbVolume.ShowBorder = true;
            pbVolume.Size = new Size(108, 20);
            pbVolume.TabIndex = 34;
            pbVolume.Text = "flatProgressBar1";
            pbVolume.Value = 50;
            pbVolume.MouseDown += pbVolume_MouseDown;
            // 
            // btnMuteToggle
            // 
            btnMuteToggle.Dock = DockStyle.Fill;
            btnMuteToggle.FlatAppearance.BorderSize = 0;
            btnMuteToggle.FlatStyle = FlatStyle.Flat;
            btnMuteToggle.IconChar = FontAwesome.Sharp.IconChar.VolumeOff;
            btnMuteToggle.IconColor = Color.Black;
            btnMuteToggle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMuteToggle.IconSize = 21;
            btnMuteToggle.ImageAlign = ContentAlignment.MiddleLeft;
            btnMuteToggle.Location = new Point(858, 3);
            btnMuteToggle.Margin = new Padding(3, 3, 10, 3);
            btnMuteToggle.Name = "btnMuteToggle";
            btnMuteToggle.Size = new Size(33, 31);
            btnMuteToggle.TabIndex = 33;
            btnMuteToggle.UseVisualStyleBackColor = true;
            btnMuteToggle.Click += btnMuteToggle_Click;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Fill;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnSettings.IconColor = Color.Black;
            btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSettings.IconSize = 28;
            btnSettings.Location = new Point(815, 3);
            btnSettings.Margin = new Padding(3, 3, 10, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(30, 31);
            btnSettings.TabIndex = 32;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnStartFromFile
            // 
            btnStartFromFile.Dock = DockStyle.Fill;
            btnStartFromFile.FlatAppearance.BorderSize = 0;
            btnStartFromFile.FlatStyle = FlatStyle.Flat;
            btnStartFromFile.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            btnStartFromFile.IconColor = Color.Cyan;
            btnStartFromFile.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnStartFromFile.IconSize = 28;
            btnStartFromFile.Location = new Point(777, 3);
            btnStartFromFile.Margin = new Padding(3, 3, 5, 3);
            btnStartFromFile.Name = "btnStartFromFile";
            btnStartFromFile.Size = new Size(30, 31);
            btnStartFromFile.TabIndex = 31;
            btnStartFromFile.UseVisualStyleBackColor = true;
            btnStartFromFile.Click += btnStartFromFile_Click;
            // 
            // btnAddToQueue
            // 
            btnAddToQueue.Dock = DockStyle.Fill;
            btnAddToQueue.FlatAppearance.BorderSize = 0;
            btnAddToQueue.FlatStyle = FlatStyle.Flat;
            btnAddToQueue.IconChar = FontAwesome.Sharp.IconChar.CirclePlus;
            btnAddToQueue.IconColor = Color.Cyan;
            btnAddToQueue.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddToQueue.IconSize = 28;
            btnAddToQueue.Location = new Point(739, 3);
            btnAddToQueue.Margin = new Padding(3, 3, 5, 3);
            btnAddToQueue.Name = "btnAddToQueue";
            btnAddToQueue.Size = new Size(30, 31);
            btnAddToQueue.TabIndex = 30;
            btnAddToQueue.UseVisualStyleBackColor = true;
            btnAddToQueue.Visible = false;
            btnAddToQueue.Click += btnAddToQueue_Click;
            // 
            // btnTouch
            // 
            btnTouch.Dock = DockStyle.Fill;
            btnTouch.FlatAppearance.BorderSize = 0;
            btnTouch.FlatStyle = FlatStyle.Flat;
            btnTouch.IconChar = FontAwesome.Sharp.IconChar.Location;
            btnTouch.IconColor = Color.Black;
            btnTouch.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnTouch.IconSize = 29;
            btnTouch.Location = new Point(696, 3);
            btnTouch.Margin = new Padding(10, 3, 10, 3);
            btnTouch.Name = "btnTouch";
            btnTouch.Size = new Size(30, 31);
            btnTouch.TabIndex = 28;
            btnTouch.UseVisualStyleBackColor = true;
            btnTouch.Click += btnTouch_Click;
            // 
            // btnAutoSkip
            // 
            btnAutoSkip.Dock = DockStyle.Fill;
            btnAutoSkip.FlatAppearance.BorderSize = 0;
            btnAutoSkip.FlatStyle = FlatStyle.Flat;
            btnAutoSkip.IconChar = FontAwesome.Sharp.IconChar.Forward;
            btnAutoSkip.IconColor = Color.Black;
            btnAutoSkip.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAutoSkip.IconSize = 29;
            btnAutoSkip.Location = new Point(646, 3);
            btnAutoSkip.Margin = new Padding(10, 3, 10, 3);
            btnAutoSkip.Name = "btnAutoSkip";
            btnAutoSkip.Size = new Size(30, 31);
            btnAutoSkip.TabIndex = 27;
            btnAutoSkip.UseVisualStyleBackColor = true;
            btnAutoSkip.Click += btnAutoSkip_Click;
            // 
            // btnSourceSelector
            // 
            btnSourceSelector.Dock = DockStyle.Fill;
            btnSourceSelector.FlatAppearance.BorderSize = 0;
            btnSourceSelector.FlatStyle = FlatStyle.Flat;
            btnSourceSelector.Image = (Image)resources.GetObject("btnSourceSelector.Image");
            btnSourceSelector.Location = new Point(546, 3);
            btnSourceSelector.Margin = new Padding(10, 3, 10, 3);
            btnSourceSelector.Name = "btnSourceSelector";
            btnSourceSelector.Padding = new Padding(0, 0, 0, 1);
            btnSourceSelector.Size = new Size(30, 31);
            btnSourceSelector.TabIndex = 26;
            btnSourceSelector.UseVisualStyleBackColor = true;
            btnSourceSelector.Click += btnSourceSelector_Click;
            // 
            // btnRepeat
            // 
            btnRepeat.Dock = DockStyle.Fill;
            btnRepeat.FlatAppearance.BorderSize = 0;
            btnRepeat.FlatStyle = FlatStyle.Flat;
            btnRepeat.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            btnRepeat.IconColor = Color.Black;
            btnRepeat.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnRepeat.IconSize = 29;
            btnRepeat.Location = new Point(496, 3);
            btnRepeat.Margin = new Padding(10, 3, 10, 3);
            btnRepeat.Name = "btnRepeat";
            btnRepeat.Size = new Size(30, 31);
            btnRepeat.TabIndex = 25;
            btnRepeat.UseVisualStyleBackColor = true;
            btnRepeat.Click += btnRepeat_Click;
            // 
            // btnShuffle
            // 
            btnShuffle.Dock = DockStyle.Fill;
            btnShuffle.FlatAppearance.BorderSize = 0;
            btnShuffle.FlatStyle = FlatStyle.Flat;
            btnShuffle.IconChar = FontAwesome.Sharp.IconChar.Shuffle;
            btnShuffle.IconColor = Color.Black;
            btnShuffle.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnShuffle.IconSize = 29;
            btnShuffle.Location = new Point(446, 3);
            btnShuffle.Margin = new Padding(10, 3, 10, 3);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new Size(30, 31);
            btnShuffle.TabIndex = 24;
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Click += btnShuffle_Click;
            // 
            // btnMoveTo
            // 
            btnMoveTo.Dock = DockStyle.Fill;
            btnMoveTo.Enabled = false;
            btnMoveTo.FlatAppearance.BorderSize = 0;
            btnMoveTo.FlatStyle = FlatStyle.Flat;
            btnMoveTo.IconChar = FontAwesome.Sharp.IconChar.Copy;
            btnMoveTo.IconColor = Color.Black;
            btnMoveTo.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnMoveTo.IconSize = 29;
            btnMoveTo.Location = new Point(396, 3);
            btnMoveTo.Margin = new Padding(10, 3, 10, 3);
            btnMoveTo.Name = "btnMoveTo";
            btnMoveTo.Size = new Size(30, 31);
            btnMoveTo.TabIndex = 23;
            btnMoveTo.UseVisualStyleBackColor = true;
            btnMoveTo.MouseDown += btnMoveTo_MouseDown;
            // 
            // btnAddToFav
            // 
            btnAddToFav.Dock = DockStyle.Fill;
            btnAddToFav.Enabled = false;
            btnAddToFav.FlatAppearance.BorderSize = 0;
            btnAddToFav.FlatStyle = FlatStyle.Flat;
            btnAddToFav.IconChar = FontAwesome.Sharp.IconChar.Heart;
            btnAddToFav.IconColor = Color.Black;
            btnAddToFav.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAddToFav.IconSize = 29;
            btnAddToFav.Location = new Point(346, 3);
            btnAddToFav.Margin = new Padding(10, 3, 10, 3);
            btnAddToFav.Name = "btnAddToFav";
            btnAddToFav.Size = new Size(30, 31);
            btnAddToFav.TabIndex = 22;
            btnAddToFav.UseVisualStyleBackColor = true;
            btnAddToFav.Click += btnAddToFav_Click;
            // 
            // btnListAdd
            // 
            btnListAdd.Dock = DockStyle.Fill;
            btnListAdd.Enabled = false;
            btnListAdd.FlatAppearance.BorderSize = 0;
            btnListAdd.FlatStyle = FlatStyle.Flat;
            btnListAdd.Image = (Image)resources.GetObject("btnListAdd.Image");
            btnListAdd.Location = new Point(296, 3);
            btnListAdd.Margin = new Padding(10, 3, 10, 3);
            btnListAdd.Name = "btnListAdd";
            btnListAdd.Padding = new Padding(0, 0, 0, 1);
            btnListAdd.Size = new Size(30, 31);
            btnListAdd.TabIndex = 21;
            btnListAdd.UseVisualStyleBackColor = true;
            btnListAdd.MouseDown += btnListAdd_MouseDown;
            // 
            // btnRemove
            // 
            btnRemove.Dock = DockStyle.Fill;
            btnRemove.Enabled = false;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnRemove.IconColor = Color.Black;
            btnRemove.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRemove.IconSize = 24;
            btnRemove.Location = new Point(246, 3);
            btnRemove.Margin = new Padding(10, 3, 10, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(30, 31);
            btnRemove.TabIndex = 19;
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnListBrowser
            // 
            btnListBrowser.Dock = DockStyle.Fill;
            btnListBrowser.FlatAppearance.BorderSize = 0;
            btnListBrowser.FlatStyle = FlatStyle.Flat;
            btnListBrowser.IconChar = FontAwesome.Sharp.IconChar.ListDots;
            btnListBrowser.IconColor = Color.Black;
            btnListBrowser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnListBrowser.IconSize = 28;
            btnListBrowser.Location = new Point(196, 3);
            btnListBrowser.Margin = new Padding(10, 3, 10, 3);
            btnListBrowser.Name = "btnListBrowser";
            btnListBrowser.Size = new Size(30, 31);
            btnListBrowser.TabIndex = 18;
            btnListBrowser.UseVisualStyleBackColor = true;
            btnListBrowser.Click += btnListBrowser_Click;
            // 
            // btnFileBrowse
            // 
            btnFileBrowse.Dock = DockStyle.Fill;
            btnFileBrowse.FlatAppearance.BorderSize = 0;
            btnFileBrowse.FlatStyle = FlatStyle.Flat;
            btnFileBrowse.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnFileBrowse.IconColor = Color.Black;
            btnFileBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFileBrowse.IconSize = 28;
            btnFileBrowse.Location = new Point(146, 3);
            btnFileBrowse.Margin = new Padding(10, 3, 10, 3);
            btnFileBrowse.Name = "btnFileBrowse";
            btnFileBrowse.Size = new Size(30, 31);
            btnFileBrowse.TabIndex = 17;
            btnFileBrowse.UseVisualStyleBackColor = true;
            btnFileBrowse.Click += btnFileBrowse_Click;
            // 
            // btnNext
            // 
            btnNext.Dock = DockStyle.Fill;
            btnNext.Enabled = false;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.IconChar = FontAwesome.Sharp.IconChar.ForwardStep;
            btnNext.IconColor = Color.Black;
            btnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNext.IconSize = 28;
            btnNext.Location = new Point(96, 3);
            btnNext.Margin = new Padding(10, 3, 10, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(30, 31);
            btnNext.TabIndex = 5;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Dock = DockStyle.Fill;
            btnPrevious.Enabled = false;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.IconChar = FontAwesome.Sharp.IconChar.BackwardStep;
            btnPrevious.IconColor = Color.Black;
            btnPrevious.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrevious.IconSize = 28;
            btnPrevious.Location = new Point(46, 3);
            btnPrevious.Margin = new Padding(10, 3, 10, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(30, 31);
            btnPrevious.TabIndex = 4;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnPlay
            // 
            btnPlay.Dock = DockStyle.Fill;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnPlay.IconColor = Color.Black;
            btnPlay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPlay.IconSize = 30;
            btnPlay.Location = new Point(3, 3);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(30, 31);
            btnPlay.TabIndex = 2;
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // tableLayoutBottomLabel
            // 
            tableLayoutBottomLabel.BackColor = Color.Chartreuse;
            tableLayoutBottomLabel.ColumnCount = 3;
            tableLayoutBottomLabel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutBottomLabel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutBottomLabel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutBottomLabel.Controls.Add(lblDurationInfo, 2, 0);
            tableLayoutBottomLabel.Controls.Add(lblSpeed, 1, 0);
            tableLayoutBottomLabel.Controls.Add(lblCurrentInfo, 0, 0);
            tableLayoutBottomLabel.Dock = DockStyle.Fill;
            tableLayoutBottomLabel.Location = new Point(0, 60);
            tableLayoutBottomLabel.Margin = new Padding(0);
            tableLayoutBottomLabel.Name = "tableLayoutBottomLabel";
            tableLayoutBottomLabel.RowCount = 1;
            tableLayoutBottomLabel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutBottomLabel.Size = new Size(1015, 20);
            tableLayoutBottomLabel.TabIndex = 3;
            // 
            // lblDurationInfo
            // 
            lblDurationInfo.Dock = DockStyle.Right;
            lblDurationInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDurationInfo.Location = new Point(898, 0);
            lblDurationInfo.Name = "lblDurationInfo";
            lblDurationInfo.Size = new Size(114, 20);
            lblDurationInfo.TabIndex = 17;
            lblDurationInfo.Text = "00:00:00 / 00:00:00";
            lblDurationInfo.TextAlign = ContentAlignment.BottomRight;
            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Dock = DockStyle.Right;
            lblSpeed.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSpeed.Location = new Point(893, 0);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(0, 20);
            lblSpeed.TabIndex = 16;
            lblSpeed.TextAlign = ContentAlignment.BottomRight;
            // 
            // lblCurrentInfo
            // 
            lblCurrentInfo.AutoEllipsis = true;
            lblCurrentInfo.Cursor = Cursors.Hand;
            lblCurrentInfo.Dock = DockStyle.Fill;
            lblCurrentInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCurrentInfo.Location = new Point(3, 0);
            lblCurrentInfo.Name = "lblCurrentInfo";
            lblCurrentInfo.Size = new Size(883, 20);
            lblCurrentInfo.TabIndex = 15;
            lblCurrentInfo.Text = "Current Folder";
            lblCurrentInfo.TextAlign = ContentAlignment.BottomLeft;
            lblCurrentInfo.DoubleClick += lblCurrentInfo_DoubleClick;
            // 
            // panelProgresBar
            // 
            panelProgresBar.BackColor = Color.Cornsilk;
            panelProgresBar.Controls.Add(pbPlayerProgress);
            panelProgresBar.Dock = DockStyle.Fill;
            panelProgresBar.Location = new Point(0, 0);
            panelProgresBar.Margin = new Padding(0, 0, 0, 3);
            panelProgresBar.Name = "panelProgresBar";
            panelProgresBar.Size = new Size(1015, 20);
            panelProgresBar.TabIndex = 4;
            // 
            // pbPlayerProgress
            // 
            pbPlayerProgress.BorderColor = Color.Black;
            pbPlayerProgress.BorderThickness = 1;
            pbPlayerProgress.CompletedBrush = Color.FromArgb(248, 111, 100);
            pbPlayerProgress.Dock = DockStyle.Fill;
            pbPlayerProgress.Location = new Point(0, 0);
            pbPlayerProgress.Margin = new Padding(0, 0, 0, 3);
            pbPlayerProgress.Maximum = 60;
            pbPlayerProgress.Minimum = 0;
            pbPlayerProgress.MouseoverBrush = Color.FromArgb(250, 164, 158);
            pbPlayerProgress.Name = "pbPlayerProgress";
            pbPlayerProgress.RemainingBrush = Color.Black;
            pbPlayerProgress.SeekIndicatorAlpha = 80;
            pbPlayerProgress.SeekValue = null;
            pbPlayerProgress.ShowBorder = false;
            pbPlayerProgress.Size = new Size(1015, 20);
            pbPlayerProgress.TabIndex = 1;
            pbPlayerProgress.Text = "flatProgressBar1";
            pbPlayerProgress.Value = 0;
            pbPlayerProgress.MouseDown += pbPlayerProgress_MouseDown;
            pbPlayerProgress.MouseLeave += pbPlayerProgress_MouseLeave;
            pbPlayerProgress.MouseMove += pbPlayerProgress_MouseMove;
            pbPlayerProgress.MouseUp += pbPlayerProgress_MouseUp;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(253, 83, 146);
            panelTop.Controls.Add(tableLayoutPanelTop);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1015, 20);
            panelTop.TabIndex = 1;
            // 
            // tableLayoutPanelTop
            // 
            tableLayoutPanelTop.BackColor = Color.FromArgb(128, 255, 255);
            tableLayoutPanelTop.ColumnCount = 8;
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTop.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelTop.Controls.Add(btnVrMenu, 3, 0);
            tableLayoutPanelTop.Controls.Add(btnExitForm, 7, 0);
            tableLayoutPanelTop.Controls.Add(btnMaximizeForm, 6, 0);
            tableLayoutPanelTop.Controls.Add(btnMinimizeForm, 5, 0);
            tableLayoutPanelTop.Controls.Add(lblTitleBar, 4, 0);
            tableLayoutPanelTop.Controls.Add(btnScriptMenu, 2, 0);
            tableLayoutPanelTop.Controls.Add(btnAudioTrackMenu, 1, 0);
            tableLayoutPanelTop.Controls.Add(btnSubtitleMenu, 0, 0);
            tableLayoutPanelTop.Dock = DockStyle.Fill;
            tableLayoutPanelTop.Location = new Point(0, 0);
            tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            tableLayoutPanelTop.RowCount = 1;
            tableLayoutPanelTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanelTop.Size = new Size(1015, 20);
            tableLayoutPanelTop.TabIndex = 0;
            // 
            // btnVrMenu
            // 
            btnVrMenu.Dock = DockStyle.Fill;
            btnVrMenu.FlatAppearance.BorderSize = 0;
            btnVrMenu.FlatStyle = FlatStyle.Flat;
            btnVrMenu.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            btnVrMenu.ForeColor = Color.Indigo;
            btnVrMenu.Location = new Point(132, 0);
            btnVrMenu.Margin = new Padding(0);
            btnVrMenu.Name = "btnVrMenu";
            btnVrMenu.Size = new Size(30, 20);
            btnVrMenu.TabIndex = 12;
            btnVrMenu.Text = "VR";
            btnVrMenu.UseVisualStyleBackColor = true;
            btnVrMenu.Click += btnVrMenu_Click;
            // 
            // btnExitForm
            // 
            btnExitForm.Dock = DockStyle.Fill;
            btnExitForm.FlatAppearance.BorderSize = 0;
            btnExitForm.FlatAppearance.MouseOverBackColor = Color.Red;
            btnExitForm.FlatStyle = FlatStyle.Flat;
            btnExitForm.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnExitForm.IconColor = Color.Black;
            btnExitForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExitForm.IconSize = 15;
            btnExitForm.Location = new Point(985, 0);
            btnExitForm.Margin = new Padding(0);
            btnExitForm.Name = "btnExitForm";
            btnExitForm.Size = new Size(30, 20);
            btnExitForm.TabIndex = 11;
            btnExitForm.UseVisualStyleBackColor = true;
            btnExitForm.Click += btnExitForm_Click;
            // 
            // btnMaximizeForm
            // 
            btnMaximizeForm.Dock = DockStyle.Fill;
            btnMaximizeForm.FlatAppearance.BorderSize = 0;
            btnMaximizeForm.FlatStyle = FlatStyle.Flat;
            btnMaximizeForm.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            btnMaximizeForm.IconColor = Color.Black;
            btnMaximizeForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMaximizeForm.IconSize = 15;
            btnMaximizeForm.Location = new Point(955, 0);
            btnMaximizeForm.Margin = new Padding(0);
            btnMaximizeForm.Name = "btnMaximizeForm";
            btnMaximizeForm.Size = new Size(30, 20);
            btnMaximizeForm.TabIndex = 10;
            btnMaximizeForm.UseVisualStyleBackColor = true;
            btnMaximizeForm.Click += btnMaximizeForm_Click;
            // 
            // btnMinimizeForm
            // 
            btnMinimizeForm.Dock = DockStyle.Fill;
            btnMinimizeForm.FlatAppearance.BorderSize = 0;
            btnMinimizeForm.FlatStyle = FlatStyle.Flat;
            btnMinimizeForm.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            btnMinimizeForm.IconColor = Color.Black;
            btnMinimizeForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimizeForm.IconSize = 15;
            btnMinimizeForm.Location = new Point(925, 0);
            btnMinimizeForm.Margin = new Padding(0);
            btnMinimizeForm.Name = "btnMinimizeForm";
            btnMinimizeForm.Size = new Size(30, 20);
            btnMinimizeForm.TabIndex = 9;
            btnMinimizeForm.UseVisualStyleBackColor = true;
            btnMinimizeForm.Click += btnMinimizeForm_Click;
            // 
            // lblTitleBar
            // 
            lblTitleBar.AutoEllipsis = true;
            lblTitleBar.Dock = DockStyle.Fill;
            lblTitleBar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTitleBar.Location = new Point(165, 0);
            lblTitleBar.Name = "lblTitleBar";
            lblTitleBar.Padding = new Padding(0, 0, 30, 0);
            lblTitleBar.Size = new Size(757, 20);
            lblTitleBar.TabIndex = 8;
            lblTitleBar.Text = "Random Video Player ";
            lblTitleBar.TextAlign = ContentAlignment.MiddleCenter;
            lblTitleBar.MouseDown += lblTitleBar_MouseDown;
            // 
            // btnScriptMenu
            // 
            btnScriptMenu.Dock = DockStyle.Fill;
            btnScriptMenu.FlatAppearance.BorderSize = 0;
            btnScriptMenu.FlatStyle = FlatStyle.Flat;
            btnScriptMenu.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            btnScriptMenu.ForeColor = Color.Indigo;
            btnScriptMenu.Location = new Point(84, 0);
            btnScriptMenu.Margin = new Padding(0);
            btnScriptMenu.Name = "btnScriptMenu";
            btnScriptMenu.Size = new Size(48, 20);
            btnScriptMenu.TabIndex = 7;
            btnScriptMenu.Text = "SCRIPT";
            btnScriptMenu.UseVisualStyleBackColor = true;
            btnScriptMenu.Click += btnScriptMenu_Click;
            // 
            // btnAudioTrackMenu
            // 
            btnAudioTrackMenu.Dock = DockStyle.Fill;
            btnAudioTrackMenu.FlatAppearance.BorderSize = 0;
            btnAudioTrackMenu.FlatStyle = FlatStyle.Flat;
            btnAudioTrackMenu.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            btnAudioTrackMenu.ForeColor = Color.Indigo;
            btnAudioTrackMenu.Location = new Point(42, 0);
            btnAudioTrackMenu.Margin = new Padding(0);
            btnAudioTrackMenu.Name = "btnAudioTrackMenu";
            btnAudioTrackMenu.Size = new Size(42, 20);
            btnAudioTrackMenu.TabIndex = 6;
            btnAudioTrackMenu.Text = "AUD";
            btnAudioTrackMenu.UseVisualStyleBackColor = true;
            btnAudioTrackMenu.Click += btnAudioTrackMenu_Click;
            // 
            // btnSubtitleMenu
            // 
            btnSubtitleMenu.Dock = DockStyle.Fill;
            btnSubtitleMenu.FlatAppearance.BorderSize = 0;
            btnSubtitleMenu.FlatStyle = FlatStyle.Flat;
            btnSubtitleMenu.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            btnSubtitleMenu.ForeColor = Color.Indigo;
            btnSubtitleMenu.Location = new Point(0, 0);
            btnSubtitleMenu.Margin = new Padding(0);
            btnSubtitleMenu.Name = "btnSubtitleMenu";
            btnSubtitleMenu.Size = new Size(42, 20);
            btnSubtitleMenu.TabIndex = 5;
            btnSubtitleMenu.Text = "SUB";
            btnSubtitleMenu.UseVisualStyleBackColor = true;
            btnSubtitleMenu.Click += btnSubtitleMenu_Click;
            // 
            // panelPlayerMPV
            // 
            panelPlayerMPV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPlayerMPV.BackColor = Color.Black;
            panelPlayerMPV.Location = new Point(0, 20);
            panelPlayerMPV.Name = "panelPlayerMPV";
            panelPlayerMPV.Size = new Size(1015, 297);
            panelPlayerMPV.TabIndex = 2;
            panelPlayerMPV.SizeChanged += panelPlayerMPV_SizeChanged;
            panelPlayerMPV.MouseDown += panelPlayerMPV_MouseDown;
            panelPlayerMPV.MouseMove += panelPlayerMPV_MouseMove;
            panelPlayerMPV.MouseUp += panelPlayerMPV_MouseUp;
            // 
            // timerProgressUpdate
            // 
            timerProgressUpdate.Enabled = true;
            timerProgressUpdate.Interval = 50;
            timerProgressUpdate.Tick += timerProgressUpdate_Tick;
            // 
            // timeVolumeCheck
            // 
            timeVolumeCheck.Enabled = true;
            timeVolumeCheck.Tick += timeVolumeCheck_Tick;
            // 
            // timerAutoSkipCheck
            // 
            timerAutoSkipCheck.Interval = 1000;
            timerAutoSkipCheck.Tick += timerAutoSkipCheck_Tick;
            // 
            // timerScriptProgressionUpdate
            // 
            timerScriptProgressionUpdate.Enabled = true;
            timerScriptProgressionUpdate.Interval = 200;
            timerScriptProgressionUpdate.Tick += timerScriptProgressionUpdate_Tick;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1015, 391);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Controls.Add(panelPlayerMPV);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 430);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RVP";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResizeEnd += MainForm_ResizeEnd;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            Resize += MainForm_Resize;
            panelBottom.ResumeLayout(false);
            tableLayoutBottomPanel.ResumeLayout(false);
            tableLayoutButtons.ResumeLayout(false);
            tableLayoutBottomLabel.ResumeLayout(false);
            tableLayoutBottomLabel.PerformLayout();
            panelProgresBar.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            tableLayoutPanelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBottom;
        private Panel panelTop;
        private Panel panelPlayerMPV;
        private System.Windows.Forms.Timer timerProgressUpdate;
        private ToolTip toolTipInfo;
        private FolderBrowserDialog fbDialog;
        private System.Windows.Forms.Timer timeVolumeCheck;
        private ToolTip toolTipUI;
        private System.Windows.Forms.Timer timerAutoSkipCheck;
        private TableLayoutPanel tableLayoutBottomPanel;
        private FlatProgressBar pbPlayerProgress;
        private TableLayoutPanel tableLayoutButtons;
        private FontAwesome.Sharp.IconButton btnPlay;
        private FontAwesome.Sharp.IconButton btnPrevious;
        private FontAwesome.Sharp.IconButton btnNext;
        private FontAwesome.Sharp.IconButton btnFileBrowse;
        private FontAwesome.Sharp.IconButton btnListBrowser;
        private FontAwesome.Sharp.IconButton btnRemove;
        private Button btnListAdd;
        private FontAwesome.Sharp.IconButton btnAddToFav;
        private FontAwesome.Sharp.IconButton btnMoveTo;
        private FontAwesome.Sharp.IconButton btnShuffle;
        private FontAwesome.Sharp.IconButton btnRepeat;
        private Button btnSourceSelector;
        private FontAwesome.Sharp.IconButton btnAutoSkip;
        private FontAwesome.Sharp.IconButton btnTouch;
        private FontAwesome.Sharp.IconButton btnAddToQueue;
        private FontAwesome.Sharp.IconButton btnStartFromFile;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnMuteToggle;
        private FlatProgressBar pbVolume;
        private TableLayoutPanel tableLayoutBottomLabel;
        private EllipsisAlignedLabel lblCurrentInfo;
        private Label lblSpeed;
        private Label lblDurationInfo;
        private TableLayoutPanel tableLayoutPanelTop;
        private Button btnSubtitleMenu;
        private Button btnAudioTrackMenu;
        private Button btnScriptMenu;
        private Label lblTitleBar;
        private FontAwesome.Sharp.IconButton btnMinimizeForm;
        private FontAwesome.Sharp.IconButton btnMaximizeForm;
        private FontAwesome.Sharp.IconButton btnExitForm;
        private FontAwesome.Sharp.IconButton btnTimer;
        private Button btnVrMenu;
        private Panel panelProgresBar;
        private System.Windows.Forms.Timer timerScriptProgressionUpdate;
    }
}