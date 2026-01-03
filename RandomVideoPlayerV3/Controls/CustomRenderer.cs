using RandomVideoPlayer.Functions;
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
            : base(new ColorTable()) {}

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            Pen pen = new Pen(ThemeManager.CurrentTheme.TextColor);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var updatedArrowRectangleSize = new Size((int)(e.ArrowRectangle.Width / DPI.Scale), (int)(e.ArrowRectangle.Height / DPI.Scale));
            var updatedArrowRectangleLocation = new Point((int)(e.ArrowRectangle.X * DPI.Scale),(int)(e.ArrowRectangle.Y * DPI.Scale));
            var r = new Rectangle(updatedArrowRectangleLocation, updatedArrowRectangleSize);
            r.Inflate(-2, -6); //-2 -6
            e.Graphics.DrawLines(pen, new Point[]{
            new Point(r.Left, r.Top),
            new Point(r.Right, r.Top + r.Height /2),
            new Point(r.Left, r.Top+ r.Height)});
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            Pen pen = new Pen(ThemeManager.CurrentTheme.TextColor);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var updatedImageRectangleSize = new Size((int)(e.ImageRectangle.Width / DPI.Scale), (int)(e.ImageRectangle.Height / DPI.Scale));
            var updatedImageRectangleLocation = new Point((int)(e.ImageRectangle.X * DPI.Scale), (int)(e.ImageRectangle.Y * DPI.Scale));  
            var r = new Rectangle(updatedImageRectangleLocation, updatedImageRectangleSize);
            r.Inflate(-4, -6); //-4 -6
            e.Graphics.DrawLines(pen, new Point[]{
            new Point(r.Left, r.Bottom - r.Height /2),
            new Point(r.Left + r.Width /3,  r.Bottom),
            new Point(r.Right, r.Top)});
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = ThemeManager.CurrentTheme.TextColor;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var color = e.Item.Selected
                ? ThemeManager.CurrentTheme.ToolMenuHoverColor
                : ThemeManager.CurrentTheme.ToolMenuBackColor;
            e.Graphics.FillRectangle(new SolidBrush(color), e.Item.ContentRectangle);
        }
    }

    public class ColorTable : ProfessionalColorTable
    {
        public override Color SeparatorDark
        {
            get { return ThemeManager.CurrentTheme.TextColor; }
        }
        public override Color SeparatorLight
        {
            get { return ThemeManager.CurrentTheme.TextColor; }
        }
        public override Color MenuItemBorder
        {
            get { return ThemeManager.CurrentTheme.TextColor; }
        }
        public override Color MenuItemSelected
        {
            get { return ThemeManager.CurrentTheme.TextColor; }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return ThemeManager.CurrentTheme.ToolMenuBackColor; }
        }
        public override Color ImageMarginGradientBegin
        {
            get { return ThemeManager.CurrentTheme.ToolMenuBackColor; }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return ThemeManager.CurrentTheme.ToolMenuBackColor; }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return ThemeManager.CurrentTheme.ToolMenuBackColor; }
        }
    }
}
