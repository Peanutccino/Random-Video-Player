﻿using RandomVideoPlayer.Functions;

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


        /// <value>Loop currently played media (true) or play next media in list(false).</value> 
        public static bool LoopPlayer
        {
            get 
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.loopPlayer; 
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.loopPlayer = value;
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
        public static string ViewStateFileExplore
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.viewStateFileExplore;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.viewStateFileExplore = value;
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
    }
}
