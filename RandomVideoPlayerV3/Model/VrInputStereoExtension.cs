using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public static class VrInputStereoExtension
    {
        public static string ToMpvValue(this VrInputStereo stereo)
        {
            return stereo switch
            {
                VrInputStereo.SideBySide => "sbs",
                VrInputStereo.TopBottom => "tb",
                VrInputStereo.Mono => "2d",
                _ => "sbs"
            };
        }
        public static bool TryFromMpvValue(string value, out VrInputStereo stereo)
        {
            stereo = default;

            if (string.IsNullOrWhiteSpace(value))
                return false;

            switch (value.Trim().ToLowerInvariant())
            {
                case "sbs":
                    stereo = VrInputStereo.SideBySide;
                    return true;

                case "tb":
                    stereo = VrInputStereo.TopBottom;
                    return true;

                case "2d":
                    stereo = VrInputStereo.Mono;
                    return true;

                default:
                    return false;
            }
        }

        public static string ToDisplayName(this VrInputStereo stereo)
        {
            return stereo switch
            {
                VrInputStereo.SideBySide => "Side-by-side",
                VrInputStereo.TopBottom => "Top-bottom",
                VrInputStereo.Mono => "2D Mono",
                _ => stereo.ToString()
            };
        }
    }

    public enum VrInputStereo
    {
        SideBySide,
        TopBottom,
        Mono
    }
}
