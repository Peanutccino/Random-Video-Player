using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class ScriptConfigManager
    {
        private static string ConfigFilePath = PathHandler.PathToListFolder + @"\PreferredScriptConfig.json";

        public static void SaveVideoConfig(string videoPath, string configType, string configValue)
        {
            if (string.IsNullOrWhiteSpace(videoPath) || string.IsNullOrWhiteSpace(configType) || string.IsNullOrWhiteSpace(configValue)) return;

            List<VideoConfiguration> configs = LoadConfigurations();

            var existingVideoConfig = configs.FirstOrDefault(v =>
                NormalizePath(v.VideoPath) == NormalizePath(videoPath));

            if (existingVideoConfig == null)
            {
                existingVideoConfig = new VideoConfiguration
                {
                    VideoPath = videoPath
                };
                configs.Add(existingVideoConfig);
            }

            existingVideoConfig.Configurations.RemoveAll(c => c.Type == configType);

            existingVideoConfig.Configurations.Add(new VideoConfigItem
            {
                Type = configType,
                Value = configValue
            });

            SaveConfigurations(configs);
        }

        public static string GetVideoConfig(string videoPath, string configType)
        {
            List<VideoConfiguration> configs = LoadConfigurations();

            var videoConfig = configs.FirstOrDefault(v =>
                NormalizePath(v.VideoPath) == NormalizePath(videoPath));

            return videoConfig?.Configurations
                .FirstOrDefault(c => c.Type == configType)?.Value;
        }

        private static List<VideoConfiguration> LoadConfigurations()
        {
            if (!File.Exists(ConfigFilePath))
                return new List<VideoConfiguration>();

            string jsonString = File.ReadAllText(ConfigFilePath);
            return JsonSerializer.Deserialize<List<VideoConfiguration>>(jsonString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<VideoConfiguration>();
        }

        private static void SaveConfigurations(List<VideoConfiguration> configs)
        {
            string jsonString = JsonSerializer.Serialize(configs,
                new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ConfigFilePath, jsonString);
        }

        private static string NormalizePath(string path)
        {
            try
            {
                return Path.GetFullPath(path).ToLowerInvariant();
            }
            catch
            {
                return path?.ToLowerInvariant() ?? string.Empty;
            }
        }
    }

    public class VideoConfiguration
    {
        [JsonPropertyName("videoPath")]
        public string VideoPath { get; set; }

        [JsonPropertyName("configurations")]
        public List<VideoConfigItem> Configurations { get; set; } = new List<VideoConfigItem>();
    }

    public class VideoConfigItem
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
