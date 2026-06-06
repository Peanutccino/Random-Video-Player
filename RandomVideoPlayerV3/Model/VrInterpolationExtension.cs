using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public static class VrInterpolationExtension
    {
        public static string ToMpvValue(this VrInterpolation interpolation)
        {
            return interpolation switch
            {
                VrInterpolation.Nearest => "nearest",
                VrInterpolation.Linear => "linear",
                VrInterpolation.Cubic => "cubic",
                VrInterpolation.Lanczos => "lanczos",
                VrInterpolation.Spline => "spline16",
                _ => "sbs"
            };
        }

        public static bool TryFromMpvValue(string value, out VrInterpolation interpolation)
        {
            interpolation = default;

            if (string.IsNullOrWhiteSpace(value))
                return false;

            switch (value.Trim().ToLowerInvariant())
            {
                case "nearest":
                    interpolation = VrInterpolation.Nearest;
                    return true;

                case "linear":
                    interpolation = VrInterpolation.Linear;
                    return true;

                case "cubic":
                    interpolation = VrInterpolation.Cubic;
                    return true;

                case "lanczos":
                    interpolation = VrInterpolation.Lanczos;
                    return true;

                case "spline16":
                    interpolation = VrInterpolation.Spline;
                    return true;

                default:
                    return false;
            }
        }

        public static string ToDisplayName(this VrInterpolation interpolation)
        {
            return interpolation switch
            {
                VrInterpolation.Nearest => "Nearest",
                VrInterpolation.Linear => "Bilinear",
                VrInterpolation.Cubic => "Bicubic",
                VrInterpolation.Lanczos => "Lanczos",
                VrInterpolation.Spline => "Spline16",
                _ => interpolation.ToString()
            };
        }
    }
    public enum VrInterpolation
    {
        Nearest,
        Linear,
        Cubic,
        Lanczos,
        Spline
    }
}
