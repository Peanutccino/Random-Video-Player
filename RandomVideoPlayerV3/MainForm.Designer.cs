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
            btnAddToQueue = new FontAwesome.Sharp.IconButton();
            panelControls = new Panel();
            btnRepeat = new FontAwesome.Sharp.IconButton();
            btnMoveTo = new FontAwesome.Sharp.IconButton();
            btnRemove = new FontAwesome.Sharp.IconButton();
            btnShuffle = new FontAwesome.Sharp.IconButton();
            btnListAdd = new Button();
            btnAddToFav = new FontAwesome.Sharp.IconButton();
            btnListDel = new Button();
            btnFileBrowse = new FontAwesome.Sharp.IconButton();
            lblCurrentInfo = new Label();
            lblDurationInfo = new Label();
            btnMuteToggle = new FontAwesome.Sharp.IconButton();
            pbVolume = new FlatProgressBar();
            btnSettings = new FontAwesome.Sharp.IconButton();
            btnListBrowser = new FontAwesome.Sharp.IconButton();
            btnNext = new FontAwesome.Sharp.IconButton();
            btnPrevious = new FontAwesome.Sharp.IconButton();
            btnPlay = new FontAwesome.Sharp.IconButton();
            pbPlayerProgress = new FlatProgressBar();
            panelTop = new Panel();
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
            panelBottom.SuspendLayout();
            panelControls.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(253, 83, 146);
            panelBottom.Controls.Add(btnAddToQueue);
            panelBottom.Controls.Add(panelControls);
            panelBottom.Controls.Add(btnFileBrowse);
            panelBottom.Controls.Add(lblCurrentInfo);
            panelBottom.Controls.Add(lblDurationInfo);
            panelBottom.Controls.Add(btnMuteToggle);
            panelBottom.Controls.Add(pbVolume);
            panelBottom.Controls.Add(btnSettings);
            panelBottom.Controls.Add(btnListBrowser);
            panelBottom.Controls.Add(btnNext);
            panelBottom.Controls.Add(btnPrevious);
            panelBottom.Controls.Add(btnPlay);
            panelBottom.Controls.Add(pbPlayerProgress);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 306);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(844, 75);
            panelBottom.TabIndex = 0;
            // 
            // btnAddToQueue
            // 
            btnAddToQueue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddToQueue.FlatAppearance.BorderSize = 0;
            btnAddToQueue.FlatStyle = FlatStyle.Flat;
            btnAddToQueue.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            btnAddToQueue.IconColor = Color.Indigo;
            btnAddToQueue.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAddToQueue.IconSize = 28;
            btnAddToQueue.Location = new Point(617, 22);
            btnAddToQueue.Margin = new Padding(10, 3, 5, 3);
            btnAddToQueue.Name = "btnAddToQueue";
            btnAddToQueue.Size = new Size(30, 30);
            btnAddToQueue.TabIndex = 22;
            btnAddToQueue.UseVisualStyleBackColor = true;
            btnAddToQueue.Visible = false;
            btnAddToQueue.Click += btnAddToQueue_Click;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(btnRepeat);
            panelControls.Controls.Add(btnMoveTo);
            panelControls.Controls.Add(btnRemove);
            panelControls.Controls.Add(btnShuffle);
            panelControls.Controls.Add(btnListAdd);
            panelControls.Controls.Add(btnAddToFav);
            panelControls.Controls.Add(btnListDel);
            panelControls.Location = new Point(254, 23);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(351, 29);
            panelControls.TabIndex = 21;
            // 
            // btnRepeat
            // 
            btnRepeat.FlatAppearance.BorderSize = 0;
            btnRepeat.FlatStyle = FlatStyle.Flat;
            btnRepeat.IconChar = FontAwesome.Sharp.IconChar.Sync;
            btnRepeat.IconColor = Color.Black;
            btnRepeat.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnRepeat.IconSize = 29;
            btnRepeat.Location = new Point(307, 0);
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
            btnMoveTo.Location = new Point(207, 0);
            btnMoveTo.Margin = new Padding(10, 3, 10, 3);
            btnMoveTo.Name = "btnMoveTo";
            btnMoveTo.Size = new Size(30, 30);
            btnMoveTo.TabIndex = 21;
            btnMoveTo.UseVisualStyleBackColor = true;
            btnMoveTo.Click += btnMoveTo_Click;
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
            btnRemove.Location = new Point(7, -1);
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
            btnShuffle.Location = new Point(257, 0);
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
            btnListAdd.Location = new Point(107, 0);
            btnListAdd.Margin = new Padding(10, 3, 10, 3);
            btnListAdd.Name = "btnListAdd";
            btnListAdd.Size = new Size(30, 29);
            btnListAdd.TabIndex = 20;
            btnListAdd.UseVisualStyleBackColor = true;
            btnListAdd.Click += btnListAdd_Click;
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
            btnAddToFav.Location = new Point(157, 0);
            btnAddToFav.Margin = new Padding(10, 3, 10, 3);
            btnAddToFav.Name = "btnAddToFav";
            btnAddToFav.Size = new Size(30, 30);
            btnAddToFav.TabIndex = 17;
            btnAddToFav.UseVisualStyleBackColor = true;
            btnAddToFav.Click += btnAddToFav_Click;
            // 
            // btnListDel
            // 
            btnListDel.Enabled = false;
            btnListDel.FlatAppearance.BorderSize = 0;
            btnListDel.FlatStyle = FlatStyle.Flat;
            btnListDel.Image = (Image)resources.GetObject("btnListDel.Image");
            btnListDel.Location = new Point(57, 0);
            btnListDel.Margin = new Padding(10, 3, 10, 3);
            btnListDel.Name = "btnListDel";
            btnListDel.Size = new Size(30, 29);
            btnListDel.TabIndex = 19;
            btnListDel.UseVisualStyleBackColor = true;
            btnListDel.Click += btnListDel_Click;
            // 
            // btnFileBrowse
            // 
            btnFileBrowse.FlatAppearance.BorderSize = 0;
            btnFileBrowse.FlatStyle = FlatStyle.Flat;
            btnFileBrowse.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            btnFileBrowse.IconColor = Color.Black;
            btnFileBrowse.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFileBrowse.IconSize = 28;
            btnFileBrowse.Location = new Point(161, 22);
            btnFileBrowse.Margin = new Padding(10, 3, 10, 3);
            btnFileBrowse.Name = "btnFileBrowse";
            btnFileBrowse.Size = new Size(30, 30);
            btnFileBrowse.TabIndex = 16;
            btnFileBrowse.UseVisualStyleBackColor = true;
            btnFileBrowse.Click += btnFileBrowse_Click;
            // 
            // lblCurrentInfo
            // 
            lblCurrentInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblCurrentInfo.AutoEllipsis = true;
            lblCurrentInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentInfo.Location = new Point(3, 55);
            lblCurrentInfo.Name = "lblCurrentInfo";
            lblCurrentInfo.Size = new Size(721, 15);
            lblCurrentInfo.TabIndex = 14;
            lblCurrentInfo.Text = "Current Folder";
            lblCurrentInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDurationInfo
            // 
            lblDurationInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblDurationInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblDurationInfo.Location = new Point(730, 55);
            lblDurationInfo.Name = "lblDurationInfo";
            lblDurationInfo.Size = new Size(114, 15);
            lblDurationInfo.TabIndex = 13;
            lblDurationInfo.Text = "00:00:00 / 00:00:00";
            lblDurationInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnMuteToggle
            // 
            btnMuteToggle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMuteToggle.FlatAppearance.BorderSize = 0;
            btnMuteToggle.FlatStyle = FlatStyle.Flat;
            btnMuteToggle.IconChar = FontAwesome.Sharp.IconChar.VolumeOff;
            btnMuteToggle.IconColor = Color.Black;
            btnMuteToggle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnMuteToggle.IconSize = 21;
            btnMuteToggle.ImageAlign = ContentAlignment.MiddleLeft;
            btnMuteToggle.Location = new Point(698, 26);
            btnMuteToggle.Margin = new Padding(10, 3, 10, 3);
            btnMuteToggle.Name = "btnMuteToggle";
            btnMuteToggle.Size = new Size(33, 23);
            btnMuteToggle.TabIndex = 12;
            btnMuteToggle.UseVisualStyleBackColor = true;
            btnMuteToggle.Click += btnMuteToggle_Click;
            // 
            // pbVolume
            // 
            pbVolume.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pbVolume.BorderColor = Color.Black;
            pbVolume.BorderThickness = 5;
            pbVolume.CompletedBrush = Color.Black;
            pbVolume.CompletedGraphBrush = Color.White;
            pbVolume.GraphThickness = 1;
            pbVolume.Location = new Point(734, 26);
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
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.IconChar = FontAwesome.Sharp.IconChar.Gear;
            btnSettings.IconColor = Color.Black;
            btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSettings.IconSize = 28;
            btnSettings.Location = new Point(657, 22);
            btnSettings.Margin = new Padding(5, 3, 10, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(30, 30);
            btnSettings.TabIndex = 7;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnListBrowser
            // 
            btnListBrowser.FlatAppearance.BorderSize = 0;
            btnListBrowser.FlatStyle = FlatStyle.Flat;
            btnListBrowser.IconChar = FontAwesome.Sharp.IconChar.ListUl;
            btnListBrowser.IconColor = Color.Black;
            btnListBrowser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnListBrowser.IconSize = 28;
            btnListBrowser.Location = new Point(211, 23);
            btnListBrowser.Margin = new Padding(10, 3, 10, 3);
            btnListBrowser.Name = "btnListBrowser";
            btnListBrowser.Size = new Size(30, 30);
            btnListBrowser.TabIndex = 6;
            btnListBrowser.UseVisualStyleBackColor = true;
            btnListBrowser.Click += btnListBrowser_Click;
            // 
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.IconChar = FontAwesome.Sharp.IconChar.ForwardStep;
            btnNext.IconColor = Color.Black;
            btnNext.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNext.IconSize = 28;
            btnNext.Location = new Point(111, 23);
            btnNext.Margin = new Padding(10, 3, 10, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(30, 30);
            btnNext.TabIndex = 4;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
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
            btnPrevious.Location = new Point(61, 23);
            btnPrevious.Margin = new Padding(10, 3, 10, 3);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(30, 30);
            btnPrevious.TabIndex = 3;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnPlay
            // 
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
            btnPlay.IconColor = Color.Black;
            btnPlay.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPlay.IconSize = 30;
            btnPlay.Location = new Point(3, 23);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(45, 30);
            btnPlay.TabIndex = 1;
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
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
            pbPlayerProgress.Size = new Size(844, 17);
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
            panelTop.Controls.Add(lblTitleBar);
            panelTop.Controls.Add(btnMinimizeForm);
            panelTop.Controls.Add(btnMaximizeForm);
            panelTop.Controls.Add(btnExitForm);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(844, 20);
            panelTop.TabIndex = 1;
            // 
            // lblTitleBar
            // 
            lblTitleBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitleBar.AutoEllipsis = true;
            lblTitleBar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitleBar.Location = new Point(93, 0);
            lblTitleBar.Name = "lblTitleBar";
            lblTitleBar.Size = new Size(659, 20);
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
            btnMinimizeForm.Location = new Point(754, 0);
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
            btnMaximizeForm.Location = new Point(784, 0);
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
            btnExitForm.Location = new Point(814, 0);
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
            panelPlayerMPV.Size = new Size(844, 287);
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
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(844, 381);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            Controls.Add(panelPlayerMPV);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(860, 420);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RVP";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            Resize += MainForm_Resize;
            panelBottom.ResumeLayout(false);
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
        private Button btnListDel;
        private Panel panelControls;
        private Button btnListAdd;
        private FontAwesome.Sharp.IconButton btnRepeat;
        private FontAwesome.Sharp.IconButton btnMoveTo;
        private FontAwesome.Sharp.IconButton btnAddToQueue;
    }
}