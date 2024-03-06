using System.Runtime.InteropServices;
using Mpv.NET.Player;
using RandomVideoPlayer.Model;
using RandomVideoPlayerV3.Functions;
using RandomVideoPlayerV3.Model;
using RandomVideoPlayerV3.View;
using Point = System.Drawing.Point;
using SystemColors = System.Drawing.SystemColors;

namespace RandomVideoPlayerV3
{
    public partial class MainForm : Form
    {
        private MpvPlayer playerMPV;
        private WebServer tcServer;

        //Initiate Classes
        private SettingsHandler sH = new SettingsHandler();
        private FormResize fR = new FormResize();
        private PathHandler pH = new PathHandler();
        private ListHandler lH = new ListHandler();

        //Initialize Areas for Panel Fade-In/Out in exclusive fullscreen mode
        private Rectangle areaBottom = new Rectangle();
        private Rectangle areaTop = new Rectangle();

        private Size backupSize;

        private List<string> tempFavorites = new List<string>();
        private bool favoriteMatch = false;
        private bool internalCheck = false;

        private Label timeOverlayLabel = new Label();
        private int durationMS = 0;
        private string currentFile;

        private System.Windows.Forms.Timer tooltipUpdateTimer = new System.Windows.Forms.Timer();

        //Init mouse idle to hide cursor when in exclusive fullscreen mode
        System.Windows.Forms.Timer activityTimer = new System.Windows.Forms.Timer();
        TimeSpan activityThreshold = TimeSpan.FromSeconds(2); //Idleduration it takes to hide the cursor in seconds
        bool cursorHidden = false;

