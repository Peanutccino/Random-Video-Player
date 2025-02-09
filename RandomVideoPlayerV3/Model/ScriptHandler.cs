﻿using RandomVideoPlayer.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public static class ScriptHandler
    {
        public static string CurrentlySelectedScript = "";

        public static List<string> scriptFilesFound = new List<string>();
        private static List<string> multiAxis = new List<string>
        { ".surge", ".sway", ".suck", ".twist", ".roll", ".pitch", ".vib", ".pump", ".raw" };

        private static Dictionary<string, AxisData> multiAxisScriptsFound = new Dictionary<string, AxisData>
        {
            {"Surge",   new AxisData()},
            {"Sway",    new AxisData()},
            {"Suck",    new AxisData()},
            {"Twist",   new AxisData()},
            {"Roll",    new AxisData()},
            {"Pitch",   new AxisData()},
            {"Vib",     new AxisData()},
            {"Pump",    new AxisData()},
            {"Raw",     new AxisData()}
        };
        public static Dictionary<string, AxisData> MultiAxisScriptsFound
        {
            get { return multiAxisScriptsFound; }
            private set { multiAxisScriptsFound = value; }
        }

        public async static Task FillScriptList(string videoPath)
        {
            ResetScriptList();

            string directory = Path.GetDirectoryName(videoPath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(videoPath);
            string scriptFilePath = Path.Combine(directory, fileNameWithoutExtension + ".funscript");

            foreach (var dir in ListHandler.ScriptDirectories)
            {
                if (dir == "local")
                {
                    SearchOption searchOptionLocal = SettingsHandler.IncludeSubdirectoriesForScriptLoad ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

                    var matchingfilesLocal = Directory.GetFiles(directory, "*.funscript", searchOptionLocal)
                        .Where(file => Path.GetFileName(file).StartsWith(fileNameWithoutExtension, StringComparison.OrdinalIgnoreCase))
                        .Where(file => !multiAxis.Any(axis => Path.GetFileNameWithoutExtension(file).ToLower().Contains(axis)))
                        .ToList();

                    foreach (var file in matchingfilesLocal)
                    {
                        scriptFilesFound.Add(file);
                    }

                    foreach (var kvp in MultiAxisScriptsFound)
                    {
                        var multiScriptType = kvp.Key.ToLower();
                        var multiScriptPath = Path.Combine(directory, fileNameWithoutExtension + "." + multiScriptType + ".funscript");

                        if (File.Exists(multiScriptPath))
                        {
                            AddMultiAxisScriptEntry(kvp.Key, multiScriptPath);
                        }
                    }

                    continue;
                }

                if (!Directory.Exists(dir)) continue;


                SearchOption searchOption = SettingsHandler.IncludeSubdirectoriesForScriptLoad ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

                var matchingfiles = Directory.GetFiles(dir, "*.funscript", searchOption)
                    .Where(file => Path.GetFileName(file).StartsWith(fileNameWithoutExtension, StringComparison.OrdinalIgnoreCase))
                    .Where(file => !multiAxis.Any(axis => Path.GetFileNameWithoutExtension(file).ToLower().Contains(axis)))
                    .ToList();


                foreach (var file in matchingfiles)
                {
                    scriptFilesFound.Add(file);
                }

                if (!SettingsHandler.HandleMultiAxisScripts) continue;

                foreach (var kvp in MultiAxisScriptsFound)
                {
                    var multiScriptType = kvp.Key.ToLower();

                    var matchingFiles = Directory.GetFiles(dir, "*.funscript", searchOption)
                        .Where(file => Path.GetFileName(file).StartsWith(fileNameWithoutExtension, StringComparison.OrdinalIgnoreCase) &&
                        Path.GetFileName(file).EndsWith(multiScriptType + ".funscript", StringComparison.OrdinalIgnoreCase))
                        .ToList();


                    foreach (var file in matchingFiles)
                    {
                        AddMultiAxisScriptEntry(kvp.Key, file);
                    }
                }
            }
        }

        private static string tempScriptBackupPath;
        private static string tempScriptLocalPath;
        private static bool backupScriptCreated = false;
        private static bool movedScriptWithoutLocal = false;
        public async static Task LoadScript(int index, string videoFile)
        {
            if (scriptFilesFound.Count <= 0 && index > scriptFilesFound.Count - 1) return;

            var selectedScript = scriptFilesFound[index];
            CurrentlySelectedScript = selectedScript;

            var selectedScriptNameWithoutExt = Path.GetFileNameWithoutExtension(selectedScript);
            var selectedScriptDirectory = Path.GetDirectoryName(selectedScript);

            var videoFileNameWithoutExt = Path.GetFileNameWithoutExtension(videoFile);
            var videoFileDirectory = Path.GetDirectoryName(videoFile);

            if (selectedScriptDirectory == videoFileDirectory && selectedScriptNameWithoutExt == videoFileNameWithoutExt) //selectedScriptDirectory == videoFileDirectory
            {
                return;
            }
            else //if (selectedScriptDirectory != videoFileDirectory)
            {
                var scriptLocalPath = Path.Combine(videoFileDirectory, videoFileNameWithoutExt + ".funscript");
                tempScriptLocalPath = scriptLocalPath;

                await CreateBackupScript(scriptLocalPath, videoFileDirectory, videoFileNameWithoutExt);

                await Task.Run(() => File.Copy(selectedScript, scriptLocalPath, true));

                movedScriptWithoutLocal = backupScriptCreated ? false : true;
            }
        }

        public async static Task LoadMultiAxisScript(int index, string videoFile, string Axis)
        {
            List<string> scripts = new List<string>();
            if (MultiAxisScriptsFound.ContainsKey(Axis))
            {
                scripts = MultiAxisScriptsFound[Axis].ScriptFiles;
            }
            if (scripts.Count <= 0) return;

            var selectedScript = scripts[index];
            var selectedScriptNameWithoutExt = Path.GetFileNameWithoutExtension(selectedScript);
            var selectedScriptDirectory = Path.GetDirectoryName(selectedScript);

            var videoFileNameWithoutExt = Path.GetFileNameWithoutExtension(videoFile);
            var videoFileDirectory = Path.GetDirectoryName(videoFile);

            if (selectedScriptDirectory == videoFileDirectory)
            {
                return;
            }
            else if (selectedScriptDirectory != videoFileDirectory)
            {
                var scriptLocalPath = Path.Combine(videoFileDirectory, videoFileNameWithoutExt + "." + Axis + ".funscript");

                await CreateBackupMultiAxisScript(scriptLocalPath, videoFileDirectory, videoFileNameWithoutExt, Axis);

                await Task.Run(() => File.Copy(selectedScript, scriptLocalPath, true));
            }
        }

        private async static Task CreateBackupScript(string scriptLocal, string videoDir, string videoNameWithoutExt)
        {
            if (File.Exists(scriptLocal))
            {
                tempScriptBackupPath = Path.Combine(videoDir, videoNameWithoutExt + ".backup");
                await Task.Run(() => File.Copy(scriptLocal, tempScriptBackupPath, true));
                backupScriptCreated = true;
            }
            else
            {
                tempScriptBackupPath = "";
                backupScriptCreated = false;
            }
        }

        private async static Task CreateBackupMultiAxisScript(string scriptLocal, string videoDir, string videoNameWithoutExt, string Axis)
        {
            if (File.Exists(scriptLocal))
            {
                var backupPath = Path.Combine(videoDir, videoNameWithoutExt + "." + Axis + ".backup");
                if (MultiAxisScriptsFound.ContainsKey(Axis))
                {
                    MultiAxisScriptsFound[Axis].BackupPath = backupPath;
                    MultiAxisScriptsFound[Axis].LocalPath = scriptLocal;
                }
                await Task.Run(() => File.Copy(scriptLocal, backupPath, true));
                UpdateAxisData(Axis, hasBackup: true, movedWithoutLocal: false);
            }
            else
            {
                if (MultiAxisScriptsFound.ContainsKey(Axis))
                {
                    MultiAxisScriptsFound[Axis].BackupPath = string.Empty;
                    MultiAxisScriptsFound[Axis].LocalPath = scriptLocal;
                }
                UpdateAxisData(Axis, hasBackup: false, movedWithoutLocal: true);
            }
        }

        public async static Task RevertDefaultScript()
        {
            if (backupScriptCreated)
            {
                File.Move(tempScriptBackupPath, tempScriptLocalPath, true);
            }
            else if (movedScriptWithoutLocal)
            {
                File.Delete(tempScriptLocalPath);
            }

            backupScriptCreated = false;
            movedScriptWithoutLocal = false;
        }

        public async static Task RevertDefaultMultiAxisScript()
        {
            foreach (var kvp in MultiAxisScriptsFound)
            {
                if (kvp.Value.HasBackup)
                {
                    File.Move(kvp.Value.BackupPath, kvp.Value.LocalPath, true);
                }
                else if (kvp.Value.MovedWithoutLocal)
                {
                    File.Delete(kvp.Value.LocalPath);
                }

                kvp.Value.BackupPath = string.Empty;
                kvp.Value.LocalPath = string.Empty;
                kvp.Value.MovedWithoutLocal = false;
                kvp.Value.HasBackup = false;
            }

        }

        private static void AddMultiAxisScriptEntry(string axisName, string newScript)
        {
            if (MultiAxisScriptsFound.ContainsKey(axisName))
            {
                MultiAxisScriptsFound[axisName].ScriptFiles.Add(newScript);
            }
        }

        private static void UpdateAxisData(string axisName, bool? hasBackup = null, bool? movedWithoutLocal = null, int? selectedIndex = null)
        {
            if (MultiAxisScriptsFound.ContainsKey(axisName))
            {
                if (hasBackup.HasValue)
                {
                    MultiAxisScriptsFound[axisName].HasBackup = hasBackup.Value;
                }
                if (movedWithoutLocal.HasValue)
                {
                    MultiAxisScriptsFound[axisName].MovedWithoutLocal = movedWithoutLocal.Value;
                }
                if (selectedIndex.HasValue)
                {
                    MultiAxisScriptsFound[axisName].SelectedIndex = selectedIndex.Value;
                }
            }
        }

        private static void ResetScriptList()
        {
            scriptFilesFound.Clear();
            foreach (var kvp in MultiAxisScriptsFound)
            {
                kvp.Value.ScriptFiles.Clear();
                kvp.Value.LocalPath = string.Empty;
                kvp.Value.BackupPath = string.Empty;
                kvp.Value.HasBackup = false;
                kvp.Value.MovedWithoutLocal = false;
            }
        }
    }

    public class AxisData
    {
        public List<String> ScriptFiles;
        public bool HasBackup;
        public bool MovedWithoutLocal;
        public int SelectedIndex;
        public string BackupPath;
        public string LocalPath;

        public AxisData()
        {
            ScriptFiles = new List<string>();
            HasBackup = false;
            MovedWithoutLocal = false;
            SelectedIndex = 0;
            BackupPath = string.Empty;
            LocalPath = string.Empty;
        }
    }
}
