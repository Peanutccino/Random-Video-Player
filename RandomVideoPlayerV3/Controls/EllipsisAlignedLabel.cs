using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class EllipsisAlignedLabel : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            var flags =
                TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPrefix |
                TextFormatFlags.NoPadding |
                TextFormatFlags.PreserveGraphicsClipping;

            flags |= ToFlags(this.TextAlign);

            TextRenderer.DrawText(
                e.Graphics,
                this.Text,
                this.Font,
                this.ClientRectangle,
                this.ForeColor,
                flags);
        }

        private static TextFormatFlags ToFlags(ContentAlignment a) => a switch
        {
            ContentAlignment.TopLeft => TextFormatFlags.Top | TextFormatFlags.Left,
            ContentAlignment.TopCenter => TextFormatFlags.Top | TextFormatFlags.HorizontalCenter,
            ContentAlignment.TopRight => TextFormatFlags.Top | TextFormatFlags.Right,

            ContentAlignment.MiddleLeft => TextFormatFlags.VerticalCenter | TextFormatFlags.Left,
            ContentAlignment.MiddleCenter => TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter,
            ContentAlignment.MiddleRight => TextFormatFlags.VerticalCenter | TextFormatFlags.Right,

            ContentAlignment.BottomLeft => TextFormatFlags.Bottom | TextFormatFlags.Left,
            ContentAlignment.BottomCenter => TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter,
            ContentAlignment.BottomRight => TextFormatFlags.Bottom | TextFormatFlags.Right,

            _ => TextFormatFlags.Left | TextFormatFlags.Top
        };
    }
}
