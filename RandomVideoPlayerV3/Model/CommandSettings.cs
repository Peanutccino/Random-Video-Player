
namespace RandomVideoPlayer.Model
{
    public class CommandSettings
    {
        public const double ZoomStep = 0.05;

        public const double PanStep = 0.02;

        public const double ScaleStep = 0.05;


        private static CommandSettings instance;
        private static readonly object lockObj = new object();


        private int _zoomCounter;
        public int ZoomCounter
        {
            get { return _zoomCounter; }
            set { _zoomCounter = value; }
        }
        private int _maxZoomCounter { get; set; } = 50;

        private int _panCounterX;
        public int PanCounterHorizonal
        {
            get { return _panCounterX; }
            set { _panCounterX = value; }
        }

        private int _panCounterY;
        public int PanCounterVertical
        {
            get { return _panCounterY; }
            set { _panCounterY = value; }
        }

        private int _maxPanCounterX { get; set; } = 150;
        private int _maxPanCounterY { get; set; } = 150;


        private int _scaleCounterX;
        public int ScaleCounterHorizontal
        {
            get { return _scaleCounterX; }
            set { _scaleCounterX = value; }
        }

        private int _scaleCounterY;
        public int ScaleCounterVertical
        {
            get { return _scaleCounterY; }
            set { _scaleCounterY = value; }
        }

        private int _maxScaleCounterX { get; set; } = 50;
        private int _maxScaleCounterY { get; set; } = 50;

        private CommandSettings()
        {
            //Prevent instantiation
        }

        public static CommandSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new CommandSettings();
                        }
                    }
                }
                return instance;
            }
        }


        public bool IncrementZoomCounter(int increment)
        {
            int newZoomCounter = _zoomCounter + increment;

            if (newZoomCounter > _maxZoomCounter)
            {
                _zoomCounter = _maxZoomCounter;
                return true;
            }
            else if (newZoomCounter < -_maxZoomCounter)
            {
                _zoomCounter = -_maxZoomCounter;
                return true;
            }
            else
            {
                _zoomCounter = newZoomCounter;
                return false;
            }
        }

        public bool IncrementPanCounterHorizontal(int increment)
        {
            int newZoomCounter = _panCounterX + increment;

            if (newZoomCounter > _maxPanCounterX)
            {
                _panCounterX = _maxPanCounterX;
                return true;
            }
            else if (newZoomCounter < -_maxPanCounterX)
            {
                _panCounterX = -_maxPanCounterX;
                return true;
            }
            else
            {
                _panCounterX = newZoomCounter;
                return false;
            }
        }

        public bool IncrementPanCounterVertical(int increment)
        {
            int newZoomCounter = _panCounterY + increment;

            if (newZoomCounter > _maxPanCounterY)
            {
                _panCounterY = _maxPanCounterY;
                return true;
            }
            else if (newZoomCounter < -_maxPanCounterY)
            {
                _panCounterY = -_maxPanCounterY;
                return true;
            }
            else
            {
                _panCounterY = newZoomCounter;
                return false;
            }
        }

        public bool IncrementScaleCounterHorizontal(int increment)
        {
            int newZoomCounter = _scaleCounterX + increment;

            if (newZoomCounter > _maxScaleCounterX)
            {
                _scaleCounterX = _maxScaleCounterX;
                return true;
            }
            else if (newZoomCounter < (int)-(1 / ScaleStep))
            {
                _scaleCounterX = (int)-(1 / ScaleStep);
                return true;
            }
            else
            {
                _scaleCounterX = newZoomCounter;
                return false;
            }
        }

        public bool IncrementScaleCounterVertical(int increment)
        {
            int newZoomCounter = _scaleCounterY + increment;

            if (newZoomCounter > _maxScaleCounterY)
            {
                _scaleCounterY = _maxScaleCounterY;
                return true;
            }
            else if (newZoomCounter < (int)-(1 / ScaleStep))
            {
                _scaleCounterY = (int)-(1 / ScaleStep);
                return true;
            }
            else
            {
                _scaleCounterY = newZoomCounter;
                return false;
            }
        }
    }
}
