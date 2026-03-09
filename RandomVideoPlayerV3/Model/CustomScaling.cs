using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Model
{
    public static class CustomScaling
    {
        public static Dictionary<string, float> ScalingFactors = new Dictionary<string, float>
        {
            { "125%", 0.75f },
            { "120%", 0.80f },
            { "115%", 0.85f },
            { "110%", 0.90f },
            { "105%" , 0.95f },
            { "100%", 1.00f },
            { "95%", 1.05f },
            { "90%", 1.10f },
            { "85%", 1.15f },
            { "80%", 1.20f },
            { "75%", 1.25f },
        };
    }
}
