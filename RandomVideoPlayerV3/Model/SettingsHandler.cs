using RandomVideoPlayer.Functions;
using System.Windows.Navigation;

namespace RandomVideoPlayer.Model
{
    public class SettingsHandler
    {
        public static double CurrentVersion = 1.34;

        private static int _volumeTemp = 50;
        private static bool _sourceSelected = false; //False = Folder | True = List
        private static bool _isPlaying = false;
        private static bool _initPlay = false;
        private static bool _settingChanged = false;
        public static int VolumeTemp
        {
            get { return _volumeTemp; }
            set { _volumeTemp = value; }
        }
        public static int VideoDuration { get; set; }

        public static int VideoRemaining { get; set; }

        /// <value>Play from list (true) or play from folder (false).</value> 
        public static bool SourceSelected
        {
            get { return _sourceSelected; }
            set { _sourceSelected = value; }
        }
        public static bool IsPlaying
        {
            get { return _isPlaying; }
            set { _isPlaying = value; }
        }
        /// <value>Set to true after player is initialized for the first time</value> 
        public static bool InitPlay
        {
            get { return _initPlay; }
            set { _initPlay = value; }
        }

        public static bool SettingChanged
        {
            get { return _settingChanged; }
            set { _settingChanged = value; }
        }


        /// <value>Uses Creation Date (true) or Last Date modified (false).</value> 
        public static bool CreationDate
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.sortCreationDate;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.sortCreationDate = value;
                _settingsInstance.Save();
            }
        }

        /// <value>How many of the latest files should be loaded into the playlist</value> 
        public static int RecentCount
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.recentCount;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.recentCount = value;
                _settingsInstance.Save();
            }
        }
        public static bool RecentCountSaved
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.recentCountSaved;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.recentCountSaved = value;
                _settingsInstance.Save();
            }
        }

        public static int RecentCountSavedTemp { get; set; }
        /// <value>Check if only the latest files should be used</value> 
        public static bool RecentCheckedSaved
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.recentCheckedSaved;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.recentCheckedSaved = value;
                _settingsInstance.Save();
            }
        }
        public static bool RecentChecked
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.recentChecked;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.recentChecked = value;
                _settingsInstance.Save();
            }
        }
        public static bool RecentCheckedTemp { get; set; }
        public static bool TempTriggered { get; set; } = false;

        public static bool VolumeMember
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.VolumeMember;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.VolumeMember = value;
                _settingsInstance.Save();
            }
        }
        public static int VolumeLastValue
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.VolumeLast;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.VolumeLast = value;
                _settingsInstance.Save();
            }
        }
        public static bool StartupAlwaysAsk
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.startupAlwaysAsk;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.startupAlwaysAsk = value;
                _settingsInstance.Save();
            }
        }
        public static bool StartupAllDirectories
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.startupAllDirectories;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.startupAllDirectories = value;
                _settingsInstance.Save();
            }
        }

        /// <value>Delete videofile completely (true) or move it to set folder(false).</value> 
        public static bool DeleteFull
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.deleteFull;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.deleteFull = value;
                _settingsInstance.Save();
            }
        }
        /// <value>Look for associated funscripts and apply delete method.</value> 
        public static bool IncludeScripts
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.includeScripts;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.includeScripts = value;
                _settingsInstance.Save();
            }
        }
        public static bool ApplyFilterToList
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.applyFilterToList;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.applyFilterToList = value;
                _settingsInstance.Save();
            }
        }
        /// <value>Defines whether the timecode server should be started</value> 
        public static bool TimeCodeServer
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.timeCodeServer;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.timeCodeServer = value;
                _settingsInstance.Save();
            }
        }

        public static bool GraphEnabled
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.graphEnabled;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.graphEnabled = value;
                _settingsInstance.Save();
            }
        }

        public static bool ShowIconsCustomLíst
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.showIconsCustomList;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.showIconsCustomList = value;
                _settingsInstance.Save();
            }
        }

        public static bool ShowFullPathCustomList
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.showFullPathCustomList;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.showFullPathCustomList = value;
                _settingsInstance.Save();
            }
        }
        public static string ViewStateListFileExplore
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.viewStateListFileExplore;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.viewStateListFileExplore = value;
                _settingsInstance.Save();
            }
        }

        public static string ViewStateFolderFileExplore
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.viewStateFolderFileExplore;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.viewStateFolderFileExplore = value;
                _settingsInstance.Save();
            }
        }

        public static Size TileSizeFileExplore
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.tileSizeFileExplore;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.tileSizeFileExplore = value;
                _settingsInstance.Save();
            }
        }
        public static Size TileSizeFileBrowser
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.tileSizeFileBrowser;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.tileSizeFileBrowser = value;
                _settingsInstance.Save();
            }
        }
        public static bool FileCopy
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.fileCopy;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.fileCopy = value;
                _settingsInstance.Save();
            }
        }

        public static bool[] ButtonStates
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.buttonStates;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.buttonStates = value;
                _settingsInstance.Save();
            }
        }

        public static bool PlayOnDrop
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.playOnDrop;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.playOnDrop = value;
                _settingsInstance.Save();
            }
        }

        public static bool AlwaysAddFilesToQueue
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.alwaysAddFilesToQueue;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.alwaysAddFilesToQueue = value;
                _settingsInstance.Save();
            }
        }
        public static bool IncludeSubdirectoriesDnD
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.includeSubdirectoriesDnD;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.includeSubdirectoriesDnD = value;
                _settingsInstance.Save();
            }
        }
        public static bool LeftMousePause
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.leftMousePause;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.leftMousePause = value;
                _settingsInstance.Save();
            }
        }

        public static List<int> ButtonOrder
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.buttonOrder;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.buttonOrder = value;
                _settingsInstance.Save();
            }
        }

        public static double PanAmount
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.panAmount;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.panAmount = value;
                _settingsInstance.Save();
            }
        }

        public static double ZoomAmount
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.zoomAmount;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.zoomAmount = value;
                _settingsInstance.Save();
            }
        }

        public static int ZoomEasingFunction
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.zoomEasingFunction;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.zoomEasingFunction = value;
                _settingsInstance.Save();
            }
        }

        public static int PanEasingFunction
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.panEasingFunction;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.panEasingFunction = value;
                _settingsInstance.Save();
            }
        }

        public static bool BurnsEffectEnabled
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.burnsEffectEnabled;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.burnsEffectEnabled = value;
                _settingsInstance.Save();
            }
        }
        public static bool FadeEnabled
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.fadeEnabled;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.fadeEnabled = value;
                _settingsInstance.Save();
            }
        }
        public static List<int> SelectedAnimations
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.selectedAnimations;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.selectedAnimations = value;
                _settingsInstance.Save();
            }
        }
        public static bool AlwaysCheckUpdate
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.alwaysCheckUpdate;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.alwaysCheckUpdate = value;
                _settingsInstance.Save();
            }
        }

        public static AutoPlayMethod AutoPlayMethod
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.autoPlayMethod;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.autoPlayMethod = value;
                _settingsInstance.Save();
            }
        }
        public static int AutoPlayTimerValueStartPoint(bool returnRandom = true)
        {
            var _settingsInstance = CustomSettings.Instance;
            if (SettingsHandler.AutoPlayTimerRangeEnabled == false || returnRandom == false)
            {
                return _settingsInstance.autoPlayTimerValueStartPoint;
            }
            else
            {
                Random rng = new Random();
                return rng.Next(_settingsInstance.autoPlayTimerValueStartPoint, _settingsInstance.autoPlayTimerValueEndPoint + 1);
            }
        }

        public static void SetAutoPlayTimerValueStartPoint(int value)
        {
            var _settingsInstance = CustomSettings.Instance;
            _settingsInstance.autoPlayTimerValueStartPoint = value;
            _settingsInstance.Save();
        }

        public static int AutoPlayTimerValueEndPoint
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.autoPlayTimerValueEndPoint;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.autoPlayTimerValueEndPoint = value;
                _settingsInstance.Save();
            }
        }

        public static bool AutoPlayTimerRangeEnabled
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.autoPlayTimerRangeEnabled;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.autoPlayTimerRangeEnabled = value;
                _settingsInstance.Save();
            }
        }

        public static bool SubtitlesEnabled
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.subtitlesEnabled;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.subtitlesEnabled = value;
                _settingsInstance.Save();
            }
        }

        public static int SubtitleFontSize
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.subtitleFontSize;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.subtitleFontSize = value;
                _settingsInstance.Save();
            }
        }
        public static int SubtitleBorderSize
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.subtitleBorderSize;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.subtitleBorderSize = value;
                _settingsInstance.Save();
            }
        }

        public static string SubtitleFontType
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.subtitleFontName;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.subtitleFontName = value;
                _settingsInstance.Save();
            }
        }

        public static string SubtitleFontColor
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.subtitleFontColor;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.subtitleFontColor = value;
                _settingsInstance.Save();
            }
        }

        public static bool ShowScriptPath
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.showScriptPath;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.showScriptPath = value;
                _settingsInstance.Save();
            }
        }

        public static bool HandleMultiAxisScripts
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.handleMultiAxisScripts;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.handleMultiAxisScripts = value;
                _settingsInstance.Save();
            }
        }

        public static bool UsingScriptPlayer
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.usingScriptPlayer;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.usingScriptPlayer = value;
                _settingsInstance.Save();
            }
        }
    }
}
