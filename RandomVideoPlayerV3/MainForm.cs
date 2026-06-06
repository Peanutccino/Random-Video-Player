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
using System.IO.Packaging;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;
using Point = System.Drawing.Point;
using Timer = System.Windows.Forms.Timer;

namespace RandomVideoPlayer
{
    public partial class MainForm : Form
    {
        private MpvPlayer playerMPV;
        private MpvPlayer thumbMPV;

        private WebServer tcServer;
        private HotkeySettings hkSettings;

        private FormResize fR = new();
        private Rectangle areaBottom = new();
        private Rectangle areaTop = new();

        private VrController vrController;

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
                ListHandler.SelectedExtensions = ListHandler.CombinedExtensions;

            if (ListHandler.ExtensionFilterForList.Count<string>() <= 0)
                ListHandler.ExtensionFilterForList = ListHandler.CombinedExtensions;


            CheckStartedByFile(filePath);

            UpdateSourceSelectorIcon();

            InitializeContextMenus();

            InitializePreviewPanel();

            InitializeTimeOverlay();

            DPI.UpdateDPIScaling(this);

            LoadThemeOption();

            ThemeManager.ThemeChanged += (_, __) => ThemeManager.ApplyTheme(this);
            ThemeManager.ThemeChanged += (_, __) => ApplyThemeToButtons();
            ThemeManager.ApplyTheme(this);

            ApplyControlTheme();
            ApplyThemeToButtons();

            Error.MinimumLevel = SettingsHandler.LogLevel;
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

                string img = Path.Combine(MainFormData.startupPath, @"Resources\RVP-Splash.png");
                playerMPV.Load(img, true);
            }
            else
            {
                initStartUp(MainFormData.directoryFromStartupFile);
            }

