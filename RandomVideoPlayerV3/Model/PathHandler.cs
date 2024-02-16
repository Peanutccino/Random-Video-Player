
namespace RandomVideoPlayerV3.Model
{
    public class PathHandler
    {
		string _fallbackPath = @"C:\"; //Default path if everything else fails
        public string FolderPath { get; set; }

        /// <value>Stores user defined default directory to start from</value> 
        public string DefaultFolder
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
        public string FallbackPath { get { return _fallbackPath; } }
        /// <value>User defined folder where files are moved to when deleted with option "delete full" disabled</value> 
        public string RemoveFolder
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
        /// <value>Used to stores directory where custom lists are saved from and loaded to</value> 
        public string FolderList
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
        public string TempRecentFolder 
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
		/// <summary>
		/// Trim string to length and optionally add string at the end (e.g. "...")
		/// </summary>
		/// <param name="text">String to trim</param>
		/// <param name="length">Trim to length</param>
		/// <param name="end">Add string to end of trimmed string</param>
		/// <returns>Trimmed text</returns>
        public string TrimText(string text, int length, string end)
        {
            int maxLength = length; // Maximum text length.
            string truncatedText = text.Length <= maxLength ? text : text.Substring(0, maxLength) + end;

            return truncatedText;
        }
    }
}
