using FontAwesome.Sharp;
using Mpv.NET.Player;
using RandomVideoPlayer.Controls;
using RandomVideoPlayer.Functions;
using RandomVideoPlayer.Model;
using RandomVideoPlayer.Views;
using Svg;
using Svg.FilterEffects;
using System.Diagnostics;
using System.Drawing.Text;
using System.Globalization;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Timers;
using System.Windows.Navigation;
using System.Windows.Shell;
using static System.Windows.Forms.Design.AxImporter;
using Point = System.Drawing.Point;
using Timer = System.Windows.Forms.Timer;

namespace RandomVideoPlayer
{
    public partial class MainForm : Form
    {
        private MpvPlayer playerMPV;
        private WebServer tcServer;
        private HotkeySettings hkSettings;

        private FormResize fR = new FormResize();
        private Rectangle areaBottom = new Rectangle();
        private Rectangle areaTop = new Rectangle();


        public MainForm(string filePath)
        {
            InitializeComponent();

            CreateDefaultThemes();

            DPI.SetScalingFactor();

            this.DoubleBuffered = true;

            hkSettings = HotkeyManager.LoadHotkeySettings();

            InitializeFormFunctions();

            MainFormData.startupPath = Application.StartupPath;

            InitializePlayer();

            tcServer = new WebServer();
            tcServer.CommandReceived += TcServer_CommandReceived;
            if (SettingsHandler.TimeCodeServer) { tcServer.Start(); }

            InitializePlayerEvents();

            VideoManipulation.KenBurnsEffectInitializeTimer(playerMPV);
            VideoManipulation.KenBurnsEffectUpdateSettings();

            InitializeTimers();

            RegisterHotKeys();

            if (ListHandler.SelectedExtensions.Count<string>() <= 0)
                ListHandler.SelectedExtensions = ListHandler.VideoExtensions;

            if (ListHandler.ExtensionFilterForList.Count<string>() <= 0)
                ListHandler.ExtensionFilterForList = ListHandler.CombinedExtensions;


            CheckStartedByFile(filePath);

            UpdateSourceSelectorIcon();

            InitializeContextMenus();

            UpdateDPIScaling();

            LoadThemeOption();

            ThemeManager.ThemeChanged += (_, __) => ThemeManager.ApplyTheme(this);
            ThemeManager.ThemeChanged += (_, __) => ApplyThemeToButtons();
            ThemeManager.ApplyTheme(this);

            ApplyControlTheme();
            ApplyThemeToButtons();
        }


