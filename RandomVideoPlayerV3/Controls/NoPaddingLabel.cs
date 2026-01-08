using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public partial class NoPaddingLabel : Label
    {
        private TextFormatFlags flags = TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.NoPadding;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.AutoSize = false;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.Size = GetTextSize();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Size = GetTextSize();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Size = GetTextSize();
        }
        public Size TrueSize
        {
            get { return GetTextSize(); }
        }

        private Size GetTextSize()
        {
            Size padSize = TextRenderer.MeasureText(".", this.Font);
            Size textSize = TextRenderer.MeasureText(this.Text + ".", this.Font);
            return new Size(textSize.Width - padSize.Width, textSize.Height);
        }

        public bool RightAlignment
        {
            get
            {
                return (flags & TextFormatFlags.Right) == TextFormatFlags.Right;
            }
            set
            {
                if (value)
                {
                    flags = flags |= TextFormatFlags.Right;
                }
                else
                {
                    flags = flags &= ~TextFormatFlags.Right;
                }
                Invalidate();
            }
        }

        public NoPaddingLabel()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, ClientRectangle, this.ForeColor, Color.Transparent, flags);
        }
    }
}
