using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public static class MainFormData
    {
        public static readonly string VersionUrl = "https://raw.githubusercontent.com/Peanutccino/Random-Video-Player/master/version.txt";
        public static readonly string VersionHistoryUrl = "https://raw.githubusercontent.com/Peanutccino/Random-Video-Player/master/version_history.txt";

        public static readonly int doubleClickDelay = 180; //Delay to wait for potential double click otherwise execute single click

        //Safety time to prevent event spamming
        public static DateTime lastPlayCommandTime { get; set; } = DateTime.MinValue;
        public static readonly TimeSpan minimumInterval = TimeSpan.FromMilliseconds(300);

        //Idle duration it takes to hide the cursor in seconds
        public static readonly TimeSpan activityThreshold = TimeSpan.FromSeconds(2); 

        public static string directoryFromStartupFile { get; set; } = "";
        public static string filepathFromStartupFile { get; set; } = "";
        public static string startupPath { get; set; }
        public static bool startedByFile { get; set; } = false;
        public static bool playingSingleFile { get; set; } = false;
        public static string draggedFilePath { get; set; }

        public static int durationMS { get; set; } = 0;
        public static string currentFile { get; set; }
        public static bool favoriteMatch { get; set; } = false;
        public static Size backupSize { get; set; }
        public static bool foundUpdate { get; set; } = false;

        public static bool cursorHidden { get; set; } = false;
        public static bool TouchEnabled { get; set; } = false;

        public static List<string> tempFavorites = new List<string>();
        public static List<Task> ongoingTasks = new List<Task>();
        public static List<string> ongoingFileProcesses = new List<string>();
      
    }
}
