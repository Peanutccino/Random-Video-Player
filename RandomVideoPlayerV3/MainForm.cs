using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Shell;
using Mpv.NET.API;
using Mpv.NET.Player;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using RandomVideoPlayer.View;

using Point = System.Drawing.Point;
using SystemColors = System.Drawing.SystemColors;

namespace RandomVideoPlayer
{
    public partial class MainForm : Form
    {
        private MpvPlayer playerMPV;


        private WebServer tcServer;
        private HotkeySettings hkSettings;

        private FormResize fR = new FormResize();

        //Initialize Areas for Panel Fade-In/Out in exclusive fullscreen mode
        private Rectangle areaBottom = new Rectangle();
        private Rectangle areaTop = new Rectangle();

        private Size backupSize;

        private List<string> tempFavorites = new List<string>();
        private bool favoriteMatch = false;

        private Label timeOverlayLabel = new Label();
        private int durationMS = 0;
        private string currentFile;

        //Safety time to prevent event spamming
        private DateTime lastPlayCommandTime = DateTime.MinValue;
        private readonly TimeSpan minimumInterval = TimeSpan.FromMilliseconds(300);


        //Init mouse idle to hide cursor when in exclusive fullscreen mode
        System.Windows.Forms.Timer activityTimer = new System.Windows.Forms.Timer();
        TimeSpan activityThreshold = TimeSpan.FromSeconds(2); //Idleduration it takes to hide the cursor in seconds
        bool cursorHidden = false;

        private List<Task> ongoingTasks = new List<Task>();
        private List<string> ongoingFileProcesses = new List<string>();

        private string directoryFromStartupFile = "";
        private string filepathFromStartupFile = "";
        private string startupPath;
        private bool startedByFile = false;

        private bool playingSingleFile = false;
        private string draggedFilePath;

        private Stopwatch stopwatch;
        private System.Windows.Forms.Timer checkwatch;
        private int doubleClickDelay = 180; //Delay to wait for potential double click otherwise execute single click

        public MainForm(string filePath)
        {
            InitializeComponent();
            hkSettings = HotkeyManager.LoadHotkeySettings();
            //If setting set to remember last size, regain size
            if (fR.SaveLastSize == true)
            {
                fR.FormSize = new Size(fR.FormSize.Width - 16, fR.FormSize.Height - 39);
                this.ClientSize = fR.FormSize;
            }
            startupPath = Application.StartupPath;

            int initVolume = SettingsHandler.VolumeMember ? SettingsHandler.VolumeLastValue : 50;

            pbVolume.Value = initVolume;
            string libMpv = startupPath + "lib\\libmpv-2.dll";
            playerMPV = new MpvPlayer(panelPlayerMPV.Handle, libMpv) { Loop = SettingsHandler.LoopPlayer, Volume = initVolume, KeepOpen = KeepOpen.Yes };

            tcServer = new WebServer();

            if (SettingsHandler.TimeCodeServer) { tcServer.Start(); }

            panelPlayerMPV.MouseWheel += new MouseEventHandler(panelPlayerMPV_MouseWheel);
            pbVolume.MouseWheel += new MouseEventHandler(pbVolume_MouseWheel);
            playerMPV.MediaLoaded += new EventHandler(SetMediaInfo);
            playerMPV.MediaFinished += new EventHandler(MediaFinished);

            //Adjust Form for Borderless Style
            this.Padding = new Padding(fR.BorderSize);//Border size
            this.BackColor = Color.FromArgb(253, 83, 146);//Border color

            //Set up AcitivityWorker for checking cursor idle hide
            activityTimer.Tick += activityWorker_Tick;
            activityTimer.Interval = 100;

            RegisterHotKeys();

            if (ListHandler.SelectedExtensions.Count<string>() <= 0)
            {
                ListHandler.SelectedExtensions = ListHandler.VideoExtensions;
            }
            if (ListHandler.ExtensionFilterForList.Count<string>() <= 0)
            {
                ListHandler.ExtensionFilterForList = ListHandler.VideoExtensions;
            }

            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    if (!File.Exists(filePath)) return;
                    filepathFromStartupFile = filePath;
                    directoryFromStartupFile = FileManipulation.GetFileDirectory(filePath);
                    startedByFile = true;
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Error starting application by file");
                    MessageBox.Show($"Failed to open with file {ex}, continue loading default");
                }
            }

            stopwatch = new Stopwatch();
            checkwatch = new System.Windows.Forms.Timer();

            checkwatch.Interval = doubleClickDelay;
            checkwatch.Tick += Checkwatch_Tick;

            UpdateSourceSelectorIcon();
            lblTitleBar.Text = $"Random Video Player - v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(directoryFromStartupFile))
            {
                initStartUp(""); //Load default folder if set and fill playlist
            }
            else
            {
                initStartUp(directoryFromStartupFile);
            }

            RepositionButtons();
            SetupTooltips();
            UpdateButtonStates();

            //Load up a default image
            string img = Path.Combine(startupPath, @"Resources\RVP_BlackBG.png");
            playerMPV.Load(img, true);

            InitializeTimeOverlay();
            timerProgressUpdate.Enabled = true;

