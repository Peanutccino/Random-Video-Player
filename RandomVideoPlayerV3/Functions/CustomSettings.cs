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
        public int recentCountSaved { get; set; } = 50;
        public bool includeSubfolders { get; set; } = true;
        public string tempLastFolder { get; set; }
        public bool sortCreationDate { get; set; } = true;
        public bool playVideos { get; set; } = true;
        public bool playImages { get; set; } = false;
        public bool shuffle { get; set; } = true;
        public bool loopPlayer { get; set; } = true;
        public bool timeCodeServer { get; set; } = false;
        public StringCollection favoriteCollection { get; set; } = new StringCollection();
        public StringCollection customListConfig { get; set; } = new StringCollection();

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
