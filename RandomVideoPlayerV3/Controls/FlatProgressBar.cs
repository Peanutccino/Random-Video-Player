using Mpv.NET.API;
using Newtonsoft.Json.Linq;

namespace RandomVideoPlayerV3
{
    public class FlatProgressBar : Control
    {
        private int _value = 0;
        private int _minimum = 0;
        private int _maximum = 100;
        private int _borderThickness = 1;
        private int _graphThickness = 1;
        private bool mouseOver = false;
        private bool _showBorder = false;
        private Color _completedBrush = Color.DodgerBlue;
        private Color _remainingBrush = Color.Black;
        private Color _mousehoverBrush = Color.DeepSkyBlue;
        private Color _borderColor = Color.Black;
        private Color _completedGraphBrush = Color.White;
        private Color _remainingGraphBrush = Color.Black;
        private Color _mouseOverColor = Color.Black;
        private Bitmap? progressBitmap;
        private Bitmap? remainingBitmap;
        private List<ActionPoint> actionPoints = new List<ActionPoint>();

        public FlatProgressBar()
        {
            DoubleBuffered = true;
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (value > Maximum)
                {
                    value = Maximum;
                }
                else if (value < Minimum)
                {
                    value = Minimum;
                }
                _value = value;
                Invalidate();
            }
        }
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                Invalidate();
            }
        }

        public Color CompletedBrush
        {
            get { return _completedBrush; }
            set
            {
                _completedBrush = value;
                Invalidate();
            }
        }

        public Color RemainingBrush
        {
            get { return _remainingBrush; }
            set
            {
                _remainingBrush = value;
                Invalidate();
            }
        }
        public Color CompletedGraphBrush
        {
            get { return _completedGraphBrush; }
            set 
            { 
                _completedGraphBrush = value; 
                Invalidate();
            }
        }
        public Color RemainingGraphBrush
        {
            get { return _remainingGraphBrush; }
            set 
            { 
                _remainingGraphBrush = value;
                Invalidate();
            }
        }
        public Color MouseoverBrush
        {
            get { return _mousehoverBrush; }
            set
            {
                _mousehoverBrush = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        public int BorderThickness
        {
            get { return _borderThickness; }
            set
            {
                _borderThickness = value;
                Invalidate();
            }
        }

        public int GraphThickness
        {
            get { return _graphThickness; }
            set { _graphThickness = value; }
        }


        public bool ShowBorder
        {
            get { return _showBorder; }
            set
            {
                _showBorder = value;
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            mouseOver = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            mouseOver = false;
            Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            PreRenderGraph(); // Re-render the graph to fit the new size
        }

        public void LoadFunScript(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            var jObject = JObject.Parse(jsonContent);

            actionPoints = jObject["actions"]
                .Select(jt => new ActionPoint { At = (long)jt["at"], Pos = (int)jt["pos"] })
                .ToList();

            PreRenderGraph(); // Pre-render the graph after loading new data
        }

        public void DeleteActionsPoints()
        {
            actionPoints.Clear();
        }
        private void PreRenderGraph()
        {
            progressBitmap?.Dispose();
            remainingBitmap?.Dispose();

            if (actionPoints == null || actionPoints.Count == 0 || this.Width == 0 || this.Height == 0)
            {
                progressBitmap = null;
                remainingBitmap = null;
                return;
            }

            progressBitmap = new Bitmap(Width, Height);
            remainingBitmap = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(progressBitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(_completedBrush);

                DrawFunscriptGraph(g, _completedGraphBrush);
            }
            using (Graphics g = Graphics.FromImage(remainingBitmap))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(_remainingBrush); 

                DrawFunscriptGraph(g, _remainingGraphBrush); 
            }
        }
        private void DrawFunscriptGraph(Graphics g, Color graphcolor)
        {
            if (actionPoints.Count < 2) return;

            int maxTime = Maximum;

            using (Pen remainingGraphPen = new Pen(graphcolor, _graphThickness)) 
            {
                for (int i = 0; i < actionPoints.Count - 1; i++)
                {
                    var startPoint = actionPoints[i];
                    var endPoint = actionPoints[i + 1];

                    float startX = (float)startPoint.At / maxTime * Width;
                    float startY = (1 - (float)startPoint.Pos / 100) * Height;
                    float endX = (float)endPoint.At / maxTime * Width;
                    float endY = (1 - (float)endPoint.Pos / 100) * Height;

                    g.DrawLine(remainingGraphPen, startX, startY, endX, endY);
                    
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            float progressPercentage = (float)Value / Maximum;
            int progressWidth = (int)(progressPercentage * Width);

            _mouseOverColor = mouseOver ? _mousehoverBrush : _completedBrush;

            if (actionPoints.Count == 0 || actionPoints == null)
            {
                e.Graphics.FillRectangle(new SolidBrush(_remainingBrush), 0, 0, Width, Height);
                e.Graphics.FillRectangle(new SolidBrush(_mouseOverColor), 0, 0, progressWidth, Height);
            }
            else
            {
                // Draw the pre-rendered graph bitmap
                if (progressBitmap != null && remainingBitmap != null)
                {
                    Rectangle progressRect = new Rectangle(0, 0, progressWidth, Height);
                    e.Graphics.DrawImage(progressBitmap, progressRect, progressRect, GraphicsUnit.Pixel);

                    Rectangle remainingRect = new Rectangle(progressWidth, 0, Width - progressWidth, Height);
                    e.Graphics.DrawImage(remainingBitmap, remainingRect, remainingRect, GraphicsUnit.Pixel);
                }
            }
            // Draw border if ShowBorder is true
            if (ShowBorder)
            {
                var borderRect = new Rectangle(0, 0, Width - 1, Height - 1);
                var pen = new Pen(_borderColor, BorderThickness);
                e.Graphics.DrawRectangle(pen, borderRect);
            }

        }



    }
    public class ActionPoint
    {
        public long At { get; set; } // Time in milliseconds
        public int Pos { get; set; } // Position value
    }


}
