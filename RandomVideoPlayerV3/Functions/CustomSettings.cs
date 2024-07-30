using Newtonsoft.Json;
using System.Collections.Specialized;

namespace RandomVideoPlayer.Functions
{
    public class CustomSettings
    {
        public string defaultFolder { get; set; }
        public Size FormSize { get; set; } = new Size(0, 0);
        public bool lastSize { get; set; } = false;
        public string removeFolder { get; set; } = @"C:\";
        public bool deleteFull { get; set; } = true;
        public bool includeScripts { get; set; } = true;
        public string listFolder { get; set; }
        public bool recentCheckedSaved { get; set; } = false;
        public bool recentChecked { get; set; } = false;
        public bool recentCountSaved { get; set; } = true;
        public int recentCount { get; set; } = 50;
        public bool VolumeMember { get; set; } = false;
        public int VolumeLast { get; set; } = 50;
        public bool includeSubfolders { get; set; } = true;
        public string tempLastFolder { get; set; }
        public bool sortCreationDate { get; set; } = true;
        public bool shuffle { get; set; } = true;
        public bool loopPlayer { get; set; } = true;
        public bool applyFilterToList { get; set; }
        public bool timeCodeServer { get; set; } = false;
        public bool graphEnabled { get; set; } = true;
        public string viewStateFileExplore { get; set; } = "Tile";
        public bool showIconsCustomList { get; set; } = true;
        public bool showFullPathCustomList { get; set; } = false;
        public Size tileSizeFileExplore { get; set; } = new Size(150, 40);
        public Size tileSizeFileBrowser { get; set; } = new Size(120, 34);
        public StringCollection selectedExtensions { get; set; } = new StringCollection();
        public StringCollection extensionFilterForList { get; set; } = new StringCollection();
        public StringCollection favoriteCollection { get; set; } = new StringCollection();
        public StringCollection favoriteMoveBackupCollection { get; set; } = new StringCollection();
        public StringCollection customListConfig { get; set; } = new StringCollection();
        public string pathToMoveFolder { get; set; } = "";
        public bool fileCopy { get; set; } = true;
        public bool[] buttonStates { get; set; } = Enumerable.Repeat(true, 7).ToArray();
        public bool playOnDrop { get; set; } = true;


        private static string settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RVP-Config.json");

        private static CustomSettings _instance;
        private static readonly object _lock = new object();

        private CustomSettings() { }

        public static CustomSettings Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = Load();
                    }
                    return _instance;
                }
            }
        }
        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(settingsFilePath, json);
        }
        public static CustomSettings Load()
        {
            if (File.Exists(settingsFilePath))
            {
                string json = File.ReadAllText(settingsFilePath);
                return JsonConvert.DeserializeObject<CustomSettings>(json);
            }
            return new CustomSettings(); // Return default settings if file does not exist
        }
    }
}
