using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public static class VrInputFovExtension
    {
        public static string ToMpvValue(this VrInputFov fov)
        {
            return fov switch
            {
                VrInputFov.Fov180 => "180.0",
                VrInputFov.Fov360 => "360.0",
                _ => "180.0"
            };
        }
        public static bool TryFromMpvValue(string value, out VrInputFov fov)
        {
            fov = default;

            if (string.IsNullOrWhiteSpace(value))
                return false;

            switch (value.Trim().ToLowerInvariant())
            {
                case "180.0":
                    fov = VrInputFov.Fov180;
                    return true;

                case "360.0":
                    fov = VrInputFov.Fov360;
                    return true;

                default:
                    return false;
            }
        }
        public static string ToDisplayName(this VrInputFov fov)
        {
            return fov switch
            {
                VrInputFov.Fov180 => "180°",
                VrInputFov.Fov360 => "360°",
                _ => fov.ToString()
            };
        }
    }

    public enum VrInputFov
    {
        Fov180,
        Fov360
    }
}
