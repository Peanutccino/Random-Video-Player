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
        private readonly ColorTable colorTable;
        public Color TextColor { get; set; } = Color.Black;
        public Color BackgroundColor { get; set; } = Color.White;
        public Color HighlightColor { get; set; } = Color.Cyan;

        public CustomRenderer()
            : this(Color.Black, Color.White) { }

        public CustomRenderer(Color text, Color background)
            : base(new ColorTable(text, background))
        {
            colorTable = (ColorTable)ColorTable;
        }
        public void ApplyColors()
        {
            colorTable.UpdateColors(TextColor, BackgroundColor);
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            Pen pen = new Pen(TextColor);

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
            Pen pen = new Pen(TextColor);

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
            e.TextColor = TextColor;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var color = e.Item.Selected
                ? HighlightColor
                : BackgroundColor;
            e.Graphics.FillRectangle(new SolidBrush(color), e.Item.ContentRectangle);
        }
    }

    public class ColorTable : ProfessionalColorTable
    {
        private Color textColor;
        private Color backgroundColor;

        public ColorTable(Color text, Color background)
        {
            UpdateColors(text, background);
        }
        public override Color ToolStripDropDownBackground => backgroundColor;
        public override Color ImageMarginGradientBegin => backgroundColor;
        public override Color ImageMarginGradientMiddle => backgroundColor;
        public override Color ImageMarginGradientEnd => backgroundColor;
        public override Color MenuItemSelected => textColor;
        public override Color MenuItemBorder => textColor;
        public override Color SeparatorDark => textColor;
        public override Color SeparatorLight => textColor;

        public void UpdateColors(Color text, Color background)
        {
            textColor = text;
            backgroundColor = background;
        }
    }
}
