using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer.Model
{
    public class PathHandler
    {
        public static string FolderPath { get; set; } = "";

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
        public static string PathToListFolder
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
        public static string FileMoveFolderPath
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.pathToMoveFolder;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.pathToMoveFolder = value;
                _settingsInstance.Save();
            }
        }
    }
}
