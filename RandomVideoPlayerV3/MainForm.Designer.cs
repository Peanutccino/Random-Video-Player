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
            panelExtraButtons = new Panel();
            btnAddToQueue = new FontAwesome.Sharp.IconButton();
            btnStartFromFile = new FontAwesome.Sharp.IconButton();
            btnSettings = new FontAwesome.Sharp.IconButton();
            btnMuteToggle = new FontAwesome.Sharp.IconButton();
            panelMainButtons = new Panel();
            btnPlay = new FontAwesome.Sharp.IconButton();
            btnPrevious = new FontAwesome.Sharp.IconButton();
            btnNext = new FontAwesome.Sharp.IconButton();
            btnFileBrowse = new FontAwesome.Sharp.IconButton();
            btnListBrowser = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            lblCurrentInfo = new Label();
            lblSpeed = new Label();
            lblDurationInfo = new Label();
            panelControls = new Panel();
            btnTouch = new FontAwesome.Sharp.IconButton();
            btnAutoSkip = new FontAwesome.Sharp.IconButton();
            btnSourceSelector = new Button();
            btnRepeat = new FontAwesome.Sharp.IconButton();
            btnMoveTo = new FontAwesome.Sharp.IconButton();
            btnRemove = new FontAwesome.Sharp.IconButton();
            btnShuffle = new FontAwesome.Sharp.IconButton();
            btnListAdd = new Button();
            btnAddToFav = new FontAwesome.Sharp.IconButton();
            pbVolume = new FlatProgressBar();
            pbPlayerProgress = new FlatProgressBar();
            panelTop = new Panel();
            btnScriptMenu = new Button();
            btnAudioTrackMenu = new Button();
            btnSubtitleMenu = new Button();
            lblTitleBar = new Label();
            btnMinimizeForm = new FontAwesome.Sharp.IconButton();
            btnMaximizeForm = new FontAwesome.Sharp.IconButton();
            btnExitForm = new FontAwesome.Sharp.IconButton();
            panelPlayerMPV = new Panel();
            timerProgressUpdate = new System.Windows.Forms.Timer(components);
            toolTipInfo = new ToolTip(components);
            fbDialog = new FolderBrowserDialog();
            timeVolumeCheck = new System.Windows.Forms.Timer(components);
            toolTipUI = new ToolTip(components);
            timerAutoSkipCheck = new System.Windows.Forms.Timer(components);
            panelBottom.SuspendLayout();
            panelExtraButtons.SuspendLayout();
            panelMainButtons.SuspendLayout();
            panel1.SuspendLayout();
            panelControls.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(253, 83, 146);
            panelBottom.Controls.Add(panelExtraButtons);
            panelBottom.Controls.Add(panelMainButtons);
            panelBottom.Controls.Add(panel1);
            panelBottom.Controls.Add(panelControls);
            panelBottom.Controls.Add(pbVolume);
            panelBottom.Controls.Add(pbPlayerProgress);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 316);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1015, 75);
            panelBottom.TabIndex = 0;
            // 
            // panelExtraButtons
            // 
            panelExtraButtons.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelExtraButtons.BackColor = Color.FromArgb(253, 83, 146);
            panelExtraButtons.Controls.Add(btnAddToQueue);
            panelExtraButtons.Controls.Add(btnStartFromFile);
            panelExtraButtons.Controls.Add(btnSettings);
            panelExtraButtons.Controls.Add(btnMuteToggle);
            panelExtraButtons.Location = new Point(742, 23);
            panelExtraButtons.Name = "panelExtraButtons";
            panelExtraButtons.Size = new Size(159, 29);
            panelExtraButtons.TabIndex = 26;
            // 
            // btnAddToQueue
            // 
            btnAddToQueue.FlatAppearance.BorderSize = 0;
            btnAddToQueue.FlatStyle = FlatStyle.Flat;
            btnAddToQueue.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            btnAddToQueue.IconColor = Color.Cyan;
            btnAddToQueue.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddToQueue.IconSize = 28;
            btnAddToQueue.Location = new Point(0, 0);
            btnAddToQueue.Margin = new Padding(3, 3, 5, 3);
            btnAddToQueue.Name = "btnAddToQueue";
            btnAddToQueue.Size = new Size(30, 30);
            btnAddToQueue.TabIndex = 22;
            btnAddToQueue.UseVisualStyleBackColor = true;
            btnAddToQueue.Visible = false;
            btnAddToQueue.Click += btnAddToQueue_Click;
            // 
            // btnStartFromFile
            // 
            btnStartFromFile.FlatAppearance.BorderSize = 0;
            btnStartFromFile.FlatStyle = FlatStyle.Flat;
            btnStartFromFile.IconChar = FontAwesome.Sharp.IconChar.CirclePlay;
            btnStartFromFile.IconColor = Color.Cyan;
            btnStartFromFile.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnStartFromFile.IconSize = 28;
            btnStartFromFile.Location = new Point(38, 0);
            btnStartFromFile.Margin = new Padding(3, 3, 5, 3);
            btnStartFromFile.Name = "btnStartFromFile";
            btnStartFromFile.Size = new Size(30, 30);
            btnStartFromFile.TabIndex = 23;
            btnStartFromFile.UseVisualStyleBackColor = true;
            btnStartFromFile.Click += btnStartFromFile_Click;
            // 
            // btnSettings
            // 
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnSettings.IconColor = Color.Black;
            btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSettings.IconSize = 28;
            btnSettings.Location = new Point(76, 0);
            btnSettings.Margin = new Padding(3, 3, 10, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(30, 30);
            btnSettings.TabIndex = 7;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnMuteToggle
            // 
            btnMuteToggle.FlatAppearance.BorderSize = 0;
            btnMuteToggle.FlatStyle = FlatStyle.Flat;
            btnMuteToggle.IconChar = FontAwesome.Sharp.IconChar.VolumeOff;
            btnMuteToggle.IconColor = Color.Black;
            btnMuteToggle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMuteToggle.IconSize = 21;
            btnMuteToggle.ImageAlign = ContentAlignment.MiddleLeft;
            btnMuteToggle.Location = new Point(117, 4);
            btnMuteToggle.Margin = new Padding(3, 3, 10, 3);
            btnMuteToggle.Name = "btnMuteToggle";
            btnMuteToggle.Size = new Size(33, 23);
            btnMuteToggle.TabIndex = 12;
            btnMuteToggle.UseVisualStyleBackColor = true;
            btnMuteToggle.Click += btnMuteToggle_Click;
            // 
            // panelMainButtons
            // 
            panelMainButtons.BackColor = Color.FromArgb(253, 83, 146);
            panelMainButtons.Controls.Add(btnPlay);
            panelMainButtons.Controls.Add(btnPrevious);
            panelMainButtons.Controls.Add(btnNext);
            panelMainButtons.Controls.Add(btnFileBrowse);
            panelMainButtons.Controls.Add(btnListBrowser);
            panelMainButtons.Location = new Point(3, 17);
            panelMainButtons.Name = "panelMainButtons";
            panelMainButtons.Size = new Size(245, 38);
            panelMainButtons.TabIndex = 25;
            // 
            // btnPlay
            // 
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnPlay.IconColor = Color.Black;
            btnPlay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPlay.IconSize = 30;
            btnPlay.Location = new Point(0, 6);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(30, 30);
            btnPlay.TabIndex = 1;
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Enabled = false;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.IconChar = FontAwesome.Sharp.IconChar.BackwardStep;
            btnPrevious.IconColor = Color.Black;
            btnPrevious.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrevious.IconSize = 28;
            btnPrevious.Location = new Point(55, 6);
            btnPrevious.Margin = new Padding(10, 3, 10, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(30, 30);
            btnPrevious.TabIndex = 3;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.IconChar = FontAwesome.Sharp.IconChar.StepForward;
            btnNext.IconColor = Color.Black;
            btnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNext.IconSize = 28;
            btnNext.Location = new Point(105, 6);
            btnNext.Margin = new Padding(10, 3, 10, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(30, 30);
            btnNext.TabIndex = 4;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnFileBrowse
            // 
            btnFileBrowse.FlatAppearance.BorderSize = 0;
            btnFileBrowse.FlatStyle = FlatStyle.Flat;
            btnFileBrowse.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnFileBrowse.IconColor = Color.Black;
            btnFileBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFileBrowse.IconSize = 28;
            btnFileBrowse.Location = new Point(155, 6);
            btnFileBrowse.Margin = new Padding(10, 3, 10, 3);
            btnFileBrowse.Name = "btnFileBrowse";
            btnFileBrowse.Size = new Size(30, 30);
            btnFileBrowse.TabIndex = 16;
            btnFileBrowse.UseVisualStyleBackColor = true;
            btnFileBrowse.Click += btnFileBrowse_Click;
            // 
            // btnListBrowser
            // 
            btnListBrowser.FlatAppearance.BorderSize = 0;
            btnListBrowser.FlatStyle = FlatStyle.Flat;
            btnListBrowser.IconChar = FontAwesome.Sharp.IconChar.ListUl;
            btnListBrowser.IconColor = Color.Black;
            btnListBrowser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnListBrowser.IconSize = 28;
            btnListBrowser.Location = new Point(205, 6);
            btnListBrowser.Margin = new Padding(10, 3, 10, 3);
            btnListBrowser.Name = "btnListBrowser";
            btnListBrowser.Size = new Size(30, 30);
            btnListBrowser.TabIndex = 6;
            btnListBrowser.UseVisualStyleBackColor = true;
            btnListBrowser.Click += btnListBrowser_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblCurrentInfo);
            panel1.Controls.Add(lblSpeed);
            panel1.Controls.Add(lblDurationInfo);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(1015, 17);
            panel1.TabIndex = 24;
            // 
            // lblCurrentInfo
            // 
            lblCurrentInfo.AutoEllipsis = true;
            lblCurrentInfo.Cursor = Cursors.Hand;
            lblCurrentInfo.Dock = DockStyle.Fill;
            lblCurrentInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCurrentInfo.Location = new Point(0, 0);
            lblCurrentInfo.Name = "lblCurrentInfo";
            lblCurrentInfo.Size = new Size(901, 17);
            lblCurrentInfo.TabIndex = 14;
            lblCurrentInfo.Text = "Current Folder";
            lblCurrentInfo.TextAlign = ContentAlignment.BottomLeft;
            lblCurrentInfo.DoubleClick += lblCurrentInfo_DoubleClick;
            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Dock = DockStyle.Right;
            lblSpeed.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSpeed.Location = new Point(901, 0);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new Size(0, 15);
            lblSpeed.TabIndex = 15;
            // 
            // lblDurationInfo
            // 
            lblDurationInfo.Dock = DockStyle.Right;
            lblDurationInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDurationInfo.Location = new Point(901, 0);
            lblDurationInfo.Name = "lblDurationInfo";
            lblDurationInfo.Size = new Size(114, 17);
            lblDurationInfo.TabIndex = 13;
            lblDurationInfo.Text = "00:00:00 / 00:00:00";
            lblDurationInfo.TextAlign = ContentAlignment.BottomRight;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(btnTouch);
            panelControls.Controls.Add(btnAutoSkip);
            panelControls.Controls.Add(btnSourceSelector);
            panelControls.Controls.Add(btnRepeat);
            panelControls.Controls.Add(btnMoveTo);
            panelControls.Controls.Add(btnRemove);
            panelControls.Controls.Add(btnShuffle);
            panelControls.Controls.Add(btnListAdd);
            panelControls.Controls.Add(btnAddToFav);
            panelControls.Location = new Point(251, 23);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(485, 29);
            panelControls.TabIndex = 21;
            // 
            // btnTouch
            // 
            btnTouch.FlatAppearance.BorderSize = 0;
            btnTouch.FlatStyle = FlatStyle.Flat;
            btnTouch.IconChar = FontAwesome.Sharp.IconChar.LocationCrosshairs;
            btnTouch.IconColor = Color.Black;
            btnTouch.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnTouch.IconSize = 29;
            btnTouch.Location = new Point(407, -1);
            btnTouch.Margin = new Padding(10, 3, 10, 3);
            btnTouch.Name = "btnTouch";
            btnTouch.Size = new Size(30, 30);
            btnTouch.TabIndex = 25;
            btnTouch.UseVisualStyleBackColor = true;
            btnTouch.Click += btnTouch_Click;
            // 
            // btnAutoSkip
            // 
            btnAutoSkip.FlatAppearance.BorderSize = 0;
            btnAutoSkip.FlatStyle = FlatStyle.Flat;
            btnAutoSkip.IconChar = FontAwesome.Sharp.IconChar.Forward;
            btnAutoSkip.IconColor = Color.Black;
            btnAutoSkip.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAutoSkip.IconSize = 29;
            btnAutoSkip.Location = new Point(357, -1);
            btnAutoSkip.Margin = new Padding(10, 3, 10, 3);
            btnAutoSkip.Name = "btnAutoSkip";
            btnAutoSkip.Size = new Size(30, 30);
            btnAutoSkip.TabIndex = 24;
            btnAutoSkip.UseVisualStyleBackColor = true;
            btnAutoSkip.Click += btnAutoSkip_Click;
            // 
            // btnSourceSelector
            // 
            btnSourceSelector.FlatAppearance.BorderSize = 0;
            btnSourceSelector.FlatStyle = FlatStyle.Flat;
            btnSourceSelector.Image = (Image)resources.GetObject("btnSourceSelector.Image");
            btnSourceSelector.Location = new Point(307, -1);
            btnSourceSelector.Margin = new Padding(10, 3, 10, 3);
            btnSourceSelector.Name = "btnSourceSelector";
            btnSourceSelector.Size = new Size(30, 29);
            btnSourceSelector.TabIndex = 23;
            btnSourceSelector.UseVisualStyleBackColor = true;
            btnSourceSelector.Click += btnSourceSelector_Click;
            // 
            // btnRepeat
            // 
            btnRepeat.FlatAppearance.BorderSize = 0;
            btnRepeat.FlatStyle = FlatStyle.Flat;
            btnRepeat.IconChar = FontAwesome.Sharp.IconChar.Sync;
            btnRepeat.IconColor = Color.Black;
            btnRepeat.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnRepeat.IconSize = 29;
            btnRepeat.Location = new Point(257, 0);
            btnRepeat.Margin = new Padding(10, 3, 10, 3);
            btnRepeat.Name = "btnRepeat";
            btnRepeat.Size = new Size(30, 30);
            btnRepeat.TabIndex = 22;
            btnRepeat.UseVisualStyleBackColor = true;
            btnRepeat.Click += btnRepeat_Click;
            // 
            // btnMoveTo
            // 
            btnMoveTo.Enabled = false;
            btnMoveTo.FlatAppearance.BorderSize = 0;
            btnMoveTo.FlatStyle = FlatStyle.Flat;
            btnMoveTo.IconChar = FontAwesome.Sharp.IconChar.Copy;
            btnMoveTo.IconColor = Color.Black;
            btnMoveTo.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnMoveTo.IconSize = 29;
            btnMoveTo.Location = new Point(157, 0);
            btnMoveTo.Margin = new Padding(10, 3, 10, 3);
            btnMoveTo.Name = "btnMoveTo";
            btnMoveTo.Size = new Size(30, 30);
            btnMoveTo.TabIndex = 21;
            btnMoveTo.UseVisualStyleBackColor = true;
            btnMoveTo.MouseDown += btnMoveTo_MouseDown;
            // 
            // btnRemove
            // 
            btnRemove.Enabled = false;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnRemove.IconColor = Color.Black;
            btnRemove.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnRemove.IconSize = 24;
            btnRemove.Location = new Point(7, 0);
            btnRemove.Margin = new Padding(10, 3, 10, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(30, 30);
            btnRemove.TabIndex = 15;
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnShuffle
            // 
            btnShuffle.FlatAppearance.BorderSize = 0;
            btnShuffle.FlatStyle = FlatStyle.Flat;
            btnShuffle.IconChar = FontAwesome.Sharp.IconChar.Shuffle;
            btnShuffle.IconColor = Color.Black;
            btnShuffle.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnShuffle.IconSize = 29;
            btnShuffle.Location = new Point(207, 0);
            btnShuffle.Margin = new Padding(10, 3, 10, 3);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new Size(30, 30);
            btnShuffle.TabIndex = 18;
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Click += btnShuffle_Click;
            // 
            // btnListAdd
            // 
            btnListAdd.Enabled = false;
            btnListAdd.FlatAppearance.BorderSize = 0;
            btnListAdd.FlatStyle = FlatStyle.Flat;
            btnListAdd.Image = (Image)resources.GetObject("btnListAdd.Image");
            btnListAdd.Location = new Point(57, 0);
            btnListAdd.Margin = new Padding(10, 3, 10, 3);
            btnListAdd.Name = "btnListAdd";
            btnListAdd.Size = new Size(30, 29);
            btnListAdd.TabIndex = 20;
            btnListAdd.UseVisualStyleBackColor = true;
            btnListAdd.MouseDown += btnListAdd_MouseDown;
            // 
            // btnAddToFav
            // 
            btnAddToFav.Enabled = false;
            btnAddToFav.FlatAppearance.BorderSize = 0;
            btnAddToFav.FlatStyle = FlatStyle.Flat;
            btnAddToFav.IconChar = FontAwesome.Sharp.IconChar.Heart;
            btnAddToFav.IconColor = Color.Black;
            btnAddToFav.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnAddToFav.IconSize = 29;
            btnAddToFav.Location = new Point(107, 0);
            btnAddToFav.Margin = new Padding(10, 3, 10, 3);
            btnAddToFav.Name = "btnAddToFav";
            btnAddToFav.Size = new Size(30, 30);
            btnAddToFav.TabIndex = 17;
            btnAddToFav.UseVisualStyleBackColor = true;
            btnAddToFav.Click += btnAddToFav_Click;
            // 
            // pbVolume
            // 
            pbVolume.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pbVolume.BorderColor = Color.Black;
            pbVolume.BorderThickness = 5;
            pbVolume.CompletedBrush = Color.Black;
            pbVolume.CompletedGraphBrush = Color.White;
            pbVolume.GraphThickness = 1;
            pbVolume.Location = new Point(905, 27);
            pbVolume.Maximum = 100;
            pbVolume.Minimum = 0;
            pbVolume.MouseoverBrush = Color.Black;
            pbVolume.Name = "pbVolume";
            pbVolume.RemainingBrush = Color.FromArgb(253, 83, 146);
            pbVolume.RemainingGraphBrush = Color.Black;
            pbVolume.ShowBorder = true;
            pbVolume.Size = new Size(108, 20);
            pbVolume.TabIndex = 11;
            pbVolume.Text = "flatProgressBar1";
            pbVolume.Value = 50;
            pbVolume.MouseDown += pbVolume_MouseDown;
            // 
            // pbPlayerProgress
            // 
            pbPlayerProgress.BorderColor = Color.Black;
            pbPlayerProgress.BorderThickness = 1;
            pbPlayerProgress.CompletedBrush = Color.FromArgb(248, 111, 100);
            pbPlayerProgress.CompletedGraphBrush = Color.Black;
            pbPlayerProgress.Dock = DockStyle.Top;
            pbPlayerProgress.GraphThickness = 1;
            pbPlayerProgress.Location = new Point(0, 0);
            pbPlayerProgress.Maximum = 60;
            pbPlayerProgress.Minimum = 0;
            pbPlayerProgress.MouseoverBrush = Color.FromArgb(250, 164, 158);
            pbPlayerProgress.Name = "pbPlayerProgress";
            pbPlayerProgress.RemainingBrush = Color.Black;
            pbPlayerProgress.RemainingGraphBrush = Color.MistyRose;
            pbPlayerProgress.ShowBorder = false;
            pbPlayerProgress.Size = new Size(1015, 17);
            pbPlayerProgress.TabIndex = 0;
            pbPlayerProgress.Text = "flatProgressBar1";
            pbPlayerProgress.Value = 0;
            pbPlayerProgress.MouseDown += pbPlayerProgress_MouseDown;
            pbPlayerProgress.MouseLeave += pbPlayerProgress_MouseLeave;
            pbPlayerProgress.MouseMove += pbPlayerProgress_MouseMove;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(253, 83, 146);
            panelTop.Controls.Add(btnScriptMenu);
            panelTop.Controls.Add(btnAudioTrackMenu);
            panelTop.Controls.Add(btnSubtitleMenu);
            panelTop.Controls.Add(lblTitleBar);
            panelTop.Controls.Add(btnMinimizeForm);
            panelTop.Controls.Add(btnMaximizeForm);
            panelTop.Controls.Add(btnExitForm);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1015, 20);
            panelTop.TabIndex = 1;
            // 
            // btnScriptMenu
            // 
            btnScriptMenu.Dock = DockStyle.Left;
            btnScriptMenu.FlatAppearance.BorderSize = 0;
            btnScriptMenu.FlatStyle = FlatStyle.Flat;
            btnScriptMenu.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            btnScriptMenu.ForeColor = Color.Indigo;
            btnScriptMenu.Location = new Point(84, 0);
            btnScriptMenu.Name = "btnScriptMenu";
            btnScriptMenu.Size = new Size(48, 20);
            btnScriptMenu.TabIndex = 6;
            btnScriptMenu.Text = "SCRIPT";
            btnScriptMenu.UseVisualStyleBackColor = true;
            btnScriptMenu.Click += btnScriptMenu_Click;
            // 
            // btnAudioTrackMenu
            // 
            btnAudioTrackMenu.Dock = DockStyle.Left;
            btnAudioTrackMenu.FlatAppearance.BorderSize = 0;
            btnAudioTrackMenu.FlatStyle = FlatStyle.Flat;
            btnAudioTrackMenu.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            btnAudioTrackMenu.ForeColor = Color.Indigo;
            btnAudioTrackMenu.Location = new Point(42, 0);
            btnAudioTrackMenu.Name = "btnAudioTrackMenu";
            btnAudioTrackMenu.Size = new Size(42, 20);
            btnAudioTrackMenu.TabIndex = 5;
            btnAudioTrackMenu.Text = "AUD";
            btnAudioTrackMenu.UseVisualStyleBackColor = true;
            btnAudioTrackMenu.Click += btnAudioTrackMenu_Click;
            // 
            // btnSubtitleMenu
            // 
            btnSubtitleMenu.Dock = DockStyle.Left;
            btnSubtitleMenu.FlatAppearance.BorderSize = 0;
            btnSubtitleMenu.FlatStyle = FlatStyle.Flat;
            btnSubtitleMenu.Font = new Font("Segoe UI Semibold", 7F, FontStyle.Bold);
            btnSubtitleMenu.ForeColor = Color.Indigo;
            btnSubtitleMenu.Location = new Point(0, 0);
            btnSubtitleMenu.Name = "btnSubtitleMenu";
            btnSubtitleMenu.Size = new Size(42, 20);
            btnSubtitleMenu.TabIndex = 4;
            btnSubtitleMenu.Text = "SUB";
            btnSubtitleMenu.UseVisualStyleBackColor = true;
            btnSubtitleMenu.Click += btnSubtitleMenu_Click;
            // 
            // lblTitleBar
            // 
            lblTitleBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleBar.AutoEllipsis = true;
            lblTitleBar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblTitleBar.Location = new Point(93, 0);
            lblTitleBar.Name = "lblTitleBar";
            lblTitleBar.Size = new Size(830, 20);
            lblTitleBar.TabIndex = 3;
            lblTitleBar.Text = "Random Video Player ";
            lblTitleBar.TextAlign = ContentAlignment.MiddleCenter;
            lblTitleBar.MouseDown += lblTitleBar_MouseDown;
            // 
            // btnMinimizeForm
            // 
            btnMinimizeForm.Dock = DockStyle.Right;
            btnMinimizeForm.FlatAppearance.BorderSize = 0;
            btnMinimizeForm.FlatStyle = FlatStyle.Flat;
            btnMinimizeForm.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            btnMinimizeForm.IconColor = Color.Black;
            btnMinimizeForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMinimizeForm.IconSize = 15;
            btnMinimizeForm.Location = new Point(925, 0);
            btnMinimizeForm.Name = "btnMinimizeForm";
            btnMinimizeForm.Size = new Size(30, 20);
            btnMinimizeForm.TabIndex = 2;
            btnMinimizeForm.UseVisualStyleBackColor = true;
            btnMinimizeForm.Click += btnMinimizeForm_Click;
            // 
            // btnMaximizeForm
            // 
            btnMaximizeForm.Dock = DockStyle.Right;
            btnMaximizeForm.FlatAppearance.BorderSize = 0;
            btnMaximizeForm.FlatStyle = FlatStyle.Flat;
            btnMaximizeForm.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            btnMaximizeForm.IconColor = Color.Black;
            btnMaximizeForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMaximizeForm.IconSize = 15;
            btnMaximizeForm.Location = new Point(955, 0);
            btnMaximizeForm.Name = "btnMaximizeForm";
            btnMaximizeForm.Size = new Size(30, 20);
            btnMaximizeForm.TabIndex = 1;
            btnMaximizeForm.UseVisualStyleBackColor = true;
            btnMaximizeForm.Click += btnMaximizeForm_Click;
            // 
            // btnExitForm
            // 
            btnExitForm.Dock = DockStyle.Right;
            btnExitForm.FlatAppearance.BorderSize = 0;
            btnExitForm.FlatAppearance.MouseOverBackColor = Color.Red;
            btnExitForm.FlatStyle = FlatStyle.Flat;
            btnExitForm.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            btnExitForm.IconColor = Color.Black;
            btnExitForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExitForm.IconSize = 15;
            btnExitForm.Location = new Point(985, 0);
            btnExitForm.Name = "btnExitForm";
            btnExitForm.Size = new Size(30, 20);
            btnExitForm.TabIndex = 0;
            btnExitForm.UseVisualStyleBackColor = true;
            btnExitForm.Click += btnExitForm_Click;
            // 
            // panelPlayerMPV
            // 
            panelPlayerMPV.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPlayerMPV.BackColor = Color.Black;
            panelPlayerMPV.Location = new Point(0, 20);
            panelPlayerMPV.Name = "panelPlayerMPV";
            panelPlayerMPV.Size = new Size(1015, 297);
            panelPlayerMPV.TabIndex = 2;
            panelPlayerMPV.MouseDown += panelPlayerMPV_MouseDown;
            panelPlayerMPV.MouseMove += panelPlayerMPV_MouseMove;
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
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RVP";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            Resize += MainForm_Resize;
            panelBottom.ResumeLayout(false);
            panelExtraButtons.ResumeLayout(false);
            panelMainButtons.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelControls.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelBottom;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnListBrowser;
        private FontAwesome.Sharp.IconButton btnNext;
        private FontAwesome.Sharp.IconButton btnPrevious;
        private FontAwesome.Sharp.IconButton btnPlay;
        private FlatProgressBar pbPlayerProgress;
        private Panel panelTop;
        private Label lblDurationInfo;
        private FontAwesome.Sharp.IconButton btnMuteToggle;
        private FlatProgressBar pbVolume;
        private Label lblCurrentInfo;
        private FontAwesome.Sharp.IconButton btnMinimizeForm;
        private FontAwesome.Sharp.IconButton btnMaximizeForm;
        private FontAwesome.Sharp.IconButton btnExitForm;
        private Label lblTitleBar;
        private Panel panelPlayerMPV;
        private System.Windows.Forms.Timer timerProgressUpdate;
        private ToolTip toolTipInfo;
        private FolderBrowserDialog fbDialog;
        private System.Windows.Forms.Timer timeVolumeCheck;
        private FontAwesome.Sharp.IconButton btnRemove;
        private FontAwesome.Sharp.IconButton btnFileBrowse;
        private ToolTip toolTipUI;
        private FontAwesome.Sharp.IconButton btnAddToFav;
        private FontAwesome.Sharp.IconButton btnShuffle;
        private Panel panelControls;
        private Button btnListAdd;
        private FontAwesome.Sharp.IconButton btnRepeat;
        private FontAwesome.Sharp.IconButton btnMoveTo;
        private FontAwesome.Sharp.IconButton btnAddToQueue;
        private FontAwesome.Sharp.IconButton btnStartFromFile;
        private Button btnSourceSelector;
        private Panel panel1;
        private Label lblSpeed;
        private Button btnSubtitleMenu;
        private Button btnAudioTrackMenu;
        private Button btnScriptMenu;
        private FontAwesome.Sharp.IconButton btnAutoSkip;
        private System.Windows.Forms.Timer timerAutoSkipCheck;
        private FontAwesome.Sharp.IconButton btnTouch;
        private Panel panelMainButtons;
        private Panel panelExtraButtons;
    }
}