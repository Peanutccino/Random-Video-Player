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
    public static class VrConfigManager
    {
        public static readonly string ConfigFilePath = PathHandler.PathToListFolder + @"\VrPreferences.json";
        public static void SaveVrConfig(string videoPath, string configType, string configValue)
        {
            if (string.IsNullOrWhiteSpace(videoPath) || string.IsNullOrWhiteSpace(configType) || string.IsNullOrWhiteSpace(configValue)) return;

            List<VrConfiguration> configs = LoadConfigurations();

            var existingVideoConfig = configs.FirstOrDefault(v =>
                NormalizePath(v.VideoPath) == NormalizePath(videoPath));

            if (existingVideoConfig == null)
            {
                existingVideoConfig = new VrConfiguration
                {
                    VideoPath = videoPath
                };
                configs.Add(existingVideoConfig);
            }

            existingVideoConfig.Configurations.RemoveAll(c => c.Type == configType);

            existingVideoConfig.Configurations.Add(new VrConfigItem
            {
                Type = configType,
                Value = configValue
            });

            SaveConfigurations(configs);
        }

        public static string GetVrConfig(string videoPath, string configType)
        {
            List<VrConfiguration> configs = LoadConfigurations();

            var videoConfig = configs.FirstOrDefault(v =>
                NormalizePath(v.VideoPath) == NormalizePath(videoPath));

            return videoConfig?.Configurations
                .FirstOrDefault(c => c.Type == configType)?.Value;
        }
        public static bool RemoveConfiguration(string videoPath)
        {
            if (string.IsNullOrWhiteSpace(videoPath))
                return false;

            List<VrConfiguration> configs = LoadConfigurations();

            string normalizedPath = NormalizePath(videoPath);

            int removedCount = configs.RemoveAll(v =>
                NormalizePath(v.VideoPath) == normalizedPath);

            if (removedCount > 0)
            {
                SaveConfigurations(configs);
                return true;
            }

            return false;
        }

        private static List<VrConfiguration> LoadConfigurations()
        {
            if (!File.Exists(ConfigFilePath))
                return new List<VrConfiguration>();

            string jsonString = File.ReadAllText(ConfigFilePath);
            if (string.IsNullOrWhiteSpace(jsonString))
                return new List<VrConfiguration>();
            return JsonSerializer.Deserialize<List<VrConfiguration>>(jsonString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<VrConfiguration>();
        }

        private static void SaveConfigurations(List<VrConfiguration> configs)
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

    public class VrConfiguration
    {
        [JsonPropertyName("videoPath")]
        public string VideoPath { get; set; }

        [JsonPropertyName("configurations")]
        public List<VrConfigItem> Configurations { get; set; } = new List<VrConfigItem>();
    }

    public class VrConfigItem
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
