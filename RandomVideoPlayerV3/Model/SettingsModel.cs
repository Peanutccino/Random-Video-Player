

namespace RandomVideoPlayer.Model
{
    public class SettingsModel
    {
        #region Sync
        public bool IsTimeCodeServerEnabled { get; set; }
        public bool IsGraphEnabled { get; set; }
        #endregion

        #region Paths
        public string DefaultPathText { get; set; }
        public string RemovalPathText { get; set; }
        public string ListPathText { get; set; }
        public bool DeleteFull { get; set; }
        public bool IncludeScript { get; set; }
        #endregion

        #region Remember
        public bool MemberWindowSize { get; set; }
        public bool MemberPlayRecent { get; set; }
        public bool MemberRecentCount { get; set; }
        public bool MemberVolume { get; set; }
        #endregion

        #region Player
        public bool LoopPlayer { get; set; }
        public bool ShufflePlaylist { get; set; }
        public bool SortCreated { get; set; }
        public bool ApplyFilterToList{ get; set; }
        public List<string> SelectedExtensions { get; set; }
        public bool LeftMousePause { get; set; }
        #endregion

        #region FileMove
        public string FileMovePath { get; set; }
        public bool FileCopy { get; set; }

        #endregion

        #region DragDrop
        public bool PlayOnDrop { get; set; }
        public bool AlwaysAddFilesToQueue { get; set; }
        #endregion

        #region Interface
        public bool[] ButtonStates { get; set; }
        public List<int> ButtonOrder { get; set; }
        #endregion
    }
}