        private void InitializeScriptProfile()
        {
            if (string.IsNullOrWhiteSpace(SettingsHandler.SelectedProfile))
            {
                if (SettingsHandler.ScriptProfileList.Count > 0)
                {
                    SettingsHandler.SelectedProfile = SettingsHandler.ScriptProfileList[0];
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForUpdates();

            if (string.IsNullOrWhiteSpace(MainFormData.directoryFromStartupFile))
            {
                initStartUp(""); //Load default folder if set and fill playlist

                string img = Path.Combine(MainFormData.startupPath, @"Resources\RVP_BlackBG.png");
                playerMPV.Load(img, true);
            }
            else
            {
                initStartUp(MainFormData.directoryFromStartupFile);
            }

            RepositionButtons();
            SetupTooltips();
            UpdateButtonStates();

            InitializeTimeOverlay();
            timerProgressUpdate.Enabled = true;
            AutoSkipHandler();

            UpdateAddToListContext();
            UpdateScriptProfiles();

            if (MainFormData.startedByFile) PlayerResume();
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
            OpenFileBrowser();
        }
        private void btnListBrowser_Click(object sender, EventArgs e)
        {
            OpenListBrowser();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            DeleteCurrent();
        }

        private void btnListAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MatchCustomList();
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuAddToList.Show(btnListAdd, new Point(0, 0), ToolStripDropDownDirection.AboveRight);
            }
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenSettingsMenu();
        }
        private void btnAddToFav_Click(object sender, EventArgs e)
        {
            MatchFavorites();
        }
        private void btnMoveTo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveOrCopyCurrentFile();
            }
            else if (e.Button == MouseButtons.Right)
            {
                MoveFilePathSelectorView mfpsForm = new MoveFilePathSelectorView();
                mfpsForm.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = mfpsForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    hkSettings = HotkeyManager.LoadHotkeySettings();
                    SetupTooltips();
                }
            }
        }
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            ToggleShuffle();
        }
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            SwitchPlaybackBehavior();
        }
        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            AddCurrentToQueue();
        }
        private void btnStartFromFile_Click(object sender, EventArgs e)
        {
            if (MainFormData.playingSingleFile)
            {
                StartFromCurrentFile();
            }
            else if (SettingsHandler.ShowButtonStayInCurrentFolder)
            {
                var currentFolder = Path.GetDirectoryName(MainFormData.currentFile);
                StartFromFolder(currentFolder, true);
            }
        }
        private void btnSourceSelector_Click(object sender, EventArgs e)
        {
            TrySourceToggle();
        }

        private void btnAutoSkip_Click(object sender, EventArgs e)
        {
            ToggleSkip();
        }

        private void btnTouch_Click(object sender, EventArgs e)
        {
            ToggleTouchMode();
        }

        private void btnSubtitleMenu_Click(object sender, EventArgs e)
        {
            contextMenuSubtitles.Show(btnSubtitleMenu, new Point(0, btnSubtitleMenu.Height));
        }
        private void btnAudioTrackMenu_Click(object sender, EventArgs e)
        {
            contextMenuAudioTracks.Show(btnAudioTrackMenu, new Point(0, btnAudioTrackMenu.Height));
        }
        private void btnScriptMenu_Click(object sender, EventArgs e)
        {
            contextMenuScriptFiles.Show(btnScriptMenu, new Point(0, btnScriptMenu.Height));
        }
        private void lblCurrentInfo_DoubleClick(object sender, EventArgs e)
        {
            var filePath = lblCurrentInfo.Text;
            if (File.Exists(filePath))
                Process.Start("explorer.exe", $"/select, \"{filePath}\"");
        }

        #region Themepark
        public sealed record ThemeOption(string Name, Theme Theme);
        private readonly Dictionary<IconButton, Color> idleColors = new();
        private readonly Dictionary<Button, Color> idleColorsContext = new();
        private readonly HashSet<IconButton> highlightedButtons = new();

        private void LoadThemeOption()
        {
            IReadOnlyDictionary<string, Theme> themes = ThemeLoader.LoadThemes();

            if (!themes.ContainsKey("Light"))
            {
                themes = themes.Concat(new[] {
            new KeyValuePair<string, Theme>("Light", ThemeDefaults.Light)}).ToDictionary(k => k.Key, k => k.Value);
            }

            var options = themes
                .Select(kvp => new ThemeOption(kvp.Key, kvp.Value))
                .OrderBy(opt => opt.Name)
                .ToList();

            string savedThemeName = SettingsHandler.SelectedTheme;
            var match = options.FirstOrDefault(o => o.Name == savedThemeName)
                        ?? options.First(o => o.Name == "Light");

            ThemeManager.SetTheme(match.Theme);
        }
        private void ApplyControlTheme()
        {
            WireIconButton(btnPlay);
            WireIconButton(btnPrevious);
            WireIconButton(btnNext);
            WireIconButton(btnFileBrowse);
            WireIconButton(btnListBrowser);
            WireIconButton(btnRemove);
            WireIconButton(btnSettings);
            WireIconButton(btnAddToFav);
            WireIconButton(btnMoveTo);
            WireIconButton(btnAddToQueue);
            WireIconButton(btnStartFromFile);
            WireIconButton(btnTouch);
            WireIconButton(btnMuteToggle);
            WireIconButton(btnMinimizeForm);
            WireIconButton(btnMaximizeForm);
            WireIconButton(btnShuffle);
            WireIconButton(btnRepeat);
            WireIconButton(btnAutoSkip);
            WireIconButton(btnAddToFav);

            WireContextButton(btnAudioTrackMenu);
            WireContextButton(btnSubtitleMenu);
            WireContextButton(btnScriptMenu);
        }

        private void ApplyThemeToButtons()
        {
            foreach (var btn in idleColors.Keys.ToList())
            {
                idleColors[btn] = highlightedButtons.Contains(btn)
                    ? GetHighlightColor(btn)
                    : ThemeManager.CurrentTheme.ButtonIconColor;

                btn.IconColor = idleColors[btn];
            }


            ConfigureSVGButton(btnListAdd, SVGTemplates.ListAddIcon, ThemeManager.CurrentTheme.ButtonIconColor, ThemeManager.CurrentTheme.ButtonHighlightColor);

            ConfigureSVGButton(btnSourceSelector, SVGTemplates.SplitIconFolder, ThemeManager.CurrentTheme.ButtonIconColor, ThemeManager.CurrentTheme.ButtonHighlightColor);
        }

        private void WireIconButton(IconButton btn)
        {
            idleColors[btn] = ThemeManager.CurrentTheme.ButtonIconColor;
            btn.IconColor = ThemeManager.CurrentTheme.ButtonIconColor;

            btn.MouseEnter += (_, _) => btn.IconColor = HoverColor(btn);
            btn.MouseLeave += (_, _) => btn.IconColor = idleColors[btn];
            btn.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    btn.IconColor = PressedColor(btn);
            };
            btn.MouseUp += (_, _) =>
            {
                btn.IconColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? HoverColor(btn)
                    : idleColors[btn];
            };
            btn.GotFocus += (_, _) => btn.IconColor = HoverColor(btn);
            btn.LostFocus += (_, _) => btn.IconColor = idleColors[btn];
        }
        private void WireContextButton(Button btn)
        {
            idleColorsContext[btn] = ThemeManager.CurrentTheme.ButtonIconColor;
            btn.ForeColor = ThemeManager.CurrentTheme.ButtonIconColor;

            btn.MouseEnter += (_, _) => btn.ForeColor = Lighten(idleColorsContext[btn], 90);
            btn.MouseLeave += (_, _) => btn.ForeColor = idleColorsContext[btn];
            btn.MouseDown += (_, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    btn.ForeColor = Lighten(idleColorsContext[btn], 40);
            };
            btn.MouseUp += (_, _) =>
            {
                btn.ForeColor = btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position))
                    ? Lighten(idleColorsContext[btn], 90)
                    : idleColorsContext[btn];
            };
            btn.GotFocus += (_, _) => btn.ForeColor = Lighten(idleColorsContext[btn], 90);
            btn.LostFocus += (_, _) => btn.ForeColor = idleColorsContext[btn];
        }

        private Color HoverColor(IconButton btn) => Lighten(idleColors[btn], 140);
        private Color PressedColor(IconButton btn) => Lighten(idleColors[btn], 60);
        private Color GetHighlightColor(IconButton btn) => ThemeManager.CurrentTheme.ButtonHighlightColor;
        private void ConfigureSVGButton(Button button, string svgTemplate, Color iconBack, Color iconAccent)
        {
            void Render(Color main, Color accent) =>
                ApplyIcon(button, svgTemplate, main, accent);

            button.Tag = (Action)(() => Render(iconBack, iconAccent));
            button.HandleDestroyed += (_, __) => button.Image?.Dispose();

            button.MouseEnter += (_, __) => Render(Lighten(iconBack, 90), Lighten(iconAccent, 90));
            button.MouseLeave += (_, __) => Render(iconBack, iconAccent);
            button.MouseDown += (_, __) => Render(Lighten(iconBack, 40), Lighten(iconAccent, 40));
            button.MouseUp += (_, __) => Render(Lighten(iconBack, 90), Lighten(iconAccent, 90));

            Render(iconBack, iconAccent);
        }
        private void ApplyIcon(Button target, string template, Color main, Color accent)
        {
            var svgMarkup = template
                .Replace("{{main}}", ColorTranslator.ToHtml(main))
                .Replace("{{accent}}", ColorTranslator.ToHtml(accent));

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(svgMarkup));
            var svgDoc = SvgDocument.Open<SvgDocument>(stream); // SVG.NET
            using var bmp = svgDoc.Draw(20, 20);

            target.Image?.Dispose();
            target.Image = (Bitmap)bmp.Clone();
        }

        private void SetHighlight(IconButton btn, bool highlight, Color? customColor = null)
        {
            if (highlight)
                highlightedButtons.Add(btn);
            else
                highlightedButtons.Remove(btn);

            var color = customColor ?? GetHighlightColor(btn);

            idleColors[btn] = highlight ? color
                                        : ThemeManager.CurrentTheme.ButtonIconColor;

            btn.IconColor = idleColors[btn];
        }

        private static Color Lighten(Color baseColor, int delta)
        {
            var hColor = ThemeManager.CurrentTheme.ButtonHighlightColor;

            return Color.FromArgb(baseColor.A,
                Math.Clamp(baseColor.R + delta + (hColor.R / 2), 0, 255),
                Math.Clamp(baseColor.G + delta + (hColor.G / 2), 0, 255),
                Math.Clamp(baseColor.B + delta + (hColor.B / 2), 0, 255));
        }

        private void CreateDefaultThemes()
        {
            string themeDir = Path.Combine(AppContext.BaseDirectory, "Themes");
            Directory.CreateDirectory(themeDir);

            WriteThemeIfMissing(Path.Combine(themeDir, "Light.json"), "Light", ThemeDefaults.Light);
            WriteThemeIfMissing(Path.Combine(themeDir, "Dark.json"), "Dark", ThemeDefaults.Dark);
        }

        private static void WriteThemeIfMissing(string path, string name, Theme defaults)
        {
            if (File.Exists(path)) return;

            ThemeDto dto = ThemeDto.FromTheme(name, defaults);
            JsonSerializerOptions options = new() { WriteIndented = true };
            string json = JsonSerializer.Serialize(dto, options);
            File.WriteAllText(path, json);
        }
        #endregion

        #region ExclusiveFullscreen
        private void panelPlayerMPV_MouseMove(object sender, MouseEventArgs e) //Used to determin Cursor position in exclusive Fullscreen mode to show or hide Panels
        {
            if (fR.WindowExclusiveFullscreen && !MainFormData.TouchEnabled) //Only use when exclusive Fullscreen is enabled
            {
                panelBottom.Visible = areaBottom.Contains(e.Location) ? true : false;
                panelTop.Visible = areaTop.Contains(e.Location) ? true : false;
            }
        }

        private void panelPlayerMPV_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left && this.WindowState != FormWindowState.Maximized && !MainFormData.TouchEnabled)
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
            else if (e.Button == MouseButtons.Left && this.WindowState == FormWindowState.Maximized && !MainFormData.TouchEnabled)
            {
                stopwatch.Restart();
                long elapsedTime = stopwatch.ElapsedMilliseconds;
                if (elapsedTime < 60 && SettingsHandler.LeftMousePause) //Check whether it was a click
                {
                    checkwatch.Start();
                }
            }
            else if (e.Button == MouseButtons.Left && this.WindowState == FormWindowState.Maximized && MainFormData.TouchEnabled)
            {
                panelBottom.Visible = !panelBottom.Visible;
                panelTop.Visible = !panelTop.Visible;
            }
            if (e.Button == MouseButtons.Left && e.Clicks >= 2 && !MainFormData.TouchEnabled) //Double Click
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
            MainFormData.backupSize = fR.TempSize;
            if (this.WindowState == FormWindowState.Maximized) //Switch to normal state, because windows doesn't like switch to exclusive fullscreen from maximized
            {
                fR.MaximizeForm(this);
            }

            fR.PlayerToExclusiveFullscreen(this, panelTop, panelBottom, panelPlayerMPV);

            if (fR.WindowExclusiveFullscreen)
            {
                activityTimer.Enabled = true;
                if (MainFormData.cursorHidden)
                {
                    Cursor.Show();
                    MainFormData.cursorHidden = false;
                }
            }
            else
            {
                activityTimer.Enabled = false;
                if (MainFormData.cursorHidden)
                {
                    Cursor.Show();
                    MainFormData.cursorHidden = false;
                }
                this.Size = MainFormData.backupSize;
            }
        }
        private int tempPanelBottomHeight = 75;
        private void ToggleTouchMode()
        {
            MainFormData.TouchEnabled = !MainFormData.TouchEnabled;

            if (MainFormData.TouchEnabled)
            {
                tempPanelBottomHeight = panelBottom.Height;
                panelBottom.Height = 102; //75
                pbPlayerProgress.Height = 34; //17

                panelMainButtons.Location = new Point(0, pbPlayerProgress.Height);
                panelControls.Location = new Point(6 + panelMainButtons.Width, pbPlayerProgress.Height + 6);
                panelExtraButtons.Location = new Point(pbVolume.Location.X - panelExtraButtons.Width - 6, pbPlayerProgress.Height + 6);
                pbVolume.Location = new Point(panelBottom.Width - pbVolume.Width - 2, pbPlayerProgress.Height + 9);

                btnTouch.IconColor = Color.PaleGreen;

                if (!fR.WindowExclusiveFullscreen)
                {
                    ToggleExclusiveFullscreen();
                }
                else
                {
                    fR.UpdateFullscreenSize(this, panelTop, panelBottom, panelPlayerMPV);
                }
            }
            else
            {
                panelBottom.Height = tempPanelBottomHeight;
                pbPlayerProgress.Height = 17;

                panelMainButtons.Location = new Point(0, pbPlayerProgress.Height);
                panelControls.Location = new Point(6 + panelMainButtons.Width, pbPlayerProgress.Height + 6);
                panelExtraButtons.Location = new Point(pbVolume.Location.X - panelExtraButtons.Width - 6, pbPlayerProgress.Height + 6);
                pbVolume.Location = new Point(panelBottom.Width - pbVolume.Width - 2, pbPlayerProgress.Height + 9);

                btnTouch.IconColor = Color.Black;

                if (fR.WindowExclusiveFullscreen)
                {
                    ToggleExclusiveFullscreen();
                }
            }

        }
        #endregion

        #region Player Controls
        private async void PlayNext()
        {
            if (SettingsHandler.InitPlay == false && MainFormData.playingSingleFile == false)
            {
                PlayerResume();
                //return;
            }
            // Check if the method is called too quickly in succession
            if ((DateTime.Now - MainFormData.lastPlayCommandTime) < MainFormData.minimumInterval)
            {
                return;
            }
            MainFormData.lastPlayCommandTime = DateTime.Now; // Update the last command time



            ListHandler.PreparePlayList(SettingsHandler.SourceSelected, MainFormData.startedByFile, MainFormData.filepathFromStartupFile); //If needed, prepare the Playlist

            if (!(ListHandler.PlayList?.Any() ?? false))
            {
                MessageBox.Show("Playlist is empty!\nMake sure to set a default folder with your files or choose a folder to play from in the folder browser!");

                if (!MainFormData.playingSingleFile)
                {
                    ThreadHelper.SetText(this, lblTitleBar, "Random Video Player - 0 / 0 (Nothing found to play)");
                }
                return;
            }
            else
            {
                MainFormData.playingSingleFile = false;
                if (!(SettingsHandler.AutoPlayMethod == AutoPlayMethod.AutoNext))
                {
                    playerMPV.Loop = true;
                }
                UpdateButtonStates();
            }

            if (!ListHandler.FirstPlay)
            {
                ListHandler.PlayListIndex = (ListHandler.PlayListIndex + 1) % ListHandler.PlayList.Count();

                if (ListHandler.PlayListIndex == 0 && ListHandler.DoShuffle && ListHandler.ReShuffle)
                {
                    ListHandler.shufflePlayList(MainFormData.startedByFile, MainFormData.filepathFromStartupFile);
                }
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

            MainFormData.currentFile = videoFile;

            await ScriptHandler.RevertDefaultScript();
            await ScriptHandler.RevertDefaultMultiAxisScript();

            if (SettingsHandler.TimeCodeServer)
            {
                await ScriptHandler.FillScriptList(MainFormData.currentFile);

                string videoPath = MainFormData.currentFile;
                string preferredScript = ScriptConfigManager.GetVideoConfig(videoPath, "script");
                int preferredScriptIndex = 0;

                if (!string.IsNullOrWhiteSpace(preferredScript))
                {
                    preferredScriptIndex = ScriptHandler.scriptFilesFound.FindIndex(file => file == preferredScript);
                    preferredScriptIndex = preferredScriptIndex < 0 ? 0 : preferredScriptIndex;
                }


                await ScriptHandler.LoadScript(preferredScriptIndex, MainFormData.currentFile);
                foreach (var multiAxisScript in ScriptHandler.MultiAxisScriptsFound)
                {
                    if (multiAxisScript.Value.ScriptFiles.Count <= 0) continue;
                    string multiAxis = multiAxisScript.Key;
                    string preferredMultiAxisScript = ScriptConfigManager.GetVideoConfig(videoPath, multiAxis);
                    int preferredMultiAxisScriptIndex = 0;

                    if (!string.IsNullOrWhiteSpace(preferredMultiAxisScript))
                    {
                        preferredMultiAxisScriptIndex = ScriptHandler.FindMatchingScriptFileIndex(multiAxis, preferredMultiAxisScript);
                    }

                    await ScriptHandler.LoadMultiAxisScript(preferredMultiAxisScriptIndex, MainFormData.currentFile, multiAxis);
                }
            }
            if (SettingsHandler.EnableAutoSkip)
            {
                playerMPV.SetBrightness(-100);
            }

            playerMPV.Load(videoFile, true);

            SettingsHandler.IsPlaying = false;

            ChangePlaybackSpeed(VideoManipulation.Speed.Reset);
            VideoManipulation.ResetVideoManipulation(playerMPV);

            PlayerResume(); //Resumes player if it's paused
        }
        private async void PlayPrevious()
        {
            if (SettingsHandler.InitPlay == false)
            {
                PlayerResume();
                return;
            }
            // Check if the method is called too quickly in succession
            if ((DateTime.Now - MainFormData.lastPlayCommandTime) < MainFormData.minimumInterval)
            {
                return;
            }
            MainFormData.lastPlayCommandTime = DateTime.Now; // Update the last command time

            ListHandler.PreparePlayList(SettingsHandler.SourceSelected, MainFormData.startedByFile, MainFormData.filepathFromStartupFile); //If needed, prepare the Playlist

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

            MainFormData.currentFile = videoFile;

            await ScriptHandler.RevertDefaultScript();
            await ScriptHandler.RevertDefaultMultiAxisScript();

            if (SettingsHandler.TimeCodeServer)
            {
                await ScriptHandler.FillScriptList(MainFormData.currentFile);

                string videoPath = MainFormData.currentFile;
                string preferredScript = ScriptConfigManager.GetVideoConfig(videoPath, "script");
                int preferredScriptIndex = 0;

                if (!string.IsNullOrWhiteSpace(preferredScript))
                {
                    preferredScriptIndex = ScriptHandler.scriptFilesFound.FindIndex(file => file == preferredScript);
                }


                await ScriptHandler.LoadScript(preferredScriptIndex, MainFormData.currentFile);
                foreach (var multiAxisScript in ScriptHandler.MultiAxisScriptsFound)
                {
                    if (multiAxisScript.Value.ScriptFiles.Count <= 0) continue;
                    string multiAxis = multiAxisScript.Key;
                    string preferredMultiAxisScript = ScriptConfigManager.GetVideoConfig(videoPath, multiAxis);
                    int preferredMultiAxisScriptIndex = 0;

                    if (!string.IsNullOrWhiteSpace(preferredMultiAxisScript))
                    {
                        preferredMultiAxisScriptIndex = ScriptHandler.FindMatchingScriptFileIndex(multiAxis, preferredMultiAxisScript);
                    }

                    await ScriptHandler.LoadMultiAxisScript(preferredMultiAxisScriptIndex, MainFormData.currentFile, multiAxis);
                }
            }

            playerMPV.Load(videoFile, true);

            SettingsHandler.IsPlaying = false;

            ChangePlaybackSpeed(VideoManipulation.Speed.Reset);
            VideoManipulation.ResetVideoManipulation(playerMPV);

            PlayerResume();
        }
        private void PlayerResume()
        {
            if (ListHandler.PlayList?.Any() == true && SettingsHandler.InitPlay == false) //First Play to get going
            {
                SettingsHandler.InitPlay = true;
                return;
            }
            else if (!(ListHandler.PlayList?.Any() ?? false) && MainFormData.playingSingleFile == false)
            {
                ListHandler.NeedsToPrepare = true;
                if (!MainFormData.startedByFile && !string.IsNullOrWhiteSpace(PathHandler.FolderPath) && (!ListHandler.FolderList?.Any() ?? false))
                {
                    ListHandler.fillFolderList(PathHandler.FolderPath, ListHandler.IncludeSubfolders);
                }

                ListHandler.PreparePlayList(SettingsHandler.SourceSelected, MainFormData.startedByFile, MainFormData.filepathFromStartupFile);
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
            else if (!(ListHandler.PlayList?.Any() ?? false) && MainFormData.playingSingleFile == true)
            {
                SettingsHandler.InitPlay = true;
                ListHandler.NeedsToPrepare = true;
                ListHandler.fillFolderList(PathHandler.FolderPath, ListHandler.IncludeSubfolders);
                ListHandler.PreparePlayList(SettingsHandler.SourceSelected, MainFormData.startedByFile, MainFormData.filepathFromStartupFile);
            }

            if (MainFormData.playingSingleFile == false)
            {
                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
                btnRemove.Enabled = true;
                btnListAdd.Enabled = true;
                btnMoveTo.Enabled = true;
                btnAddToFav.Enabled = true;

                ThreadHelper.SetVisibility(this, btnAddToQueue, false);
                //ThreadHelper.SetVisibility(this, btnStartFromFile, false);
            }

            var playPauseHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "PlayPauseToggle");

            if (SettingsHandler.EnableAutoSkip && SettingsHandler.SkipAlways)
            {
                timerAutoSkipCheck.Enabled = true;
                playerMPV.Resume();
            }
            else
            {
                playerMPV.Resume();
            }

            if (!SettingsHandler.EnableAutoSkip)
            {
                playerMPV.Resume();
            }
            SettingsHandler.IsPlaying = true;
            btnPlay.IconChar = FontAwesome.Sharp.IconChar.Pause;
            ThreadHelper.SetToolTipSafe(btnPlay, toolTipUI, $"{GetKeyCombination(playPauseHotkey)} | Pause playback");
            tcServer.State = 2;

            if ((SettingsHandler.AutoPlayMethod == AutoPlayMethod.AutoTimer) && !MainFormData.playingSingleFile)
            {
                timerAutoPlayNext.Enabled = true;
                timerAutoPlayNext.Interval = SettingsHandler.AutoPlayTimerValueStartPoint() * 1000;
                timerAutoPlayNext.Start();

                VideoManipulation.KenBurnsEffectUpdateSettings();

                if (SettingsHandler.BurnsEffectEnabled)
                {
                    var currentFileExtension = Path.GetExtension(MainFormData.currentFile).TrimStart('.').ToLower();
                    if (ListHandler.ImageExtensions.Contains(currentFileExtension))
                    {
                        MainFormData.isImage = true;
                        VideoManipulation.StartRandomAnimation(playerMPV, PlayNext);
                    }
                    else
                    {
                        VideoManipulation.KenBurnsEffectStop();
                        VideoManipulation.ResetVideoManipulation(playerMPV);
                        playerMPV.SetBrightness(0);
                        MainFormData.isImage = false;
                    }
                }
            }


            UpdateSourceSelectorIcon();
            UpdateListEditIcon();
            UpdateButtonStates();
            MainFormData.startedByFile = false;
        }

        private void PlayerPause()
        {
            var playPauseHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "PlayPauseToggle");

            playerMPV.Pause();
            SettingsHandler.IsPlaying = false;

            if (SettingsHandler.EnableAutoSkip && SettingsHandler.SkipAlways)
            {
                timerAutoSkipCheck.Enabled = false;
            }

            btnPlay.IconChar = FontAwesome.Sharp.IconChar.Play;
            ThreadHelper.SetToolTipSafe(btnPlay, toolTipUI, $"{GetKeyCombination(playPauseHotkey)} | Start playing from selected source");
            tcServer.State = 1;
            timerAutoPlayNext.Enabled = false;
            VideoManipulation.KenBurnsEffectStop();
        }

        private void PlayerPlayPauseToggle()
        {
            if (SettingsHandler.IsPlaying)
            {
                PlayerPause();
            }
            else
            {
                PlayerResume();
            }
        }

        private void panelPlayerMPV_MouseWheel(object sender, MouseEventArgs e) //Move through video by Scrolling
        {
            MainFormData.progressBufferActive = true;

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
                MainFormData.progressBufferActive = true;

                var videoDuration = SettingsHandler.VideoDuration;
                var videoRemaining = SettingsHandler.VideoRemaining;
                var videoSizeThreshold = SettingsHandler.VideoSizeThreshold;

                var customSmallSeekForwardValue = SettingsHandler.CustomSeekForwardValueSmall;
                var customLargeSeekForwardValue = SettingsHandler.CustomSeekForwardValueLarge;

                bool isShortVideo = videoDuration <= 60; //Smaller seek increments in short videos
                bool isLongVideo = videoDuration <= videoSizeThreshold; //Bigger seek increments in long video (30 minutes)
                bool isExtraLongVideo = videoDuration > videoSizeThreshold; //Even Bigger seek increments in extra long video 
                //bool isNearEnd = SettingsHandler.VideoRemaining > 0 && SettingsHandler.VideoRemaining < (customSmallSeekValue + 2); //Decrease seek increments at the end to trigger next etc.                

                bool isNearEnd = false;
                if (videoRemaining > 0 && isLongVideo)
                {
                    isNearEnd = videoRemaining < (customSmallSeekForwardValue + 2);
                }
                else if (videoRemaining > 0 && isExtraLongVideo)
                {
                    isNearEnd = videoRemaining < (customLargeSeekForwardValue + 2);
                }
                else
                {
                    isNearEnd = videoRemaining > 0 && videoRemaining < 7;
                }


                if (isShortVideo)
                {
                    MainFormData.cumulativeSeek += isNearEnd ? 1 : 2;
                }
                else if (isLongVideo)
                {
                    MainFormData.cumulativeSeek += isNearEnd ? 1 : customSmallSeekForwardValue;
                }
                else if (isExtraLongVideo)
                {
                    MainFormData.cumulativeSeek += isNearEnd ? 1 : customLargeSeekForwardValue;
                }
                else
                {
                    MainFormData.cumulativeSeek += isNearEnd ? 1 : 3; //Sub 60 second videos
                }

                var positionMS = (int)playerMPV.Position.TotalMilliseconds;
                pbPlayerProgress.Value = (positionMS + (MainFormData.cumulativeSeek * 1000) - MainFormData.seekTimerDelay);

                seekTimer.Stop();
                seekTimer.Start();
            }
            catch (Exception) { } //Player busy
        }
        private void SeekBackward()
        {
            try
            {
                if (!playerMPV.IsMediaLoaded) return;
                MainFormData.progressBufferActive = true;

                var videoDuration = SettingsHandler.VideoDuration;
                var videoRemaining = SettingsHandler.VideoRemaining;
                var videoSizeThreshold = SettingsHandler.VideoSizeThreshold;

                var customSmallSeekBackwardValue = SettingsHandler.CustomSeekBackwardValueSmall;
                var customLargeSeekBackwardValue = SettingsHandler.CustomSeekBackwardValueLarge;

                bool isShortVideo = videoDuration <= 60;
                bool isLongVideo = videoDuration <= videoSizeThreshold;
                bool isExtraLongVideo = videoDuration > videoSizeThreshold;

                if (isShortVideo)
                {
                    MainFormData.cumulativeSeek -= 2;
                }
                else if (isLongVideo)
                {
                    MainFormData.cumulativeSeek -= customSmallSeekBackwardValue;
                }
                else if (isExtraLongVideo)
                {
                    MainFormData.cumulativeSeek -= customLargeSeekBackwardValue;
                }
                else
                {
                    MainFormData.cumulativeSeek -= 5;
                }

                var positionMS = (int)playerMPV.Position.TotalMilliseconds;
                pbPlayerProgress.Value = positionMS + (MainFormData.cumulativeSeek * 1000);

                seekTimer.Stop();
                seekTimer.Start();
            }
            catch (Exception) { } //Player busy
        }
        private void ToggleShuffle()
        {
            ListHandler.DoShuffle = !ListHandler.DoShuffle;
            UpdateButtonStates();

            ListHandler.NeedsToPrepare = true;

            PlayNext();
        }
        private void SwitchPlaybackBehavior()
        {
            SettingsHandler.AutoPlayMethod = (AutoPlayMethod)(((int)SettingsHandler.AutoPlayMethod + 1) % Enum.GetValues(typeof(AutoPlayMethod)).Length);

            switch (SettingsHandler.AutoPlayMethod)
            {
                case AutoPlayMethod.LoopVideo:
                    playerMPV.Loop = true;
                    timerAutoPlayNext.Enabled = false;
                    playerMPV.SetBrightness(0);
                    break;
                case AutoPlayMethod.AutoNext:
                    playerMPV.Loop = false;
                    timerAutoPlayNext.Enabled = false;
                    playerMPV.SetBrightness(0);
                    break;
                case AutoPlayMethod.AutoTimer:
                    playerMPV.Loop = true;
                    if (SettingsHandler.IsPlaying) timerAutoPlayNext.Enabled = true;
                    playerMPV.SetBrightness(0);
                    break;
            }
            UpdateButtonStates();
        }

        private void TrySourceToggle()
        {
            if (SettingsHandler.SourceSelected) //If currently list
            {
                if (!(ListHandler.FolderList?.Any() ?? false))
                {
                    if (string.IsNullOrWhiteSpace(PathHandler.FolderPath))
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
            MainFormData.startedByFile = false;
            ListHandler.NeedsToPrepare = true;

            PlayNext();
        }
        private void ToggleSkip()
        {
            SettingsHandler.EnableAutoSkip = !SettingsHandler.EnableAutoSkip;
            UpdateButtonStates();

            AutoSkipHandler();
        }


        private void ChangePlaybackSpeed(VideoManipulation.Speed action)
        {
            VideoManipulation.ChangePlaybackSpeed(playerMPV, this, lblSpeed, action);
        }
        #endregion

        #region Browser Dialogues
        private void OpenFileBrowser()
        {
            SetHighlight(btnFileBrowse, true);
            string _selectedPath = "";

            if (SettingsHandler.FolderBrowserV2Enabled)
            {
                FolderBrowserV2View fbForm = new FolderBrowserV2View();
                fbForm.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = fbForm.ShowDialog();
                _selectedPath = fbForm.SelectedPath;
                SetHighlight(btnFileBrowse, false);
                if (result != DialogResult.OK) return;
            }
            else
            {
                FolderBrowserView fbForm = new FolderBrowserView();
                fbForm.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = fbForm.ShowDialog();
                _selectedPath = fbForm.SelectedPath;
                SetHighlight(btnFileBrowse, false);
                if (result != DialogResult.OK) return;
            }

            if (SettingsHandler.RecentCheckedTemp)
            {
                ListHandler.latestFolderList(_selectedPath, SettingsHandler.RecentCount, ListHandler.IncludeSubfolders);
            }
            else
            {
                ListHandler.fillFolderList(_selectedPath, ListHandler.IncludeSubfolders);
            }

            if (!(ListHandler.TempFolderList?.Any() ?? false))
            {
                if (!(ListHandler.FolderList?.Any() ?? false))
                {
                    MessageBox.Show($"Your chosen folder has no valid files to play from and there is no valid path to fall back to!\n\nThe Path was:\n{_selectedPath}");
                    return;
                }
                MessageBox.Show($"Your chosen folder has no valid files to play from; No action taken!\n\nThe Path was:\n{_selectedPath}");
                return;
            }
            else
            {
                PathHandler.FolderPath = _selectedPath;
                ListHandler.TempFolderList = Enumerable.Empty<string>();
            }

            MainFormData.startedByFile = false;
            lblCurrentInfo.Text = PathHandler.FolderPath;
            ListHandler.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next
            SettingsHandler.SourceSelected = false;
            Thread.Sleep(200);
            PlayNext();
        }

        private void OpenListBrowser()
        {
            SetHighlight(btnListBrowser, true);
            DialogResult result;

            if (SettingsHandler.ListBrowserV2Enabled)
            {
                ListBrowserV2View lbForm = new ListBrowserV2View();
                lbForm.StartPosition = FormStartPosition.CenterParent;
                result = lbForm.ShowDialog();
                SetHighlight(btnListBrowser, false);
            }
            else
            {
                ListBrowserView lbForm = new ListBrowserView();
                lbForm.StartPosition = FormStartPosition.CenterParent;
                result = lbForm.ShowDialog();
                SetHighlight(btnListBrowser, false);
            }

            if (result == DialogResult.OK)
            {
                if (!(ListHandler.CustomList?.Any() ?? false))
                {
                    MessageBox.Show("Custom List is empty");
                    return;
                }

                ListHandler.NeedsToPrepare = true; //Since we changed the content, we need to prepare the Playlist next
                MainFormData.startedByFile = false;
                SettingsHandler.SourceSelected = true;
                PlayNext();
            }
            string tempFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;

            MainFormData.presentInCustomList = ListHandler.DoesCustomListContainString(tempFile);
            UpdateListEditIcon();
            UpdateAddToListContext();
        }
        private void OpenSettingsMenu()
        {
            SettingsView svForm = new SettingsView();
            svForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = svForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (SettingsHandler.TimeCodeServer)
                {
                    tcServer.Start();
                }
                else
                {
                    tcServer.Stop();
                }

                initStartUp(""); //Used to fix issues at first time startup
                if (SettingsHandler.SettingChanged)
                    PlayNext();
                timerAutoPlayNext.Interval = SettingsHandler.AutoPlayTimerValueStartPoint() * 1000;
                VideoManipulation.KenBurnsEffectUpdateSettings();

                if (SettingsHandler.BurnsEffectEnabled == false)
                {
                    VideoManipulation.KenBurnsEffectStop();
                    VideoManipulation.ResetVideoManipulation(playerMPV);
                    playerMPV.SetBrightness(0);
                }

                enableDisableSubtitlesItem.Checked = SettingsHandler.SubtitlesEnabled;
                ToggleSubtitles();
                SubFunctions.UpdateSubtitleParameters(playerMPV);

                AutoSkipHandler();

                if (SettingsHandler.RTXVSREnabled)
                {
                    playerMPV.API.Command("vf", "add", MainFormData.VSRFilter);
                }
                else
                {
                    playerMPV.API.Command("vf", "del", "d3d11vpp");
                }


                LoadThemeOption();
                ThemeManager.ApplyTheme(this);

                renderer.BackgroundColor = ThemeManager.CurrentTheme.ToolMenuBackColor;
                renderer.TextColor = ThemeManager.CurrentTheme.TextColor;
                renderer.HighlightColor = ThemeManager.CurrentTheme.ToolMenuHoverColor;
                renderer.ApplyColors();

                UpdateListEditIcon();
                UpdateSourceSelectorIcon();
                UpdateAddToListContext();

                RepositionButtons();
            }

            UpdateButtonStates();

            if (fR.WindowExclusiveFullscreen)
            {
                fR.UpdateFullscreenSize(this, panelTop, panelBottom, panelPlayerMPV);
            }

            hkSettings = HotkeyManager.LoadHotkeySettings();
            SetupTooltips();
        }
        #endregion

        #region CustomButton
        private void RepositionButtons()
        {
            List<Button> buttons = new List<Button> { btnRemove, btnListAdd, btnAddToFav, btnMoveTo, btnShuffle, btnRepeat, btnSourceSelector, btnAutoSkip, btnTouch };
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
            btnListAdd.Visible = buttonStates[1];
            btnAddToFav.Visible = buttonStates[2];
            btnMoveTo.Visible = buttonStates[3];
            btnShuffle.Visible = buttonStates[4];
            btnRepeat.Visible = buttonStates[5];
            btnSourceSelector.Visible = buttonStates[6];
            btnAutoSkip.Visible = buttonStates[7];
            btnTouch.Visible = buttonStates[8];


            int x = 10; // starting x position
            int y = 0; // starting y position
            int margin = 20; // space between buttons

            int minimumFormSize = 1018;

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

            int mainX = 10;
            int mainY = 6;
            int mainMargin = 20;

            foreach (Button button in panelMainButtons.Controls)
            {
                button.Location = new Point(mainX, mainY);
                mainX += button.Width + mainMargin;
            }

            int extraX = 10;
            int extraY = 0;
            int extraMargin = 6;
            int extraButtonCount = 1;

            foreach (Button button in panelExtraButtons.Controls)
            {
                if (extraButtonCount == 4) extraY = 3; //Volume button

                button.Location = new Point(extraX, extraY);
                extraX += button.Width + extraMargin;
                extraButtonCount++;
            }

            this.MinimumSize = new Size(minimumFormSize, 420);
        }

        private void UpdateButtonStates()
        {
            btnMoveTo.IconChar = SettingsHandler.FileCopy ? FontAwesome.Sharp.IconChar.Copy : FontAwesome.Sharp.IconChar.FileExport;

            switch (SettingsHandler.AutoPlayMethod)
            {
                case AutoPlayMethod.LoopVideo:
                    btnRepeat.IconChar = FontAwesome.Sharp.IconChar.Repeat;
                    //btnRepeat.IconColor = ThemeManager.CurrentTheme.ButtonHoverColor;
                    SetHighlight(btnRepeat, true);
                    VideoManipulation.KenBurnsEffectStop();
                    playerMPV.SetBrightness(0);
                    VideoManipulation.ResetVideoManipulation(playerMPV);
                    break;
                case AutoPlayMethod.AutoNext:
                    btnRepeat.IconChar = FontAwesome.Sharp.IconChar.Repeat;
                    //btnRepeat.IconColor = ThemeManager.CurrentTheme.TextColor;
                    SetHighlight(btnRepeat, false);
                    VideoManipulation.KenBurnsEffectStop();
                    playerMPV.SetBrightness(0);
                    VideoManipulation.ResetVideoManipulation(playerMPV);
                    break;
                case AutoPlayMethod.AutoTimer:
                    btnRepeat.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
                    //btnRepeat.IconColor = ThemeManager.CurrentTheme.ButtonHoverColor;
                    SetHighlight(btnRepeat, true);
                    if (SettingsHandler.BurnsEffectEnabled && SettingsHandler.InitPlay) PlayNext();
                    break;
            }

            SetHighlight(btnShuffle, ListHandler.DoShuffle);

            SetHighlight(btnAutoSkip, SettingsHandler.EnableAutoSkip);

            SetHighlight(btnAddToFav, MainFormData.favoriteMatch, Color.Red);

            WireContextButton(btnAudioTrackMenu);
            WireContextButton(btnSubtitleMenu);
            WireContextButton(btnScriptMenu);

            if (SettingsHandler.ShowButtonStayInCurrentFolder && !MainFormData.playingSingleFile && SettingsHandler.InitPlay)
            {
                ThreadHelper.SetVisibility(this, btnStartFromFile, true);
            }
            else
            {
                ThreadHelper.SetVisibility(this, btnStartFromFile, false);
            }
        }

        private void UpdateSourceSelectorIcon()
        {
            if (SettingsHandler.SourceSelected)
            {
                ConfigureSVGButton(btnSourceSelector, SVGTemplates.SplitIconList, ThemeManager.CurrentTheme.ButtonIconColor, ThemeManager.CurrentTheme.ButtonHighlightColor);
            }
            else
            {
                ConfigureSVGButton(btnSourceSelector, SVGTemplates.SplitIconFolder, ThemeManager.CurrentTheme.ButtonIconColor, ThemeManager.CurrentTheme.ButtonHighlightColor);
            }
        }

        private void UpdateListEditIcon()
        {
            if (MainFormData.presentInCustomList)
            {
                ConfigureSVGButton(btnListAdd, SVGTemplates.ListRemoveIcon, ThemeManager.CurrentTheme.ButtonIconColor, Color.Red);
            }
            else
            {
                ConfigureSVGButton(btnListAdd, SVGTemplates.ListAddIcon, ThemeManager.CurrentTheme.ButtonIconColor, ThemeManager.CurrentTheme.ButtonHighlightColor);
            }
        }
        #endregion

        #region ContextMenu

        private CustomRenderer renderer;

        //Add to list menu
        private ContextMenuStrip contextMenuAddToList;
        //Subtitle menu
        private ContextMenuStrip contextMenuSubtitles;
        private ToolStripMenuItem enableDisableSubtitlesItem;
        private ToolStripMenuItem loadExternalSubtitlesItem;
        //Audio menu
        private ContextMenuStrip contextMenuAudioTracks;
        //Script menu
        private ContextMenuStrip contextMenuScriptFiles;
        private ToolStripMenuItem enableDisableTimeServerItem;
        private ToolStripMenuItem enableDisableShowGraphItem;
        private ToolStripMenuItem selectScriptProfiles;
        private ToolStripMenuItem savePreferredScriptSetupItem;

        private bool tsmiAutoSize = true;

        private void InitializeContextMenus()
        {
            renderer = new CustomRenderer()
            {
                BackgroundColor = ThemeManager.CurrentTheme.ToolMenuBackColor,
                TextColor = ThemeManager.CurrentTheme.TextColor,
                HighlightColor = ThemeManager.CurrentTheme.ToolMenuHoverColor,
            };
            renderer.ApplyColors();


            //Add to list menu
            contextMenuAddToList = new ContextMenuStrip
            {
                ShowImageMargin = false,
                ShowCheckMargin = false,
                Renderer = renderer
            };

            //Subtitle menu
            contextMenuSubtitles = new ContextMenuStrip { Renderer = renderer };

            //Create first context menu item for toggling subtitles
            enableDisableSubtitlesItem = new ToolStripMenuItem("Enable")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                TextAlign = ContentAlignment.MiddleLeft,
                CheckOnClick = true
            };
            enableDisableSubtitlesItem.CheckedChanged += EnableDisableSubtitlesItem_CheckedChanged;
            contextMenuSubtitles.Items.Add(enableDisableSubtitlesItem);
            //Create context menu item to load external subtitle file
            loadExternalSubtitlesItem = new ToolStripMenuItem("Load external subtitle file")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                TextAlign = ContentAlignment.MiddleLeft
            };
            loadExternalSubtitlesItem.Click += (sender, e) => LoadExternalSubtitles();
            contextMenuSubtitles.Items.Add(loadExternalSubtitlesItem);
            contextMenuSubtitles.Items.Add(new ToolStripSeparator());
            if (SettingsHandler.SubtitlesEnabled) enableDisableSubtitlesItem.Checked = true;
            ToggleSubtitles();
            SubFunctions.UpdateSubtitleParameters(playerMPV);

            //Audio menu
            contextMenuAudioTracks = new ContextMenuStrip { Renderer = renderer };

            //Script menu
            contextMenuScriptFiles = new ContextMenuStrip { Renderer = renderer };

            // 1:Create first context menu item for toggling time server
            enableDisableTimeServerItem = new ToolStripMenuItem("Enable Timecode Server")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                TextAlign = ContentAlignment.MiddleLeft,
                CheckOnClick = true
            };
            enableDisableTimeServerItem.CheckedChanged += EnableDisableTimeServerItem_CheckedChanged;
            contextMenuScriptFiles.Items.Add(enableDisableTimeServerItem);

            // 2:Create context menu item for toggling graph
            enableDisableShowGraphItem = new ToolStripMenuItem("Show Graph")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                TextAlign = ContentAlignment.MiddleLeft,
                CheckOnClick = true
            };
            enableDisableShowGraphItem.CheckedChanged += EnableDisableShowGraphItem_CheckedChanged;
            contextMenuScriptFiles.Items.Add(enableDisableShowGraphItem);
            // 3: Choose Script Profile
            selectScriptProfiles = new ToolStripMenuItem("Select Script Profile")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                TextAlign = ContentAlignment.MiddleLeft
            };
            contextMenuScriptFiles.Items.Add(selectScriptProfiles);
            // 4:Create context menu button to save preferred script config
            savePreferredScriptSetupItem = new ToolStripMenuItem("Save preferred script for this video")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                ForeColor = ThemeManager.CurrentTheme.TextColor,
                TextAlign = ContentAlignment.MiddleLeft
            };
            savePreferredScriptSetupItem.Click += SavePreferredScriptSetup_Click;
            contextMenuScriptFiles.Items.Add(savePreferredScriptSetupItem);

            contextMenuScriptFiles.Items.Add(new ToolStripSeparator());
            if (SettingsHandler.TimeCodeServer) enableDisableTimeServerItem.Checked = true;
            if (SettingsHandler.GraphEnabled) enableDisableShowGraphItem.Checked = true;
        }



        private void LoadExternalSubtitles()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = FileManipulation.GetFileDirectory(MainFormData.currentFile);
                openFileDialog.Filter = "Subtitle Files|*.srt;*.sub;*.ssa;*.ass;*.idx;*.txt;*.smi;*.rt;*.utf;*.aqt;*.vtt;*.mpsub|All Files|*.*";
                openFileDialog.Title = "Select a Subtitle File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var subName = FileManipulation.GetFileName(openFileDialog.FileName);

                    playerMPV.AddSubtitle(openFileDialog.FileName, MpvPlayer.SubtitleFlags.Select, subName, "ext");

                    TrackInfo.GrabTrackInfo(playerMPV);

                    UpdateSubtitleOptions(true);
                }
            }
        }

        private void UpdateSubtitleOptions(bool loadedExternal = false)
        {
            bool isFirstItem = true;

            if (InvokeRequired)
            {
                Invoke(new Action<bool>(UpdateSubtitleOptions), loadedExternal);
            }
            else
            {
                for (int i = contextMenuSubtitles.Items.Count - 1; i >= 3; i--)
                {
                    contextMenuSubtitles.Items.RemoveAt(i);
                }

                if (TrackInfo.Subtitles.Count <= 0)
                {
                    var placeholder = new ToolStripMenuItem("No subtitles found")
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    placeholder.Enabled = false;
                    contextMenuSubtitles.Items.Add(placeholder);
                    return;
                }

                int currentIndex = 0;

                foreach (var subtitle in TrackInfo.Subtitles)
                {
                    currentIndex++;

                    var subtitleItem = new ToolStripMenuItem(subtitle)
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    subtitleItem.Click += SubtitleItem_Click;
                    if (loadedExternal)
                    {
                        if (currentIndex == TrackInfo.Subtitles.Count)
                        {
                            subtitleItem.Checked = true;
                        }
                    }
                    else if (isFirstItem && loadedExternal == false)
                    {
                        subtitleItem.Checked = true;
                        isFirstItem = false;
                    }

                    contextMenuSubtitles.Items.Add(subtitleItem);
                }
            }
        }

        private void UpdateAudioTracks()
        {
            bool isFirstItem = true;

            if (InvokeRequired)
            {
                Invoke(new Action(UpdateAudioTracks));
            }
            else
            {
                for (int i = contextMenuAudioTracks.Items.Count - 1; i >= 0; i--)
                {
                    contextMenuAudioTracks.Items.RemoveAt(i);
                }

                if (TrackInfo.AudioTracks.Count <= 0)
                {
                    var placeholder = new ToolStripMenuItem("No audio found")
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    placeholder.Enabled = false;
                    contextMenuAudioTracks.Items.Add(placeholder);
                    return;
                }

                foreach (var audioTrack in TrackInfo.AudioTracks)
                {
                    var audioTrackItem = new ToolStripMenuItem(audioTrack)
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    audioTrackItem.Click += AudioTracksItem_Click;
                    if (isFirstItem)
                    {
                        audioTrackItem.Checked = true;
                        isFirstItem = false;
                    }
                    contextMenuAudioTracks.Items.Add(audioTrackItem);
                }
            }
        }

        private void UpdateScriptProfiles()
        {
            bool isFirstItem = true;
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateScriptProfiles));
            }
            else
            {
                for (int i = selectScriptProfiles.DropDownItems.Count - 1; i >= 0; i--)
                {
                    selectScriptProfiles.DropDownItems.RemoveAt(i);
                }

                bool anyScriptProfileFound = false;

                string videoPath = MainFormData.currentFile;
                string preferredScript = SettingsHandler.SelectedProfile;
                int preferredScriptProfileIndex = 0;

                if (!string.IsNullOrWhiteSpace(preferredScript))
                {
                    preferredScriptProfileIndex = SettingsHandler.ScriptProfileList.FindIndex(file => file == preferredScript);
                }
                int profileIndex = 0;
                foreach (var scriptProfile in SettingsHandler.ScriptProfileList)
                {
                    var scriptProfileItem = new ToolStripMenuItem(scriptProfile)
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    scriptProfileItem.Click += scriptProfileItem_Click;
                    if (preferredScriptProfileIndex > 0)
                    {
                        if (preferredScriptProfileIndex == profileIndex)
                        {
                            scriptProfileItem.Checked = true;
                            isFirstItem = false;
                        }
                    }
                    else if (isFirstItem)
                    {
                        scriptProfileItem.Checked = true;
                        isFirstItem = false;
                    }
                    if (!SettingsHandler.ShowScriptPath)
                    {
                        scriptProfileItem.Text = Path.GetFileName(scriptProfile);
                    }
                    selectScriptProfiles.DropDownItems.Add(scriptProfileItem);
                    anyScriptProfileFound = true;
                    profileIndex++;
                }
                if (anyScriptProfileFound == false)
                {
                    var placeholder = new ToolStripMenuItem("No script profiles found")
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    placeholder.Enabled = false;
                    selectScriptProfiles.DropDownItems.Add(placeholder);

                    var createProfileItem = new ToolStripMenuItem("Create Script Profile")
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    selectScriptProfiles.DropDownItems.Add(createProfileItem);
                    createProfileItem.Click += CreateScriptProfileItem_Click;
                }
            }
        }

        private void UpdateScriptFiles()
        {
            bool isFirstItem = true;
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateScriptFiles));
            }
            else
            {
                for (int i = contextMenuScriptFiles.Items.Count - 1; i >= 5; i--)
                {
                    contextMenuScriptFiles.Items.RemoveAt(i);
                }

                if (SettingsHandler.TimeCodeServer == false)
                {
                    var placeholder = new ToolStripMenuItem("Timecode Server is disabled")
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    placeholder.Enabled = false;
                    contextMenuScriptFiles.Items.Add(placeholder);
                    return;
                }

                bool anyScriptFound = false;

                string videoPath = MainFormData.currentFile;
                string preferredScript = ScriptConfigManager.GetVideoConfig(videoPath, "script");
                int preferredScriptIndex = 0;

                if (!string.IsNullOrWhiteSpace(preferredScript))
                {
                    preferredScriptIndex = ScriptHandler.scriptFilesFound.FindIndex(file => file == preferredScript);
                }
                int scriptIndex = 0;
                foreach (var scriptFile in ScriptHandler.scriptFilesFound)
                {
                    var scriptItem = new ToolStripMenuItem(scriptFile)
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    scriptItem.Click += ScriptItem_Click;
                    if (preferredScriptIndex > 0)
                    {
                        if (preferredScriptIndex == scriptIndex)
                        {
                            scriptItem.Checked = true;
                            isFirstItem = false;
                        }
                    }
                    else if (isFirstItem)
                    {
                        scriptItem.Checked = true;
                        isFirstItem = false;
                    }
                    if (!SettingsHandler.ShowScriptPath)
                    {
                        scriptItem.Text = Path.GetFileName(scriptFile);
                    }
                    contextMenuScriptFiles.Items.Add(scriptItem);
                    anyScriptFound = true;
                    scriptIndex++;
                }

                foreach (var kvp in ScriptHandler.MultiAxisScriptsFound)
                {
                    string menuName = kvp.Key;
                    List<string> scripts = kvp.Value.ScriptFiles;

                    string preferredMultiAxisScript = ScriptConfigManager.GetVideoConfig(videoPath, menuName);

                    int preferredMultiAxisScriptIndex = 0;

                    if (!string.IsNullOrWhiteSpace(preferredMultiAxisScript))
                    {
                        preferredMultiAxisScriptIndex = ScriptHandler.FindMatchingScriptFileIndex(menuName, preferredMultiAxisScript);
                    }


                    int multiAxisScriptIndex = 0;

                    if (scripts.Count > 0)
                    {
                        var menuItem = new ToolStripMenuItem(menuName)
                        {
                            AutoSize = tsmiAutoSize,
                            Font = new Font("Segoe UI", 9 / DPI.Scale),
                            TextAlign = ContentAlignment.MiddleLeft
                        };
                        contextMenuScriptFiles.Items.Add(menuItem);

                        bool isFirstItemInMulti = true;
                        foreach (var script in scripts)
                        {
                            var scriptItem = new ToolStripMenuItem(script)
                            {
                                AutoSize = tsmiAutoSize,
                                Font = new Font("Segoe UI", 9 / DPI.Scale),
                                TextAlign = ContentAlignment.MiddleLeft,
                                CheckOnClick = true
                            };
                            scriptItem.Click += MultiScriptItem_Click;

                            if (preferredMultiAxisScriptIndex > 0)
                            {
                                if (preferredMultiAxisScriptIndex == multiAxisScriptIndex)
                                {
                                    scriptItem.Checked = true;
                                    isFirstItem = false;
                                }
                            }
                            else if (isFirstItemInMulti)
                            {
                                scriptItem.Checked = true;
                                isFirstItemInMulti = false;
                            }

                            if (!SettingsHandler.ShowScriptPath)
                            {
                                scriptItem.Text = Path.GetFileName(script);
                            }

                            menuItem.DropDownItems.Add(scriptItem);
                            multiAxisScriptIndex++;
                        }
                        anyScriptFound = true;
                    }
                }

                if (anyScriptFound == false)
                {
                    var placeholder = new ToolStripMenuItem("No scripts found")
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    placeholder.Enabled = false;
                    contextMenuScriptFiles.Items.Add(placeholder);

                    ScriptHandler.CurrentlySelectedScript = "";
                    ScriptHandler.CurrentlySelectedMultiAxisScript = ScriptHandler.CurrentlySelectedMultiAxisScript.ToDictionary(k => k.Key, k => "");
                    return;
                }
            }
        }

        private void UpdateAddToListContext()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateAddToListContext));
            }
            else
            {
                for (int i = contextMenuAddToList.Items.Count - 1; i >= 0; i--)
                {
                    contextMenuAddToList.Items.RemoveAt(i);
                }

                var listItens = new List<ToolStripMenuItem>();

                var pathToListDir = PathHandler.PathToListFolder;
                if (string.IsNullOrWhiteSpace(pathToListDir)) return;

                DirectoryInfo dir = new DirectoryInfo(pathToListDir);
                try
                {
                    foreach (FileInfo file in dir.EnumerateFiles())
                    {
                        string currentFileExtension = Path.GetExtension(file.Name).TrimStart('.').ToLower();
                        if (!currentFileExtension.Contains("txt")) continue;
                        if (file.Name == "Favorites.txt") continue; //Handled by favorite button

                        var item = new ToolStripMenuItem()
                        {
                            AutoSize = tsmiAutoSize,
                            Font = new Font("Segoe UI", 9 / DPI.Scale),
                            Text = file.Name.Replace(".txt", ""),
                            Tag = file.FullName
                        };
                        item.Click += AddToListItem_Click;

                        listItens.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Failed to access list files");
                    return;
                }


                if (listItens.Count <= 0)
                {
                    var placeholder = new ToolStripMenuItem("No list found")
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                    };
                    contextMenuAddToList.Items.Add(placeholder);
                    return;
                }
                else
                {
                    var placeholder = new ToolStripMenuItem("Save to list:")
                    {
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 10 / DPI.Scale, FontStyle.Bold)
                    };
                    contextMenuAddToList.Items.Add(placeholder);
                    contextMenuAddToList.Items.Add(new ToolStripSeparator());
                }

                foreach (var listItem in listItens)
                {
                    contextMenuAddToList.Items.Add(listItem);
                }
            }
        }

        private void AddToListItem_Click(object sender, EventArgs e)
        {
            //Add currently played file to specified list
            var clickedItem = sender as ToolStripMenuItem;
            var selectedList = clickedItem.Text;
            var currentFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;

            if (string.IsNullOrWhiteSpace(selectedList) || string.IsNullOrWhiteSpace(currentFile)) return;

            if (selectedList == ListHandler.ListNameTemp)
            {
                AddCurrentToList();
                MainFormData.presentInCustomList = ListHandler.DoesCustomListContainString(currentFile);
                UpdateListEditIcon();
                ListHandler.ListChanged = true;
            }
            else
            {
                var selectedListFulPath = clickedItem.Tag.ToString();
                File.AppendAllText(selectedListFulPath, currentFile + Environment.NewLine);
                playerMPV.ShowText($"Added to list: {selectedList}");
            }

        }

        private void EnableDisableSubtitlesItem_CheckedChanged(object sender, EventArgs e)
        {
            ToggleSubtitles();
        }

        private void EnableDisableTimeServerItem_CheckedChanged(object sender, EventArgs e)
        {
            SettingsHandler.TimeCodeServer = enableDisableTimeServerItem.Checked;
            (SettingsHandler.TimeCodeServer ? (Action)tcServer.Start : tcServer.Stop)();

            string updatedCurrentFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;
            if (string.IsNullOrWhiteSpace(updatedCurrentFile) == false)
            {
                Task.Run(async () =>
                {
                    await ScriptHandler.RevertDefaultScript();
                    await ScriptHandler.RevertDefaultMultiAxisScript();

                    if (SettingsHandler.TimeCodeServer)
                    {
                        await ScriptHandler.FillScriptList(updatedCurrentFile);

                        await ScriptHandler.LoadScript(0, updatedCurrentFile);
                        foreach (var multiAxisScript in ScriptHandler.MultiAxisScriptsFound)
                        {
                            if (multiAxisScript.Value.ScriptFiles.Count <= 0) continue;
                            await ScriptHandler.LoadMultiAxisScript(0, updatedCurrentFile, multiAxisScript.Key);
                        }

                        playerMPV.Load(updatedCurrentFile, true);

                        SettingsHandler.IsPlaying = false;

                        ChangePlaybackSpeed(VideoManipulation.Speed.Reset);
                        VideoManipulation.ResetVideoManipulation(playerMPV);
                        playerMPV.SetBrightness(0);

                        PlayerResume();
                    }
                });
            }
        }

        private void EnableDisableShowGraphItem_CheckedChanged(object sender, EventArgs e)
        {
            SettingsHandler.GraphEnabled = enableDisableShowGraphItem.Checked;
            string updatedCurrentFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;
            if (string.IsNullOrWhiteSpace(updatedCurrentFile) == false)
            {
                pbPlayerProgress.DeleteActionsPoints();

                var currentFileExtension = Path.GetExtension(updatedCurrentFile).TrimStart('.').ToLower();
                if (ListHandler.ImageExtensions.Contains(currentFileExtension)) return;

                UpdateFunscriptGraph();
            }
        }

        private void AudioTracksItem_Click(object sender, EventArgs e)
        {
            var clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                foreach (ToolStripItem item in contextMenuAudioTracks.Items)
                {
                    if (item is ToolStripMenuItem menuItem)
                    {
                        menuItem.Checked = false;
                    }
                }

                clickedItem.Checked = true;
                var index = contextMenuAudioTracks.Items.IndexOf(clickedItem) + 1;
                playerMPV.SetAudioTrack(index);
            }
        }

        private void scriptProfileItem_Click(object sender, EventArgs e)
        {
            var clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                foreach (ToolStripItem item in selectScriptProfiles.DropDownItems)
                {
                    if (item is ToolStripMenuItem menuItem)
                    {
                        menuItem.Checked = false;
                    }
                }
                clickedItem.Checked = true;
                SettingsHandler.SelectedProfile = clickedItem.Text;

                PlayNext();
            }
        }
        private void CreateScriptProfileItem_Click(object? sender, EventArgs e)
        {
            var newProfileName = "PreferredScripts_Profile-1";

            try
            {
                File.Create(Path.Combine(PathHandler.PathToListFolder, newProfileName + ".json")).Close();
            }
            catch (Exception ex)
            {
                Error.Log(ex, $"Couldn't create new profile file: {ex}");
            }

            SettingsHandler.SelectedProfile = newProfileName;

            UpdateScriptProfiles();
            playerMPV.ShowText("Script config created");
        }
        private void SavePreferredScriptSetup_Click(object sender, EventArgs e)
        {
            string videoPath = MainFormData.currentFile;
            string scriptPath = ScriptHandler.CurrentlySelectedScript;

            if (string.IsNullOrWhiteSpace(videoPath) || string.IsNullOrWhiteSpace(scriptPath)) return;

            if (SettingsHandler.ScriptProfileList.Count <= 0)
            {
                var newProfileName = "PreferredScripts_Profile-1";

                try
                {
                    File.Create(Path.Combine(PathHandler.PathToListFolder, newProfileName + ".json")).Close();
                }
                catch (Exception ex)
                {
                    Error.Log(ex, $"Couldn't create new profile file: {ex}");
                }

                SettingsHandler.SelectedProfile = newProfileName;
            }

            ScriptConfigManager.SaveVideoConfig(videoPath, "script", scriptPath);
            foreach (var entry in ScriptHandler.CurrentlySelectedMultiAxisScript)
            {
                if (!string.IsNullOrWhiteSpace(entry.Value))
                {
                    ScriptConfigManager.SaveVideoConfig(videoPath, entry.Key, entry.Value);
                }
            }
            playerMPV.ShowText("Script config saved");
        }
        private void ScriptItem_Click(object sender, EventArgs e)
        {
            var clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                var itemsCopy = contextMenuScriptFiles.Items.OfType<ToolStripItem>().ToList();
                foreach (var item in itemsCopy)
                {
                    if (item is ToolStripMenuItem menuItem)
                    {
                        if (menuItem != enableDisableTimeServerItem && menuItem != enableDisableShowGraphItem)
                        {
                            menuItem.Checked = false;
                        }
                    }
                }

                clickedItem.Checked = true;
                var index = contextMenuScriptFiles.Items.IndexOf(clickedItem) - 5;
                Task.Run(async () =>
                {
                    await ScriptHandler.RevertDefaultScript();
                    await ScriptHandler.LoadScript(index, MainFormData.currentFile);
                    string updatedCurrentFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;
                    await SetTimeServerFile("Reload", true);
                    await Task.Delay(1000);
                    await SetTimeServerFile(updatedCurrentFile);
                    UpdateFunscriptGraph();
                });
            }
        }

        private void MultiScriptItem_Click(object sender, EventArgs e)
        {
            var clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                var parentItem = clickedItem.OwnerItem as ToolStripMenuItem;
                if (parentItem != null)
                {
                    foreach (ToolStripMenuItem item in parentItem.DropDownItems)
                    {
                        item.Checked = false;
                    }
                }

                clickedItem.Checked = true;
                var selectedText = clickedItem.Text;
                var selectedAxis = parentItem.Text;
                var index = parentItem.DropDownItems.IndexOf(clickedItem);

                Task.Run(async () =>
                {
                    await ScriptHandler.RevertDefaultMultiAxisScript();
                    foreach (var multiAxisScript in ScriptHandler.MultiAxisScriptsFound)
                    {
                        if (multiAxisScript.Value.ScriptFiles.Count <= 0) continue;
                        if (multiAxisScript.Key == selectedAxis)
                        {
                            multiAxisScript.Value.SelectedIndex = index;
                            await ScriptHandler.LoadMultiAxisScript(index, MainFormData.currentFile, multiAxisScript.Key);
                        }
                        else
                        {
                            var oldIndex = multiAxisScript.Value.SelectedIndex;
                            await ScriptHandler.LoadMultiAxisScript(oldIndex, MainFormData.currentFile, multiAxisScript.Key);
                        }
                    }
                    string updatedCurrentFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;
                    await SetTimeServerFile("Reload", true);
                    Thread.Sleep(1000);
                    await SetTimeServerFile(updatedCurrentFile);
                });

            }
        }

        private void SubtitleItem_Click(object sender, EventArgs e)
        {
            var clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                foreach (ToolStripItem item in contextMenuSubtitles.Items)
                {
                    if (item is ToolStripMenuItem menuItem)
                    {
                        if (menuItem != enableDisableSubtitlesItem)
                        {
                            menuItem.Checked = false;
                        }
                    }
                }

                clickedItem.Checked = true;
                var index = contextMenuSubtitles.Items.IndexOf(clickedItem) - 2;
                playerMPV.SetSubtitleTrack(index);
            }
        }

        private void ToggleSubtitles()
        {
            if (enableDisableSubtitlesItem.Checked)
            {
                playerMPV.ShowSubtitles(true);
                playerMPV.SetSubtitleTrack(1);
                SettingsHandler.SubtitlesEnabled = true;
            }
            else
            {
                playerMPV.ShowSubtitles(false);
                SettingsHandler.SubtitlesEnabled = false;
            }
        }

        #endregion

        #region FileManipulation
        private async void DeleteCurrent()
        {
            if (ListHandler.FirstPlay && !MainFormData.playingSingleFile) return;

            if (string.IsNullOrWhiteSpace(PathHandler.RemoveFolder))
            {
                MessageBox.Show("Please choose a folder to delete files to under Settings => Paths");
                return;
            }
            if ((MainFormData.playingSingleFile && string.IsNullOrWhiteSpace(MainFormData.draggedFilePath)) || (!MainFormData.playingSingleFile && !(ListHandler.PlayList?.Any() ?? false)))
            {
                MessageBox.Show("No files available that could be copied/moved");
                return;
            }

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
                MessageBox.Show($"Folder to move deleted files to is not valid:\n\"{PathHandler.RemoveFolder}\"");
                return;
            }


            var fileForDeletion = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : ListHandler.PlayList.ElementAt(ListHandler.PlayListIndex);
            var fileScripts = SettingsHandler.IncludeScripts ? FileManipulation.GetAssociatedFunscripts(fileForDeletion) : new List<string>();


            if (!SettingsHandler.DeleteFull) //Actually reversed due checkbox naming
            {
                try
                {
                    File.Delete(fileForDeletion);
                    foreach (var script in fileScripts)
                    {
                        File.Delete(script);
                    }
                }
                catch (Exception ex)
                {
                    Error.Log(ex, $"Error deleting file");
                    MessageBox.Show($"Error deleting file:\n\"{fileForDeletion}\"");
                    return;
                }

            }
            else
            {
                string removalPath = Path.Combine(PathHandler.RemoveFolder, FileManipulation.GetFileName(fileForDeletion));

                Task deleteTask = null;
                try
                {
                    deleteTask = FileManipulation.MoveFileAsync(fileForDeletion, removalPath);
                    MainFormData.ongoingTasks.Add(deleteTask);
                    MainFormData.ongoingFileProcesses.Add(fileForDeletion);

                    await deleteTask;

                    foreach (var script in fileScripts)
                    {
                        removalPath = Path.Combine(PathHandler.RemoveFolder, FileManipulation.GetFileName(script));
                        File.Move(script, removalPath);
                    }
                }
                catch (Exception ex)
                {
                    Error.Log(ex, $"Error deleting file with action moving instead of deleting");
                    MessageBox.Show($"Error moving the file for deletion:\n\"{fileForDeletion}\"");
                    return;
                }
                finally
                {
                    if (deleteTask != null)
                    {
                        MainFormData.ongoingFileProcesses.Remove(fileForDeletion);
                        MainFormData.ongoingTasks.Remove(deleteTask);
                    }
                }
            }


            ListHandler.DeleteStringFromCustomList(fileForDeletion); //Delete path from Properties Settings

            if (!MainFormData.playingSingleFile)
            {
                var updatedList = ListHandler.PlayList.ToList();
                updatedList.RemoveAt(ListHandler.PlayListIndex);
                ListHandler.PlayList = updatedList;  //Delete Path from current List and update it
                ListHandler.PlayListIndex--;
            }

            PlayNext();
        }
        private async void MoveOrCopyCurrentFile()
        {
            if (ListHandler.FirstPlay && !MainFormData.playingSingleFile) return;

            if (string.IsNullOrWhiteSpace(PathHandler.FileMoveFolderPath))
            {
                MessageBox.Show("Please choose a folder to Copy/Move files to under Settings => Paths");
                return;
            }

            if ((MainFormData.playingSingleFile && string.IsNullOrWhiteSpace(MainFormData.draggedFilePath)) || (!MainFormData.playingSingleFile && !(ListHandler.PlayList?.Any() ?? false)))
            {
                MessageBox.Show("No files available that could be copied/moved");
                return;
            }

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
                MessageBox.Show($"Folder to Copy/Move files to is not valid: {PathHandler.FileMoveFolderPath}");
                return;
            }


            var fileForAction = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : ListHandler.PlayList.ElementAt(ListHandler.PlayListIndex);

            if (MainFormData.ongoingFileProcesses.Contains(fileForAction)) return;


            string fileDestinationPath = Path.Combine(PathHandler.FileMoveFolderPath, FileManipulation.GetFileName(fileForAction));

            if (SettingsHandler.FileCopy)
            {
                Task copyTask = null;
                try
                {
                    copyTask = FileManipulation.CopyFileAsync(fileForAction, fileDestinationPath);
                    MainFormData.ongoingTasks.Add(copyTask);
                    MainFormData.ongoingFileProcesses.Add(fileForAction);
                    await copyTask;
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Couldn't copy file to destination");
                    MessageBox.Show($"Couldn't copy file\n\"{fileForAction}\"\nto destination:\n\"{fileDestinationPath}\"");
                }
                finally
                {
                    if (copyTask != null)
                    {
                        MainFormData.ongoingFileProcesses.Remove(fileForAction);
                        MainFormData.ongoingTasks.Remove(copyTask);
                        playerMPV.ShowText($"Copied file to {fileDestinationPath}");
                    }
                }
            }
            else
            {
                Task moveTask = null;
                try
                {
                    moveTask = FileManipulation.MoveFileAsync(fileForAction, fileDestinationPath);

                    MainFormData.ongoingTasks.Add(moveTask);
                    MainFormData.ongoingFileProcesses.Add(fileForAction);
                    await moveTask;
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Couldn't move file to destination");
                    MessageBox.Show($"Couldn't move file\n\"{fileForAction}\"\nto destination:\n\"{fileDestinationPath}\"");
                    return;
                }
                finally
                {
                    if (moveTask != null)
                    {
                        MainFormData.ongoingFileProcesses.Remove(fileForAction);
                        MainFormData.ongoingTasks.Remove(moveTask);
                        playerMPV.ShowText($"Moved file to {fileDestinationPath}");
                    }
                }
                ListHandler.DeleteStringFromCustomList(fileForAction); //Delete path from Properties Settings

                if (!MainFormData.playingSingleFile)
                {
                    var updatedList = ListHandler.PlayList.ToList();
                    updatedList.RemoveAt(ListHandler.PlayListIndex);
                    ListHandler.PlayList = updatedList;  //Delete Path from current List and update it
                    ListHandler.PlayListIndex--;
                }

                PlayNext();
            }
        }

        private void DeleteCurrentFromList()
        {
            if (ListHandler.FirstPlay && !MainFormData.playingSingleFile) return;

            if (MainFormData.playingSingleFile)
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

            playerMPV.ShowText("Deleted from list");
        }
        private void AddCurrentToList()
        {
            if (ListHandler.FirstPlay && !MainFormData.playingSingleFile) return;

            var currentFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : ListHandler.PlayList.ElementAt(ListHandler.PlayListIndex);

            ListHandler.AddStringToCustomList(currentFile);
            playerMPV.ShowText("Added to list");
        }
        #endregion

        #region Initialization
        private void CheckStartedByFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    if (!File.Exists(filePath)) return;
                    MainFormData.filepathFromStartupFile = filePath;
                    MainFormData.directoryFromStartupFile = FileManipulation.GetFileDirectory(filePath);
                    MainFormData.startedByFile = true;
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Error starting application by file");
                    MessageBox.Show($"Failed to open with file {ex}, continue loading default");
                }
            }
        }
        private async void initStartUp(string alternativePath)
        {
            if (!string.IsNullOrWhiteSpace(alternativePath))
            {
                PathHandler.FolderPath = alternativePath;
            }
            else
            {
                PathHandler.FolderPath = string.IsNullOrWhiteSpace(PathHandler.DefaultFolder) || !Directory.Exists(PathHandler.DefaultFolder) ? "" : PathHandler.DefaultFolder;
            }

            if (!SettingsHandler.IsPlaying)
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

                MainFormData.tempFavorites = fromTXT;
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Failed to read Favorites.txt");
            }

            if (string.IsNullOrWhiteSpace(PathHandler.PathToListFolder) == false)
            {
                InitializeScriptProfile();
            }
        }
        private void InitializePlayerEvents()
        {
            panelPlayerMPV.MouseWheel += new MouseEventHandler(panelPlayerMPV_MouseWheel);
            pbVolume.MouseWheel += new MouseEventHandler(pbVolume_MouseWheel);
            playerMPV.MediaLoaded += new EventHandler(SetMediaInfo);
            playerMPV.MediaFinished += new EventHandler(MediaFinished);
        }

        private void InitializePlayer()
        {
            int initVolume = SettingsHandler.VolumeMember ? SettingsHandler.VolumeLastValue : 50;

            pbVolume.Value = initVolume;
            string libMpv = MainFormData.startupPath + "lib\\libmpv-2.dll";
            playerMPV = new MpvPlayer(panelPlayerMPV.Handle, libMpv) { Loop = (!(SettingsHandler.AutoPlayMethod == AutoPlayMethod.AutoNext)), Volume = initVolume, KeepOpen = KeepOpen.Yes };
            if (SettingsHandler.RTXVSREnabled)
            {
                try
                {
                    playerMPV.API.Command("vf", "append", MainFormData.VSRFilter);
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "Failed to load RTX VSR");
                }
            }
        }
        #endregion

        #region Player Events
        private void MediaFinished(object sender, EventArgs e)
        {
            try
            {
                if (playerMPV.IsMediaLoaded && (SettingsHandler.AutoPlayMethod == AutoPlayMethod.AutoNext) && !MainFormData.playingSingleFile)
                {
                    if (!(MainFormData.durationMS > 0)) return; //Check if it's an image
                    PlayNext();
                }
                else if (playerMPV.IsMediaLoaded && MainFormData.playingSingleFile)
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
            MainFormData.durationMS = (int)(playerMPV?.Duration.TotalMilliseconds ?? 0);

            SettingsHandler.VideoDuration = MainFormData.durationMS / 1000; //seconds

            tcServer.Duration = MainFormData.durationMS.ToString();

            pbPlayerProgress.Maximum = MainFormData.durationMS;

            string updatedCurrentFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;


            if (!string.IsNullOrWhiteSpace(updatedCurrentFile))
            {
                MainFormData.favoriteMatch = FavFunctions.IsFavoriteMatched(updatedCurrentFile, MainFormData.tempFavorites);
                SetHighlight(btnAddToFav, MainFormData.favoriteMatch, Color.Red);
                SetTimeServerFile(updatedCurrentFile);

                var currentFileExtension = Path.GetExtension(updatedCurrentFile).TrimStart('.').ToLower();
                if (ListHandler.ImageExtensions.Contains(currentFileExtension))
                {
                    pbPlayerProgress.DeleteActionsPoints();
                    return;
                }

                TrackInfo.GrabTrackInfo(playerMPV);

                UpdateSubtitleOptions();
                UpdateAudioTracks();

                UpdateScriptFiles();
                UpdateScriptProfiles();

                ToggleSubtitles();
                MainFormData.presentInCustomList = ListHandler.DoesCustomListContainString(updatedCurrentFile);
                UpdateListEditIcon();
            }
            else
            {
                pbPlayerProgress.DeleteActionsPoints();
                return;
            }
            pbPlayerProgress.DeleteActionsPoints();
            UpdateFunscriptGraph();

            if (SettingsHandler.EnableAutoSkip)
            {
                var nextActionToSkipTo = pbPlayerProgress.DetectGap(0, 5000);


                if (nextActionToSkipTo > 0 && SettingsHandler.EnableRandomVideoStartPoint && SettingsHandler.RandomVideoStartPointIgnoreScripts == false)
                {
                    var startRange = (int)(nextActionToSkipTo / 1000);
                    var maxRange = (int)(MainFormData.durationMS / 1000 * 0.8);
                    var random = new Random();

                    var randomStartPoint = random.Next(startRange, maxRange);

                    playerMPV.SeekAsync(randomStartPoint);
                }
                else if (nextActionToSkipTo > 0 && SettingsHandler.SkipVideoStart)
                {
                    playerMPV.ShowText("Skipping to next action");
                    playerMPV.SeekAsync(nextActionToSkipTo / 1000);
                }
                else if (SettingsHandler.EnableRandomVideoStartPoint && (SettingsHandler.RandomVideoStartPointIgnoreScripts && pbPlayerProgress.HasActionPoints) == false)
                {
                    var maxRange = (int)(MainFormData.durationMS / 1000 * 0.8);
                    var random = new Random();

                    var randomStartPoint = random.Next(0, maxRange);

                    playerMPV.API.Command("seek", randomStartPoint.ToString(), "absolute");
                }
                playerMPV.SetBrightness(0);
                playerMPV.Resume();
            }
        }
        private void UpdateFunscriptGraph()
        {
            if (SettingsHandler.GraphEnabled)
            {
                var funscriptFilePath = MainFormData.playingSingleFile ? FileManipulation.GetFilePathWithDifferentExtension(MainFormData.draggedFilePath, ".funscript") : FileManipulation.GetFilePathWithDifferentExtension(MainFormData.currentFile, ".funscript");
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
        private void TcServer_CommandReceived(object sender, string commandData)
        {
            HandleCommand(commandData);
        }

        private void HandleCommand(string commandData)
        {

            if (commandData.StartsWith("wm_command=887"))
            {
                //Play
                PlayerResume();
            }
            else if (commandData.StartsWith("wm_command=888"))
            {
                //Pause
                PlayerPause();
            }
            else if (commandData.StartsWith("wm_command=-1"))
            {
                //Position
                string timeString = WebServerCommands.ExtractTimeFromCommand(commandData);
                int seconds = WebServerCommands.ConvertTimeToSeconds(timeString);

                try
                {
                    playerMPV.SeekAsync(seconds);
                }
                catch (Exception ex)
                {
                    Error.Log(ex, "ScriptPlayer seek command failed");
                }
            }
        }

        private void MatchFavorites()
        {
            if (ListHandler.FirstPlay && !MainFormData.playingSingleFile) return;

            string tempFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;

            if (!MainFormData.favoriteMatch)
            {
                MainFormData.tempFavorites = FavFunctions.AddToFavoritesList(tempFile);
                MainFormData.favoriteMatch = FavFunctions.IsFavoriteMatched(tempFile, MainFormData.tempFavorites);
                SetHighlight(btnAddToFav, MainFormData.favoriteMatch, Color.Red);
            }
            else
            {
                MainFormData.tempFavorites = FavFunctions.DeleteFromFavorites(tempFile, MainFormData.tempFavorites);
                MainFormData.favoriteMatch = FavFunctions.IsFavoriteMatched(tempFile, MainFormData.tempFavorites);
                SetHighlight(btnAddToFav, MainFormData.favoriteMatch, Color.Red);
            }
        }

        private void MatchCustomList()
        {
            if (ListHandler.FirstPlay && !MainFormData.playingSingleFile) return;

            string tempFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;

            if (!MainFormData.presentInCustomList)
            {
                AddCurrentToList();
                MainFormData.presentInCustomList = ListHandler.DoesCustomListContainString(tempFile);
                UpdateListEditIcon();
            }
            else
            {
                DeleteCurrentFromList();
                MainFormData.presentInCustomList = ListHandler.DoesCustomListContainString(tempFile);
                UpdateListEditIcon();
            }

            ListHandler.ListChanged = true;
        }
        private async Task SetTimeServerFile(string fileName, bool reload = false)
        {
            var tempFile = MainFormData.playingSingleFile ? MainFormData.draggedFilePath : MainFormData.currentFile;
            string content = @"{""actions"":[{""at"":0,""pos"":50}],""inverted"":false,""metadata"":{""bookmarks"":[],""chapters"":[],""creator"":"""",""description"":"""",""duration"":504,""license"":"""",""notes"":"""",""performers"":[],""script_url"":"""",""tags"":[],""title"":"""",""type"":""basic"",""video_url"":""""},""range"":100,""version"":""1.0""}";
            var pathTempScript = Path.Combine(Path.GetDirectoryName(tempFile), "Reload.funscript");
            var pathTempVideo = Path.Combine(Path.GetDirectoryName(tempFile), "Reload.mp4");
            try
            {
                if (reload)
                {
                    if (SettingsHandler.UsingScriptPlayer)
                    {
                        File.WriteAllText(pathTempScript, content);
                    }
                    tcServer.File = Path.GetFileName(pathTempVideo);
                    tcServer.FilePathArg = Uri.EscapeDataString(pathTempVideo).Replace("%3A", ":").Replace("%5C", "%5c");
                    tcServer.Filepath = pathTempVideo;
                    tcServer.FileDir = Path.GetDirectoryName(pathTempVideo);
                }
                else
                {
                    tcServer.File = Path.GetFileName(fileName);
                    tcServer.FilePathArg = Uri.EscapeDataString(fileName).Replace("%3A", ":").Replace("%5C", "%5c");
                    tcServer.Filepath = fileName;
                    tcServer.FileDir = Path.GetDirectoryName(fileName);

                    if (File.Exists(pathTempScript))
                    {
                        File.Delete(pathTempScript);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Failed to create or delete temporary funscript file");
            }


        }
        #endregion

        #region Player Progressbar related
        private void pbPlayerProgress_MouseDown(object sender, MouseEventArgs e) //Jump to video position based on cursor position on progress bar
        {
            try
            {
                if (playerMPV.IsMediaLoaded)
                {
                    base.OnMouseClick(e);

                    var percentage = (int)((float)e.X / pbPlayerProgress.Width * pbPlayerProgress.Maximum);
                    playerMPV.SeekAsync(percentage / 1000, false);
                    pbPlayerProgress.Refresh();
                }
            }
            catch (Exception) { return; } //Player is busy
        }

        private Label timeOverlayLabel = new Label();

        private void pbPlayerProgress_MouseMove(object sender, MouseEventArgs e) //Set Tooltip with video position on cursor position
        {
            if (!(MainFormData.durationMS > 0)) return;

            var percentage = (int)(((double)e.X) / pbPlayerProgress.Width * pbPlayerProgress.Maximum);
            var OnCursor = TimeSpan.FromMilliseconds(percentage);
            var formattedTime = OnCursor.ToString(@"hh\:mm\:ss");

            timeOverlayLabel.Text = formattedTime;

            Point controlRelativePosition = this.PointToClient(pbPlayerProgress.PointToScreen(new Point(e.X, e.Y)));

            // Set the label's location directly above the progress bar, horizontally centered on the cursor
            var labelX = controlRelativePosition.X - (timeOverlayLabel.Width / 2) + pbPlayerProgress.Location.X;
            var labelY = this.Height - (panelBottom.Height + 19); //94

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
            timeOverlayLabel.Font = new Font("Arial", 8 / DPI.Scale, FontStyle.Bold);
            timeOverlayLabel.ForeColor = Color.Black;

            this.Controls.Add(timeOverlayLabel);
            timeOverlayLabel.BringToFront();
        }
        #endregion

        #region Player Volume related Controls
        private void MutePlayer()
        {
            if (pbVolume.Value > 0)
            {
                SettingsHandler.VolumeTemp = pbVolume.Value;
                pbVolume.Value = 0;
                playerMPV.Volume = 0;
            }
            else
            {
                pbVolume.Value = SettingsHandler.VolumeTemp;
                playerMPV.Volume = pbVolume.Value;
            }
        }
        private void btnMuteToggle_Click(object sender, EventArgs e)
        {
            MutePlayer();
        }
        private void pbVolume_MouseWheel(object sender, MouseEventArgs e) //Adjust Player Volume with scrolling while Cursor on Volume bar
        {
            if (e.Delta > 0)
            {
                VolumeChange(true);
            }
            else if (e.Delta < 0)
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
            base.OnMouseMove(e);

            UpdateVolume(e);

            pbVolume.MouseMove += pbVolume_MouseMove;
            pbVolume.MouseUp += pbVolume_MouseUp;
        }

        private void pbVolume_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);

            UpdateVolume(e);
        }

        private void pbVolume_MouseUp(object sender, MouseEventArgs e)
        {
            pbVolume.MouseMove -= pbVolume_MouseMove;
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
            var loopHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "SwitchPlaybackBehavior");
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
            toolTipUI.SetToolTip(btnListAdd, $"{GetKeyCombination(addToCurrentListHotkey)} | Add/Remove currently played videofile to/from custom List and Playlist | Right-click to save directly to list");
            toolTipUI.SetToolTip(btnSettings, "Open settings menu");
            toolTipUI.SetToolTip(btnAddToFav, $"{GetKeyCombination(addToFavHotkey)} | Add current to favorite list");
            toolTipUI.SetToolTip(btnShuffle, $"{GetKeyCombination(shuffleHotkey)} | Toggle shuffle / Parse order");
            toolTipUI.SetToolTip(btnRepeat, $"{GetKeyCombination(loopHotkey)} | Switch playback behavior");
            toolTipUI.SetToolTip(btnMuteToggle, $"{GetKeyCombination(muteHotkey)} | Mute sound");
            toolTipUI.SetToolTip(pbVolume, "Scroll/Click to change volume");
            toolTipUI.SetToolTip(btnAddToQueue, "Add dropped file to queue");
            toolTipUI.SetToolTip(btnSourceSelector, "Switch between Folder and List Queue");
            toolTipUI.SetToolTip(btnAutoSkip, "Auto skip gaps in funscript");
            toolTipUI.SetToolTip(btnTouch, "Toggle Touch mode");

            toolTipUI.SetToolTip(btnAddToQueue, "Add the dropped file to the end of the current queue");
            toolTipUI.SetToolTip(btnStartFromFile, "Start playing from the files directory");

            if (SettingsHandler.FileCopy)
            {
                toolTipUI.SetToolTip(btnMoveTo, $"{GetKeyCombination(moveOrCopyFileHotkey)} | Copy file to: {PathHandler.FileMoveFolderPath} | Right-click to choose target");
            }
            else
            {
                toolTipUI.SetToolTip(btnMoveTo, $"{GetKeyCombination(moveOrCopyFileHotkey)} | Move file to: {PathHandler.FileMoveFolderPath} | Right-click to choose target");
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
                    case "AddRemoveCurrentToList":
                        MatchCustomList();
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
                    case "SwitchPlaybackBehavior":
                        SwitchPlaybackBehavior();
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
                        if (MainFormData.TouchEnabled)
                        {
                            ToggleTouchMode();
                        }
                        else
                        {
                            ToggleExclusiveFullscreen();
                        }
                        return true;
                    case "ToggleStatisticsOverlay":
                        playerMPV.API.Command("script-binding", "stats/display-stats-toggle");
                        return true;
                    case "SeekForward":
                        SeekForward();
                        return true;
                    case "SeekBackward":
                        SeekBackward();
                        return true;
                    case "SpeedIncrease":
                        ChangePlaybackSpeed(VideoManipulation.Speed.Increase);
                        return true;
                    case "SpeedDecrease":
                        ChangePlaybackSpeed(VideoManipulation.Speed.Decrease);
                        return true;
                    case "SpeedReset":
                        ChangePlaybackSpeed(VideoManipulation.Speed.Reset);
                        return true;
                    case "ZoomIn":
                        VideoManipulation.ZoomVideo(playerMPV, CommandSettings.ZoomStep);
                        return true;
                    case "ZoomOut":
                        VideoManipulation.ZoomVideo(playerMPV, -CommandSettings.ZoomStep);
                        return true;
                    case "PanLeft":
                        VideoManipulation.PanVideo(playerMPV, -CommandSettings.PanStep, true);
                        return true;
                    case "PanRight":
                        VideoManipulation.PanVideo(playerMPV, CommandSettings.PanStep, true);
                        return true;
                    case "PanUp":
                        VideoManipulation.PanVideo(playerMPV, -CommandSettings.PanStep, false);
                        return true;
                    case "PanDown":
                        VideoManipulation.PanVideo(playerMPV, CommandSettings.PanStep, false);
                        return true;
                    case "ResetVideoManipulation":
                        VideoManipulation.ResetVideoManipulation(playerMPV);
                        return true;
                    case "FitHorizontal":
                        VideoManipulation.AutoFillVideoHorizontally(playerMPV, true);
                        return true;
                    case "FitVertical":
                        VideoManipulation.AutoFillVideoHorizontally(playerMPV, false);
                        return true;
                    case "ScaleWidthUp":
                        VideoManipulation.ScaleVideo(playerMPV, CommandSettings.ScaleStep, true);
                        return true;
                    case "ScaleWidthDown":
                        VideoManipulation.ScaleVideo(playerMPV, -CommandSettings.ScaleStep, true);
                        return true;
                    case "ScaleHeightUp":
                        VideoManipulation.ScaleVideo(playerMPV, CommandSettings.ScaleStep, false);
                        return true;
                    case "ScaleHeightDown":
                        VideoManipulation.ScaleVideo(playerMPV, -CommandSettings.ScaleStep, false);
                        return true;
                    case "RotateClockwise":
                        VideoManipulation.RotateVideo(playerMPV, 90, false);
                        return true;
                    case "Rotate180":
                        VideoManipulation.RotateVideo(playerMPV, 180, false);
                        return true;
                    case "RotateCounterClockwise":
                        VideoManipulation.RotateVideo(playerMPV, -90, false);
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Timer
        //Init mouse idle to hide cursor when in exclusive fullscreen mode
        Timer activityTimer = new Timer();
        //Timer to check for single mouse click 
        Stopwatch stopwatch = new Stopwatch();

        Timer checkwatch = new Timer();
        System.Timers.Timer timerAutoPlayNext = new System.Timers.Timer();
        private System.Timers.Timer seekTimer;
        private void InitializeTimers()
        {
            activityTimer.Tick += activityWorker_Tick;
            activityTimer.Interval = 100;

            checkwatch.Interval = MainFormData.doubleClickDelay;
            checkwatch.Tick += Checkwatch_Tick;

            timerAutoPlayNext.Interval = SettingsHandler.AutoPlayTimerValueStartPoint() * 1000;
            timerAutoPlayNext.Elapsed += timerAutoPlayNext_Tick;

            seekTimer = new System.Timers.Timer(MainFormData.seekTimerDelay);
            seekTimer.AutoReset = false; // Only trigger once after delay
            seekTimer.Elapsed += SeekTimer_Elapsed;
        }
        private void SeekTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!playerMPV.IsMediaLoaded) return;

            try
            {
                var positionMS = (int)playerMPV.Position.TotalMilliseconds;
                var newSeekPositionMS = positionMS + (MainFormData.cumulativeSeek * 1000);

                if (newSeekPositionMS < 0)
                {
                    newSeekPositionMS = 0;
                }
                else if (newSeekPositionMS > MainFormData.durationMS)
                {
                    newSeekPositionMS = MainFormData.durationMS;
                }


                playerMPV.SeekAsync(newSeekPositionMS / 1000);
            }
            catch (Exception) { } //player is busy

            MainFormData.cumulativeSeek = 0;

            MainFormData.progressBufferActive = false;
        }
        private void timerProgressUpdate_Tick(object sender, EventArgs e) //Updates the ProgressBar to show current Videoposition
        {
            try
            {
                if (playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && SettingsHandler.InitPlay && SettingsHandler.VideoDuration > 0)
                {
                    var positionMS = (int)playerMPV.Position.TotalMilliseconds;
                    var remainingS = (int)playerMPV.Remaining.TotalSeconds;

                    SettingsHandler.VideoRemaining = remainingS;

                    if (MainFormData.progressBufferActive == false)
                    {
                        pbPlayerProgress.Value = positionMS;
                    }


                    var _totalSpan = TimeSpan.FromMilliseconds(MainFormData.durationMS);
                    var _currentSpan = TimeSpan.FromMilliseconds(positionMS);
                    lblDurationInfo.Text = $"{_currentSpan:hh\\:mm\\:ss} / {_totalSpan:hh\\:mm\\:ss}";

                    tcServer.Position = positionMS.ToString();
                    pbPlayerProgress.Refresh();
                }
                else if (playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && MainFormData.playingSingleFile && SettingsHandler.VideoDuration > 0)
                {
                    var positionMS = (int)playerMPV.Position.TotalMilliseconds;
                    var remainingS = (int)playerMPV.Remaining.TotalSeconds;

                    SettingsHandler.VideoRemaining = remainingS;
                    if (MainFormData.progressBufferActive == false)
                    {
                        pbPlayerProgress.Value = positionMS;
                    }

                    var _totalSpan = TimeSpan.FromMilliseconds(MainFormData.durationMS);
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

        private void timerAutoPlayNext_Tick(object sender, EventArgs e)
        {
            timerAutoPlayNext.Stop();
            if (!SettingsHandler.BurnsEffectEnabled || (MainFormData.isImage == false && SettingsHandler.BurnsEffectEnabled))
            {
                PlayNext();
            }
        }
        private void timerAutoSkipCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                if (playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && SettingsHandler.VideoDuration > 0 && SettingsHandler.EnableAutoSkip && SettingsHandler.SkipAlways)
                {
                    var positionMS = (int)playerMPV.Position.TotalMilliseconds;

                    var nextActionToSkipTo = pbPlayerProgress.DetectGap(positionMS, (SettingsHandler.AutoSkipSeconds * 1000));

                    if (nextActionToSkipTo > 0)
                    {
                        playerMPV.ShowText("Skipping to next action");
                        playerMPV.SeekAsync(nextActionToSkipTo / 1000);
                    }
                }
            }
            catch (Exception) { return; }
        }
        #endregion

        #region AutoSkip
        private void AutoSkipHandler()
        {
            if (SettingsHandler.EnableAutoSkip && SettingsHandler.SkipAlways)
            {
                timerAutoSkipCheck.Enabled = true;
            }
            else
            {
                timerAutoSkipCheck.Enabled = false;
            }

            if (SettingsHandler.EnableAutoSkip)
            {
                SettingsHandler.GraphEnabled = true;
            }
            InitializeContextMenus();
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

        private async void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    MainFormData.draggedFilePath = files[0];
                    var pathIsDirectory = false;

                    if (!File.Exists(MainFormData.draggedFilePath))
                    {
                        if (Directory.Exists(MainFormData.draggedFilePath))
                            pathIsDirectory = true;
                        else
                            MainFormData.draggedFilePath = string.Empty;
                        return;
                    }

                    MainFormData.currentFile = MainFormData.draggedFilePath;

                    ChangePlaybackSpeed(VideoManipulation.Speed.Reset);

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
                            StartFromFolder(MainFormData.draggedFilePath, SettingsHandler.IncludeSubdirectoriesDnD);
                            return;
                        }

                        timerAutoPlayNext.Enabled = false;

                        playerMPV.Loop = true;
                        playerMPV.Load(MainFormData.draggedFilePath, true);

                        SettingsHandler.IsPlaying = false;

                        MainFormData.playingSingleFile = true;

                        await ScriptHandler.RevertDefaultScript();
                        await ScriptHandler.RevertDefaultMultiAxisScript();

                        if (SettingsHandler.TimeCodeServer)
                        {
                            await ScriptHandler.FillScriptList(MainFormData.draggedFilePath);
                            await ScriptHandler.LoadScript(0, MainFormData.draggedFilePath);
                            foreach (var multiAxisScript in ScriptHandler.MultiAxisScriptsFound)
                            {
                                if (multiAxisScript.Value.ScriptFiles.Count <= 0) continue;
                                await ScriptHandler.LoadMultiAxisScript(0, MainFormData.draggedFilePath, multiAxisScript.Key);
                            }
                        }

                        PlayerResume();

                        ThreadHelper.SetText(this, lblCurrentInfo, MainFormData.draggedFilePath);
                        ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - Playing single file : Press next to jump back to queue or select other options");

                        btnNext.Enabled = true;
                        btnPrevious.Enabled = false;
                        btnRemove.Enabled = true;
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
            if (MainFormData.playingSingleFile)
            {
                if (!(ListHandler.PlayList?.Any() ?? false))
                {
                    MessageBox.Show("No Playlist loaded, so this can't be added to it");
                    return;
                }

                var updatedList = ListHandler.PlayList.ToList();
                updatedList.Add(MainFormData.draggedFilePath);
                ListHandler.PlayList = updatedList;
                ListHandler.FolderList = updatedList;
                ListHandler.PlayListIndex--;
                PlayNext();
            }
        }
        private void StartFromCurrentFile()
        {
            try
            {
                ListHandler.fillFolderList(FileManipulation.GetFileDirectory(MainFormData.draggedFilePath), false);

                ListHandler.NeedsToPrepare = true;
                SettingsHandler.SourceSelected = false;
                ListHandler.PreparePlayList(SettingsHandler.SourceSelected, true, MainFormData.draggedFilePath);

                MainFormData.playingSingleFile = false;
                PlayNext();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing from this path: {ex}");
                throw;
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

            MainFormData.startedByFile = false;
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

        #region Update
        private async void CheckForUpdates()
        {
            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            string[] versionParts = currentVersion.ToString().Split('.');
            string truncatedVersion = string.Join(".", versionParts[0], versionParts[1]);

            try
            {
                if (SettingsHandler.AlwaysCheckUpdate)
                {
                    var latestVersion = await GetLatestVersionFromGitHub();

                    if (latestVersion > currentVersion)
                    {
                        ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - v{truncatedVersion} - Update available!");
                        return;
                    }
                }
                ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - v{truncatedVersion}");
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Error checking for updates");
                ThreadHelper.SetText(this, lblTitleBar, $"Random Video Player - v{truncatedVersion}");
            }

        }
        private async Task<Version> GetLatestVersionFromGitHub()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true
                };

                var versionHistory = UpdateFunctions.GetVersionHistory(MainFormData.VersionHistoryUrl);

                return new Version(versionHistory.Last().Key);
            }
        }
        #endregion

        #region RTX

        //Still not working
        private void ActivateRTXFeatures(bool autoVSR = true, bool autoHDR = false)
        {
            var video_width = playerMPV.API.GetPropertyDouble("width");
            var video_height = playerMPV.API.GetPropertyDouble("height");
            var display_width = playerMPV.API.GetPropertyDouble("display-width");
            var display_height = playerMPV.API.GetPropertyDouble("display-height");
            var codec = playerMPV.API.GetPropertyString("video-codec");
            var pixelformat = playerMPV.API.GetPropertyString("video-params/pixelformat");
            var primaries = playerMPV.API.GetPropertyString("video-params/primaries");
            var gamma = playerMPV.API.GetPropertyString("video-params/gamma");

            bool HasMissingDouble(double value) => double.IsNaN(value) || double.IsInfinity(value);
            bool HasMissingString(string value) => string.IsNullOrWhiteSpace(value);

            if (HasMissingDouble(video_width) || HasMissingDouble(video_height) || HasMissingDouble(display_width) || HasMissingDouble(display_height) ||
                                HasMissingString(codec) || HasMissingString(pixelformat))
            {
                Error.Log("Missing video properties for RTX");
                return;
            }

            var scale = Math.Max(display_width / video_width, display_height / video_height);
            scale = Math.Ceiling(scale * 10) / 10;

            playerMPV.API.Command("vf", "remove", "@format-nv12");
            playerMPV.API.Command("vf", "remove", "@rtx-vsr");
            playerMPV.API.Command("vf", "remove", "@rtx-hdr");
            playerMPV.API.Command("vf", "remove", "@rtx-combined");

            var isSDR = true;
            if (primaries == "bt.2020" || gamma == "pq" || gamma == "hlg")
            {
                isSDR = false;
            }

            if (codec.ToLowerInvariant().Contains("hevc") || codec.ToLowerInvariant().Contains("h.265"))
            {
                if (pixelformat.EndsWith("p101e") || pixelformat == "p010")
                {
                    playerMPV.API.Command("vf", "add", "@format-nv12:format=nv12");
                }
            }

            if (isSDR && autoHDR)
            {
                playerMPV.API.Command("set", "d3d11-output-csp", "srgb");
            }

            if (scale > 1.0 && autoVSR && autoHDR)
            {
                string combined = "@rtx-combined:d3d11vpp=scaling-mode=nvidia:scale=" + scale.ToString("0.0", CultureInfo.InvariantCulture) + ":format=nv12:nvidia-true-hdr";

                playerMPV.API.Command("vf", "append", combined);
            }
            else if (scale > 1.0 && autoVSR)
            {
                playerMPV.API.Command("vf", "append", "@rtx-vsr:d3d11vpp=scaling-mode=nvidia:scale=" + scale.ToString("0.0", CultureInfo.InvariantCulture));
            }
            else if (autoHDR)
            {
                playerMPV.API.Command("vf", "append", "@rtx-hdr:d3d11vpp=format=nv12:nvidia-true-hdr");
            }
            else if (autoHDR == false)
            {
                playerMPV.API.Command("set", "d3d11-output-csp", "auto");
            }
        }
        #endregion

        #region Logic for standard WindowsForms Controls

        private void InitializeFormFunctions()
        {
            if (fR.SaveLastSize == true)
            {
                fR.FormSize = new Size(fR.FormSize.Width - 16, fR.FormSize.Height - 39);
                this.ClientSize = fR.FormSize;
            }
            this.Padding = new Padding(fR.BorderSize);
            this.BackColor = Color.FromArgb(253, 83, 146);
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            fR.AdjustForm(this); //Correct Padding based on window state because WndProc method messes up a bit

            //Adjust the areas used for determin when panels should show up during exclusive Fullscreen mode
            areaBottom = new Rectangle(2, this.Height - panelBottom.Height - 30, this.Width, panelBottom.Height + 30);
            areaTop = new Rectangle(2, 2, this.Width, panelTop.Height + 10);

            if (this.WindowState == FormWindowState.Normal)
            {
                fR.TempSize = DPI.GetSizeScaled(this.Size);
                fR.FormSize = fR.TempSize;
            }
        }
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MainFormData.ongoingTasks.Count > 0)
            {
                e.Cancel = true;
                if (MainFormData.ongoingTasks.Count == 1)
                {
                    MessageBox.Show($"A file moving/copying task is still being executed, please wait until finished before closing");
                }
                else
                {
                    MessageBox.Show($"{MainFormData.ongoingTasks.Count} file moving/copying tasks are still being executed, please wait until finished before closing");
                }

            }
            UnregisterHotKeys();
            tcServer.Stop();
            await ScriptHandler.RevertDefaultScript();
            await ScriptHandler.RevertDefaultMultiAxisScript();
            fR.FormSize = fR.TempSize; //Save last known form size to property
            PathHandler.TempRecentFolder = string.Empty;

            if (SettingsHandler.VolumeMember)
                SettingsHandler.VolumeLastValue = pbVolume.Value;
        }

        private void UpdateDPIScaling()
        {
            pbPlayerProgress.Height = DPI.GetDivided(pbPlayerProgress.Height);
            pbVolume.Size = new Size(DPI.GetDivided(pbVolume.Width), DPI.GetDivided(pbVolume.Size.Height));

            panelBottom.Height = DPI.GetDivided(panelBottom.Height);
            panelTop.Height = DPI.GetDivided(panelTop.Height);

            panelMainButtons.Size = DPI.GetSizeScaled(panelMainButtons.Size);
            panelControls.Size = DPI.GetSizeScaled(panelControls.Size);
            panelExtraButtons.Size = DPI.GetSizeScaled(panelExtraButtons.Size);

            pbVolume.Location = new Point(panelBottom.Width - pbVolume.Width - 2, pbPlayerProgress.Height + 9);

            panelMainButtons.Location = new Point(0, pbPlayerProgress.Height);
            panelControls.Location = new Point(6 + panelMainButtons.Width, pbPlayerProgress.Height + 6);
            panelExtraButtons.Location = new Point(pbVolume.Location.X - panelExtraButtons.Width - 6, pbPlayerProgress.Height + 6);



            lblCurrentInfo.Height = DPI.GetDivided(lblCurrentInfo.Height);
            lblCurrentInfo.Font = new Font(lblCurrentInfo.Font.FontFamily, lblCurrentInfo.Font.Size / DPI.Scale, lblCurrentInfo.Font.Style);

            lblDurationInfo.Height = (int)(lblDurationInfo.Height / DPI.Scale);
            lblDurationInfo.Font = new Font(lblDurationInfo.Font.FontFamily, lblDurationInfo.Font.Size / DPI.Scale, lblDurationInfo.Font.Style);

            lblTitleBar.Height = (int)(lblTitleBar.Height / DPI.Scale);
            lblTitleBar.Font = new Font(lblTitleBar.Font.FontFamily, lblTitleBar.Font.Size / DPI.Scale, lblTitleBar.Font.Style);

            btnAudioTrackMenu.Size = DPI.GetSizeScaled(btnAudioTrackMenu.Size);
            btnAudioTrackMenu.Font = new Font(btnAudioTrackMenu.Font.FontFamily, btnAudioTrackMenu.Font.Size / DPI.Scale, btnAudioTrackMenu.Font.Style);

            btnSubtitleMenu.Size = DPI.GetSizeScaled(btnSubtitleMenu.Size);
            btnSubtitleMenu.Font = new Font(btnSubtitleMenu.Font.FontFamily, btnSubtitleMenu.Font.Size / DPI.Scale, btnSubtitleMenu.Font.Style);

            btnScriptMenu.Size = DPI.GetSizeScaled(btnScriptMenu.Size);
            btnScriptMenu.Font = new Font(btnScriptMenu.Font.FontFamily, btnScriptMenu.Font.Size / DPI.Scale, btnScriptMenu.Font.Style);

            btnMinimizeForm.Size = DPI.GetSizeScaled(btnMinimizeForm.Size);
            btnMaximizeForm.Size = DPI.GetSizeScaled(btnMaximizeForm.Size);
            btnExitForm.Size = DPI.GetSizeScaled(btnExitForm.Size);

            fR.PlayerIsWindowSize(this, panelTop, panelBottom, panelPlayerMPV);




            foreach (Button button in panelMainButtons.Controls)
            {
                button.Size = new Size(DPI.GetDivided(button.Width), DPI.GetDivided(button.Height));
            }
            foreach (Button button in panelControls.Controls)
            {
                button.Size = new Size(DPI.GetDivided(button.Width), DPI.GetDivided(button.Height));
            }
            foreach (Button button in panelExtraButtons.Controls)
            {
                button.Size = new Size(DPI.GetDivided(button.Width), DPI.GetDivided(button.Height));
            }
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
            bool shouldHide = User32Interop.GetLastInput() > MainFormData.activityThreshold;
            if (MainFormData.cursorHidden != shouldHide)
            {
                if (shouldHide)
                    Cursor.Hide();
                else
                    Cursor.Show();

                MainFormData.cursorHidden = shouldHide;
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
                        PlayerResume();
                        break;
                    case 1:
                        PlayerResume();
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