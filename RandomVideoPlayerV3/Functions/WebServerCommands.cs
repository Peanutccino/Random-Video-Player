using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RandomVideoPlayer.Functions
{
    public static class WebServerCommands
    {
        public static string ExtractTimeFromCommand(string command)
        {
            var queryParams = HttpUtility.ParseQueryString(command);
            return queryParams["position"];
        }

        public static int ConvertTimeToSeconds(string timeString)
        {
            string decodedTime = HttpUtility.UrlDecode(timeString);

            string[] timeParts = decodedTime.Split(':');
            int hours = int.Parse(timeParts[0]);
            int minutes = int.Parse(timeParts[1]);
            int seconds = int.Parse(timeParts[2]);

            int totalSeconds = (hours * 3600 + minutes * 60 + seconds);
            return totalSeconds;
        }
    }
}
