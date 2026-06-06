using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public static class VrInputProjectionExtension
    {
        public static string ToMpvValue(this VrInputProjection projection)
        {
            return projection switch
            {
                VrInputProjection.HalfEquirectangular => "hequirect",
                VrInputProjection.Equirectangular => "equirect",
                VrInputProjection.Fisheye => "fisheye",
                VrInputProjection.Stereographic => "sg",
                _ => "hequirect"
            };
        }

        public static bool TryFromMpvValue(string value, out VrInputProjection projection)
        {
            projection = default;

            if (string.IsNullOrWhiteSpace(value))
                return false;

            switch (value.Trim().ToLowerInvariant())
            {
                case "hequirect":
                    projection = VrInputProjection.HalfEquirectangular;
                    return true;

                case "equirect":
                    projection = VrInputProjection.Equirectangular;
                    return true;

                case "fisheye":
                    projection = VrInputProjection.Fisheye;
                    return true;

                case "sg":
                    projection = VrInputProjection.Stereographic;
                    return true;

                default:
                    return false;
            }
        }

        public static string ToDisplayName(this VrInputProjection projection)
        {
            return projection switch
            {
                VrInputProjection.HalfEquirectangular => "Half Equirectangular",
                VrInputProjection.Equirectangular => "Equirectangular",
                VrInputProjection.Fisheye => "Fisheye",
                VrInputProjection.Stereographic => "Stereographic",
                _ => projection.ToString()
            };
        }
    }

    public enum VrInputProjection
    {
        HalfEquirectangular,
        Equirectangular,
        Fisheye,
        Stereographic
    }
}
