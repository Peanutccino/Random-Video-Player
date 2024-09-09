using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class UpdateFunctions
    {
        public static Dictionary<string, string> GetVersionHistory(string versionUrl)
        {
            var versionHistory = new Dictionary<string, string>();

            try
            {
                using (WebClient client = new WebClient())
                {
                    string versionData = client.DownloadString(versionUrl);
                    var lines = versionData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var line in lines)
                    {
                        var parts = line.Split(' ');
                        if (parts.Length == 2)
                        {
                            versionHistory.Add(parts[0], parts[1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Error fetching version history");
                //UpdateProgress($"Error fetching version history: {ex.Message}");
            }

            return versionHistory;
        }

        public static string CreateBatchScript(string extractPath, List<string> zipPaths)
        {
            string batchScript = $@"
@echo off
echo Waiting for application to exit...
:loop
tasklist /fi ""imagename eq RandomVideoPlayer.exe"" | find /i ""RandomVideoPlayer.exe"" >nul 2>&1
if not errorlevel 1 (
    timeout /t 1 /nobreak >nul
    goto loop
)
echo Copy new files...
timeout /t 2 /nobreak >nul
xcopy /s /e /y ""{extractPath}"" ""{Application.StartupPath}""
echo Delete update files...
rd /s /q ""{extractPath}""
echo Delete download packages...
";
            foreach (var zipPath in zipPaths)
            {
                batchScript += $@"del ""{zipPath}""{Environment.NewLine}";
            }

            batchScript += $@"
echo Restart application...
timeout /t 3 /nobreak >nul
start """" ""{Application.StartupPath}RandomVideoPlayer.exe""
echo All done!
echo Deleting myself...
del ""%~f0"" & exit
";

            return batchScript;
        }
    }
}
