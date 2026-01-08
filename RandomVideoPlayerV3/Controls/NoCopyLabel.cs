using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class NoCopyLabel : Label
    {
        private const int WM_LBUTTONDBLCLK = 0x0203;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK)
            {
                var lParam = m.LParam.ToInt32();
                int x = lParam & 0xFFFF;
                int y = (lParam >> 16) & 0xFFFF;

                var args = new MouseEventArgs(MouseButtons.Left, 2, x, y, 0);
                OnMouseDoubleClick(args);
                OnDoubleClick(EventArgs.Empty);
                return;                     
            }

            base.WndProc(ref m);
        }
    }
}