            if (startedByFile) PlayerPlayPauseToggle();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayerPlayPauseToggle();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PlayPrevious();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            PlayNext();
        }
        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserView fbForm = new FolderBrowserView();
            fbForm.StartPosition = FormStartPosition.CenterParent;

            btnFileBrowse.IconColor = Color.PaleGreen;
            DialogResult result = fbForm.ShowDialog();
            btnFileBrowse.IconColor = Color.Black;

            if (result != DialogResult.OK) return;


            if (SettingsHandler.RecentCheckedTemp)
            {
                ListHandler.latestFolderList(fbForm.selectedPath, SettingsHandler.RecentCount);
            }
            else
            {
                ListHandler.fillFolderList(fbForm.selectedPath, ListHandler.IncludeSubfolders);
            }

            if (!(ListHandler.TempFolderList?.Any() ?? false))
            {
                if (!(ListHandler.FolderList?.Any() ?? false))
                {
                    MessageBox.Show($"Yor chosen folder has no valid files to play from and there is no valid path to fall back to!\n\nThe Path was:\n{fbForm.selectedPath}");
                    return;
                }
                MessageBox.Show($"Yor chosen folder has no valid files to play from; No action taken!\n\nThe Path was:\n{fbForm.selectedPath}");
                return;
            }
            else
            {
                PathHandler.FolderPath = fbForm.selectedPath;
                ListHandler.TempFolderList = Enumerable.Empty<string>();
            }

            startedByFile = false;
            lblCurrentInfo.Text = PathHandler.FolderPath;
            ListHandler.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next
            SettingsHandler.SourceSelected = false;
            PlayNext();
        }
        private void btnListBrowser_Click(object sender, EventArgs e)
        {
            ListBrowserView lbForm = new ListBrowserView();
            lbForm.StartPosition = FormStartPosition.CenterParent;

            btnListBrowser.IconColor = Color.PaleGreen;
            DialogResult result = lbForm.ShowDialog();
            btnListBrowser.IconColor = Color.Black;
            if (result == DialogResult.OK)
            {
                if (!(ListHandler.CustomList?.Any() ?? false))
                {
                    MessageBox.Show("Custom List is empty");
                    return;
                }

                ListHandler.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next
                startedByFile = false;
                SettingsHandler.SourceSelected = true;
                PlayNext();
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }
        private void btnListDel_Click(object sender, EventArgs e)
        {
            DeleteCurrentFromList();
        }
        private void btnListAdd_Click(object sender, EventArgs e)
        {
            AddCurrentToList();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsView svForm = new SettingsView();
            svForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = svForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                RepositionButtons();

                if (SettingsHandler.TimeCodeServer)
                {
                    tcServer.Start();
                }
                else
                {
                    tcServer.Stop();
                }
                playerMPV.Loop = SettingsHandler.LoopPlayer; //Update Player behavior
                initStartUp(""); //Used to fix issues at first time startup
                if (SettingsHandler.SettingChanged)
                    PlayNext();
            }

            UpdateButtonStates();
            if (fR.WindowExclusiveFullscreen)
            {
                fR.UpdateFullscreenSize(this, panelTop, panelBottom, panelPlayerMPV);
            }

            hkSettings = HotkeyManager.LoadHotkeySettings();
            SetupTooltips();
        }
        private void btnAddToFav_Click(object sender, EventArgs e)
        {
            MatchFavorites();
        }
        private void btnMoveTo_Click(object sender, EventArgs e)
        {
            MoveOrCopyCurrentFile();
        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            ToggleShuffle();
        }
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            ToggleLoop();
        }
        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            AddCurrentToQueue();
        }
        private void btnStartFromFile_Click(object sender, EventArgs e)
        {
            StartFromCurrentFile();
        }
        private void btnSourceSelector_Click(object sender, EventArgs e)
        {
            TrySourceToggle();
        }

        #region ExclusiveFullscreen
        private void panelPlayerMPV_MouseMove(object sender, MouseEventArgs e) //Used to determin Cursor position in exclusive Fullscreen mode to show or hide Panels
        {
            if (fR.WindowExclusiveFullscreen) //Only use when exclusive Fullscreen is enabled
            {
                panelBottom.Visible = areaBottom.Contains(e.Location) ? true : false;
                panelTop.Visible = areaTop.Contains(e.Location) ? true : false;
            }
        }

        private void panelPlayerMPV_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left && this.WindowState != FormWindowState.Maximized)
            {
                stopwatch.Restart();

                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
                long elapsedTime = stopwatch.ElapsedMilliseconds;
                if (elapsedTime < 105 && SettingsHandler.LeftMousePause) //Check whether it was a click
                {
                    checkwatch.Start();
                }
            }
            else if (e.Button == MouseButtons.Left && this.WindowState == FormWindowState.Maximized)
            {
                stopwatch.Restart();
                long elapsedTime = stopwatch.ElapsedMilliseconds;
                if (elapsedTime < 60 && SettingsHandler.LeftMousePause) //Check whether it was a click
                {
                    checkwatch.Start();
                }
            }
            if (e.Button == MouseButtons.Left && e.Clicks >= 2)
            {
                checkwatch.Stop();
                ToggleExclusiveFullscreen();
            }
            if (e.Button == MouseButtons.XButton1)
            {
                PlayPrevious();
            }
            if (e.Button == MouseButtons.XButton2 || e.Button == MouseButtons.Right)
            {
                PlayNext();
            }
        }

        private void Checkwatch_Tick(object? sender, EventArgs e)
        {
            checkwatch.Stop();
            PlayerPlayPauseToggle();
        }
        private void ToggleExclusiveFullscreen()
        {
            backupSize = fR.TempSize;
            fR.PlayerToExclusiveFullscreen(this, panelTop, panelBottom, panelPlayerMPV); //Toggle exclusive Fullscreen mode on double click

            if (fR.WindowExclusiveFullscreen)
            {
                activityTimer.Enabled = true;
            }
            else
            {
                activityTimer.Enabled = false;
                Cursor.Show();
                this.Size = backupSize;
            }
        }
        #endregion

        #region Player Controls
        private void PlayNext()
        {
            if (SettingsHandler.InitPlay == false && playingSingleFile == false)
            {
                PlayerPlayPauseToggle();
                //return;
            }
            // Check if the method is called too quickly in succession
            if ((DateTime.Now - lastPlayCommandTime) < minimumInterval)
            {
                return; // Exit if the call is too soon
            }
            lastPlayCommandTime = DateTime.Now; // Update the last command time

            ListHandler.PreparePlayList(SettingsHandler.SourceSelected, startedByFile, filepathFromStartupFile); //If needed, prepare the Playlist

            if (!(ListHandler.PlayList?.Any() ?? false))
            {
                MessageBox.Show("Playlist is empty!\nMake sure to set a default folder with your files or choose a folder to play from in the folder browser!");

                if (!playingSingleFile)
                {
                    ThreadHelper.SetText(this, lblTitleBar, "Random Video Player - 0 / 0 (Nothing found to play)");
                }
                return;
            }
            else
            {
                playingSingleFile = false;
                playerMPV.Loop = SettingsHandler.LoopPlayer;
            }

            if (!ListHandler.FirstPlay)
            {
                ListHandler.PlayListIndex = (ListHandler.PlayListIndex + 1) % ListHandler.PlayList.Count();
            }
            else
            {
                ListHandler.FirstPlay = false;
            }

            string videoFile = ListHandler.PlayList.ElementAt(ListHandler.PlayListIndex);

            if (!File.Exists(videoFile))
            {
                MessageBox.Show(string.Format("Can't find file:\n{0}\nMaybe the path has changed?", videoFile));
                var updatedList = ListHandler.PlayList.ToList();
                updatedList.RemoveAt(ListHandler.PlayListIndex);
                ListHandler.PlayList = updatedList;  //Delete Path from current List and update it
                ListHandler.PlayListIndex--;
                ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - {(ListHandler.PlayListIndex + 1).ToString()} / {ListHandler.PlayList.Count().ToString()}");
                return;
            }

            ThreadHelper.SetText(this, lblCurrentInfo, videoFile);
            ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - {(ListHandler.PlayListIndex + 1).ToString()} / {ListHandler.PlayList.Count().ToString()}");

            currentFile = videoFile;

            playerMPV.Load(videoFile, true);

            SettingsHandler.IsPlaying = false;

            ChangePlaybackSpeed(Speed.Reset);

            PlayerPlayPauseToggle(); //Resumes player if it's paused           
        }
        private void PlayPrevious()
        {
            if (SettingsHandler.InitPlay == false)
            {
                PlayerPlayPauseToggle();
                return;
            }
            // Check if the method is called too quickly in succession
            if ((DateTime.Now - lastPlayCommandTime) < minimumInterval)
            {
                return; // Exit if the call is too soon
            }
            lastPlayCommandTime = DateTime.Now; // Update the last command time

            ListHandler.PreparePlayList(SettingsHandler.SourceSelected, startedByFile, filepathFromStartupFile); //If needed, prepare the Playlist

            if (!(ListHandler.PlayList?.Any() ?? false) || (ListHandler.PlayListIndex == 0 && !ListHandler.FirstPlay))
            {
                return;
            }

            if (ListHandler.FirstPlay)
            {
                ListHandler.PlayListIndex = ListHandler.PlayList.Count() - 1;
                ListHandler.FirstPlay = false;
            }
            else
            {
                ListHandler.PlayListIndex = (ListHandler.PlayListIndex - 1 + ListHandler.PlayList.Count()) % ListHandler.PlayList.Count();
            }

            string videoFile = ListHandler.PlayList.ElementAt(ListHandler.PlayListIndex);

            if (!File.Exists(videoFile))
            {
                MessageBox.Show(string.Format("Can't find file:\n{0}\nMaybe the path has changed?", videoFile));
                var updatedList = ListHandler.PlayList.ToList();
                updatedList.RemoveAt(ListHandler.PlayListIndex);
                ListHandler.PlayList = updatedList;  //Delete Path from current List and update it
                ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - {(ListHandler.PlayListIndex + 1).ToString()} / {ListHandler.PlayList.Count().ToString()}");
                return;
            }

            ThreadHelper.SetText(this, lblCurrentInfo, videoFile);
            ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - {(ListHandler.PlayListIndex + 1).ToString()} / {ListHandler.PlayList.Count().ToString()}");

            currentFile = videoFile;

            playerMPV.Load(videoFile, true);

            SettingsHandler.IsPlaying = false;

            ChangePlaybackSpeed(Speed.Reset);

            PlayerPlayPauseToggle();
        }
        private void PlayerPlayPauseToggle()
        {
            if (ListHandler.PlayList?.Any() == true && SettingsHandler.InitPlay == false) //First Play to get going
            {
                SettingsHandler.InitPlay = true;
                return;
            }
            else if (!(ListHandler.PlayList?.Any() ?? false) && playingSingleFile == false)
            {
                ListHandler.NeedsToPrepare = true;
                if (!startedByFile && !string.IsNullOrWhiteSpace(PathHandler.FolderPath)) ListHandler.fillFolderList(PathHandler.FolderPath, ListHandler.IncludeSubfolders);
                ListHandler.PreparePlayList(SettingsHandler.SourceSelected, startedByFile, filepathFromStartupFile);
                if (!(ListHandler.PlayList?.Any() ?? false))
                {
                    MessageBox.Show("Check your folder paths!", "Nothing to play", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    SettingsHandler.InitPlay = true;
                    PlayNext();
                    return;
                }
            }
            else if (!(ListHandler.PlayList?.Any() ?? false) && playingSingleFile == true)
            {
                SettingsHandler.InitPlay = true;
                ListHandler.NeedsToPrepare = true;
                ListHandler.fillFolderList(PathHandler.FolderPath, ListHandler.IncludeSubfolders);
                ListHandler.PreparePlayList(SettingsHandler.SourceSelected, startedByFile, filepathFromStartupFile);
            }

            if (playingSingleFile == false)
            {
                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
                btnRemove.Enabled = true;
                btnListDel.Enabled = true;
                btnListAdd.Enabled = true;
                btnMoveTo.Enabled = true;
                btnAddToFav.Enabled = true;

                ThreadHelper.SetVisibility(this, btnAddToQueue, false);
                ThreadHelper.SetVisibility(this, btnStartFromFile, false);
            }

            var playPauseHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "PlayPauseToggle");

            if (SettingsHandler.IsPlaying)
            {
                playerMPV.Pause();
                SettingsHandler.IsPlaying = false;
                btnPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
                ThreadHelper.SetToolTipSafe(btnPlay, toolTipUI, $"{GetKeyCombination(playPauseHotkey)} | Start playing from selected source");
                tcServer.State = 1;
            }
            else
            {
                playerMPV.Resume();
                SettingsHandler.IsPlaying = true;
                btnPlay.IconChar = FontAwesome.Sharp.IconChar.Pause;
                ThreadHelper.SetToolTipSafe(btnPlay, toolTipUI, $"{GetKeyCombination(playPauseHotkey)} | Pause playback");
                tcServer.State = 2;
            }

            UpdateSourceSelectorIcon();

            startedByFile = false;
        }

        private void panelPlayerMPV_MouseWheel(object sender, MouseEventArgs e) //Move through video by Scrolling
        {
            if (e.Delta > 0)
            {
                SeekForward();
            }
            else if (e.Delta < 0)
            {
                SeekBackward();
            }
        }
        private void SeekForward()
        {
            try
            {
                if (!playerMPV.IsMediaLoaded) return;

                int seekValue = 0;

                bool isShortVideo = SettingsHandler.VideoDuration <= 60; //Smaller seek increments in short videos
                bool isLongVideo = SettingsHandler.VideoDuration >= 1800; //Bigger seek increments in long video (30 minutes+)
                bool isNearEnd = SettingsHandler.VideoRemaining > 0 && SettingsHandler.VideoRemaining < 15; //Decrease seek increments at the end to trigger next etc.

                if (isShortVideo)
                {
                    seekValue = isNearEnd ? 1 : 2;
                }
                else if (isLongVideo)
                {
                    seekValue = isNearEnd ? 1 : 15;
                }
                else
                {
                    seekValue = isNearEnd ? 1 : 5;
                }

                if (seekValue != 0)
                {
                    playerMPV.SeekAsync(seekValue, true);
                }
            }
            catch (Exception) { } //Player busy
        }
        private void SeekBackward()
        {
            try
            {
                if (!playerMPV.IsMediaLoaded) return;

                int seekValue = 0;

                seekValue = -2;

                if (seekValue != 0)
                {
                    playerMPV.SeekAsync(seekValue, true);
                }
            }
            catch (Exception) { } //Player busy
        }
        private void ToggleShuffle()
        {
            ListHandler.DoShuffle = !ListHandler.DoShuffle;
            UpdateButtonStates();

            ListHandler.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next

            PlayNext();
        }
        private void ToggleLoop()
        {
            SettingsHandler.LoopPlayer = !SettingsHandler.LoopPlayer;
            UpdateButtonStates();
            playerMPV.Loop = SettingsHandler.LoopPlayer;
        }

        private void TrySourceToggle()
        {
            if (SettingsHandler.SourceSelected) //If currently list
            {
                if (!(ListHandler.FolderList?.Any() ?? false))
                {
                    if(string.IsNullOrWhiteSpace(PathHandler.FolderPath))
                    {
                        MessageBox.Show("No folder to play from was set therefore I can't do that!");
                        return;
                    }
                    ListHandler.fillFolderList(PathHandler.FolderPath, ListHandler.IncludeSubfolders);
                    if (!(ListHandler.FolderList?.Any() ?? false))
                    {
                        MessageBox.Show("No Files to play, make sure you choose a correct folderpath!");
                        return;
                    }
                }
                SettingsHandler.SourceSelected = false;

            }
            else
            {
                if (!(ListHandler.CustomList?.Any() ?? false))
                {
                    MessageBox.Show("Custom List is empty");
                    return;
                }

                SettingsHandler.SourceSelected = true;
            }
            startedByFile = false;
            ListHandler.NeedsToPrepare = true;

            PlayNext();
        }

        private void ChangePlaybackSpeed(Speed action)
        {
            if (action == Speed.Reset)
            {
                ThreadHelper.SetText(this, lblSpeed, "");
                playerMPV.Speed = 1.0;
                return;
            }

            double[] playbackSpeeds = { 0.125, 0.25, 0.5, 0.75, 1.0, 1.2, 1.5, 2.0, 4.0 };
            string[] playbackSpeedStrings = { "0.125", "0.25", "0.5", "0.75", "1.0", "1.2", "1.5", "2.0", "4.0" }; //Because I couldn't figure another way to display the values as is

            double currentSpeed = playerMPV.Speed;

            int currentIndex = Array.IndexOf(playbackSpeeds, currentSpeed);

            if (currentIndex == -1)
            {
                currentIndex = Array.IndexOf(playbackSpeeds, 1.0);
            }

            if (action == Speed.Increase)
            {
                currentIndex = Math.Min(currentIndex + 1, playbackSpeeds.Length - 1);
            }
            else if (action == Speed.Decrease)
            {
                currentIndex = Math.Max(currentIndex - 1, 0);
            }

            playerMPV.Speed = playbackSpeeds[currentIndex];

            ThreadHelper.SetText(this, lblSpeed, $"x{playbackSpeedStrings[currentIndex]} -");       
        }

        public enum Speed
        {
            Increase,
            Decrease,
            Reset
        }
        #endregion

        #region CustomButton
        private void RepositionButtons()
        {
            List<Button> buttons = new List<Button> { btnRemove, btnListDel, btnListAdd, btnAddToFav, btnMoveTo, btnShuffle, btnRepeat, btnSourceSelector };
            if (buttons.Count != SettingsHandler.ButtonStates.Length)
            {
                SettingsHandler.ButtonStates = Enumerable.Repeat(true, buttons.Count).ToArray();
            }
            if (SettingsHandler.ButtonOrder.Count != SettingsHandler.ButtonStates.Length)
            {
                List<int> tempListForRestore = new List<int>();
                for (int i = 0; i < SettingsHandler.ButtonStates.Length; i++)
                {
                    tempListForRestore.Add(i);
                }
                SettingsHandler.ButtonOrder = tempListForRestore;
            }
            List<int> buttonOrder = SettingsHandler.ButtonOrder; //Default order

            bool[] buttonStates = SettingsHandler.ButtonStates;

            btnRemove.Visible = buttonStates[0];
            btnListDel.Visible = buttonStates[1];
            btnListAdd.Visible = buttonStates[2];
            btnAddToFav.Visible = buttonStates[3];
            btnMoveTo.Visible = buttonStates[4];
            btnShuffle.Visible = buttonStates[5];
            btnRepeat.Visible = buttonStates[6];
            btnSourceSelector.Visible = buttonStates[7];

            int x = 10; // starting x position
            int y = 0; // starting y position
            int margin = 20; // space between buttons

            int minimumFormSize = 930;

            foreach (int index in buttonOrder)
            {
                Button btn = buttons[index];
                if (btn.Visible)
                {
                    btn.Location = new Point(x, y);
                    x += btn.Width + margin;
                }
                else
                {
                    minimumFormSize = minimumFormSize - btn.Width - margin;
                }
            }
            this.MinimumSize = new Size(minimumFormSize, 420);
        }

        private void UpdateButtonStates()
        {
            btnMoveTo.IconChar = SettingsHandler.FileCopy ? FontAwesome.Sharp.IconChar.Copy : FontAwesome.Sharp.IconChar.FileExport;

            btnRepeat.IconColor = SettingsHandler.LoopPlayer ? Color.PaleGreen : Color.Black;
            btnShuffle.IconColor = ListHandler.DoShuffle ? Color.PaleGreen : Color.Black;
        }

        private void UpdateSourceSelectorIcon()
        {
            // Method 1: If the image is an embedded resource
            var assembly = Assembly.GetExecutingAssembly();

            var resourceName = SettingsHandler.SourceSelected ? "RandomVideoPlayer.Resources.SplitIconListHighlight.png" : "RandomVideoPlayer.Resources.SplitIconFolderHighlight.png";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    var image = Image.FromStream(stream);
                    btnSourceSelector.Image = image;
                    btnSourceSelector.ImageAlign = ContentAlignment.MiddleCenter; // Adjust alignment as needed
                    btnSourceSelector.TextImageRelation = TextImageRelation.ImageAboveText; // Adjust as needed
                }
                else
                {
                    MessageBox.Show("Was null duh");
                }
            }
        }
        #endregion

        #region FileManipulation
        private void DeleteCurrent()
        {
            if (ListHandler.FirstPlay && !playingSingleFile) return;

            var currentFile = playingSingleFile ? draggedFilePath : ListHandler.PlayList.ElementAt(ListHandler.PlayListIndex);
            var fileScripts = SettingsHandler.IncludeScripts ? FileManipulation.GetAssociatedFunscripts(currentFile) : new List<string>();

            if (string.IsNullOrWhiteSpace(PathHandler.RemoveFolder))
            {
                MessageBox.Show("Please choose a folder to delete files to under Settings => Paths");
                return;
            }
            else
            {
                try
                {
                    if (!Directory.Exists(PathHandler.RemoveFolder))
                    {
                        Directory.CreateDirectory(PathHandler.RemoveFolder);
                    }
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Couldn't get or create folder to delete files to");
                    MessageBox.Show($"Folder to move deleted files to is not valid: {ex}");
                    return;
                }
            }



            try
            {
                if (!SettingsHandler.DeleteFull) //Actually reversed due checkbox naming
                {
                    File.Delete(currentFile);
                    foreach (var script in fileScripts)
                    {
                        File.Delete(script);
                    }
                }
                else
                {
                    string removalPath = Path.Combine(PathHandler.RemoveFolder, FileManipulation.GetFileName(currentFile));

                    File.Move(currentFile, removalPath);
                    foreach (var script in fileScripts)
                    {
                        removalPath = Path.Combine(PathHandler.RemoveFolder, FileManipulation.GetFileName(script));
                        File.Move(script, removalPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, $"Error deleting file with action moving instead of deleting: {SettingsHandler.DeleteFull}");
                MessageBox.Show($"Error processing the file: {ex}");
                return;
            }

            ListHandler.DeleteStringFromCustomList(currentFile); //Delete path from Properties Settings

            if (!playingSingleFile)
            {
                var updatedList = ListHandler.PlayList.ToList();
                updatedList.RemoveAt(ListHandler.PlayListIndex);
                ListHandler.PlayList = updatedList;  //Delete Path from current List and update it
                ListHandler.PlayListIndex--;
            }
            else
            {
                var updatedList = ListHandler.PlayList.ToList();

                if (updatedList.Contains(currentFile))
                {
                    updatedList.Remove(currentFile);
                    ListHandler.PlayList = updatedList;  //Delete Path from current List and update it
                    ListHandler.PlayListIndex--;
                }
            }


            PlayNext();
        }
        private async void MoveOrCopyCurrentFile()
        {
            if (ListHandler.FirstPlay && !playingSingleFile) return;

            var currentFile = playingSingleFile ? draggedFilePath : ListHandler.PlayList.ElementAt(ListHandler.PlayListIndex);

            if (string.IsNullOrWhiteSpace(PathHandler.FileMoveFolderPath))
            {
                MessageBox.Show("Please choose a folder to Copy/Move files to under Settings => Paths");
                return;
            }
            else
            {
                try
                {
                    if (!Directory.Exists(PathHandler.FileMoveFolderPath))
                    {
                        Directory.CreateDirectory(PathHandler.FileMoveFolderPath);
                    }
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Couldn't get or create folder to copy/move files to");
                    MessageBox.Show($"Folder to Copy/Move files to is not valid: {ex}");
                    return;
                }
            }

            try
            {
                string FileDestinationPath = Path.Combine(PathHandler.FileMoveFolderPath, FileManipulation.GetFileName(currentFile));

                if (SettingsHandler.FileCopy)
                {
                    if (ongoingFileProcesses.Contains(currentFile)) return;

                    Task copyTask = CopyFileAsync(currentFile, FileDestinationPath);
                    ongoingTasks.Add(copyTask);
                    ongoingFileProcesses.Add(currentFile);
                    await copyTask;
                    ongoingFileProcesses.Remove(currentFile);
                    ongoingTasks.Remove(copyTask);
                }
                else
                {
                    if (!SettingsHandler.FileCopy) //When File was moved, delete it from current list
                    {
                        ListHandler.DeleteStringFromCustomList(currentFile); //Delete path from Properties Settings

                        var updatedList = ListHandler.PlayList.ToList();
                        updatedList.RemoveAt(ListHandler.PlayListIndex);
                        ListHandler.PlayList = updatedList;  //Delete Path from current List and update it
                        ListHandler.PlayListIndex--;

                        PlayNext();
                    }

                    await MoveFileAsync(currentFile, FileDestinationPath);
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Couldn't copy/move file to destination");
                MessageBox.Show($"Error processing the file: {ex}");
                return;
            }
        }
        private async Task CopyFileAsync(string sourceFilePath, string destinationFilePath)
        {
            await Task.Run(() => File.Copy(sourceFilePath, destinationFilePath, true));
        }

        private async Task MoveFileAsync(string sourceFilePath, string destinationFilePath)
        {
            await Task.Run(() => File.Move(sourceFilePath, destinationFilePath, true));
        }

        private void DeleteCurrentFromList()
        {
            if (ListHandler.FirstPlay && !playingSingleFile) return;

            if (playingSingleFile)
            {
                PlayNext();
                return;
            }

            var currentFile = ListHandler.PlayList.ElementAt(ListHandler.PlayListIndex);

            ListHandler.DeleteStringFromCustomList(currentFile); //Delete path from Properties Settings if found

            var updatedList = ListHandler.PlayList.ToList();
            updatedList.RemoveAt(ListHandler.PlayListIndex);
            ListHandler.PlayList = updatedList;  //Delete Path from current List and update it
            ListHandler.PlayListIndex--;

            PlayNext();
        }
        private void AddCurrentToList()
        {
            if (ListHandler.FirstPlay && !playingSingleFile) return;

            var currentFile = playingSingleFile ? draggedFilePath : ListHandler.PlayList.ElementAt(ListHandler.PlayListIndex);

            ListHandler.AddStringToCustomList(currentFile);
        }
        #endregion

        #region Initialization
        private void initStartUp(string alternativePath)
        {
            if (!string.IsNullOrWhiteSpace(alternativePath))
            {
                PathHandler.FolderPath = alternativePath;
            }
            else
            {
                PathHandler.FolderPath = string.IsNullOrWhiteSpace(PathHandler.DefaultFolder) || !Directory.Exists(PathHandler.DefaultFolder) ? "" : PathHandler.DefaultFolder;                
            }
            
            if(!SettingsHandler.IsPlaying)
                lblCurrentInfo.Text = string.IsNullOrWhiteSpace(PathHandler.FolderPath) ? "No folder selected!" : PathHandler.FolderPath; //Show current Folder

            if (ListHandler.FolderList?.Any() == false && !string.IsNullOrWhiteSpace(alternativePath))
            {
                if (SettingsHandler.StartupAlwaysAsk)
                {
                    var (result, isChecked) = CustomMessageBox.Show("Choose how to proceed", "You're about to play from the file's current directory, should I also include all subdirectories?", "Always ask? (You can change it in settings)", true);

                    if (result == DialogResult.Yes)
                    {
                        ListHandler.fillFolderList(PathHandler.FolderPath, true);
                    }
                    else
                    {
                        ListHandler.fillFolderList(PathHandler.FolderPath, false);
                    }

                    SettingsHandler.StartupAlwaysAsk = isChecked;
                }
                else
                {
                    ListHandler.fillFolderList(PathHandler.FolderPath, SettingsHandler.StartupAllDirectories);
                }
            }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var defaultListFolder = $@"{path}\RVP_ListFolder";

            if (string.IsNullOrWhiteSpace(PathHandler.PathToListFolder))
            {
                PathHandler.PathToListFolder = defaultListFolder;

                try
                {
                    if (!Directory.Exists(PathHandler.PathToListFolder))
                    {
                        Directory.CreateDirectory(PathHandler.PathToListFolder);
                    }
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Failed to create list folder");
                }
            }

            string favFile = PathHandler.PathToListFolder + @"\Favorites.txt";
            List<string> fromTXT = new List<string>();

            try
            {
                if (File.Exists(favFile))
                {
                    fromTXT = File.ReadLines(favFile).ToList();
                }

                tempFavorites = fromTXT;
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Failed to read Favorites.txt");
            }
        }

        #endregion

        #region Player Events
        private void MediaFinished(object sender, EventArgs e)
        {
            try
            {
                if (playerMPV.IsMediaLoaded && !SettingsHandler.LoopPlayer && !playingSingleFile)
                {
                    if (!(durationMS > 0)) return; //Check if it's an image
                    PlayNext();
                }
                else if (playerMPV.IsMediaLoaded && playingSingleFile)
                {
                    playerMPV.RestartAsync();
                }

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void SetMediaInfo(object sender, EventArgs e)
        {
            durationMS = (int)playerMPV.Duration.TotalMilliseconds;

            SettingsHandler.VideoDuration = durationMS / 1000; //seconds

            tcServer.Duration = durationMS.ToString();

            pbPlayerProgress.Maximum = durationMS;

            if (!string.IsNullOrWhiteSpace(currentFile))
            {
                favoriteMatch = playingSingleFile ? FavFunctions.IsFavoriteMatched(draggedFilePath, tempFavorites, btnAddToFav) : FavFunctions.IsFavoriteMatched(currentFile, tempFavorites, btnAddToFav);
                tcServer.Filepath = currentFile;

                var currentFileExtension = Path.GetExtension(currentFile).TrimStart('.').ToLower();
                if (ListHandler.ImageExtensions.Contains(currentFileExtension))
                {
                    pbPlayerProgress.DeleteActionsPoints();
                    return;
                }
            }
            else
            {
                pbPlayerProgress.DeleteActionsPoints();
                return;
            }
            pbPlayerProgress.DeleteActionsPoints();
            if (SettingsHandler.GraphEnabled)
            {
                var funscriptFilePath = playingSingleFile ? FileManipulation.GetFilePathWithDifferentExtension(draggedFilePath, ".funscript") : FileManipulation.GetFilePathWithDifferentExtension(currentFile, ".funscript");
                if (File.Exists(funscriptFilePath))
                {
                    pbPlayerProgress.LoadFunScript(funscriptFilePath);
                }
                else
                {
                    pbPlayerProgress.DeleteActionsPoints();
                }
            }
        }

        private void MatchFavorites()
        {
            if (ListHandler.FirstPlay && !playingSingleFile) return;

            string tempFile = playingSingleFile ? draggedFilePath : currentFile;

            if (!favoriteMatch)
            {
                tempFavorites = FavFunctions.AddToFavoritesList(tempFile);
                favoriteMatch = FavFunctions.IsFavoriteMatched(tempFile, tempFavorites, btnAddToFav);
            }
            else
            {
                tempFavorites = FavFunctions.DeleteFromFavorites(tempFile, tempFavorites);
                favoriteMatch = FavFunctions.IsFavoriteMatched(tempFile, tempFavorites, btnAddToFav);
            }
        }
        #endregion

        #region Player Progressbar related
        //Use progressbar for player control
        private void pbPlayerProgress_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (playerMPV.IsMediaLoaded)
                {
                    base.OnMouseClick(e);

                    var percentage = (int)((float)e.X / pbPlayerProgress.Width * pbPlayerProgress.Maximum);

                    playerMPV.SeekAsync(percentage / 1000, false); //Jump to video position based on cursor position on progress bar
                    pbPlayerProgress.Refresh();
                }
            }
            catch (Exception) { return; } //Player is busy
        }
        private void pbPlayerProgress_MouseMove(object sender, MouseEventArgs e) //Set Tooltip with video position on cursor position
        {
            if (!(durationMS > 0)) return;

            var percentage = (int)(((double)e.X) / pbPlayerProgress.Width * pbPlayerProgress.Maximum);
            var OnCursor = TimeSpan.FromMilliseconds(percentage);
            var formattedTime = OnCursor.ToString(@"hh\:mm\:ss");

            timeOverlayLabel.Text = formattedTime;

            Point controlRelativePosition = this.PointToClient(pbPlayerProgress.PointToScreen(new Point(e.X, e.Y)));

            // Set the label's location directly above the progress bar, horizontally centered on the cursor
            var labelX = controlRelativePosition.X - (timeOverlayLabel.Width / 2) + pbPlayerProgress.Location.X;
            var labelY = this.Height - 94;

            // Prevent the label from going beyond the left or right bounds of the progress bar
            labelX = Math.Max(labelX, panelBottom.Location.X);
            labelX = Math.Min(labelX, panelBottom.Location.X + pbPlayerProgress.Width - timeOverlayLabel.Width);

            timeOverlayLabel.Location = new Point(labelX, labelY);
            timeOverlayLabel.Visible = true;
        }
        private void pbPlayerProgress_MouseLeave(object sender, EventArgs e)
        {
            timeOverlayLabel.Visible = false;
        }
        private void InitializeTimeOverlay()
        {
            timeOverlayLabel.AutoSize = true;
            timeOverlayLabel.BackColor = Color.FromArgb(255, 182, 193);
            timeOverlayLabel.Padding = new Padding(0, 0, 0, 1);
            timeOverlayLabel.Font = new Font("Arial", 8, FontStyle.Bold);
            timeOverlayLabel.ForeColor = Color.Black;
            this.Controls.Add(timeOverlayLabel);
            timeOverlayLabel.BringToFront();
        }
        #endregion

        #region Player Volume related Controls
        private void MutePlayer()
        {
            if (pbVolume.Value > 0) //If Volume is not 0, set it to 0 aka mute it and save the last value
            {
                SettingsHandler.VolumeTemp = pbVolume.Value;
                pbVolume.Value = 0;
                playerMPV.Volume = 0;
            }
            else //If Volume is 0 aka muted, return Volume to previous value
            {
                pbVolume.Value = SettingsHandler.VolumeTemp;
                playerMPV.Volume = pbVolume.Value;
            }
        }
        private void btnMuteToggle_Click(object sender, EventArgs e) //Mute or Revert Volume
        {
            MutePlayer();
        }
        private void pbVolume_MouseWheel(object sender, MouseEventArgs e) //Adjust Player Volume with scrolling while Cursor on Volume bar
        {
            if (e.Delta > 0) //Detect Scroll Up and increase Volume
            {
                VolumeChange(true);
            }
            else if (e.Delta < 0) //Detect Scroll Down and decrease Volume
            {
                VolumeChange(false);
            }
        }
        private void VolumeChange(bool increase)
        {
            if (increase)
            {
                pbVolume.Value += 5;
                playerMPV.Volume = pbVolume.Value;
            }
            else
            {
                pbVolume.Value -= 5;
                playerMPV.Volume = pbVolume.Value;
            }
        }
        private void pbVolume_MouseDown(object sender, MouseEventArgs e) //Set Volume on Cursor position
        {
            base.OnMouseMove(e); // Ensure base event is called if needed

            UpdateVolume(e); // Update volume based on mouse position

            // Subscribe to the MouseMove event to continually update volume while mouse is down
            pbVolume.MouseMove += pbVolume_MouseMove;

            // Subscribe to the MouseUp event to stop updating volume when mouse button is released
            pbVolume.MouseUp += pbVolume_MouseUp;
        }

        private void pbVolume_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e); // Ensure base event is called if needed

            UpdateVolume(e); // Update volume based on mouse position
        }

        private void pbVolume_MouseUp(object sender, MouseEventArgs e)
        {
            // Unsubscribe from MouseMove event when mouse button is released
            pbVolume.MouseMove -= pbVolume_MouseMove;

            // Unsubscribe from MouseUp event
            pbVolume.MouseUp -= pbVolume_MouseUp;
        }

        private void UpdateVolume(MouseEventArgs e)
        {
            var percentage = (int)((float)e.X / pbVolume.Width * pbVolume.Maximum); // Get cursor position on Volume Bar

            pbVolume.Value = percentage; // Set Volume Bar to cursor position
            playerMPV.Volume = pbVolume.Value; // Set Player Volume to chosen Value
        }

        private void timeVolumeCheck_Tick(object sender, EventArgs e) //Change MuteButton Icon based on Volume for visibile consistency
        {
            byte volume = (byte)pbVolume.Value;
            switch (volume)
            {
                case <= 0:
                    btnMuteToggle.IconChar = FontAwesome.Sharp.IconChar.VolumeMute;
                    btnMuteToggle.IconSize = 28;
                    btnMuteToggle.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
                    break;
                case > 0 and <= 40:
                    btnMuteToggle.IconChar = FontAwesome.Sharp.IconChar.VolumeOff;
                    btnMuteToggle.IconSize = 21;
                    btnMuteToggle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    break;
                case > 40 and <= 70:
                    btnMuteToggle.IconChar = FontAwesome.Sharp.IconChar.VolumeLow;
                    btnMuteToggle.IconSize = 24;
                    btnMuteToggle.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
                    break;
                case > 70 and <= 100:
                    btnMuteToggle.IconChar = FontAwesome.Sharp.IconChar.VolumeHigh;
                    btnMuteToggle.IconSize = 31;
                    btnMuteToggle.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
                    break;
            }
        }
        #endregion

        #region Setup Tooltips and Hotkeys
        private void SetupTooltips()
        {
            var playPauseHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "PlayPauseToggle");
            var previousHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "PlayPrevious");
            var nextHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "PlayNext");
            var addToFavHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "Favorite");
            var moveOrCopyFileHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "MoveCopyFile");
            var shuffleHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "ToggleShuffle");
            var loopHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "ToggleLoop");
            var muteHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "MutePlayer");
            var deleteHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "DeleteCurrent");
            var deleteCurrentFromListHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "DeleteCurrentFromList");
            var addToCurrentListHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "AddCurrentToList");

            toolTipUI.InitialDelay = 1000;

            toolTipUI.SetToolTip(btnPlay, $"{GetKeyCombination(playPauseHotkey)} | Start playing from selected source");

            toolTipUI.SetToolTip(btnPrevious, $"{GetKeyCombination(previousHotkey)} | Previous track");
            toolTipUI.SetToolTip(btnNext, $"{GetKeyCombination(nextHotkey)} | Next track");
            toolTipUI.SetToolTip(btnFileBrowse, "Choose folder to play from");
            toolTipUI.SetToolTip(btnListBrowser, "Create your own lists with selected videos");
            toolTipUI.SetToolTip(btnListDel, $"{GetKeyCombination(deleteCurrentFromListHotkey)} | Remove currently played videofile from custom List and Playlist (No deletion)");
            toolTipUI.SetToolTip(btnListAdd, $"{GetKeyCombination(addToCurrentListHotkey)} | Add currently played videofile to custom List and Playlist");
            toolTipUI.SetToolTip(btnSettings, "Open settings menu");
            toolTipUI.SetToolTip(btnAddToFav, $"{GetKeyCombination(addToFavHotkey)} | Add current to favorite list");
            toolTipUI.SetToolTip(btnShuffle, $"{GetKeyCombination(shuffleHotkey)} | Toggle shuffle / Parse order");
            toolTipUI.SetToolTip(btnRepeat, $"{GetKeyCombination(loopHotkey)} | Toggle loop");
            toolTipUI.SetToolTip(btnMuteToggle, $"{GetKeyCombination(muteHotkey)} | Mute sound");
            toolTipUI.SetToolTip(pbVolume, "Scroll/Click to change volume");
            toolTipUI.SetToolTip(btnAddToQueue, "Add dropped file to queue");
            toolTipUI.SetToolTip(btnSourceSelector, "Switch between Folder and List Queue");

            toolTipUI.SetToolTip(btnAddToQueue, "Add the dropped file to the end of the current queue");
            toolTipUI.SetToolTip(btnStartFromFile, "Start playing from the files directory");

            if (SettingsHandler.FileCopy)
            {
                toolTipUI.SetToolTip(btnMoveTo, $"{GetKeyCombination(moveOrCopyFileHotkey)} | Copy file to: {PathHandler.FileMoveFolderPath}");
            }
            else
            {
                toolTipUI.SetToolTip(btnMoveTo, $"{GetKeyCombination(moveOrCopyFileHotkey)} | Move file to: {PathHandler.FileMoveFolderPath}");
            }

            if (!SettingsHandler.DeleteFull)
            {
                toolTipUI.SetToolTip(btnRemove, $"{GetKeyCombination(deleteHotkey)} | Delete currently played videofile completely (Change in settings)");
            }
            else
            {
                toolTipUI.SetToolTip(btnRemove, $"{GetKeyCombination(deleteHotkey)}  | Move currently played videofile to: {PathHandler.RemoveFolder}");
            }
        }

        private string GetKeyCombination(HotkeySetting hotkey)
        {
            if (hotkey == null) return "";
            if (hotkey.Modifiers == Keys.None)
            {
                return $"{hotkey.Key}";
            }
            else
            {
                return $"{hotkey.Modifiers} + {hotkey.Key}";
            }
        }
        //Setup Hotkeys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var hotkeys = HotkeyManager.LoadHotkeySettings();
            var matchedHotkey = hotkeys.Hotkeys.FirstOrDefault(h => h.Key == (keyData & Keys.KeyCode) && h.Modifiers == (keyData & Keys.Modifiers));
            if (matchedHotkey != null)
            {
                switch (matchedHotkey.Action)
                {
                    case "PlayPrevious":
                        PlayPrevious();
                        return true;
                    case "PlayNext":
                        PlayNext();
                        return true;
                    case "PlayPauseToggle":
                        PlayerPlayPauseToggle();
                        return true;
                    case "Close":
                        this.Close();
                        return true;
                    case "DeleteCurrent":
                        DeleteCurrent();
                        return true;
                    case "DeleteCurrentFromList":
                        DeleteCurrentFromList();
                        return true;
                    case "AddCurrentToList":
                        AddCurrentToList();
                        return true;
                    case "Favorite":
                        MatchFavorites();
                        return true;
                    case "MoveCopyFile":
                        MoveOrCopyCurrentFile();
                        return true;
                    case "ToggleShuffle":
                        ToggleShuffle();
                        return true;
                    case "ToggleLoop":
                        ToggleLoop();
                        return true;
                    case "MutePlayer":
                        MutePlayer();
                        return true;
                    case "VolumeIncrease":
                        VolumeChange(true);
                        return true;
                    case "VolumeDecrease":
                        VolumeChange(false);
                        return true;
                    case "ToggleExclusiveFullscreen":
                        ToggleExclusiveFullscreen();
                        return true;
                    case "SeekForward":
                        SeekForward();
                        return true;
                    case "SeekBackward":
                        SeekBackward();
                        return true;
                    case "SpeedIncrease":
                        ChangePlaybackSpeed(Speed.Increase);
                        return true;
                    case "SpeedDecrease":
                        ChangePlaybackSpeed(Speed.Decrease);
                        return true;
                    case "SpeedReset":
                        ChangePlaybackSpeed(Speed.Reset);
                        return true;
                    case "ZoomIn":
                        ZoomVideo(CommandSettings.ZoomStep);
                        return true;
                    case "ZoomOut":
                        ZoomVideo(-CommandSettings.ZoomStep);
                        return true;
                    case "PanLeft":
                        PanVideo(-CommandSettings.PanStep, true);
                        return true;
                    case "PanRight":
                        PanVideo(CommandSettings.PanStep, true);
                        return true;
                    case "PanUp":
                        PanVideo(-CommandSettings.PanStep, false);
                        return true;
                    case "PanDown":
                        PanVideo(CommandSettings.PanStep, false);
                        return true;
                    case "ResetVideoManipulation":
                        ResetVideoManipulation();
                        return true;
                    case "FitHorizontal":
                        AutoFillVideoHorizontally(true);
                        return true;
                    case "FitVertical":
                        AutoFillVideoHorizontally(false);
                        return true;
                    case "ScaleWidthUp":
                        ScaleVideo(CommandSettings.ScaleStep, true);
                        return true;
                    case "ScaleWidthDown":
                        ScaleVideo(-CommandSettings.ScaleStep, true);
                        return true;
                    case "ScaleHeightUp":
                        ScaleVideo(CommandSettings.ScaleStep, false);
                        return true;
                    case "ScaleHeightDown":
                        ScaleVideo(-CommandSettings.ScaleStep, false);
                        return true;
                    case "RotateClockwise":
                        RotateVideo(90, false);
                        return true;
                    case "Rotate180":
                        RotateVideo(180, false);
                        return true;
                    case "RotateCounterClockwise":
                        RotateVideo(-90, false);
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Timer
        private void timerProgressUpdate_Tick(object sender, EventArgs e) //Updates the ProgressBar to show current Videoposition
        {
            try
            {
                if (playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && SettingsHandler.InitPlay && SettingsHandler.VideoDuration > 0)
                {
                    var positionMS = (int)playerMPV.Position.TotalMilliseconds;
                    var remainingS = (int)playerMPV.Remaining.TotalSeconds;

                    SettingsHandler.VideoRemaining = remainingS;
                    pbPlayerProgress.Value = positionMS;

                    var _totalSpan = TimeSpan.FromMilliseconds(durationMS);
                    var _currentSpan = TimeSpan.FromMilliseconds(positionMS);
                    lblDurationInfo.Text = $"{_currentSpan:hh\\:mm\\:ss} / {_totalSpan:hh\\:mm\\:ss}";

                    tcServer.Position = positionMS.ToString();
                    pbPlayerProgress.Refresh();
                }
                else if (playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && playingSingleFile && SettingsHandler.VideoDuration > 0)
                {
                    var positionMS = (int)playerMPV.Position.TotalMilliseconds;
                    var remainingS = (int)playerMPV.Remaining.TotalSeconds;

                    SettingsHandler.VideoRemaining = remainingS;
                    pbPlayerProgress.Value = positionMS;

                    var _totalSpan = TimeSpan.FromMilliseconds(durationMS);
                    var _currentSpan = TimeSpan.FromMilliseconds(positionMS);
                    lblDurationInfo.Text = $"{_currentSpan:hh\\:mm\\:ss} / {_totalSpan:hh\\:mm\\:ss}";

                    tcServer.Position = positionMS.ToString();
                    pbPlayerProgress.Refresh();
                }
                else if (playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && SettingsHandler.InitPlay && SettingsHandler.VideoDuration == 0)
                {
                    lblDurationInfo.Text = "00:00:00 / 00:00:00";
                }
            }
            catch (Exception) { return; } //Player is busy
        }
        #endregion

        #region Drag and Drop

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    draggedFilePath = files[0];
                    var pathIsDirectory = false;

                    if (!File.Exists(draggedFilePath))
                    {
                        if (Directory.Exists(draggedFilePath))
                            pathIsDirectory = true;
                        else
                            return;

                    }

                    ChangePlaybackSpeed(Speed.Reset);

                    bool manageMultipleFiles;

                    if (files.Length > 1 && SettingsHandler.AlwaysAddFilesToQueue)
                    {
                        manageMultipleFiles = true;
                    }
                    else
                    {
                        manageMultipleFiles = false;
                    }


                    if (SettingsHandler.PlayOnDrop && manageMultipleFiles == false)
                    {
                        if (pathIsDirectory)
                        {
                            StartFromFolder(draggedFilePath, SettingsHandler.IncludeSubdirectoriesDnD);
                            return;
                        }

                        playerMPV.Loop = true;
                        playerMPV.Load(draggedFilePath, true);

                        SettingsHandler.IsPlaying = false;

                        playingSingleFile = true;

                        PlayerPlayPauseToggle();

                        ThreadHelper.SetText(this, lblCurrentInfo, draggedFilePath);
                        ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - Playing single file : Press next to jump back to queue or select other options");

                        btnNext.Enabled = true;
                        btnPrevious.Enabled = false;
                        btnRemove.Enabled = true;
                        btnListDel.Enabled = true;
                        btnListAdd.Enabled = true;
                        btnMoveTo.Enabled = true;
                        btnAddToFav.Enabled = true;

                        btnAddToQueue.Visible = true;
                        btnStartFromFile.Visible = true;
                    }
                    else
                    {
                        var playlistLoadedBefore = true;

                        if (!(ListHandler.PlayList?.Any() ?? false)) playlistLoadedBefore = false;

                        if (pathIsDirectory)
                        {
                            var filesAddedCount = 0;
                            var updatedList = ListHandler.PlayList.ToList();

                            foreach (string dir in files)
                            {
                                var filesFromDirectory = GrabFromDirectory(dir, SettingsHandler.IncludeSubdirectoriesDnD);
                                if (filesFromDirectory.Count() == 0) continue;

                                filesAddedCount = filesAddedCount + filesFromDirectory.Count();
                                updatedList.AddRange(filesFromDirectory);
                            }

                            ListHandler.PlayList = updatedList;
                            ListHandler.FolderList = updatedList;

                            ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - {(ListHandler.PlayListIndex + 1).ToString()} / {ListHandler.PlayList.Count().ToString()} - Added {filesAddedCount} files to queue");

                        }
                        else
                        {
                            foreach (string file in files)
                            {
                                AddAFileToQueue(file);
                                ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - {(ListHandler.PlayListIndex + 1).ToString()} / {ListHandler.PlayList.Count().ToString()} - Added {files.Length} files to queue");
                            }
                        }

                        if (!playlistLoadedBefore)
                        {
                            PlayNext();
                        }
                    }
                }
            }
        }
        private void AddCurrentToQueue()
        {
            if (playingSingleFile)
            {
                if (!(ListHandler.PlayList?.Any() ?? false))
                {
                    MessageBox.Show("No Playlist loaded, so this can't be added to it");
                    return;
                }

                var updatedList = ListHandler.PlayList.ToList();
                updatedList.Add(draggedFilePath);
                ListHandler.PlayList = updatedList;
                ListHandler.FolderList = updatedList;
                ListHandler.PlayListIndex--;
                PlayNext();
            }
        }
        private void StartFromCurrentFile()
        {
            if (playingSingleFile)
            {
                try
                {
                    ListHandler.fillFolderList(FileManipulation.GetFileDirectory(draggedFilePath), false);

                    ListHandler.NeedsToPrepare = true;
                    SettingsHandler.SourceSelected = false;
                    ListHandler.PreparePlayList(SettingsHandler.SourceSelected, true, draggedFilePath);

                    playingSingleFile = false;
                    PlayNext();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error playing from this path: {ex}");
                    throw;
                }

            }
        }
        private void StartFromFolder(string path, bool includeSubDirectories)
        {
            ListHandler.fillFolderList(path, includeSubDirectories);


            if (!(ListHandler.TempFolderList?.Any() ?? false))
            {
                if (!(ListHandler.FolderList?.Any() ?? false))
                {
                    MessageBox.Show($"Yor chosen folder has no valid files to play from and there is no valid path to fall back to!\n\nThe Path was:\n{path}");
                    return;
                }
                MessageBox.Show($"Yor chosen folder has no valid files to play from; No action taken!\n\nThe Path was:\n{path}");
                return;
            }
            else
            {
                PathHandler.FolderPath = path;
                ListHandler.TempFolderList = Enumerable.Empty<string>();
            }

            startedByFile = false;
            lblCurrentInfo.Text = PathHandler.FolderPath;
            ListHandler.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next
            SettingsHandler.SourceSelected = false;
            PlayNext();
        }
        private void AddAFileToQueue(string filePath)
        {
            var updatedList = ListHandler.PlayList.ToList();
            updatedList.Add(filePath);
            ListHandler.PlayList = updatedList;
            ListHandler.FolderList = updatedList;
        }
        private IEnumerable<string> GrabFromDirectory(string folderPath, bool includeSubDirectories)
        {
            SearchOption searchOption = includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var combinedExtensions = ListHandler.Extensions;
            try
            {
                //Get all Files from current Directory and return all Files filtered by Extensions
                return Directory.EnumerateFiles(folderPath, "*.*", searchOption)
                        .Where(s => combinedExtensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                        .ToArray();
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Unable to gather directory information in LB");
                MessageBox.Show($"Unable to gather directory information: {ex}");
                return Enumerable.Empty<string>();
            }
        }
        #endregion

        #region Videomanipulation

        private void ZoomVideo(double zoomStep)
        {
            int increment = zoomStep > 0 ? 1 : -1;
            if (CommandSettings.Instance.IncrementZoomCounter(increment)) return;

            playerMPV.ZoomVideo(zoomStep);
        }

        private void PanVideo(double panStep, bool horizontal)
        {
            int increment = panStep > 0 ? 1 : -1;

            if (horizontal)
            {
                if (CommandSettings.Instance.IncrementPanCounterHorizontal(increment)) return;
                playerMPV.PanVideoHorizontal(panStep);
            }
            else
            {
                if (CommandSettings.Instance.IncrementPanCounterVertical(increment)) return;
                playerMPV.PanVideoVertical(panStep);
            }
        }

        private void ScaleVideo(double scaleStep, bool horizontal)
        {
            int increment = scaleStep > 0 ? 1 : -1;

            if (horizontal)
            {
                if (CommandSettings.Instance.IncrementScaleCounterHorizontal(increment)) return;
                playerMPV.ScaleVideoHoriztonal(scaleStep);
            }
            else
            {
                if (CommandSettings.Instance.IncrementScaleCounterVertical(increment)) return;
                playerMPV.ScaleVideoVertical(scaleStep);
            }
        }

        private void RotateVideo(int rotateFactor, bool absolute)
        {
            playerMPV.RotateVideo(rotateFactor, absolute);
        }
        private void ResetVideoManipulation()
        {
            //Reset zoom factor
            CommandSettings.Instance.ZoomCounter = 0;
            playerMPV.ZoomVideo(0, true);
            //Reset pan factors
            CommandSettings.Instance.PanCounterHorizonal = 0;
            CommandSettings.Instance.PanCounterVertical = 0;
            playerMPV.PanVideoHorizontal(0, true);
            playerMPV.PanVideoVertical(0, true);
            //Reset panscan
            playerMPV.Panscan(false);
            //Reset scale factors
            playerMPV.ScaleVideoHoriztonal(1, true);
            playerMPV.ScaleVideoVertical(1, true);
            //Reset rotation
            playerMPV.RotateVideo(0, true);

        }
        private void AutoFillVideoHorizontally(bool alignHorizontally)
        {
            playerMPV.Panscan(alignHorizontally);
        }
        #endregion

        #region Logic for standard WindowsForms Controls
        private void MainForm_Resize(object sender, EventArgs e)
        {
            fR.AdjustForm(this); //Correct Padding based on window state because WndProc method messes up a bit

            //Adjust the areas used for determin when panels should show up during exclusive Fullscreen mode
            areaBottom = new Rectangle(2, this.Height - panelBottom.Height - 30, this.Width, panelBottom.Height + 30);
            areaTop = new Rectangle(2, 2, this.Width, panelTop.Height + 10);

            //Get Current formSize (Only from normal windows state)
            if (this.WindowState == FormWindowState.Normal)
            {
                //fR.TempSize = new System.Drawing.Size(this.Width - 16, this.Height - 39);
                fR.TempSize = this.Size;
                fR.FormSize = fR.TempSize;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ongoingTasks.Count > 0)
            {
                e.Cancel = true;
                if (ongoingTasks.Count == 1)
                {
                    MessageBox.Show($"A file moving/copying task is still being executed, please wait until finished before closing");
                }
                else
                {
                    MessageBox.Show($"{ongoingTasks.Count} file moving/copying tasks are still being executed, please wait until finished before closing");
                }

            }

            tcServer.Stop();
            fR.FormSize = fR.TempSize; //Save last known form size to property
            PathHandler.TempRecentFolder = string.Empty;

            if (SettingsHandler.VolumeMember)
                SettingsHandler.VolumeLastValue = pbVolume.Value;

            UnregisterHotKeys();

        }
        private void btnMaximizeForm_Click(object sender, EventArgs e)
        {
            fR.MaximizeForm(this);
        }
        private void btnMinimizeForm_Click(object sender, EventArgs e)
        {
            fR.MinimizeForm(this);
        }
        private void btnExitForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        //WndProc
        #region WndProc Code for clean style of the Form and regaining usability
        //Used for still being able to move the Form around with a mouse down event
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        private const uint MOD_NONE = 0x0000; // No modifier
        public void RegisterHotKeys()
        {
            RegisterHotKey(this.Handle, 0, MOD_NONE, (uint)Keys.MediaPlayPause);
            RegisterHotKey(this.Handle, 1, MOD_NONE, (uint)Keys.MediaStop);
            RegisterHotKey(this.Handle, 2, MOD_NONE, (uint)Keys.MediaNextTrack);
            RegisterHotKey(this.Handle, 3, MOD_NONE, (uint)Keys.MediaPreviousTrack);
        }

        // Method to unregister global hotkeys
        public void UnregisterHotKeys()
        {
            for (int i = 0; i < 3; i++)
            {
                UnregisterHotKey(this.Handle, i);
            }
        }
        //Hide Cursor in exclusive Fullscreenmode
        void activityWorker_Tick(object sender, EventArgs e)
        {
            bool shouldHide = User32Interop.GetLastInput() > activityThreshold;
            if (cursorHidden != shouldHide)
            {
                if (shouldHide)
                    Cursor.Hide();
                else
                    Cursor.Show();

                cursorHidden = shouldHide;
            }
        }

        //Code for Borderless, resizable Form with Aero Snaps. Also set up the Hotkeys
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int WM_HOTKEY = 0x0312;
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case 0: // ID for MediaPlayPause
                        PlayerPlayPauseToggle();
                        break;
                    case 1:
                        PlayerPlayPauseToggle();
                        break;
                    case 2:
                        PlayNext();
                        break;
                    case 3:
                        PlayPrevious();
                        break;
                }
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        }
        #endregion

    }
}