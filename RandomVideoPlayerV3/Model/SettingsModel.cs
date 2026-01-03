

using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer.Model
{
    public class SettingsModel
    {
        #region Profiles
        public List<string> ProfileList { get; set; } //Dynamic list of profiles
        public string SelectedProfile { get; set; } //Permanent setting
        #endregion

        #region Sync
        public bool IsTimeCodeServerEnabled { get; set; }
        public bool IsGraphEnabled { get; set; }
        public List<string> ScriptDirectories { get; set; }
        public bool ShowScriptPath { get; set; }
        public bool HandleMultiAxisScripts { get; set; }
        public bool UsingScriptPlayer { get; set; }
        public bool IncludeSubdirectoriesForScriptLoad { get; set; }
        #endregion

        #region Skip
        public bool EnableAutoSkip { get; set; }
        public bool SkipVideoStart { get; set; }
        public bool SkipAlways { get; set; }
        public int AutoSkipSeconds { get; set; }
        public bool EnableRandomVideoStartPoint { get; set; }
        public bool RandomVideoStartPointIgnoreScripts { get; set; }
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

        public bool StartupAlwaysAsk { get; set; }
        public bool StartupAllDirectories { get; set; }
        #endregion

        #region Player
        public bool ShufflePlaylist { get; set; }
        public bool ReShuffle { get; set; }
        public bool LeftMousePause { get; set; }
        public AutoPlayMethod AutoPlayMethod { get; set; }
        public int AutoPlayTimerValueStartPoint { get; set; }
        public int AutoPlayTimerValueEndPoint { get; set; }
        public bool AutoPlayTimerRangeEnabled { get; set; }
        public bool RTXVSREnabled { get; set; }
        public bool DarkModeEnabled { get; set; }
        public string SelectedTheme { get; set; }
        #endregion

        #region FilterExtensions    
        public List<string> SelectedExtensions { get; set; }
        public bool FilterImageEnabled { get; set; }
        public bool FilterVideoEnabled { get; set; }
        public bool FilterScriptEnabled { get; set; }
        public bool ApplyFilterToList { get; set; }
        public bool SortCreated { get; set; }
        #endregion

        #region Subtitles
        public bool EnableSubtitles { get; set; }
        public int SubtitleSize { get; set; }
        public int SubtitleBorderSize { get; set; }
        public string SubtitleFontType { get; set; }
        public string SubtitleFontColor { get; set; }
        #endregion

        #region FileMove
        public string FileMovePath { get; set; }
        public bool FileCopy { get; set; }
        #endregion

        #region DragDrop
        public bool PlayOnDrop { get; set; }
        public bool AlwaysAddFilesToQueue { get; set; }
        public bool IncludeSubdirectoriesDnD { get; set; }
        #endregion

        #region Interface
        public bool[] ButtonStates { get; set; }
        public List<int> ButtonOrder { get; set; }
        public bool ShowButtonToPlayFromCurrentFolder { get; set; }
        #endregion

        #region Experimental
        public List<int> SelectedAnimations { get; set; }
        public bool BurnsEffectEnabled { get; set; }
        public bool FadeEffectEnabled { get; set; }
        public double PanAmount { get; set; }
        public double ZoomAmount { get; set; }
        public int ZoomEasingFunction { get; set; }
        public int PanEasingFunction { get; set; }
        public bool EnableCustomScaling { get; set; }
        public float CustomScaling { get; set; }
        #endregion

        #region About
        public bool AlwaysCheckUpdate { get; set; }
        #endregion
    }
}