            RepositionButtons();
            SetupTooltips();
            UpdateButtonStates();

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
            ToggleLoop();
        }
        private void btnTimer_Click(object sender, EventArgs e)
        {
            ToggleTimer();
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
        private void btnVrMenu_Click(object sender, EventArgs e)
        {
            contextMenuVr.Show(btnVrMenu, new Point(0, btnVrMenu.Height));
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
            WireIconButton(btnTimer);

            WireContextButton(btnAudioTrackMenu);
            WireContextButton(btnSubtitleMenu);
            WireContextButton(btnScriptMenu);
            WireContextButton(btnVrMenu);
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
            int rasterLength = DPI.GetDivided(20);
            using var bmp = svgDoc.Draw(rasterLength, rasterLength);

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
            if (vrController.Enabled && MainFormData.vrDragging)
            {
                int dx = e.X - MainFormData.lastMouse.X;
                int dy = e.Y - MainFormData.lastMouse.Y;

                MainFormData.lastMouse = e.Location;

                double sensitivity = 0.15;

                vrController.Pan(yawDelta: dx * sensitivity, pitchDelta: -dy * sensitivity);

                Debug.WriteLine($"Mouse moved: dx={dx}, dy={dy}");
            }
            else if (fR.WindowExclusiveFullscreen && !MainFormData.TouchEnabled) //Only use when exclusive Fullscreen is enabled
            {
                panelBottom.Visible = areaBottom.Contains(e.Location) ? true : false;
                panelTop.Visible = areaTop.Contains(e.Location) ? true : false;
            }
        }

        private void panelPlayerMPV_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (vrController.Enabled && e.Button == MouseButtons.Left)
            {
                MainFormData.vrDragging = true;
                MainFormData.lastMouse = e.Location;
                panelPlayerMPV.Capture = true;
                vrController.BeginInteractivePan();
            }
            else if (e.Button == MouseButtons.Left && this.WindowState != FormWindowState.Maximized && !MainFormData.TouchEnabled)
            {
                _stopwatch.Restart();

                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
                long elapsedTime = _stopwatch.ElapsedMilliseconds;
                if (elapsedTime < 105 && SettingsHandler.LeftMousePause) //Check whether it was a click
                {
                    _checkwatch.Start();
                }
            }
            else if (e.Button == MouseButtons.Left && this.WindowState == FormWindowState.Maximized && !MainFormData.TouchEnabled)
            {
                _stopwatch.Restart();
                long elapsedTime = _stopwatch.ElapsedMilliseconds;
                if (elapsedTime < 60 && SettingsHandler.LeftMousePause) //Check whether it was a click
                {
                    _checkwatch.Start();
                }
            }
            else if (e.Button == MouseButtons.Left && this.WindowState == FormWindowState.Maximized && MainFormData.TouchEnabled)
            {
                panelBottom.Visible = !panelBottom.Visible;
                panelTop.Visible = !panelTop.Visible;
            }
            if (e.Button == MouseButtons.Left && e.Clicks >= 2 && !MainFormData.TouchEnabled) //Double Click
            {
                _checkwatch.Stop();
                MainFormData.vrDragging = false;
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
        private void panelPlayerMPV_MouseUp(object sender, MouseEventArgs e)
        {
            MainFormData.vrDragging = false;
            if (vrController.Enabled)
            {
                vrController.EndInteractivePan();
            }
            panelPlayerMPV.Capture = false;
        }
        private void Checkwatch_Tick(object? sender, EventArgs e)
        {
            _checkwatch.Stop();
            PlayerPlayPauseToggle();
        }
        private void ToggleExclusiveFullscreen()
        {
            MainFormData.backupSize = fR.TempSizeMain;
            if (this.WindowState == FormWindowState.Maximized) //Switch to normal state, because windows doesn't like switch to exclusive fullscreen from maximized
            {
                fR.MaximizeForm(this);
            }

            fR.PlayerToExclusiveFullscreen(this, panelTop, panelBottom, panelPlayerMPV);

            if (fR.WindowExclusiveFullscreen)
            {
                _activityTimer.Enabled = true;
                if (MainFormData.cursorHidden)
                {
                    Cursor.Show();
                    MainFormData.cursorHidden = false;
                }
            }
            else
            {
                _activityTimer.Enabled = false;
                if (MainFormData.cursorHidden)
                {
                    Cursor.Show();
                    MainFormData.cursorHidden = false;
                }
                this.Size = MainFormData.backupSize;
            }

            //if (vrController.Enabled)
            //{
            //    vrController.ApplyVrQualityPreset(panelPlayerMPV);
            //    vrController.Update();
            //}
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

                SetHighlight(btnTouch, true);

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

                SetHighlight(btnTouch, false);

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
                //if (!(SettingsHandler.AutoPlayMethod == AutoPlayMethod.AutoNext))
                //{
                //    playerMPV.Loop = SettingsHandler.LoopEnabled;
                //}
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

            if ((SettingsHandler.TimerEnabled) && !MainFormData.playingSingleFile)
            {
                timerAutoPlayNext.Enabled = true;
                timerAutoPlayNext.Interval = SettingsHandler.AutoPlayTimerValueStartPoint() * 1000;
                timerAutoPlayNext.Start();


                VideoManipulation.KenBurnsEffectUpdateSettings();

                if (SettingsHandler.BurnsEffectEnabled)
                {
                    if (ListHandler.InputIsImage(MainFormData.currentFile))
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
            if (vrController.Enabled && MainFormData.vrDragging)
            {
                if (e.Delta > 0)
                    vrController.Zoom(-3);
                else
                    vrController.Zoom(3);
            }
            else if (e.Delta > 0)
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

                bool isShortVideo = videoDuration <= 300; //Smaller seek increments in short videos
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

        private void SeekRandom()
        {
            var durationSeconds = MainFormData.durationMS / 1000;
            var startRange = (durationSeconds * 10 / 100);
            var maxRange = (durationSeconds * 90 / 100);

            var random = new Random();
            var randomStartPoint = random.Next(startRange, maxRange);

            playerMPV.SeekAsync(randomStartPoint);
        }
        private void ToggleShuffle()
        {
            ListHandler.DoShuffle = !ListHandler.DoShuffle;
            UpdateButtonStates();

            ListHandler.NeedsToPrepare = true;

            //PlayNext();
        }
        private void ToggleLoop()
        {
            SettingsHandler.LoopEnabled = !SettingsHandler.LoopEnabled;
            playerMPV.Loop = SettingsHandler.LoopEnabled;
            UpdateButtonStates();
        }

        private void ToggleTimer()
        {
            SettingsHandler.TimerEnabled = !SettingsHandler.TimerEnabled;

            if (SettingsHandler.IsPlaying) timerAutoPlayNext.Enabled = SettingsHandler.TimerEnabled;
            playerMPV.SetBrightness(0);

            if (SettingsHandler.TimerEnabled)
            {
                if (SettingsHandler.BurnsEffectEnabled && SettingsHandler.InitPlay) PlayNext();
            }
            else
            {
                if (SettingsHandler.BurnsEffectEnabled && SettingsHandler.InitPlay)
                {
                    VideoManipulation.KenBurnsEffectStop();
                    VideoManipulation.ResetVideoManipulation(playerMPV);
                    playerMPV.SetBrightness(0);
                }
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

            FolderBrowserV2View fbForm = new FolderBrowserV2View();
            fbForm.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = fbForm.ShowDialog();
            _selectedPath = fbForm.SelectedPath;
            SetHighlight(btnFileBrowse, false);
            if (result != DialogResult.OK) return;

            if (SettingsHandler.SelectedFolders.Count > 0)
            {
                ListHandler.FolderList = Enumerable.Empty<string>();
                ListHandler.TempFolderList = Enumerable.Empty<string>();

                foreach (string folder in SettingsHandler.SelectedFolders)
                {
                    if (!Directory.Exists(folder)) continue;


                    if (SettingsHandler.RecentCheckedTemp)
                    {
                        ListHandler.latestFolderList(folder, SettingsHandler.RecentCount, ListHandler.IncludeSubfolders, true);
                        ListHandler.SortListByNewest(SettingsHandler.RecentCount);
                    }
                    else
                    {
                        ListHandler.fillFolderList(folder, ListHandler.IncludeSubfolders, true);
                    }
                }

                var debugList = ListHandler.FolderList;

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
                    //PathHandler.FolderPath = _selectedPath;
                    ListHandler.TempFolderList = Enumerable.Empty<string>();
                }
            }
            else if (File.Exists(_selectedPath))
            {
                ListHandler.FolderList = Enumerable.Empty<string>();
                ListHandler.TempFolderList = Enumerable.Empty<string>();
                ListHandler.FolderList = ListHandler.FolderList.Concat(new[] { _selectedPath });

                PathHandler.FolderPath = Path.GetDirectoryName(_selectedPath);
            }
            else
            {
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

            ListBrowserV2View lbForm = new ListBrowserV2View();
            lbForm.StartPosition = FormStartPosition.CenterParent;
            result = lbForm.ShowDialog();
            SetHighlight(btnListBrowser, false);

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

                LoadThemeOption();
                ThemeManager.ApplyTheme(this);

                renderer.BackgroundColor = ThemeManager.CurrentTheme.ToolMenuBackColor;
                renderer.TextColor = ThemeManager.CurrentTheme.ToolMenuTextColor;
                renderer.HighlightColor = ThemeManager.CurrentTheme.ToolMenuHoverColor;
                renderer.ApplyColors();

                UpdateListEditIcon();
                UpdateSourceSelectorIcon();
                UpdateAddToListContext();

                RepositionButtons();

                AudioNormalizer.TuneNormalizer();
                AudioNormalizer.ToggleNormalizer(playerMPV);

                Error.MinimumLevel = SettingsHandler.LogLevel;
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
            List<Button> buttons = new List<Button> { btnRemove, btnListAdd, btnAddToFav, btnMoveTo, btnShuffle, btnRepeat, btnSourceSelector, btnTimer, btnAutoSkip, btnTouch };
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
            int fixedButtons = 5; //Non editable buttons

            for (int i = 0; i < buttons.Count; i++)
            {
                Button btn = buttons[buttonOrder[i]];
                btn.Visible = buttonStates[i];
                tableLayoutButtons.SetColumn(btn, i + fixedButtons);
            }
        }

        private void UpdateButtonStates()
        {
            btnMoveTo.IconChar = SettingsHandler.FileCopy ? IconChar.Copy : IconChar.FileExport;

            SetHighlight(btnRepeat, SettingsHandler.LoopEnabled);

            SetHighlight(btnTimer, SettingsHandler.TimerEnabled);

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
        //3D menu
        private ContextMenuStrip contextMenuVr;
        private ToolStripMenuItem enableDisableVrItem;
        private ToolStripMenuItem enableDisableVrAutoDetectItem;
        private ToolStripMenuItem savePreferredVrSetupItem;
        private ToolStripMenuItem removePreferredVrSetupItem;

        private bool tsmiAutoSize = true;

        private void InitializeContextMenus()
        {
            renderer = new CustomRenderer()
            {
                BackgroundColor = ThemeManager.CurrentTheme.ToolMenuBackColor,
                TextColor = ThemeManager.CurrentTheme.ToolMenuTextColor,
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

            //Vr menu
            contextMenuVr = new ContextMenuStrip { Renderer = renderer };
            // 1:Create first context menu item for toggling VR mode
            enableDisableVrItem = new ToolStripMenuItem("Enable VR")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                TextAlign = ContentAlignment.MiddleLeft,
                CheckOnClick = true
            };
            enableDisableVrItem.CheckedChanged += EnableDisableVrItem_CheckedChanged;
            contextMenuVr.Items.Add(enableDisableVrItem);
            // 2:Create first context menu item for toggling VR auto detect
            enableDisableVrAutoDetectItem = new ToolStripMenuItem("Auto-Detection")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                TextAlign = ContentAlignment.MiddleLeft,
                CheckOnClick = true,
                Checked = SettingsHandler.VrAutoDetectionEnabled
            };
            enableDisableVrAutoDetectItem.CheckedChanged += EnableDisableVrAutoDetectItem_CheckedChanged;
            contextMenuVr.Items.Add(enableDisableVrAutoDetectItem);
            // 3:Create context menu button to save preferred VR config
            savePreferredVrSetupItem = new ToolStripMenuItem("Save VR settings for this video")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                ForeColor = ThemeManager.CurrentTheme.TextColor,
                TextAlign = ContentAlignment.MiddleLeft,
                Enabled = false
            };
            savePreferredVrSetupItem.Click += SavePreferredVrSetup_Click;
            contextMenuVr.Items.Add(savePreferredVrSetupItem);
            // 4:Create context menu button to remove VR config for this video
            removePreferredVrSetupItem = new ToolStripMenuItem("Remove VR settings for this video")
            {
                AutoSize = tsmiAutoSize,
                Font = new Font("Segoe UI", 9 / DPI.Scale),
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleLeft,
                Enabled = false
            };
            removePreferredVrSetupItem.Click += RemovePreferredVrSetup_Click;
            contextMenuVr.Items.Add(removePreferredVrSetupItem);

            // Final separator
            contextMenuVr.Items.Add(new ToolStripSeparator());
        }

        private void RemovePreferredVrSetup_Click(object? sender, EventArgs e)
        {
            string videoPath = MainFormData.currentFile;

            if (string.IsNullOrWhiteSpace(videoPath)) return;

            if (VrConfigManager.RemoveConfiguration(videoPath))
            {
                playerMPV.ShowText("VR setup removed");
            }

            UpdateVrConfig();
        }

        private void SavePreferredVrSetup_Click(object? sender, EventArgs e)
        {
            string videoPath = MainFormData.currentFile;

            if (string.IsNullOrWhiteSpace(videoPath)) return;

            VrConfigManager.SaveVrConfig(videoPath, "enabled", MainFormData.vrEnabled.ToString());
            VrConfigManager.SaveVrConfig(videoPath, "quality_preset", vrController.RenderQuality.ToString());
            VrConfigManager.SaveVrConfig(videoPath, "projection", vrController.InputProjection.ToMpvValue());
            VrConfigManager.SaveVrConfig(videoPath, "stereo", vrController.InputStereo.ToMpvValue());
            VrConfigManager.SaveVrConfig(videoPath, "fov", vrController.InputFov.ToMpvValue());
            VrConfigManager.SaveVrConfig(videoPath, "flipeye", vrController.FlipEye.ToString());

            playerMPV.ShowText("VR setup saved");
            MainFormData.loadedVrStatus = true;
            UpdateVrConfig();
        }

        private void EnableDisableVrAutoDetectItem_CheckedChanged(object? sender, EventArgs e)
        {
            SettingsHandler.VrAutoDetectionEnabled = enableDisableVrAutoDetectItem.Checked;
        }

        private void EnableDisableVrItem_CheckedChanged(object? sender, EventArgs e)
        {
            if (enableDisableVrItem.Checked)
            {
                vrController.Enable();
            }
            else
            {
                vrController.Disable();
            }
            vrController.Update();
            if (MainFormData.loadedVrStatus == null)
            {
                MainFormData.vrEnabled = enableDisableVrItem.Checked;
            }

            ApplyPreviewVrEyeCrop(vrController.InputStereo);
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
                    Error.Log(ex, "Failed to access list files", LogLevel.Error);
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

                if (ListHandler.InputIsImage(updatedCurrentFile)) return;

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
                Error.Log(ex, $"Couldn't create new profile file: {ex}", LogLevel.Error);
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
                    Error.Log(ex, $"Couldn't create new profile file: {ex}", LogLevel.Error);
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

        private void UpdateVrConfig()
        {
            string videoPath = MainFormData.currentFile;

            bool isFirstItem = true;
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateVrConfig));
            }
            else
            {
                foreach (ToolStripMenuItem topItem in contextMenuVr.Items.OfType<ToolStripMenuItem>())
                {
                    if (topItem.Text == "Enable VR")
                    {
                        if (MainFormData.loadedVrStatus != null)
                        {
                            topItem.Checked = MainFormData.loadedVrStatus.Value;
                        }
                        else
                        {
                            topItem.Checked = MainFormData.vrEnabled;
                        }

                    }
                    else if (topItem.Text == "Auto-Detection")
                    {
                        topItem.Checked = SettingsHandler.VrAutoDetectionEnabled;
                    }
                    else if (topItem.Text == "Save VR settings for this video")
                    {
                        if (!string.IsNullOrWhiteSpace(videoPath))
                        {
                            topItem.Enabled = true;
                        }
                        else
                        {
                            topItem.Enabled = false;
                        }
                    }
                    else if (topItem.Text == "Remove VR settings for this video")
                    {
                        if (MainFormData.loadedVrStatus != null)
                        {
                            topItem.Enabled = true;
                        }
                        else
                        {
                            topItem.Enabled = false;
                        }
                    }
                }

                for (int i = contextMenuVr.Items.Count - 1; i >= 5; i--)
                {
                    contextMenuVr.Items.RemoveAt(i);
                }
                //Quality Preset
                var selectQualityPresetItem = new ToolStripMenuItem("Quality preset")
                {
                    AutoSize = tsmiAutoSize,
                    Font = new Font("Segoe UI", 9 / DPI.Scale),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                contextMenuVr.Items.Add(selectQualityPresetItem);

                string preferredQualityPreset = VrConfigManager.GetVrConfig(videoPath, "quality_preset");
                int preferredQualityPresetIndex = 0;

                if (!string.IsNullOrWhiteSpace(preferredQualityPreset))
                {
                    preferredQualityPresetIndex = (int)Enum.Parse(typeof(VrRenderQuality), preferredQualityPreset);
                }
                else
                {
                    preferredQualityPreset = SettingsHandler.VrQualityPreset.ToString();
                    preferredQualityPresetIndex = (int)Enum.Parse(typeof(VrRenderQuality), preferredQualityPreset);
                }
                int qualityPresetIndex = 0;
                foreach (var preset in Enum.GetValues(typeof(VrRenderQuality)))
                {
                    var qualityPresetItem = new ToolStripMenuItem(preset.ToString())
                    {
                        Tag = preset,
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft,
                        CheckOnClick = true
                    };
                    qualityPresetItem.Click += QualityPresetItem_Click;

                    if (preferredQualityPresetIndex > 0)
                    {
                        if (preferredQualityPresetIndex == qualityPresetIndex)
                        {
                            qualityPresetItem.Checked = true;
                            isFirstItem = false;
                        }
                    }
                    else if (isFirstItem)
                    {
                        qualityPresetItem.Checked = true;
                        isFirstItem = false;
                    }
                    selectQualityPresetItem.DropDownItems.Add(qualityPresetItem);
                    qualityPresetIndex++;
                }
                //Input Projection
                var selectInputProjection = new ToolStripMenuItem("Projection")
                {
                    AutoSize = tsmiAutoSize,
                    Font = new Font("Segoe UI", 9 / DPI.Scale),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                contextMenuVr.Items.Add(selectInputProjection);

                string preferredProjection = VrConfigManager.GetVrConfig(videoPath, "projection");
                int preferredProjectionIndex = 0;

                if (!string.IsNullOrWhiteSpace(preferredProjection))
                {
                    if (VrInputProjectionExtension.TryFromMpvValue(preferredProjection, out var projection))
                    {
                        preferredProjectionIndex = (int)projection;
                    }
                }
                int projectionIndex = 0;
                foreach (VrInputProjection projection in Enum.GetValues(typeof(VrInputProjection)))
                {
                    var projectionItem = new ToolStripMenuItem(projection.ToDisplayName())
                    {
                        Tag = projection,
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft,
                        CheckOnClick = true
                    };
                    projectionItem.Click += ProjectionItem_Click;

                    if (preferredProjectionIndex > 0)
                    {
                        if (preferredProjectionIndex == projectionIndex)
                        {
                            projectionItem.Checked = true;
                        }
                    }
                    else if (projection == vrController.InputProjection)
                    {
                        projectionItem.Checked = true;
                    }
                    selectInputProjection.DropDownItems.Add(projectionItem);
                    projectionIndex++;
                }
                //Input Stereo
                var selectInputStereo = new ToolStripMenuItem("Stereo Mode")
                {
                    AutoSize = tsmiAutoSize,
                    Font = new Font("Segoe UI", 9 / DPI.Scale),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                contextMenuVr.Items.Add(selectInputStereo);

                string preferredStereo = VrConfigManager.GetVrConfig(videoPath, "stereo");
                int preferredStereoIndex = 0;

                if (!string.IsNullOrWhiteSpace(preferredStereo))
                {
                    if (VrInputStereoExtension.TryFromMpvValue(preferredStereo, out var stereo))
                    {
                        preferredStereoIndex = (int)stereo;
                    }
                }
                int stereoIndex = 0;
                foreach (VrInputStereo stereo in Enum.GetValues(typeof(VrInputStereo)))
                {
                    var stereoItem = new ToolStripMenuItem(stereo.ToDisplayName())
                    {
                        Tag = stereo,
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft,
                        CheckOnClick = true
                    };
                    stereoItem.Click += StereoItem_Click;
                    if (preferredStereoIndex > 0)
                    {
                        if (preferredStereoIndex == stereoIndex)
                        {
                            stereoItem.Checked = true;
                        }
                    }
                    else if (stereo == vrController.InputStereo)
                    {
                        stereoItem.Checked = true;
                    }
                    selectInputStereo.DropDownItems.Add(stereoItem);
                    stereoIndex++;
                }
                //Input FOV
                var selectInputFov = new ToolStripMenuItem("Input FOV")
                {
                    AutoSize = tsmiAutoSize,
                    Font = new Font("Segoe UI", 9 / DPI.Scale),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                contextMenuVr.Items.Add(selectInputFov);

                string preferredFov = VrConfigManager.GetVrConfig(videoPath, "fov");
                int preferredFovIndex = 0;

                if (!string.IsNullOrWhiteSpace(preferredFov))
                {
                    if (VrInputStereoExtension.TryFromMpvValue(preferredFov, out var fov))
                    {
                        preferredFovIndex = (int)fov;
                    }
                }
                int fovIndex = 0;
                foreach (VrInputFov fov in Enum.GetValues(typeof(VrInputFov)))
                {
                    var fovItem = new ToolStripMenuItem(fov.ToDisplayName())
                    {
                        Tag = fov,
                        AutoSize = tsmiAutoSize,
                        Font = new Font("Segoe UI", 9 / DPI.Scale),
                        TextAlign = ContentAlignment.MiddleLeft,
                        CheckOnClick = true
                    };
                    fovItem.Click += FovItem_Click;
                    if (preferredFovIndex > 0)
                    {
                        if (preferredFovIndex == fovIndex)
                        {
                            fovItem.Checked = true;
                        }
                    }
                    else if (fov == vrController.InputFov)
                    {
                        fovItem.Checked = true;
                    }
                    selectInputFov.DropDownItems.Add(fovItem);
                    fovIndex++;
                }
                //Flipeye
                var selectFlipEye = new ToolStripMenuItem("Flip eyes")
                {
                    AutoSize = tsmiAutoSize,
                    Font = new Font("Segoe UI", 9 / DPI.Scale),
                    TextAlign = ContentAlignment.MiddleLeft,
                    CheckOnClick = true,
                    Checked = vrController.FlipEye
                };
                selectFlipEye.Click += SelectFlipEye_Click;
                contextMenuVr.Items.Add(selectFlipEye);

                MainFormData.loadedVrStatus = null;
            }
        }

        private void SelectFlipEye_Click(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem clickedItem)
                return;

            vrController.FlipEye = clickedItem.Checked;
            vrController.Update();
        }

        private void QualityPresetItem_Click(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem clickedItem)
                return;

            if (clickedItem.Tag is not VrRenderQuality quality)
                return;

            var parentItem = clickedItem.OwnerItem as ToolStripMenuItem;
            if (parentItem != null)
            {
                foreach (ToolStripMenuItem item in parentItem.DropDownItems)
                {
                    item.Checked = false;
                }
            }

            clickedItem.Checked = true;

            vrController.RenderQuality = quality;
            vrController.ApplyVrQualityPreset(panelPlayerMPV);
            vrController.Update();
        }

        private void FovItem_Click(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem clickedItem)
                return;

            if (clickedItem.Tag is not VrInputFov fov)
                return;

            var parentItem = clickedItem.OwnerItem as ToolStripMenuItem;
            if (parentItem != null)
            {
                foreach (ToolStripMenuItem item in parentItem.DropDownItems)
                {
                    item.Checked = false;
                }
            }

            clickedItem.Checked = true;

            vrController.InputFov = fov;
            vrController.Update();

            //UpdateVrConfig();
        }

        private void StereoItem_Click(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem clickedItem)
                return;

            if (clickedItem.Tag is not VrInputStereo sterei)
                return;

            var parentItem = clickedItem.OwnerItem as ToolStripMenuItem;
            if (parentItem != null)
            {
                foreach (ToolStripMenuItem item in parentItem.DropDownItems)
                {
                    item.Checked = false;
                }
            }

            clickedItem.Checked = true;

            vrController.InputStereo = sterei;
            vrController.Update();

            ApplyPreviewVrEyeCrop(vrController.InputStereo);
        }

        private void ProjectionItem_Click(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem clickedItem)
                return;

            if (clickedItem.Tag is not VrInputProjection projection)
                return;

            var parentItem = clickedItem.OwnerItem as ToolStripMenuItem;
            if (parentItem != null)
            {
                foreach (ToolStripMenuItem item in parentItem.DropDownItems)
                {
                    item.Checked = false;
                }
            }

            clickedItem.Checked = true;

            vrController.InputProjection = projection;
            vrController.Update();

            //UpdateVrConfig();
        }

        #endregion

        #region VR Settings
        private void LoadPreferredVrSetup()
        {
            string videoPath = MainFormData.currentFile;
            bool foundConfig = false;
            bool detectionSuccess = false;
            bool foundResults = false;
            VrDetectionResults vrDetectionResults = new();

            if (string.IsNullOrWhiteSpace(videoPath)) return;

            var vrEnabledString = VrConfigManager.GetVrConfig(videoPath, "enabled");
            var qualityPresetString = VrConfigManager.GetVrConfig(videoPath, "quality_preset");
            var inputProjection = VrConfigManager.GetVrConfig(videoPath, "projection");
            var inputStereo = VrConfigManager.GetVrConfig(videoPath, "stereo");
            var inputFov = VrConfigManager.GetVrConfig(videoPath, "fov");
            var preferredFlipEye = VrConfigManager.GetVrConfig(videoPath, "flipeye");

            if (SettingsHandler.VrAutoDetectionEnabled && ListHandler.InputIsVideo(videoPath))
            {
                var videoFrame = VrDetection.GetVideoThumbnail(videoPath, maxSize: 300);
                if (videoFrame != null)
                {
                    try
                    {
                        vrDetectionResults = VrDetection.Detect(videoFrame);
                        Error.Log("Detection results for '" + Path.GetFileName(videoPath) + "' : " + vrDetectionResults.ToString(), LogLevel.Debug);
                        foundResults = true;
                    }
                    catch (Exception ex)
                    {
                        Error.Log(ex, "Couldn't generate thumb from video for detection", LogLevel.Warning);
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(vrEnabledString))
            {
                MainFormData.loadedVrStatus = bool.Parse(vrEnabledString);
                if (MainFormData.loadedVrStatus == true)
                {
                    vrController.Enable();
                }
                else
                {
                    vrController.Disable();
                }
                foundConfig = true;
            }
            else if (foundResults)
            {
                if (vrDetectionResults.Layout != VrDetectionLayout.Unknown && vrDetectionResults.Confidence >= SettingsHandler.VrDetectionMinConfidence)
                {
                    MainFormData.vrEnabled = true;
                    vrController.Enable();
                }
                else if (vrDetectionResults.Confidence < SettingsHandler.VrDetectionMinConfidence)
                {
                    MainFormData.vrEnabled = false;
                    vrController.Disable();
                }
            }
            else
            {
                if (MainFormData.vrEnabled)
                {
                    vrController.Enable();
                }
                else
                {
                    vrController.Disable();
                }
            }

            if (!string.IsNullOrWhiteSpace(qualityPresetString))
            {
                var quality = (VrRenderQuality)Enum.Parse(typeof(VrRenderQuality), qualityPresetString);
                vrController.RenderQuality = quality;
            }
            else
            {
                vrController.RenderQuality = SettingsHandler.VrQualityPreset; //Default value
            }

            if (VrInputProjectionExtension.TryFromMpvValue(inputProjection, out var projection))
            {
                vrController.InputProjection = projection;
                foundConfig = true;
            }
            else
            {
                vrController.InputProjection = VrInputProjection.HalfEquirectangular; //Default value
            }
            if (VrInputFovExtension.TryFromMpvValue(inputFov, out var fov))
            {
                vrController.InputFov = fov;
                foundConfig = true;
            }
            else
            {
                vrController.InputFov = VrInputFov.Fov180; //Default value
            }
            if (VrInputStereoExtension.TryFromMpvValue(inputStereo, out var stereo))
            {
                vrController.InputStereo = stereo;
                foundConfig = true;
            }
            else if (foundResults)
            {
                if (vrDetectionResults.Layout == VrDetectionLayout.SideBySide && vrDetectionResults.Confidence >= SettingsHandler.VrDetectionMinConfidence)
                {
                    vrController.InputStereo = VrInputStereo.SideBySide;
                    detectionSuccess = true;
                }
                else if (vrDetectionResults.Layout == VrDetectionLayout.TopBottom && vrDetectionResults.Confidence >= SettingsHandler.VrDetectionMinConfidence)
                {
                    //Seems to be most likely settings for TB
                    vrController.InputStereo = VrInputStereo.TopBottom;
                    vrController.InputProjection = VrInputProjection.Equirectangular;
                    vrController.InputFov = VrInputFov.Fov360;
                    detectionSuccess = true;
                }
            }
            else
            {
                vrController.InputStereo = VrInputStereo.SideBySide; //Default value
            }
            if (!string.IsNullOrWhiteSpace(preferredFlipEye))
            {
                vrController.FlipEye = bool.Parse(preferredFlipEye);
            }
            else
            {
                vrController.FlipEye = false;
            }

            if (foundConfig)
            {
                playerMPV.ShowText("VR settings loaded");
            }
            else if (SettingsHandler.VrAutoDetectionDebugerEnabled && SettingsHandler.VrAutoDetectionEnabled)
            {
                string resultMsg =
                    $"Detection results: \n" +
                    $"Scoring: SBS-{vrDetectionResults.SbsScore:0.000} | TB-{vrDetectionResults.TopBottomScore:0.000}\n" +
                    $"Tendency: {vrDetectionResults.Layout}\n" +
                    $"VR propability:{vrDetectionResults.Confidence:0.0}%\n";
                if (detectionSuccess)
                {
                    resultMsg += $"Auto-detected VR mode: {vrController.InputStereo.ToDisplayName()}";
                }
                else
                {
                    resultMsg += $"Failed to detect VR mode because confidence was lower than {SettingsHandler.VrDetectionMinConfidence:0.0}%";
                }
                playerMPV.ShowText(resultMsg, 5000);
            }
            else if (detectionSuccess)
            {
                playerMPV.ShowText($"Detected VR : {vrController.InputStereo.ToDisplayName()}");
            }
            ApplyPreviewVrEyeCrop(vrController.InputStereo);
            vrController.ApplyVrQualityPreset(panelPlayerMPV);
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
                Error.Log(ex, "Couldn't get or create folder to delete files to", LogLevel.Error);
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
                    Error.Log(ex, $"Error deleting file", LogLevel.Error);
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
                    Error.Log(ex, $"Error deleting file with action moving instead of deleting", LogLevel.Error);
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
                Error.Log(ex, "Couldn't get or create folder to copy/move files to", LogLevel.Error);
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
                    Error.Log(ex, "Couldn't copy file to destination", LogLevel.Error);
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
                    Error.Log(ex, "Couldn't move file to destination", LogLevel.Error);
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
                    Error.Log(ex, "Error starting application by file", LogLevel.Error);
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
                    Error.Log(ex, "Failed to create list folder", LogLevel.Error);
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
                Error.Log(ex, "Failed to read Favorites.txt", LogLevel.Error);
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
            playerMPV.MediaStartedSeeking += new EventHandler(PlayerSeeked);
            //playerMPV.VideoWidthChanged += new EventHandler<MpvPlayerVideoWidthChangedEventArgs>(ApplyRTXFeatures);

        }

        private void InitializePlayer()
        {
            int initVolume = SettingsHandler.VolumeMember ? SettingsHandler.VolumeLastValue : 50;

            pbVolume.Value = initVolume;
            string libMpv = MainFormData.startupPath + "lib\\libmpv-2.dll";
            playerMPV = new MpvPlayer(panelPlayerMPV.Handle, libMpv) { Loop = SettingsHandler.LoopEnabled, Volume = initVolume, KeepOpen = KeepOpen.Yes };

            AudioNormalizer.TuneNormalizer();
            AudioNormalizer.ToggleNormalizer(playerMPV);

            vrController = new VrController(playerMPV);
        }
        #endregion

        #region Player Events
        private void MediaFinished(object sender, EventArgs e)
        {
            try
            {
                if (playerMPV.IsMediaLoaded && !SettingsHandler.LoopEnabled && !MainFormData.playingSingleFile)
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

        private void PlayerSeeked(object sender, EventArgs e)
        {
            if (SettingsHandler.TimerResetOnSeek)
            {
                timerAutoPlayNext.Interval = SettingsHandler.AutoPlayTimerValueStartPoint() * 1000;
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

                if (ListHandler.InputIsImage(updatedCurrentFile))
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

                LoadPreferredVrSetup();
                UpdateVrConfig();
                vrController.ResetView();
            }
            else
            {
                pbPlayerProgress.DeleteActionsPoints();
                return;
            }
            pbPlayerProgress.DeleteActionsPoints();
            UpdateFunscriptGraph();


            //Skip Function
            if (SettingsHandler.EnableAutoSkip)
            {
                var durationSeconds = MainFormData.durationMS / 1000;
                var isShortVideo = false;

                if (SettingsHandler.RandomVideoStartPointIgnoreShortVideos && (durationSeconds <= SettingsHandler.RandomVideoStartPointShortVideoThreshold))
                {
                    isShortVideo = true;
                }

                var nextActionToSkipTo = pbPlayerProgress.DetectGap(0, 5000);
                var maxRange = (durationSeconds * SettingsHandler.StartPointRangeEnd / 100);
                var random = new Random();

                if (nextActionToSkipTo > 0 && SettingsHandler.EnableRandomVideoStartPoint && !SettingsHandler.RandomVideoStartPointIgnoreScripts && !isShortVideo)
                {
                    var startRange = (int)(nextActionToSkipTo / 1000);

                    var randomStartPoint = random.Next(startRange, maxRange);

                    playerMPV.SeekAsync(randomStartPoint);
                }
                else if (nextActionToSkipTo > 0 && SettingsHandler.SkipVideoStart)
                {
                    playerMPV.ShowText("Skipping to next action");
                    playerMPV.SeekAsync(nextActionToSkipTo / 1000);
                }
                else if (SettingsHandler.EnableRandomVideoStartPoint && !(SettingsHandler.RandomVideoStartPointIgnoreScripts && pbPlayerProgress.HasActionPoints) && !isShortVideo)
                {
                    var startRange = SettingsHandler.StartPointRangeStart > 0 ? (durationSeconds * SettingsHandler.StartPointRangeStart / 100) : 0;

                    var randomStartPoint = random.Next(startRange, maxRange);

                    playerMPV.SeekAsync(randomStartPoint);
                }
                playerMPV.SetBrightness(0);
                playerMPV.Resume();
            }

            if (SettingsHandler.RTXVSREnabled)
            {
                Thread.Sleep(100);
                ApplyRTXFeatures();
            }
            else
            {
                playerMPV.API.Command("vf", "remove", "@format-nv12");
                playerMPV.API.Command("vf", "remove", "@vsr");
            }
            thumbMPV.Load(MainFormData.currentFile, true);
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
                    Error.Log(ex, "ScriptPlayer seek command failed", LogLevel.Warning);
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
                Error.Log(ex, "Failed to create or delete temporary funscript file", LogLevel.Error);
            }


        }
        #endregion

        #region Player Progressbar related

        private Label timeOverlayLabel = new();
        private Panel previewPanel = new();
        private Panel thumbPanelContainer = new();

        private TimeSpan _lastPreviewPosition = TimeSpan.FromSeconds(0);
        private readonly TimeSpan _previewInterval = TimeSpan.FromMilliseconds(20);
        private bool _progressDragging = false;
        private int _lastProgressValue = 0;
        private int _newSeekValue = 0;
        private void pbPlayerProgress_MouseDown(object sender, MouseEventArgs e) //Jump to video position based on cursor position on progress bar
        {
            _progressDragging = true;
            try
            {
                if (playerMPV.IsMediaLoaded)
                {
                    pbPlayerProgress.Capture = true;

                    var newValue = (int)((float)e.X / pbPlayerProgress.Width * pbPlayerProgress.Maximum);
                    _lastProgressValue = newValue;

                    pbPlayerProgress.Value = newValue;
                    _newSeekValue = newValue;
                    playerMPV.SeekAsync(newValue / 1000, false);
                    pbPlayerProgress.Refresh();
                }
            }
            catch (Exception) { return; } //Player is busy
        }

        private async void pbPlayerProgress_MouseMove(object sender, MouseEventArgs e) //Set Tooltip with video position on cursor position
        {
            if (MainFormData.durationMS <= 0) return;

            var clampedX = Math.Clamp(e.X, 0, pbPlayerProgress.Width);
            var fraction = (double)clampedX / pbPlayerProgress.Width;
            var hoverMs = (int)(fraction * MainFormData.durationMS);
            var hoverTime = TimeSpan.FromMilliseconds(hoverMs);

            timeOverlayLabel.Text = hoverTime.ToString(@"hh\:mm\:ss");
            PositionOverlayLabel(e.Location);

            if (_progressDragging)
            {
                pbPlayerProgress.Value = hoverMs;
                _newSeekValue = hoverMs;
                timerAutoPlayNext.Stop();
                try
                {
                    playerMPV.Pause();
                    playerMPV.SeekAsync(hoverMs / 1000);
                }
                catch (Exception) { } //Player is busy
                _lastProgressValue = _newSeekValue;
                _mouseMoveSeekTimer.Start();
                pbPlayerProgress.Refresh();
            }

            if (hoverTime - _lastPreviewPosition < _previewInterval && hoverTime >= _lastPreviewPosition)
                return;

            _lastPreviewPosition = hoverTime;

            if (SettingsHandler.PreviewSeekBarEnabled == false)
                return;

            PositionPreviewPanel(e.Location);

            try
            {
                if (thumbMPV.IsMediaLoaded)
                {
                    thumbMPV.API.Command("seek", (hoverMs / 1000.0).ToString(CultureInfo.InvariantCulture), "absolute+keyframes");
                    thumbMPV.Pause();
                }
            }
            catch (Exception) { } //Player is busy
        }
        private void pbPlayerProgress_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_progressDragging) return;
            _progressDragging = false;
            if (SettingsHandler.TimerEnabled) timerAutoPlayNext.Start();

            pbPlayerProgress.Capture = false;
            try
            {
                if (playerMPV.IsMediaLoaded)
                {
                    if (_lastProgressValue == _newSeekValue)
                    {
                        _lastProgressValue = 0;
                        return;
                    }
                    playerMPV.SeekAsync(_newSeekValue / 1000, false);
                    pbPlayerProgress.Refresh();
                }
            }
            catch (Exception) { return; } //Player is busy
        }
        private void pbPlayerProgress_MouseLeave(object sender, EventArgs e)
        {
            previewPanel.Visible = false;
            timeOverlayLabel.Visible = false;
        }
        private void PositionPreviewPanel(Point mouseLocation)
        {
            Point cursorOnForm = this.PointToClient(pbPlayerProgress.PointToScreen(mouseLocation));

            int progressLeft = panelBottom.Location.X;
            int progressRight = progressLeft + pbPlayerProgress.Width;

            int targetX = cursorOnForm.X - (previewPanel.Width / 2) + pbPlayerProgress.Location.X;
            targetX = Math.Max(targetX, progressLeft);
            targetX = Math.Min(targetX, progressRight - previewPanel.Width);

            int gap = 8;
            int targetY = this.Height - (panelBottom.Height + previewPanel.Height + timeOverlayLabel.Height + gap);

            previewPanel.Location = new Point(targetX, targetY);
            previewPanel.Visible = true;
            timeOverlayLabel.Refresh();
        }
        private void PositionOverlayLabel(Point mouseLocation)
        {
            Point cursorOnForm = this.PointToClient(pbPlayerProgress.PointToScreen(mouseLocation));

            int progressLeft = panelBottom.Location.X;
            int progressRight = progressLeft + pbPlayerProgress.Width;

            int targetX = cursorOnForm.X - (timeOverlayLabel.Width / 2) + pbPlayerProgress.Location.X;
            targetX = Math.Max(targetX, progressLeft);
            targetX = Math.Min(targetX, progressRight - timeOverlayLabel.Width);

            int gap = 8;
            int targetY = this.Height - (panelBottom.Height + timeOverlayLabel.Height + gap);

            timeOverlayLabel.Location = new Point(targetX, targetY);
            timeOverlayLabel.AutoSize = !SettingsHandler.PreviewSeekBarEnabled;
            timeOverlayLabel.Visible = true;
            timeOverlayLabel.Refresh();
        }

        private void InitializeTimeOverlay()
        {
            timeOverlayLabel.AutoSize = !SettingsHandler.PreviewSeekBarEnabled;
            timeOverlayLabel.Visible = false;
            timeOverlayLabel.Size = new Size(230, 18);
            timeOverlayLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeOverlayLabel.Padding = new Padding(0, 0, 0, 1);
            timeOverlayLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            this.Controls.Add(timeOverlayLabel);
            timeOverlayLabel.BringToFront();
        }
        private void InitializePreviewPanel()
        {
            previewPanel.Size = new Size(230, 129);
            previewPanel.Visible = false;
            this.Controls.Add(previewPanel);
            previewPanel.BringToFront();

            previewPanel.Controls.Add(thumbPanelContainer);
            thumbPanelContainer.Size = new Size(224, 126);
            thumbPanelContainer.BackColor = Color.Black;
            thumbPanelContainer.Location = new Point(3, 3);
            thumbPanelContainer.BringToFront();

            string libMpv = MainFormData.startupPath + "lib\\libmpv-2.dll";
            var thumbsize = 224;

            thumbMPV = new MpvPlayer(thumbPanelContainer.Handle, libMpv) { Volume = 0, KeepOpen = KeepOpen.Yes };

            thumbMPV.API.Command("set", "msg-level", "all=no");
            thumbMPV.API.Command("set", "terminal", "no");
            thumbMPV.API.Command("set", "idle", "yes");
            thumbMPV.API.Command("set", "pause", "yes");
            thumbMPV.API.Command("set", "hr-seek", "no");
            thumbMPV.API.Command("set", "hr-seek-framedrop", "yes");
            thumbMPV.API.Command("set", "load-scripts", "no");
            thumbMPV.API.Command("set", "osc", "no");
            thumbMPV.API.Command("set", "ytdl", "no");
            thumbMPV.API.Command("set", "load-stats-overlay", "no");
            thumbMPV.API.Command("set", "load-osd-console", "no");
            thumbMPV.API.Command("set", "load-auto-profiles", "no");
            thumbMPV.API.Command("set", "sub", "no");
            thumbMPV.API.Command("set", "audio", "no");
            thumbMPV.API.Command("set", "demuxer-readahead-secs", "0");
            thumbMPV.API.Command("set", "demuxer-max-bytes", "8MiB");
            thumbMPV.API.Command("set", "demuxer-max-back-bytes", "0");
            thumbMPV.API.Command("set", "sws-scaler", "fast-bilinear");
            thumbMPV.API.Command("set", "hwdec", "auto-safe");
            thumbMPV.API.Command("set", "vf", "");
            thumbMPV.API.Command("set", "scale", "bilinear");
            thumbMPV.API.Command("set", "cscale", "bilinear");
            thumbMPV.API.Command("set", "dscale", "bilinear");
            thumbMPV.API.Command("set", "correct-downscaling", "no");
            thumbMPV.API.Command("set", "sigmoid-upscaling", "no");
            thumbMPV.API.Command("set", "deband", "no");
        }

        private void ApplyPreviewVrEyeCrop(VrInputStereo layout)
        {
            if (layout == VrInputStereo.SideBySide && vrController.Enabled)
            {
                thumbMPV.API.Command("set", "video-zoom", "1.3");
                thumbMPV.API.Command("set", "video-pan-x", "-0.25");
                thumbMPV.API.Command("set", "video-pan-y", "0");
            }
            else if (layout == VrInputStereo.TopBottom && vrController.Enabled)
            {
                thumbMPV.API.Command("set", "video-zoom", "1.3");
                thumbMPV.API.Command("set", "video-pan-x", "0");
                thumbMPV.API.Command("set", "video-pan-y", "-0.25");
            }
            else
            {
                ResetPreviewCrop();
            }
        }

        private void ResetPreviewCrop()
        {
            thumbMPV.API.Command("set", "video-zoom", "0");
            thumbMPV.API.Command("set", "video-pan-x", "0");
            thumbMPV.API.Command("set", "video-pan-y", "0");
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
                case > 70:
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
            var timerHotkey = hkSettings.Hotkeys.FirstOrDefault(h => h.Action == "ToggleTimer");
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
            toolTipUI.SetToolTip(btnRepeat, $"{GetKeyCombination(loopHotkey)} | Toggle video repeat");
            toolTipUI.SetToolTip(btnTimer, $"{GetKeyCombination(timerHotkey)} | Toggle autoplay timer");
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
                    case "ToggleLoop":
                        ToggleLoop();
                        return true;
                    case "ToggleTimer":
                        ToggleTimer();
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
                    case "StatisticsOverlayPage0":
                        playerMPV.API.Command("script-binding", "display-page-0");
                        return true;
                    case "StatisticsOverlayPage1":
                        playerMPV.API.Command("script-binding", "display-page-1");
                        return true;
                    case "StatisticsOverlayPage2":
                        playerMPV.API.Command("script-binding", "display-page-2");
                        return true;
                    case "StatisticsOverlayPage3":
                        playerMPV.API.Command("script-binding", "display-page-3");
                        return true;
                    case "StatisticsOverlayPage4":
                        playerMPV.API.Command("script-binding", "display-page-4");
                        return true;
                    case "StatisticsOverlayPage5":
                        playerMPV.API.Command("script-binding", "display-page-5");
                        return true;
                    case "SeekForward":
                        SeekForward();
                        return true;
                    case "SeekBackward":
                        SeekBackward();
                        return true;
                    case "SeekRandom":
                        SeekRandom();
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
                    case "Toggle_VSR":
                        Toggle_VSR();
                        return true;
                    case "RTX_Status":
                        Show_Status();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Timer
        //Init mouse idle to hide cursor when in exclusive fullscreen mode
        private Timer _activityTimer = new();
        //Timer to check for single mouse click 
        private Stopwatch _stopwatch = new();

        private Timer _checkwatch = new();
        private Timer _panelResizeEnd = new();

        private System.Timers.Timer _mouseMoveSeekTimer = new();

        System.Timers.Timer timerAutoPlayNext = new();

        private System.Timers.Timer seekTimer;
        private void InitializeTimers()
        {
            _activityTimer.Tick += activityWorker_Tick;
            _activityTimer.Interval = 100;

            _checkwatch.Interval = MainFormData.doubleClickDelay;
            _checkwatch.Tick += Checkwatch_Tick;

            timerAutoPlayNext.Interval = SettingsHandler.AutoPlayTimerValueStartPoint() * 1000;
            timerAutoPlayNext.Elapsed += timerAutoPlayNext_Tick;

            seekTimer = new System.Timers.Timer(MainFormData.seekTimerDelay);
            seekTimer.AutoReset = false;
            seekTimer.Elapsed += SeekTimer_Elapsed;

            _panelResizeEnd.Interval = 100;
            _panelResizeEnd.Tick += PanelResizeEnd_Tick;

            _mouseMoveSeekTimer.Elapsed += _mouseMoveSeekTimer_Tick;
            _mouseMoveSeekTimer.AutoReset = false;
            _mouseMoveSeekTimer.Interval = 200;
        }

        private void PanelResizeEnd_Tick(object? sender, EventArgs e)
        {
            _panelResizeEnd.Stop();

            if (vrController.Enabled)
            {
                vrController.ApplyVrQualityPreset(panelPlayerMPV);
                vrController.Update();
            }
        }

        private void _mouseMoveSeekTimer_Tick(object? sender, EventArgs e)
        {
            if (!playerMPV.IsMediaLoaded) return;

            try
            {
                playerMPV.Resume();
            }
            catch (Exception) { return; } //player ist busy
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
                bool canUpdateProgress = playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && SettingsHandler.VideoDuration > 0 &&
                    (SettingsHandler.InitPlay || MainFormData.playingSingleFile);

                if (canUpdateProgress)
                {
                    int positionMS = (int)playerMPV.Position.TotalMilliseconds;
                    int remainingS = (int)playerMPV.Remaining.TotalSeconds;

                    SettingsHandler.VideoRemaining = remainingS;

                    if (!MainFormData.progressBufferActive && !_progressDragging)
                    {
                        pbPlayerProgress.Value = positionMS;
                    }

                    TimeSpan totalSpan = TimeSpan.FromMilliseconds(MainFormData.durationMS);
                    TimeSpan currentSpan = TimeSpan.FromMilliseconds(positionMS);
                    lblDurationInfo.Text = $"{currentSpan:hh\\:mm\\:ss} / {totalSpan:hh\\:mm\\:ss}";

                    tcServer.Position = positionMS.ToString();
                    pbPlayerProgress.Refresh();
                }
                else if (playerMPV.IsMediaLoaded && !playerMPV.IsPausedForCache && SettingsHandler.InitPlay && SettingsHandler.VideoDuration == 0)
                {
                    lblDurationInfo.Text = "00:00:00 / 00:00:00";
                }
            }
            catch (Exception)
            {
                return;
            }
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
                Error.Log(ex, "Unable to gather directory information in LB", LogLevel.Error);
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
                Error.Log(ex, "Error checking for updates", LogLevel.Error);
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

                var versionHistory = await UpdateFunctions.GetVersionHistory(MainFormData.VersionHistoryUrl);

                return new Version(versionHistory.Last().Key);
            }
        }
        #endregion

        #region RTX
        private bool autoVSR = false;

        private void Toggle_VSR()
        {
            SettingsHandler.RTXVSREnabled = !SettingsHandler.RTXVSREnabled;
            autoVSR = SettingsHandler.RTXVSREnabled;

            if (autoVSR)
            {
                //ApplyRTXFeatures();
                playerMPV.ShowText($"RTX VSR ON");
            }
            else
            {
                //playerMPV.API.Command("vf", "remove", "@format-nv12");
                //playerMPV.API.Command("vf", "remove", "@vsr");
                try
                {
                    playerMPV.FilterCommand("@format-nv12", MpvPlayer.FilterType.vf, MpvPlayer.ListOptions.remove);
                    playerMPV.FilterCommand("@vsr", MpvPlayer.FilterType.vf, MpvPlayer.ListOptions.remove);
                }
                catch (Exception)
                {

                }
                playerMPV.ShowText($"RTX VSR OFF");
            }
        }

        private void Show_Status()
        {
            var vsr_status = autoVSR ? "ON" : "OFF";
            //var hdr_status = autoHDR ? "ON" : "OFF";
            var vf_chain = playerMPV.API.GetPropertyString("vf");
            var output_csp = playerMPV.API.GetPropertyString("d3d11-output-csp");
            var vo = playerMPV.API.GetPropertyString("vo");
            var gpu_api = playerMPV.API.GetPropertyString("gpu-api");
            var hwdec = playerMPV.API.GetPropertyString("hwdec-current");

            var active_filters = "";

            if (vf_chain.Contains("scaling-mode=nvidia"))
            {
                active_filters += "VSR ";
            }
            //if (vf_chain.Contains("nvidia-true-hdr"))
            //{
            //    active_filters += "RTX-HDR ";
            //}
            if (string.IsNullOrWhiteSpace(active_filters))
            {
                active_filters = "None";
            }

            //var primaries = playerMPV.API.GetPropertyString("video-params/primaries");
            //var gamma = playerMPV.API.GetPropertyString("video-params/gamma");
            //var content_type = "SDR";
            //if (primaries == "bt.2020" || gamma == "pq" || gamma == "hlg")
            //{
            //    content_type = "HDR";
            //}

            var video_width = playerMPV.API.GetPropertyDouble("width");
            var video_height = playerMPV.API.GetPropertyDouble("height");
            var display_width = playerMPV.API.GetPropertyDouble("display-width");
            var display_height = playerMPV.API.GetPropertyDouble("display-height");
            var scale = 1d;

            if (video_width > 0 && video_height > 0)
            {
                scale = Math.Max(display_width / video_width, display_height / video_height);
                scale = Math.Ceiling(scale * 10) / 10;
            }
            var peak = playerMPV.API.GetPropertyString("video-params/sig-peak");
            var avg_luma = playerMPV.API.GetPropertyString("video-params/light");

            //var statusMsg = 
            //    $"RTX Status:\n" +
            //    $"VSR: {vsr_status} (scale: {scale}x)\n" +
            //    $"RTX HDR: {hdr_status}\n" +
            //    $"Active: {active_filters}\n" +
            //    $"Output CSP: {output_csp}\n" +
            //    $"VO: {vo} / API: {gpu_api} / HWDec: {hwdec}\n" +
            //    $"Filter chain: {(vf_chain = string.IsNullOrWhiteSpace(vf_chain) ? vf_chain : "none")}\n" +
            //    $"Peak: {peak} / Avg luma: {avg_luma}";
            var statusMsg =
                  $"RTX Status:\n" +
                  $"VSR: {vsr_status} (scale: {scale}x)\n" +
                  $"Active: {active_filters}\n";

            playerMPV.ShowText(statusMsg, 5000);
        }

        private async Task ApplyRTXFeatures()
        {
            if (SettingsHandler.RTXVSREnabled == false)
            {
                try
                {
                    playerMPV.FilterCommand("@format-nv12", MpvPlayer.FilterType.vf, MpvPlayer.ListOptions.remove);
                    playerMPV.FilterCommand("@vsr", MpvPlayer.FilterType.vf, MpvPlayer.ListOptions.remove);
                }
                catch (Exception) { }
                autoVSR = false;
                return;
            }

            double video_width;
            double video_height;
            double display_width;
            double display_height;

            try
            {
                video_width = await MpvRetry.GetPropertyDoubleRetryAsync(playerMPV, "width");
                video_height = await MpvRetry.GetPropertyDoubleRetryAsync(playerMPV, "height");
                display_width = await MpvRetry.GetPropertyDoubleRetryAsync(playerMPV, "display-width");
                display_height = await MpvRetry.GetPropertyDoubleRetryAsync(playerMPV, "display-height");

                bool HasMissingDouble(double value) => double.IsNaN(value) || double.IsInfinity(value) || value <= 0;
                if (HasMissingDouble(video_width) || HasMissingDouble(video_height) || HasMissingDouble(display_width) || HasMissingDouble(display_height))
                {
                    Error.Log("Missing video properties for RTX", LogLevel.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Error retrieving video properties for RTX", LogLevel.Warning);
                return;
            }

            var scale = Math.Max(display_width / video_width, display_height / video_height);

            var vf_chain = playerMPV.API.GetPropertyString("vf");
            if (vf_chain.Contains("@format-nv12"))
            {
                playerMPV.FilterCommand("@format-nv12", MpvPlayer.FilterType.vf, MpvPlayer.ListOptions.remove);
            }
            if (vf_chain.Contains("@vsr"))
            {
                playerMPV.FilterCommand("@vsr", MpvPlayer.FilterType.vf, MpvPlayer.ListOptions.remove);
            }

            if (scale > 1)
            {
                try
                {
                    playerMPV.FilterCommand("@vsr:d3d11vpp=scaling-mode=nvidia:scale=" + scale.ToString("0.0", CultureInfo.InvariantCulture), MpvPlayer.FilterType.vf, MpvPlayer.ListOptions.add);
                    autoVSR = true;
                }
                catch (Exception ex)
                {
                    var videoFile = PathAnonymizer.AnonymizeFilePath(MainFormData.currentFile);

                    Error.Log(ex, $"Current file: {videoFile}\n" +
                                    $"Videosize: {video_width}x{video_height}\n" +
                                    $"Displaysize: {display_width}x{display_height}\n" +
                                    $"Scale: {scale}\n", LogLevel.Error);
                }

            }
        }
        //HDR still not working
        private bool autoHDR = true;
        private void ApplyRTXFeaturesOld()
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
                Error.Log("Missing video properties for RTX", LogLevel.Warning);
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

            var statusMsg = "";

            if (isSDR && autoHDR)
            {
                playerMPV.API.Command("set", "d3d11-output-csp", "pq");
                playerMPV.API.Command("set", "d3d11-output-format", "rgb10_a2");
                playerMPV.API.Command("set", "target-trc", "pq");
                playerMPV.API.Command("set", "target-prim", "bt.2020");
            }

            if ((scale > 1.0 && autoVSR) && (autoHDR && isSDR))
            {
                string combined = "@rtx-combined:d3d11vpp=scaling-mode=nvidia:scale=" + scale.ToString("0.0", CultureInfo.InvariantCulture) + ":format=nv12:nvidia-true-hdr";

                playerMPV.API.Command("vf", "append", combined);
                statusMsg = $"VSR ('{scale}'x) + RTX HDR";
            }
            else if (scale > 1.0 && autoVSR)
            {
                playerMPV.API.Command("vf", "append", "@rtx-vsr:d3d11vpp=scaling-mode=nvidia:scale=" + scale.ToString("0.0", CultureInfo.InvariantCulture));
                statusMsg = $"VSR ('{scale}'x)";
            }
            else if (autoHDR && isSDR)
            {
                playerMPV.API.Command("vf", "append", "@rtx-hdr:d3d11vpp=format=nv12:nvidia-true-hdr");
                statusMsg = $"RTX HDR";
            }

            if (!string.IsNullOrWhiteSpace(statusMsg))
            {
                playerMPV.ShowText($"{statusMsg} ON");
            }
        }
        #endregion

        #region Logic for standard WindowsForms Controls

        private void InitializeFormFunctions()
        {
            if (fR.SaveLastSizeMain == true)
            {
                fR.FormSizeSaved = new Size(fR.FormSizeSaved.Width - 16, fR.FormSizeSaved.Height - 39);
                this.ClientSize = DPI.GetSizeScaled(fR.FormSizeSaved);
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
                fR.TempSizeMain = this.Size; // DPI.GetSizeScaled(this.Size);
                fR.FormSizeSaved = fR.TempSizeMain;
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            //if (vrController.Enabled)
            //{
            //    vrController.ApplyVrQualityPreset(panelPlayerMPV);
            //    vrController.Update();
            //}
        }

        private void panelPlayerMPV_SizeChanged(object sender, EventArgs e)
        {
            _panelResizeEnd.Stop();
            _panelResizeEnd.Start();
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
            fR.FormSizeSaved = DPI.RevertSize(fR.TempSizeMain); //Save last known form size to property
            PathHandler.TempRecentFolder = string.Empty;

            if (SettingsHandler.VolumeMember)
                SettingsHandler.VolumeLastValue = pbVolume.Value;
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