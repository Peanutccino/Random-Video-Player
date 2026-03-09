using Mpv.NET.Player;
using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class AudioNormalizer
    {
        private static string normalizerFilter = "lavfi=[dynaudnorm=f=250:g=31:p=0.5:m=5:r=0.9:b=1]";

        public static void TuneNormalizer()
        {
            var frameLen = SettingsHandler.FrameLen;
            var gaussSize = SettingsHandler.GaussSize;
            var peak = SettingsHandler.Peak;
            var maxGain = SettingsHandler.MaxGain;
            var targetRMS = SettingsHandler.TargetRMS;
            var altBoundary = SettingsHandler.AltBoundary ? 1 : 0;

            normalizerFilter = FormattableString.Invariant($"lavfi=[dynaudnorm=f={frameLen}:g={gaussSize}:p={peak:0.##}:m={maxGain}:r={targetRMS:0.##}:b={altBoundary}]");
        }
        public static void ToggleNormalizer(MpvPlayer player)
        {
            if(SettingsHandler.AudioNormalizerEnabled)
            {
                EnableNormalizer(player);
            }
            else
            {
                DisableNormalizer(player);
            }

        }
        private static void EnableNormalizer(MpvPlayer player)
        {
            player.API.Command("af", "set", normalizerFilter);
        }
        private static void DisableNormalizer(MpvPlayer player)
        {
            player.API.Command("af", "remove", normalizerFilter);
        }
    }
}
