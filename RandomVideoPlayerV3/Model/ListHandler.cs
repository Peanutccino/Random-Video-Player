using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer.Model
{
    public class ListHandler
    {
        private static int _playListIndex = 0;
        private static bool _needsToPrepare = true;
        private static bool _firstPlay = true;

        private static IEnumerable<string> _folderList = Enumerable.Empty<string>();
        private static IEnumerable<string> _playList = Enumerable.Empty<string>();

        private static List<string> _vidExtensions = new List<string> { "avi", "flv", "m4v", "mkv", "mov", "mp4", "webm", "wmv", "f4v", "avchd" };
        private static List<string> _imgExtensions = new List<string> { "jpg", "jpeg", "png", "gif", "tif", "tiff", "bmp", "webp", "avif" };
        /// <value>Tracks playlist position</value> 
        public static int PlayListIndex
        {
            get { return _playListIndex; }
            set { _playListIndex = value; }
        }
        /// <value>Used to update/shuffle the playlist, when we change sources</value> 
        public static bool NeedsToPrepare
        {
            get { return _needsToPrepare; }
            set { _needsToPrepare = value; }
        }
        /// <value>Check if we are at the playlists entry point</value> 
        public static bool FirstPlay
        {
            get { return _firstPlay; }
            set { _firstPlay = value; }
        }
        /// <value>Search for all directories and sub directories (true) or use only the current directory (false).</value> 
        public static bool IncludeSubfolders
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.includeSubfolders;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.includeSubfolders = value;
                _settingsInstance.Save();
            }
        }
        /// <value>Do shuffle (true) or play in parsing order (false)</value> 
        public static bool DoShuffle
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.shuffle;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.shuffle = value;
                _settingsInstance.Save();
            }
        }
        /// <value>Holds shuffled playlist of the media files to play</value> 
        public static IEnumerable<string> PlayList
        {
            get { return _playList; }
            set { _playList = value; }
        }

        /// <value>Used to store all found media files from a user defined folder</value> 
        public static IEnumerable<string> FolderList
        {
            get { return _folderList; }
            set { _folderList = value; }
        }
        /// <value>Used to store all media files fomr a user defined list</value> 
        public static IEnumerable<string> CustomList
        {
            get 
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.customListConfig.Cast<string>(); 
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.customListConfig.Clear();
                _settingsInstance.customListConfig.AddRange(value.ToArray());
                _settingsInstance.Save();
            }
        }
        /// <value>Stores added favorite folders for easier file browser navigation</value> 
        public static IEnumerable<string> FavoriteFolderList 
        {
            get 
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.favoriteCollection.Cast<string>(); 
            }
            set 
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.favoriteCollection.Clear();
                _settingsInstance.favoriteCollection.AddRange(value.ToArray());
                _settingsInstance.Save();
            }
        }
        private static List<string> GetExtensions(List<string> videoExtensions, List<string> imageExtensions, bool playVideo, bool playImage)
        {
            var combinedExtensions = new List<string>();

            if (playVideo)
            {
                combinedExtensions.AddRange(videoExtensions);
            }

            if (playImage)
            {
                combinedExtensions.AddRange(imageExtensions);
            }

            return combinedExtensions;
        }
        /// <value>Holds a defined number of supported file extensions</value> 
        private static List<string> Extensions
        {
            get 
            {
                return GetExtensions(_vidExtensions, _imgExtensions, _playVideos, _playImages);
            }
        }
        public static List<string> ImageExtensions 
        {
            get { return _imgExtensions; }  
        }
        public static List<string> VideoExtensions
        {
            get { return _vidExtensions; }
        }
        private static bool _playVideos
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.playVideos;
            }
        }
        private static bool _playImages
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.playImages;
            }
        }
        /// <value>Shuffles current playlist for random playback</value> 
        public static void PreparePlayList(bool sourceselected)
        {
            if (NeedsToPrepare)
            {                
                if (sourceselected)
                {
                    PlayList = CustomList
                        .Where(file => Extensions.Contains(GetFileExtension(file).ToLowerInvariant()));
                }
                else
                {
                    PlayList = FolderList;
                }

                PlayListIndex = 0;

                if(DoShuffle)
                    shufflePlayList();
                _needsToPrepare = false;
                _firstPlay = true;
            }
        }

        private static string GetFileExtension(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf('.') + 1);
        }
        /// <value>Grab all media files from set directory</value> 
        public static void fillFolderList(string folderpath)
        {
            SearchOption searchOption = IncludeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            try
            {
                FolderList = Directory.EnumerateFiles(folderpath, "*.*", searchOption)
                        .Where(s => Extensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                        .ToArray();
            }
            catch (UnauthorizedAccessException)
            {
                //MessageBox.Show("Access to folder denied. Try running the application as administrator");
            }
        }
        /// <value>Grab only the latest (count) media files from defined directory</value> 
        public static void latestFolderList(string folderpath, int count)
        {
            if (count <= 0) count = 10;

            var _settingsInstance = CustomSettings.Instance;
            SearchOption searchOption = IncludeSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            try
            {
                if(_settingsInstance.sortCreationDate) //Set to sort by creation date
                {
                    FolderList = Directory.EnumerateFiles(folderpath, "*.*", searchOption)
                        .Where(s => Extensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                        .OrderByDescending(s => File.GetCreationTime(s)) // Order by last modified date in descending order
                        .Take(count) // Take only the top 100
                        .ToArray();
                }
                else //Set to sort by date of last modified
                {
                    FolderList = Directory.EnumerateFiles(folderpath, "*.*", searchOption)
                        .Where(s => Extensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                        .OrderByDescending(s => File.GetLastWriteTime(s)) // Order by last modified date in descending order
                        .Take(count) // Take only the top 100
                        .ToArray();
                }
            }
            catch (UnauthorizedAccessException)
            {
                //MessageBox.Show("Access to folder denied. Try running the application as administrator");
            }
        }
        /// <value>Delete current user defined list</value> 
        public static void ClearCustomList()
        {
            var _settingsInstance = CustomSettings.Instance;
            _settingsInstance.customListConfig.Clear();
            _settingsInstance.Save();
        }
        /// <value>Delete List of favorite folders</value> 
        public static void ClearFavoriteFolderList()
        {
            var _settingsInstance = CustomSettings.Instance;
            _settingsInstance.favoriteCollection.Clear();
            _settingsInstance.Save();
        }
        /// <value>Remove media file from stored custom list in case user deleted it</value> 
        public static void DeleteStringFromCustomList(string path)
        {
            var _settingsInstance = CustomSettings.Instance;
            if (_settingsInstance.customListConfig.Contains(path))
            {
                _settingsInstance.customListConfig.Remove(path);
                _settingsInstance.Save();
            }
        }
        /// <value>Randomize Playlist</value> 
        public static void shufflePlayList()
        {
            if(PlayList?.Any() == true)
            {
                var rng = new Random();
                PlayList = rng.Shuffle(PlayList);
            }
        }
    }
}
