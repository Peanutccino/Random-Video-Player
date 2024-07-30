using System.ComponentModel;
using System.Windows.Forms.Design;

namespace RandomVideoPlayer.Controls
{
    [Designer(typeof(ParentControlDesigner))]
    public class CustomPanel : Panel
    {
        private int topRightOffset = 0;
        private int bottomRightXOffset = 0;
        private int bottomRightOffset = 0;
        private int topLeftXOffset = 0;
        private int topRightXOffset = 0;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Offset for the top right corner.")]
        public int TopRightOffset
        {
            get { return topRightOffset; }
            set
            {
                topRightOffset = value;
                UpdateRegion();
                Invalidate(); // Redraw the control
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Offset for the bottom right corner.")]
        public int BottomRightXOffset
        {
            get { return bottomRightXOffset; }
            set
            {
                bottomRightXOffset = value;
                UpdateRegion();
                Invalidate(); // Redraw the control
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Offset for the bottom left corner.")]
        public int BottomRightOffset
        {
            get { return bottomRightOffset; }
            set
            {
                bottomRightOffset = value;
                UpdateRegion();
                Invalidate(); // Redraw the control
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Offset for the top left corner.")]
        public int TopLeftXOffset
        {
            get { return topLeftXOffset; }
            set
            {
                topLeftXOffset = value;
                UpdateRegion();
                Invalidate(); // Redraw the control
            }
        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Offset for the top right corner.")]
        public int TopRightXOffset
        {
            get { return topRightXOffset; }
            set
            {
                topRightXOffset = value;
                UpdateRegion();
                Invalidate(); // Redraw the control
            }
        }

        public CustomPanel()
        {
            this.BackColor = Color.Blue; // Default color, can be changed in designer
            this.ResizeRedraw = true; // Ensures the control is redrawn when resized
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Define the points for the custom shape (trapezoid in this example)
            Point[] points = {
            new Point(0, 0),               // Top-left
            new Point(this.Width, 0 + topRightOffset),      // Top-right
            new Point(this.Width, this.Height - bottomRightOffset), // Bottom-right (angled)
            new Point(0, this.Height)     // Bottom-left (angled)
        };

            // Draw the custom shape
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                g.FillPolygon(brush, points);
            }

            // Optionally draw a border to smooth the edges further
            using (Pen pen = new Pen(this.BackColor, 1))
            {
                g.DrawPolygon(pen, points);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            // Define the points for the custom shape (trapezoid in this example)
            Point[] points = {
            new Point(0 + topLeftXOffset, 0),               // Top-left
            new Point(this.Width - topRightXOffset, 0 + topRightOffset),      // Top-right
            new Point(this.Width - bottomRightXOffset, this.Height - bottomRightOffset), // Bottom-right (angled)
            new Point(0, this.Height)     // Bottom-left (angled)
        };

            // Create a GraphicsPath from the points and set it as the control's region
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddPolygon(points);
            this.Region = new Region(path);
        }
    }
}
