using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer.Model
{
	public class SettingsHandler
	{
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
        /// <value>Plays video files (true) or images (false).</value> 
        public static bool PlayVideos
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.playVideos;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.playVideos = value;
                _settingsInstance.Save();
            }
        }
        /// <value>Plays image files (true) or images (false).</value> 
        public static bool PlayImages
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.playImages;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.playImages = value;
                _settingsInstance.Save();
            }
        }

        /// <value>How many of the latest files should be loaded into the playlist</value> 
        public static int RecentCount 
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
        /// <value>Check if only the latest files should be used</value> 
        public static bool RecentChecked
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
    }
}
