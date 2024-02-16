using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayerV3.Model
{
	public class SettingsHandler
	{
        private int _volumeTemp = 50;
		private bool _sourceSelected = false; //False = Folder | True = List
		private bool _isPlaying = false;
        private bool _initPlay = false;
        public int VolumeTemp
		{
			get { return _volumeTemp; }
			set { _volumeTemp = value; }
		}
        public int VideoDuration { get; set; }

        public int VideoRemaining { get; set; }

        /// <value>Play from list (true) or play from folder (false).</value> 
        public bool SourceSelected
		{
			get { return _sourceSelected; }
			set { _sourceSelected = value; }
		}
        public bool IsPlaying
		{
			get { return _isPlaying; }
			set { _isPlaying = value; }
		}
        /// <value>Set to true after player is initialized for the first time</value> 
        public bool InitPlay
		{
			get { return _initPlay; }
			set { _initPlay = value; }
		}

        /// <value>Uses Creation Date (true) or Last Date modified (false).</value> 
        public bool CreationDate 
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
        public int RecentCount 
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
        public bool RecentChecked
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
        public bool DeleteFull
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
        /// <value>Loop currently played media (true) or play next media in list(false).</value> 
        public bool LoopPlayer
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
        public bool TimeCodeServer
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
