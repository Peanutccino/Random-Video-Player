using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer.Model
{
    public class ListHandler
    {
        private static int _playListIndex = 0;
        private static bool _needsToPrepare = true;
        private static bool _firstPlay = true;

        private static IEnumerable<string> _folderList = Enumerable.Empty<string>();
        private static IEnumerable<string> _tempfolderList = Enumerable.Empty<string>();
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

        public static bool ReShuffle
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.reShuffle;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.reShuffle = value;
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
        /// <value>Used to store all found media files from a user defined folder</value> 
        public static IEnumerable<string> TempFolderList
        {
            get { return _tempfolderList; }
            set { _tempfolderList = value; }
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
        public static IEnumerable<string> SelectedExtensions
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.selectedExtensions.Cast<string>();
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.selectedExtensions.Clear();
                _settingsInstance.selectedExtensions.AddRange(value.ToArray());
                _settingsInstance.Save();
            }
        }

        public static IEnumerable<string> ScriptDirectories
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                if (_settingsInstance.scriptDirectories.Count <= 0)
                {
                    _settingsInstance.scriptDirectories.Add("local");
                }
                return _settingsInstance.scriptDirectories.Cast<string>().ToList();
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.scriptDirectories.Clear();
                _settingsInstance.scriptDirectories.AddRange(value.ToArray());
                _settingsInstance.Save();
            }
        }
        public static bool FilterImageEnabled
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.filterImageEnabled;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.filterImageEnabled = value;
                _settingsInstance.Save();
            }
        }

        public static bool FilterVideoEnabled
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.filterVideoEnabled;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.filterVideoEnabled = value;
                _settingsInstance.Save();
            }
        }

        public static bool FilterScriptEnabled
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.filterScriptEnabled;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.filterScriptEnabled = value;
                _settingsInstance.Save();
            }
        }

        public static bool ListChanged
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.listChanged;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.listChanged = value;
                _settingsInstance.Save();
            }
        }

        public static string ListNameTemp
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.listNameTemp;
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.listNameTemp = value;
                _settingsInstance.Save();
            }
        }

        public static IEnumerable<string> ExtensionFilterForList
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.extensionFilterForList.Cast<string>();
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.extensionFilterForList.Clear();
                _settingsInstance.extensionFilterForList.AddRange(value.ToArray());
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
        public static IEnumerable<string> FavoriteMoveBackupList
        {
            get
            {
                var _settingsInstance = CustomSettings.Instance;
                return _settingsInstance.favoriteMoveBackupCollection.Cast<string>();
            }
            set
            {
                var _settingsInstance = CustomSettings.Instance;
                _settingsInstance.favoriteMoveBackupCollection.Clear();
                _settingsInstance.favoriteMoveBackupCollection.AddRange(value.ToArray());
                _settingsInstance.Save();
            }
        }
        /// <value>Holds a defined number of supported file extensions</value> 
        public static List<string> Extensions
        {
            get
            {
                if (FilterScriptEnabled)
                {
                    return VideoExtensions;
                }

                List<string> selectedExtensionsFiltered = new List<string>();

                if (FilterVideoEnabled)
                {
                    bool foundVideo = false;

                    foreach (var extension in SelectedExtensions)
                    {
                        if (VideoExtensions.Contains(extension))
                        {
                            selectedExtensionsFiltered.Add(extension);
                            foundVideo = true;
                        }
                    }

                    if (foundVideo == false)
                    {
                        selectedExtensionsFiltered.AddRange(VideoExtensions);
                    }
                }
                if (FilterImageEnabled)
                {
                    bool foundImage = false;

                    foreach (var extension in SelectedExtensions)
                    {
                        if (ImageExtensions.Contains(extension))
                        {
                            selectedExtensionsFiltered.Add(extension);
                            foundImage = true;
                        }
                    }

                    if (foundImage == false)
                    {
                        selectedExtensionsFiltered.AddRange(ImageExtensions);
                    }
                }
                return selectedExtensionsFiltered;
            }
        }
        public static List<string> CombinedExtensions
        {
            get
            {
                var _combined = new List<string>();
                _combined.AddRange(_imgExtensions);
                _combined.AddRange(_vidExtensions);
                return _combined;
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
        /// <value>Shuffles current playlist for random playback</value> 
        public static void PreparePlayList(bool sourceselected, bool startedByFile, string startupFilePath)
        {
            if (NeedsToPrepare)
            {
                if (sourceselected)
                {
                    if (SettingsHandler.ApplyFilterToList)
                    {
                        PlayList = CustomList
                            .Where(file => Extensions.Contains(GetFileExtension(file).ToLowerInvariant()));
                    }
                    else
                    {
                        PlayList = CustomList;
                    }
                }
                else
                {
                    PlayList = FolderList;
                }

                PlayListIndex = 0;

                if (DoShuffle)
                    shufflePlayList(startedByFile, startupFilePath);
                _needsToPrepare = false;
                _firstPlay = true;
            }
        }

        private static string GetFileExtension(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf('.') + 1);
        }
        /// <value>Grab all media files from set directory</value> 
        public static void fillFolderList(string folderpath, bool includeSubfolders)
        {
            try
            {
                _tempfolderList = GetFiles(folderpath, includeSubfolders);

                if (_tempfolderList?.Any() ?? false)
                {
                    _folderList = _tempfolderList;
                }
            }
            catch (Exception ex)
            {
                _folderList = Enumerable.Empty<string>();
                Error.Log(ex, "Couldn't access folder - fillFolderList");
            }
        }
        /// <value>Grab only the latest (count) media files from defined directory</value> 
        public static void latestFolderList(string folderpath, int count, bool includeSubfolders)
        {
            if (count <= 0) count = 10;

            try
            {
                var allFiles = GetFiles(folderpath, includeSubfolders);

                if (SettingsHandler.CreationDate) //Set to sort by creation date
                {
                    _tempfolderList = allFiles
                          .Where(s => Extensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                          .OrderByDescending(s => File.GetCreationTime(s))
                          .Take(count)
                          .ToArray();
                }
                else //Set to sort by date of last modified
                {
                    _tempfolderList = allFiles
                          .Where(s => Extensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()))
                          .OrderByDescending(s => File.GetLastWriteTime(s))
                          .Take(count)
                          .ToArray();
                }
                if (_tempfolderList?.Any() ?? false)
                {
                    _folderList = _tempfolderList;
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Couldn't access folder - latestFolderList");
            }
        }
        private static List<string> multiAxis = new List<string>
        { ".surge", ".sway", ".suck", ".twist", ".roll", ".pitch", ".vib", ".pump", ".raw" };
        public static IEnumerable<string> GetFiles(string folderpath, bool includeSubfolders)
        {
            List<string> files = new List<string>();

            try
            {
                if (FilterScriptEnabled)
                {
                    List<string> foundScripts = Directory.EnumerateFiles(folderpath, "*.funscript")
                        .Where(file => !multiAxis.Any(axis => Path.GetFileNameWithoutExtension(file).ToLower().Contains(axis)))
                        .ToList();

                    if (includeSubfolders)
                    {
                        foreach (var directory in Directory.EnumerateDirectories(folderpath))
                        {
                            foundScripts.AddRange(GetFiles(directory, includeSubfolders));
                        }
                    }

                    foreach(var dir in ListHandler.ScriptDirectories)
                    {
                        if (dir == "local")
                        {
                            continue;
                        }

                        if (!Directory.Exists(dir)) continue;

                        var matchingfiles = Directory.GetFiles(dir, "*.funscript")
                            .Where(file => !multiAxis.Any(axis => Path.GetFileNameWithoutExtension(file).ToLower().Contains(axis)))
                            .ToList();

                        foreach(var subDir in Directory.EnumerateDirectories(dir))
                        {
                            matchingfiles.AddRange(Directory.GetFiles(subDir, "*.funscript")
                                .Where(file => !multiAxis.Any(axis => Path.GetFileNameWithoutExtension(file).ToLower().Contains(axis)))
                                .ToList());
                        }

                        foundScripts.AddRange(matchingfiles);
                    }

                    List<string> filesToCheck = new List<string>();

                    filesToCheck.AddRange(Directory.EnumerateFiles(folderpath)
                        .Where(s => ListHandler.VideoExtensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant())));

                    if (includeSubfolders)
                    {
                        foreach (var directory in Directory.EnumerateDirectories(folderpath))
                        {
                            filesToCheck.AddRange(GetFiles(directory, includeSubfolders));
                        }
                    }

                    foreach (var video in filesToCheck)
                    {
                        if(foundScripts.Any(script => Path.GetFileNameWithoutExtension(script).StartsWith(Path.GetFileNameWithoutExtension(video), StringComparison.OrdinalIgnoreCase)))
                        {
                            if (!files.Contains(video))
                            {
                                if (File.Exists(video))
                                {
                                    files.Add(video);
                                }
                            }
                        }
                    }
                }
                else
                {
                    files.AddRange(Directory.EnumerateFiles(folderpath)
                        .Where(s => Extensions.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant())));

                    if (includeSubfolders)
                    {
                        foreach (var directory in Directory.EnumerateDirectories(folderpath))
                        {
                            files.AddRange(GetFiles(directory, includeSubfolders));
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Error.Log(ex, $"Access denied to folder: {folderpath}");
            }
            catch (Exception ex)
            {
                Error.Log(ex, $"Error accessing folder: {folderpath}");
            }

            return files;
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
        public static void AddStringToCustomList(string path)
        {
            var _settingsInstance = CustomSettings.Instance;
            _settingsInstance.customListConfig.Add(path);
            _settingsInstance.Save();
        }

        public static bool DoesCustomListContainString(string path)
        {
            var _settingsInstance = CustomSettings.Instance;
            if (_settingsInstance.customListConfig.Contains(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <value>Randomize Playlist</value> 
        public static void shufflePlayList(bool preserveFirstFile, string startupFilePath)
        {
            if (_playList?.Any() == false) return;

            var rng = new Random();

            if (preserveFirstFile)
            {
                string firstEntry = startupFilePath;
                List<string> tempPlaylist = _playList.ToList();
                tempPlaylist.Remove(firstEntry);
                List<string> shuffledPlaylist = rng.Shuffle(tempPlaylist).ToList();
                shuffledPlaylist.Insert(0, firstEntry);
                _playList = shuffledPlaylist;

            }
            else
            {
                _playList = rng.Shuffle(_playList);
            }

        }
    }
}
