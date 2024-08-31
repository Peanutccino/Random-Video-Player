using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Controls
{
    public class CustomRenderer : ToolStripProfessionalRenderer
    {
        public CustomRenderer()
            : base(new ColorTable())
        {
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(e.ArrowRectangle.Location, e.ArrowRectangle.Size);
            r.Inflate(-2, -6);
            e.Graphics.DrawLines(Pens.Black, new Point[]{
            new Point(r.Left, r.Top),
            new Point(r.Right, r.Top + r.Height /2),
            new Point(r.Left, r.Top+ r.Height)});
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(e.ImageRectangle.Location, e.ImageRectangle.Size);
            r.Inflate(-4, -6);
            e.Graphics.DrawLines(Pens.Black, new Point[]{
            new Point(r.Left, r.Bottom - r.Height /2),
            new Point(r.Left + r.Width /3,  r.Bottom),
            new Point(r.Right, r.Top)});
        }
    }

    public class ColorTable : ProfessionalColorTable
    {
        public override Color SeparatorDark
        {
            get { return Color.Indigo; }
        }
        public override Color SeparatorLight
        {
            get { return Color.Indigo; }
        }
        public override Color MenuItemBorder
        {
            get { return Color.Black; }
        }
        public override Color MenuItemSelected
        {
            get { return Color.Black; }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return Color.LightPink; }
        }
        public override Color ImageMarginGradientBegin
        {
            get { return Color.LightPink; }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.LightPink; }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return Color.LightPink; }
        }
    }
}
