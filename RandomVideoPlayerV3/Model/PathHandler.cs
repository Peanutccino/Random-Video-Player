﻿using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer.Model
{
    public class PathHandler
    {
		private static string _fallbackPath = @"C:\"; //Default path if everything else fails
        public static string FolderPath { get; set; }

        /// <value>Stores user defined default directory to start from</value> 
        public static string DefaultFolder
		{
			get 
			{
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.defaultFolder; 
			}
			set 
			{
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.defaultFolder = value;
				_settingsInstance.Save();
			}
		}
        /// <value>Directory that is always available in case everything else fails</value> 
        public static string FallbackPath { get { return _fallbackPath; } }
        /// <value>User defined folder where files are moved to when deleted with option "delete full" disabled</value> 
        public static string RemoveFolder
		{
			get 
			{
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.removeFolder; 
			}
			set 
			{
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.removeFolder = value;
				_settingsInstance.Save();
			}
		}
        /// <value>Used to store directory where custom lists are saved from and loaded to</value> 
        public static string FolderList
		{
			get 
			{
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.listFolder; 
			}
			set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.listFolder = value;
				_settingsInstance.Save();
            }
		}
        /// <value>Stores current position within filebrowser for navigation consisteny; cleared with application exit</value> 
        public static string TempRecentFolder 
		{ 
			get 
			{
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.tempLastFolder; 
			}
			set
			{
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.tempLastFolder = value;
				_settingsInstance.Save();
			}
		}

    }
}
