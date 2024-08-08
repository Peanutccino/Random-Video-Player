﻿using Newtonsoft.Json;
using System.Collections.Specialized;

namespace RandomVideoPlayer.Functions
{
    public class CustomSettings
    {
        public string defaultFolder { get; set; }
        public Size FormSize { get; set; } = new Size(0, 0);
        public bool lastSize { get; set; } = false;
        public string removeFolder { get; set; } = "";
        public bool deleteFull { get; set; } = true;
        public bool includeScripts { get; set; } = true;
        public string listFolder { get; set; }
        public bool recentCheckedSaved { get; set; } = false;
        public bool recentChecked { get; set; } = false;
        public bool recentCountSaved { get; set; } = true;
        public int recentCount { get; set; } = 50;
        public bool VolumeMember { get; set; } = false;
        public int VolumeLast { get; set; } = 50;

        public bool startupAlwaysAsk { get; set; } = true;
        public bool startupAllDirectories { get; set; } = false;

        public bool includeSubfolders { get; set; } = true;
        public string tempLastFolder { get; set; }
        public bool sortCreationDate { get; set; } = true;
        public bool shuffle { get; set; } = true;
        public bool loopPlayer { get; set; } = true;
        public bool applyFilterToList { get; set; }
        public bool timeCodeServer { get; set; } = false;
        public bool graphEnabled { get; set; } = false;
        public string viewStateListFileExplore { get; set; } = "Tile";
        public string viewStateFolderFileExplore { get; set; } = "Tile";
        public bool showIconsCustomList { get; set; } = false;
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
        public bool[] buttonStates { get; set; } = Enumerable.Repeat(true, 8).ToArray();
        public List<int> buttonOrder { get; set; }
        
        public bool playOnDrop { get; set; } = true;
        public bool alwaysAddFilesToQueue { get; set; } = true;
        public bool includeSubdirectoriesDnD { get; set; } = true;

        public bool leftMousePause { get; set; } = false;


        private static string settingsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RVP-Config.json");

        private static CustomSettings _instance;
        private static readonly object _lock = new object();

        private CustomSettings() 
        {
            buttonOrder = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
        }

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
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(settingsFilePath, json);
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Couldn't save config");
            }
        }
        public static CustomSettings Load()
        {
            try
            {
                if (File.Exists(settingsFilePath))
                {
                    string json = File.ReadAllText(settingsFilePath);
                    var setttings = JsonConvert.DeserializeObject<CustomSettings>(json);

                    if (setttings.buttonOrder == null)
                    {
                        setttings.buttonOrder = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
                    }

                    return setttings;
                }
                
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Couldn't load config");
            }
            return new CustomSettings(); // Return default settings if file does not exist
        }
    }
}
