namespace RandomVideoPlayer.Functions
{
    public enum EasingMethods
    {
        Linear,
        EaseInQuad,
        EaseOutQuad,
        EaseInOutQuad,
        EaseOutBack
    }
    public static class Easing
    {
        public static double Linear(double t) => t;

        public static double EaseInQuad(double t) => t * t;

        public static double EaseOutQuad(double t) => t * (2 - t);

        public static double EaseInOutQuad(double t) => t < 0.5 ? 2 * t * t : -1 + (4 - 2 * t) * t;

        public static double EaseOutBack(double t)
        {
            double s = 1.70158;
            return --t * t * ((s + 1) * t + s) + 1;
        }
    }
}
