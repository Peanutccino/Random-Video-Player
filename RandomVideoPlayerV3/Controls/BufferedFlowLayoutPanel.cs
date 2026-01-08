using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class BufferedFlowLayoutPanel : FlowLayoutPanel
    {
        public BufferedFlowLayoutPanel()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint, true);
            UpdateStyles();
        }
    }
}
