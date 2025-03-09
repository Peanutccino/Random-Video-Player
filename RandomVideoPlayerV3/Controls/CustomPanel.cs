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
                Invalidate(); 
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
                Invalidate(); 
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
                Invalidate(); 
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
                Invalidate(); 
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
                Invalidate(); 
            }
        }

        public CustomPanel()
        {
            this.BackColor = Color.Blue; 
            this.ResizeRedraw = true; 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Point[] points = {
            new Point(0, 0),               
            new Point(this.Width, 0 + topRightOffset),      
            new Point(this.Width, this.Height - bottomRightOffset), 
            new Point(0, this.Height)    
            };

            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                g.FillPolygon(brush, points);
            }

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
            Point[] points = {
            new Point(0 + topLeftXOffset, 0),              
            new Point(this.Width - topRightXOffset, 0 + topRightOffset),      
            new Point(this.Width - bottomRightXOffset, this.Height - bottomRightOffset), 
            new Point(0, this.Height)     
            };

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddPolygon(points);
            this.Region = new Region(path);
        }
    }
}
