using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public partial class OverlayLabel : Label
    {
        private TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding;

        public bool MiddleAlignment
        {
            get
            {
                return (flags & TextFormatFlags.HorizontalCenter) == TextFormatFlags.HorizontalCenter;
            }
            set
            {
                if (value)
                {
                    flags = flags |= TextFormatFlags.HorizontalCenter;
                }
                else
                {
                    flags = flags &= ~TextFormatFlags.HorizontalCenter;
                }
                Invalidate();
            }
        }

        public OverlayLabel()
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, ClientRectangle, this.ForeColor, Color.Transparent, flags);
        }
    }
}
