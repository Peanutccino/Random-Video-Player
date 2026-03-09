using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class ThemeHelper
    {
        public static Color Lighten(Color baseColor, int delta)
        {
            return Color.FromArgb(baseColor.A,
                Math.Clamp(baseColor.R + delta, 0, 255),
                Math.Clamp(baseColor.G + delta, 0, 255),
                Math.Clamp(baseColor.B + delta, 0, 255));
        }
        public static Color Lighten(Color baseColor, Color hColor, int delta)
        {
            return Color.FromArgb(baseColor.A,
                Math.Clamp(delta + hColor.R, 0, 255),
                Math.Clamp(delta + hColor.G, 0, 255),
                Math.Clamp(delta + hColor.B, 0, 255));
        }

        public static Color Darken(Color baseColor, int delta = -20)
        {
            return Color.FromArgb(baseColor.A,
                Math.Clamp(baseColor.R + delta, 0, 255),
                Math.Clamp(baseColor.G + delta, 0, 255),
                Math.Clamp(baseColor.B + delta, 0, 255));
        }
    }
}