        public MainForm()
        {
            InitializeComponent();
            //If setting set to remember last size, regain size
            if (fR.SaveLastSize == true)
            {
                fR.FormSize = new Size(fR.FormSize.Width - 16, fR.FormSize.Height - 39);
                this.ClientSize = fR.FormSize;
            }
            //Initialize Player Element
            playerMPV = new MpvPlayer(panelPlayerMPV.Handle) { Loop = sH.LoopPlayer, Volume = 50, KeepOpen = KeepOpen.Yes };
            //Initialize WebServer
            tcServer = new WebServer();
            if (sH.TimeCodeServer) { tcServer.Start(); }

            //Set up MouseWheel Controlevents
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


        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            initStartUp(); //Load default folder if set and fill playlist
            SetupTooltips();
            btnShuffle.IconColor = lH.DoShuffle ? SystemColors.ButtonHighlight : Color.Black;
            //Load up a default image
            string img = Path.Combine(Application.StartupPath, @"Resources\RVP_BlackBG.png");
            playerMPV.Load(img, true);
            InitializeTimeOverlay();
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            lH.PreparePlayList(sH.SourceSelected); //If needed, prepare the Playlist

            if (lH.PlayList?.Any() == true && sH.InitPlay == false) //First Play to get going
            {
                playNext();
            }
            else if (lH.PlayList?.Any() == true && sH.InitPlay == true) //Switches to Pause/Play Toggle
            {
                playerPause();
            }
            else
            {
                MessageBox.Show("Check your folder paths!", "Nothing to play", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            playPrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            playNext();
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            btnFileBrowse.IconColor = SystemColors.ButtonHighlight;
            FolderBrowserView fbForm = new FolderBrowserView();
            fbForm.StartPosition = FormStartPosition.Manual;
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            fbForm.Load += delegate (object s2, EventArgs e2)
            {
                fbForm.Location = new Point(Bounds.Location.X + (Bounds.Width / 2) - (fbForm.Width / 2), Bounds.Location.Y + (Bounds.Height / 2) - (fbForm.Height / 2));
            };
#pragma warning restore CS8622
            DialogResult result = fbForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                int count = sH.RecentCount;

                if (count <= 0) { count = 10; }

                if (sH.RecentChecked)
                {
                    pH.FolderPath = fbForm.selectedPath;
                    Environment.SpecialFolder root = fbDialog.RootFolder;
                    lblCurrentInfo.Text = pH.FolderPath;
                    lH.latestFolderList(pH.FolderPath, count);

                    lH.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next
                }
                else
                {

                    pH.FolderPath = fbForm.selectedPath;
                    Environment.SpecialFolder root = fbDialog.RootFolder;
                    lblCurrentInfo.Text = pH.FolderPath;
                    lH.fillFolderList(pH.FolderPath);

                    lH.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next
                }
                internalCheck = true;
                tbSourceSelector.Checked = false;
                internalCheck = false;
                playNext();
            }

            btnFileBrowse.IconColor = Color.Black;
        }

        private void btnListBrowser_Click(object sender, EventArgs e)
        {
            btnListBrowser.IconColor = SystemColors.ButtonHighlight;
            ListBrowserView lbForm = new ListBrowserView();
            lbForm.StartPosition = FormStartPosition.Manual;
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            lbForm.Load += delegate (object s2, EventArgs e2)
            {
                lbForm.Location = new Point(Bounds.Location.X + (Bounds.Width / 2) - (lbForm.Width / 2), Bounds.Location.Y + (Bounds.Height / 2) - (lbForm.Height / 2));
            };
#pragma warning restore CS8622
            DialogResult result = lbForm.ShowDialog();
            lH.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next
            if (result == DialogResult.OK)
            {
                internalCheck = true;
                tbSourceSelector.Checked = true;
                internalCheck = false;
                playNext();
            }
            btnListBrowser.IconColor = Color.Black;

            //lH.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsView svForm = new SettingsView();
            svForm.StartPosition = FormStartPosition.Manual;
            svForm.Load += delegate (object s2, EventArgs e2)
            {
                svForm.Location = new Point(this.Bounds.Location.X + (this.Bounds.Width / 2) - svForm.Width / 2, this.Bounds.Location.Y + (this.Bounds.Height / 2) - svForm.Height / 2);
            };
            DialogResult result = svForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (sH.TimeCodeServer)
                {
                    tcServer.Start();
                }
                else
                {
                    tcServer.Stop();
                }

                initStartUp(); //Used to fix issues at first time startup
            }
            playerMPV.Loop = sH.LoopPlayer; //Updaze Player behavior
        }
        private void btnAddToFav_Click(object sender, EventArgs e)
        {
            if (!favoriteMatch)
                addToFavorites();
            else
                deleteFromFavorites();
        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            toggleShuffle();
        }
        private void tbSourceSelector_CheckedChanged(object sender, EventArgs e)
        {
            sH.SourceSelected = tbSourceSelector.Checked;

            lH.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next

            if (!sH.SourceSelected)
            {
                lblCurrentInfo.Text = pH.FolderPath; //Show current Folder no matter what for better usability
            }

            if (tbSourceSelector.Checked)
            {
                InfoLabelUseList.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                InfoLabelUseFolder.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            }
            else
            {
                InfoLabelUseList.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                InfoLabelUseFolder.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }

            if (!internalCheck)
            {
                playNext();
            }
        }
        private void SetupTooltips()
        {
            toolTipUI.InitialDelay = 1000;

            toolTipUI.SetToolTip(btnPlay, "Start playing from selected source");
            toolTipUI.SetToolTip(btnPrevious, "Left Arrow | Previous track");
            toolTipUI.SetToolTip(btnNext, "Right Arrow | Next track");
            toolTipUI.SetToolTip(btnFileBrowse, "Choose folder to play from (includes all subfolder)");
            toolTipUI.SetToolTip(btnListBrowser, "Create your own lists with selected videos");
            toolTipUI.SetToolTip(btnRemove, "Del | Delete currently played videofile (or move it to set directory)");
            toolTipUI.SetToolTip(btnSettings, "Open settings menu");
            toolTipUI.SetToolTip(btnAddToFav, "F | Add current to favorite list");
            toolTipUI.SetToolTip(btnShuffle, "S | Toggle shuffle / Parse order");
            toolTipUI.SetToolTip(btnMuteToggle, "M | Mute sound");
            toolTipUI.SetToolTip(pbVolume, "Scroll/Click to change volume");
            toolTipUI.SetToolTip(tbSourceSelector, "Choose whether to play from selected folder or your custom list");
        }
        //Setup Hotkeys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Left))
            {
                playPrevious();
                return true;
            }
            else if (keyData == (Keys.Right))
            {
                playNext();
                return true;
            }
            else if (keyData == (Keys.Space))
            {
                playerPause();
                return true;
            }
            else if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }
            else if (keyData == (Keys.Delete))
            {
                DeleteCurrent();
                return true;
            }
            else if (keyData == (Keys.F))
            {
                if (!favoriteMatch)
                    addToFavorites();
                else
                    deleteFromFavorites();
                return true;
            }
            else if (keyData == (Keys.S))
            {
                toggleShuffle();
                return true;
            }
            else if (keyData == (Keys.M))
            {
                MutePlayer();
                return true;
            }
            else if (keyData == (Keys.F11))
            {
                toggleExclusiveFullscreen();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #region Timer

        private void timerProgressUpdate_Tick(object sender, EventArgs e) //Updates the ProgressBar to show current Videoposition
        {
            try
            {
                if (playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && sH.InitPlay && sH.VideoDuration > 0)
                {
                    int positionMS = (int)playerMPV.Position.TotalMilliseconds;
                    int remainingS = (int)playerMPV.Remaining.TotalSeconds;

                    sH.VideoRemaining = remainingS;
                    pbPlayerProgress.Value = positionMS;

                    TimeSpan _totalSpan = TimeSpan.FromMilliseconds(durationMS);
                    TimeSpan _currentSpan = TimeSpan.FromMilliseconds(positionMS);
                    lblDurationInfo.Text = $"{_currentSpan:hh\\:mm\\:ss} / {_totalSpan:hh\\:mm\\:ss}";

                    tcServer.position = positionMS.ToString();
                    pbPlayerProgress.Refresh();
                }
                else if(playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && sH.InitPlay && sH.VideoDuration == 0)
                {
                    lblDurationInfo.Text = "00:00:00 / 00:00:00";
                }
            }
            catch (Exception) { return; } //Player is busy
        }

        #endregion

        #region ExclusiveFullscreen
        private void panelPlayerMPV_MouseMove(object sender, MouseEventArgs e) //Used to determin Cursor position in exclusive Fullscreen mode to show or hide Panels
        {
            if (fR.WindowExclusiveFullscreen) //Only use when exclusive Fullscreen is enabled
            {
                if (!areaBottom.Contains(e.Location)) //Hide or Show Bottom Panel when Cursor is in bottom area
                {
                    panelBottom.Visible = false;
                }
                else
                {
                    panelBottom.Visible = true;
                }

                if (!areaTop.Contains(e.Location)) //Hide or Show Top Panel when Cursor is in top area
                {
                    panelTop.Visible = false;
                }
                else
                {
                    panelTop.Visible = true;
                }
            }
        }

        private void panelPlayerMPV_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left && this.WindowState != FormWindowState.Maximized)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }

            if (e.Button == MouseButtons.Left && e.Clicks >= 2)
            {
                toggleExclusiveFullscreen();
            }
            if (e.Button == MouseButtons.XButton1)
            {
                playPrevious();
            }
            if (e.Button == MouseButtons.XButton2 || e.Button == MouseButtons.Right)
            {
                playNext();
            }
        }
        private void toggleExclusiveFullscreen()
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
                this.Size = backupSize;
            }
        }
        #endregion

        #region Player Controls
        private void DeleteCurrent()
        {
            //Move current playing file to a determined folder
            string currentFile = lH.PlayList.ElementAt(lH.PlayListIndex);

            string[] pathParts = currentFile.Split(@"\");
            string fileName = pathParts[pathParts.Length - 1]; //Get the FileName from full path 

            string removalPath = Path.Combine(pH.RemoveFolder, fileName);

            if (!Directory.Exists(pH.RemoveFolder))
            {
                Directory.CreateDirectory(pH.RemoveFolder);
            }

            if (sH.DeleteFull)
            {
                try
                {
                    File.Delete(currentFile);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error moving the file: {ex}");
                    return;
                }
            }
            else
            {
                try
                {
                    File.Move(currentFile, removalPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error moving the file: {ex}");
                    return;
                }
            }

            lH.DeleteStringFromCustomList(currentFile); //Delete path from Properties Settings

            List<string> updatedList = lH.PlayList.ToList();
            updatedList.RemoveAt(lH.PlayListIndex);
            lH.PlayList = updatedList;  //Delete Path from current List and update it
            lH.PlayListIndex--;

            playNext();
        }
        private void playNext()
        {
            lH.PreparePlayList(sH.SourceSelected); //If needed, prepare the Playlist

            if (lH.PlayList?.Any() == true && sH.InitPlay == false) //First Play to get going
            {
                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
                btnRemove.Enabled = true;

                sH.InitPlay = true;
            }

            string videoFile = "";

            if (lH.PlayList?.Any() == true)
            {
                if (lH.FirstPlay == true)
                {
                    videoFile = lH.PlayList.ElementAt(lH.PlayListIndex);
                    lH.FirstPlay = false;
                }
                else if (lH.PlayListIndex < lH.PlayList.Count() - 1)
                {
                    lH.PlayListIndex++;
                    videoFile = lH.PlayList.ElementAt(lH.PlayListIndex);
                }
                else if (lH.PlayListIndex == lH.PlayList.Count() - 1)
                {
                    lH.PlayListIndex = 0;
                    videoFile = lH.PlayList.ElementAt(lH.PlayListIndex);
                }

                if (!File.Exists(videoFile))
                {
                    MessageBox.Show(string.Format("Can't find file:\n{0}\nMaybe the path has changed?", videoFile));
                    return;
                }

                lblCurrentInfo.Text = videoFile;
                currentFile = videoFile;

                playerMPV.Load(videoFile, true);

                sH.IsPlaying = false;

                playerPause();

                checkFavoriteStatus(videoFile);

                tcServer.filepath = videoFile;
                tcServer.state = "2";

                string currentCount = (lH.PlayListIndex + 1).ToString();
                string totalCount = lH.PlayList.Count().ToString();

                lblTitleBar.Text = "Random Video Player - " + currentCount + " / " + totalCount;
            }
            else
            {
                lblTitleBar.Text = "Random Video Player - 0 / 0 (Nothing found to play)";
                MessageBox.Show("No Files to play");
                return;
            }
        }

        private void playPrevious()
        {
            lH.PreparePlayList(sH.SourceSelected); //If needed, prepare the Playlist

            if (lH.PlayList?.Any() == true && sH.InitPlay == false) //First Play to get going
            {
                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
                btnRemove.Enabled = true;

                sH.InitPlay = true;
            }

            string videoFile = "";

            if (lH.PlayList?.Any() == true)
            {
                if (lH.PlayListIndex > 0)
                {
                    lH.PlayListIndex--;
                    videoFile = lH.PlayList.ElementAt(lH.PlayListIndex);
                }
                else
                {
                    videoFile = lH.PlayList.ElementAt(lH.PlayListIndex);
                }

                if (!File.Exists(videoFile))
                {
                    MessageBox.Show(string.Format("Can't find file:\n{0}\nMaybe the path has changed?", videoFile));
                    return;
                }

                lblCurrentInfo.Text = videoFile;
                currentFile = videoFile;

                playerMPV.Load(videoFile, true);

                sH.IsPlaying = false;

                playerPause();

                checkFavoriteStatus(videoFile);

                tcServer.filepath = videoFile;
                tcServer.state = "2";

                string currentCount = (lH.PlayListIndex + 1).ToString();
                string totalCount = lH.PlayList.Count().ToString();

                lblTitleBar.Text = "Random Video Player - " + currentCount + " / " + totalCount;
            }
            else
            {
                lblTitleBar.Text = "Random Video Player - 0 / 0 (Nothing found to play)";
                MessageBox.Show("No Files to play");
                return;
            }
        }

        private void SetMediaInfo(object sender, EventArgs e)
        {
            durationMS = (int)playerMPV.Duration.TotalMilliseconds;

            sH.VideoDuration = durationMS / 1000; //seconds

            tcServer.duration = durationMS.ToString();

            pbPlayerProgress.Maximum = durationMS;

            if (!string.IsNullOrWhiteSpace(currentFile))
            {
                string currentFileExtension = Path.GetExtension(currentFile).TrimStart('.').ToLower();
                if (lH.ImageExtensions.Contains(currentFileExtension))
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
            string funscriptFilePath = GetFilePathWithDifferentExtension(currentFile, ".funscript");
            if (File.Exists(funscriptFilePath))
            {
                pbPlayerProgress.LoadFunScript(funscriptFilePath);
            }
            else
            {
                pbPlayerProgress.DeleteActionsPoints();
            }

        }

        private void playerPause()
        {
            if (sH.IsPlaying)
            {
                playerMPV.Pause();
                sH.IsPlaying = false;
                btnPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
                toolTipUI.SetToolTip(btnPlay, "Space | Start playing from selected source");

                tcServer.state = "1";
            }
            else
            {
                playerMPV.Resume();
                sH.IsPlaying = true;
                btnPlay.IconChar = FontAwesome.Sharp.IconChar.Pause;
                toolTipUI.SetToolTip(btnPlay, "Space | Pause playback");

                tcServer.state = "2";
            }
        }
        private void addToFavorites()
        {
            if (lH.PlayList?.Any() == true && sH.InitPlay) //First Play to get going
            {
                string currentFile = lH.PlayList.ElementAt(lH.PlayListIndex);
                string favFile = pH.FolderList + @"\Favorites.txt";

                List<string> fromTXT = new List<string>();

                if (File.Exists(favFile))
                {
                    fromTXT = File.ReadLines(favFile).ToList();
                }
                if (!fromTXT.Contains(currentFile))
                {
                    fromTXT.Add(currentFile);
                }

                tempFavorites = fromTXT;
                File.WriteAllLines(favFile, fromTXT);
                checkFavoriteStatus(currentFile);
            }
        }

        private void deleteFromFavorites()
        {
            string currentFile = lH.PlayList.ElementAt(lH.PlayListIndex);
            string favFile = pH.FolderList + @"\Favorites.txt";

            tempFavorites.Remove(currentFile);

            File.WriteAllLines(favFile, tempFavorites);
            checkFavoriteStatus(currentFile);
        }

        private void checkFavoriteStatus(string currentVideo)
        {
            if (tempFavorites.Contains(currentVideo))
            {
                btnAddToFav.IconColor = Color.Red;
                favoriteMatch = true;
            }
            else
            {
                btnAddToFav.IconColor = Color.Black;
                favoriteMatch = false;
            }
        }

        private void initStartUp()
        {
            if (string.IsNullOrEmpty(pH.DefaultFolder)) { pH.DefaultFolder = pH.FallbackPath; } //If Folder is not set yet, default to Fallback

            if (Directory.Exists(pH.DefaultFolder))
            {
                pH.FolderPath = pH.DefaultFolder;
            }
            else
            {
                MessageBox.Show("Set default path not found, using fallback!");
                pH.FolderPath = pH.FallbackPath;
            }

            if (lH.FolderList?.Any() == false) //Fill Playlist with all Files from FolderPath in case it wasn't done already
            {
                lblCurrentInfo.Text = pH.FolderPath; //Show current Folder
                lH.fillFolderList(pH.FolderPath);
            }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var defaultListFolder = $@"{path}\RVP_ListFolder";

            if (string.IsNullOrEmpty(pH.FolderList))
            {
                pH.FolderList = defaultListFolder;

                if (!Directory.Exists(pH.FolderList))
                {
                    Directory.CreateDirectory(pH.FolderList);
                }
            }

            string favFile = pH.FolderList + @"\Favorites.txt";
            List<string> fromTXT = new List<string>();

            if (File.Exists(favFile))
            {
                fromTXT = File.ReadLines(favFile).ToList();
            }

            tempFavorites = fromTXT;
        }
        static string GetFilePathWithDifferentExtension(string originalFilePath, string newExtension)
        {
            string directory = Path.GetDirectoryName(originalFilePath);

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFilePath);

            string newFilePath = Path.Combine(directory, fileNameWithoutExtension + newExtension);

            return newFilePath;
        }
        private void panelPlayerMPV_MouseWheel(object sender, MouseEventArgs e) //Move through video by Scrolling
        {
            if (e.Delta > 0) //Detect Scroll Up and seek forwards
            {
                try
                {
                    if (playerMPV.IsMediaLoaded)
                    {
                        if (sH.VideoDuration > 0 && sH.VideoDuration <= 45)
                        {
                            if (sH.VideoRemaining > 0 && sH.VideoRemaining < 5)
                            {
                                playerMPV.SeekAsync(+1, true);
                            }
                            else
                            {
                                playerMPV.SeekAsync(+2, true);
                            }
                        }
                        else if (sH.VideoDuration > 45)
                        {
                            if (sH.VideoRemaining > 0 && sH.VideoRemaining < 5)
                            {
                                playerMPV.SeekAsync(+1, true);
                            }
                            else
                            {
                                playerMPV.SeekAsync(+5, true);
                            }
                        }
                    }
                }
                catch (Exception) { return; } //Player busy at the moment
            }
            else if (e.Delta < 0) //Detect Scroll Down and seek backwards
            {
                try
                {
                    if (playerMPV.IsMediaLoaded)
                    {
                        playerMPV.SeekAsync(-2, true);
                    }
                }
                catch (Exception) { return; } //Player busy at the moment
            }
        }
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

            int percentage = (int)(((double)e.X) / pbPlayerProgress.Width * pbPlayerProgress.Maximum);
            TimeSpan OnCursor = TimeSpan.FromMilliseconds(percentage);
            string formattedTime = OnCursor.ToString(@"hh\:mm\:ss");

            timeOverlayLabel.Text = formattedTime;

            Point controlRelativePosition = this.PointToClient(pbPlayerProgress.PointToScreen(new Point(e.X, e.Y)));

            // Set the label's location directly above the progress bar, horizontally centered on the cursor
            int labelX = controlRelativePosition.X - (timeOverlayLabel.Width / 2) + pbPlayerProgress.Location.X;
            int labelY = this.Height - 95; 

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
            timeOverlayLabel.BackColor = Color.FromArgb(255, 128, 128); // Use a contrasting background
            timeOverlayLabel.ForeColor = Color.Black; // Ensure text is readable
            this.Controls.Add(timeOverlayLabel);
            timeOverlayLabel.BringToFront();
        }
        private void toggleShuffle()
        {
            lH.DoShuffle = !lH.DoShuffle;
            btnShuffle.IconColor = lH.DoShuffle ? SystemColors.ButtonHighlight : Color.Black;

            lH.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next

            playNext();
        }
        private void MediaFinished(object sender, EventArgs e)
        {
            try
            {
                if (playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && !sH.LoopPlayer)
                {
                    if (!(durationMS > 0)) return; //Check if it's an image
                    playNext();
                }
            }
            catch (Exception) { return; }
        }
        #endregion

        #region Player Volume related Controls
        private void MutePlayer()
        {
            if (pbVolume.Value > 0) //If Volume is not 0, set it to 0 aka mute it and save the last value
            {
                sH.VolumeTemp = pbVolume.Value;
                pbVolume.Value = 0;
                playerMPV.Volume = 0;
            }
            else //If Volume is 0 aka muted, return Volume to previous value
            {
                pbVolume.Value = sH.VolumeTemp;
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
                pbVolume.Value += 5;
                playerMPV.Volume = pbVolume.Value;
            }
            else if (e.Delta < 0) //Detect Scroll Down and decrease Volume
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
            int volume = pbVolume.Value;
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
            tcServer.Stop();
            fR.FormSize = fR.TempSize; //Save last known form size to property
            pH.TempRecentFolder = string.Empty;
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
        #region WndProc Code for clean style of the Form and regaining usabality
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

        // Method to unregister your hotkeys
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
                        playerPause();
                        break;
                    case 1:
                        playerPause();
                        break;
                    case 2:
                        playNext();
                        break;
                    case 3:
                        playPrevious();
                        break;
                        // Handle other cases
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