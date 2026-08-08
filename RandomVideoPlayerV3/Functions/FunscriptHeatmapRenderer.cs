using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class FunscriptHeatmapRenderer
    {
        private readonly struct Rgb
        {
            public readonly double R;
            public readonly double G;
            public readonly double B;

            public Rgb(double r, double g, double b)
            {
                R = r;
                G = g;
                B = b;
            }

            public Color ToColor()
            {
                return Color.FromArgb(
                    ClampToByte(R),
                    ClampToByte(G),
                    ClampToByte(B));
            }
        }

        private static readonly Rgb[] HeatmapColors = {
            new Rgb(0, 0, 0),
            new Rgb(30, 144, 255),
            new Rgb(34, 139, 34),
            new Rgb(255, 215, 0),
            new Rgb(220, 20, 60),
            new Rgb(147, 112, 219),
            new Rgb(37, 22, 122),
        };
        private readonly struct ClippedSegment
        {
            public readonly int SourceIndex;
            public readonly double StartMs;
            public readonly double EndMs;
            public readonly double StartPos;
            public readonly double EndPos;
            public readonly double OriginalSpeed;

            public ClippedSegment(
                int sourceIndex,
                double startMs,
                double endMs,
                double startPos,
                double endPos,
                double originalSpeed)
            {
                SourceIndex = sourceIndex;
                StartMs = startMs;
                EndMs = endMs;
                StartPos = startPos;
                EndPos = endPos;
                OriginalSpeed = originalSpeed;
            }
        }

        public static Bitmap RenderHeatmap(Funscript? script, int width, int height, double durationMS, HeatmapOptions? options = null)
        {
            options ??= new HeatmapOptions();

            var bitmap = new Bitmap(width, height);

            using var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.Half;

            if (width <= 0 || height <= 0)
                return bitmap;

            if (script == null || script.Actions == null || script.Actions.Count < 2)
            {
                Clear(g, width, height, options.Background);
                return bitmap;
            }

            var actions = script.Actions
                .OrderBy(a => a.At)
                .ToList();

            if (durationMS <= 0)
            {
                Clear(g, width, height, options.Background);
                return bitmap;
            }

            Clear(g, width, height, options.Background);

            Rgb[] pixelColors = new Rgb[width];
            int[] pixelCounts = new int[width];

            int currentIndex = 0;

            for (int x = 0; x < width; x++)
            {
                double pixelMinTime = x / (double)width * durationMS;
                double pixelMaxTime = (x + 1) / (double)width * durationMS;

                var currentPixelPairs = new List<(FunscriptAction Last, FunscriptAction Cur)>();

                while (currentIndex < actions.Count &&
                       actions[currentIndex].At < pixelMaxTime)
                {
                    if (currentIndex > 0)
                    {
                        currentPixelPairs.Add(
                            (actions[currentIndex - 1], actions[currentIndex]));
                    }

                    currentIndex++;
                }

                double speedSum = 0;

                foreach (var pair in currentPixelPairs)
                {
                    speedSum += GetSpeed(pair.Last, pair.Cur);
                }

                double averageSpeed = speedSum / Math.Max(1, currentPixelPairs.Count);

                pixelColors[x] = GetColor(averageSpeed);
                pixelCounts[x] = currentPixelPairs.Count;
            }

            int smoothing = Math.Max(1, options.ColorSmoothing);

            Rgb[] smoothedColors = SmoothColorsLikeOriginal(pixelColors, pixelCounts, smoothing, options.Solid);

            if (options.Solid)
            {
                DrawSolidGradient(g, smoothedColors, width, height);
                return bitmap;
            }

            Clear(g, width, height, options.Background);

            using var pen = new Pen(Color.White, options.LineWidth)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            double TimeToX(double time)
            {
                return time / durationMS * width;
            }

            double verticalPadding = Math.Ceiling(options.LineWidth / 2.0) + 1;

            double PosToY(double pos)
            {
                pos = Math.Max(0, Math.Min(100, pos));

                double drawableTop = verticalPadding;
                double drawableBottom = height - 1 - verticalPadding;
                double drawableHeight = drawableBottom - drawableTop;

                if (drawableHeight <= 0)
                    return height / 2.0;

                return drawableTop + (1.0 - pos / 100.0) * drawableHeight;
            }

            for (int i = 1; i < actions.Count; i++)
            {
                var prev = actions[i - 1];
                var cur = actions[i];

                pen.Color = GetSegmentColor(
                    actions,
                    i,
                    smoothingRadius: 4,
                    minVisibleSpeed: 35,
                    softenAmount: 0.80,
                    background: options.Background);


                float x1 = (float)TimeToX(prev.At);
                float y1 = (float)PosToY(prev.Pos);
                float x2 = (float)TimeToX(cur.At);
                float y2 = (float)PosToY(cur.Pos);

                g.DrawLine(pen, x1, y1, x2, y2);
            }

            return bitmap;
        }

        public static Bitmap? RenderHeatmapWindow(Funscript script, int width, int height, double durationMs, double centerMs, double radiusMs, HeatmapOptions? options = null)
        {
            if (script == null) return null;

            options ??= new HeatmapOptions();

            var bitmap = new Bitmap(width, height);

            using var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            if (width <= 0 || height <= 0)
                return bitmap;

            Clear(g, width, height, options.Background);

            if (script.Actions == null || script.Actions.Count < 2 || durationMs <= 0)
                return bitmap;

            double startMs = Math.Max(0, centerMs - radiusMs);
            double endMs = Math.Min(durationMs, centerMs + radiusMs);

            if (endMs <= startMs)
                return bitmap;

            var sourceActions = script.Actions
                .OrderBy(a => a.At)
                .ToList();

            double windowDuration = endMs - startMs;

            double TimeToX(double time)
            {
                return (time - startMs) / windowDuration * (width - 1);
            }
            double verticalPadding = Math.Ceiling(options.LineWidth / 2.0) + 1;

            double PosToY(double pos)
            {
                pos = Math.Max(0, Math.Min(100, pos));

                double drawableTop = verticalPadding;
                double drawableBottom = height - 1 - verticalPadding;
                double drawableHeight = drawableBottom - drawableTop;

                if (drawableHeight <= 0)
                    return height / 2.0;

                return drawableTop + (1.0 - pos / 100.0) * drawableHeight;
            }

            var clippedSegments = GetSegmentsOverlappingWindow(
                sourceActions,
                startMs,
                endMs);

            using var pen = new Pen(Color.White, options.LineWidth)
            {
                StartCap = System.Drawing.Drawing2D.LineCap.Round,
                EndCap = System.Drawing.Drawing2D.LineCap.Round,
                LineJoin = System.Drawing.Drawing2D.LineJoin.Round
            };

            foreach (var segment in clippedSegments)
            {
                double speed = segment.OriginalSpeed;

                pen.Color = GetSegmentColor(
                    sourceActions,
                    segment.SourceIndex,
                    smoothingRadius: 2,
                    minVisibleSpeed: 35,
                    softenAmount: 0.85,
                    background: options.Background);

                float x1 = (float)TimeToX(segment.StartMs);
                float y1 = (float)PosToY(segment.StartPos);
                float x2 = (float)TimeToX(segment.EndMs);
                float y2 = (float)PosToY(segment.EndPos);

                g.DrawLine(pen, x1, y1, x2, y2);
            }

            double centerX = (centerMs - startMs) / windowDuration * (width - 1);
            centerX = Math.Max(0, Math.Min(width - 1, centerX));

            using var markerPen = new Pen(Color.FromArgb(230, 255, 255, 255), 1);
            g.DrawLine(markerPen, (float)centerX, 0, (float)centerX, height - 1);

            return bitmap;
        }

        public static long DetectGap(Funscript? script, long currentVideoPosition, int gapThreshhold)
        {
            long nextActionPoint = 0;

            if (script == null || script.Actions == null || script.Actions.Count < 2)
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < script.Actions.Count; i++)
                {
                    var action = script.Actions[i];

                    if (action.At > currentVideoPosition)
                    {
                        if (action.At > (currentVideoPosition + gapThreshhold))
                        {
                            nextActionPoint = action.At;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }

                }
                return nextActionPoint;
            }
        }

        public static Funscript LoadFunscript(string path)
        {
            Funscript script = null;

            try
            {
                var json = File.ReadAllText(path);
                script = JsonSerializer.Deserialize<Funscript>(json);
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Failed to read funscript for graph", LogLevel.Error);
            }

            if (script == null)
                return null;

            script.Actions = script.Actions
                .OrderBy(a => a.At)
                .ToList();

            return script;
        }

        private static Rgb[] SmoothColorsLikeOriginal(Rgb[] pixelColors, int[] pixelCounts, int colorSmoothing, bool solid)
        {
            int width = pixelColors.Length;
            var result = new Rgb[width];

            var colorAverage = new Queue<Rgb>();

            for (int x = 0; x < width; x++)
            {
                if (pixelCounts[x] > 0 || solid)
                {
                    if (colorAverage.Count == colorSmoothing)
                        colorAverage.Dequeue();

                    colorAverage.Enqueue(pixelColors[x]);
                }

                Rgb average = GetAverageColor(colorAverage);

                int targetX = x - (int)Math.Floor(colorSmoothing * 0.5);

                if (targetX >= 0 && targetX < width)
                    result[targetX] = average;
            }

            Rgb last = new Rgb(0, 0, 0);

            for (int x = 0; x < width; x++)
            {
                if (!IsBlack(result[x]))
                    last = result[x];
                else if (x > 0)
                    result[x] = last;
            }

            return result;
        }

        private static void DrawSolidGradient(Graphics g, Rgb[] colors, int width, int height)
        {
            using var pen = new Pen(Color.Black, 1);

            for (int x = 0; x < width; x++)
            {
                pen.Color = colors[x].ToColor();
                g.DrawLine(pen, x, 0, x, height);
            }
        }

        private static void Clear(Graphics g, int width, int height, Color? background)
        {
            if (background.HasValue)
            {
                using var brush = new SolidBrush(background.Value);
                g.FillRectangle(brush, 0, 0, width, height);
            }
            else
            {
                g.Clear(Color.Transparent);
            }
        }

        private static double GetSpeed(FunscriptAction previous, FunscriptAction current)
        {
            int dt = current.At - previous.At;

            if (dt <= 0)
                return 0;

            int dp = Math.Abs(current.Pos - previous.Pos);

            //Positions per second
            return dp / (dt / 1000.0);
        }

        private static Rgb GetColor(double intensity)
        {
            const double stepSize = 120.0;

            if (intensity <= 0)
                return HeatmapColors[0];

            if (intensity > 5 * stepSize)
                return HeatmapColors[6];

            intensity += stepSize / 2.0;

            int index = (int)Math.Floor(intensity / stepSize);
            index = Clamp(index, 0, HeatmapColors.Length - 2);

            double t = (intensity - Math.Floor(intensity / stepSize) * stepSize) / stepSize;
            t = Clamp01(t);

            return Lerp(HeatmapColors[index], HeatmapColors[index + 1], t);
        }

        private static Rgb Lerp(Rgb a, Rgb b, double t)
        {
            return new Rgb(
                a.R + (b.R - a.R) * t,
                a.G + (b.G - a.G) * t,
                a.B + (b.B - a.B) * t);
        }

        private static Rgb GetAverageColor(IEnumerable<Rgb> colors)
        {
            int count = 0;
            double r = 0;
            double g = 0;
            double b = 0;

            foreach (var color in colors)
            {
                r += color.R;
                g += color.G;
                b += color.B;
                count++;
            }

            if (count == 0)
                return new Rgb(0, 0, 0);

            return new Rgb(r / count, g / count, b / count);
        }

        private static bool IsBlack(Rgb color)
        {
            return Math.Abs(color.R) < 0.0001 &&
                   Math.Abs(color.G) < 0.0001 &&
                   Math.Abs(color.B) < 0.0001;
        }

        private static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        private static double Clamp01(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        private static int ClampToByte(double value)
        {
            if (value < 0) return 0;
            if (value > 255) return 255;
            return (int)Math.Round(value);
        }

        private static List<ClippedSegment> GetSegmentsOverlappingWindow(List<FunscriptAction> actions, double windowStartMs, double windowEndMs)
        {
            var result = new List<ClippedSegment>();

            if (actions.Count < 2)
                return result;

            for (int i = 1; i < actions.Count; i++)
            {
                var prev = actions[i - 1];
                var cur = actions[i];

                double segmentStartMs = prev.At;
                double segmentEndMs = cur.At;

                if (segmentEndMs <= segmentStartMs)
                    continue;

                if (segmentEndMs < windowStartMs || segmentStartMs > windowEndMs)
                    continue;

                double clippedStartMs = Math.Max(segmentStartMs, windowStartMs);
                double clippedEndMs = Math.Min(segmentEndMs, windowEndMs);

                if (clippedEndMs <= clippedStartMs)
                    continue;

                double startPos = InterpolatePos(prev, cur, clippedStartMs);
                double endPos = InterpolatePos(prev, cur, clippedEndMs);

                double originalSpeed = GetSpeed(prev, cur);

                result.Add(new ClippedSegment(
                    i,
                    clippedStartMs,
                    clippedEndMs,
                    startPos,
                    endPos,
                    originalSpeed));
            }

            return result;
        }

        private static double InterpolatePos(FunscriptAction prev, FunscriptAction cur, double timeMs)
        {
            double dt = cur.At - prev.At;

            if (dt <= 0)
                return prev.Pos;

            double t = (timeMs - prev.At) / dt;
            t = Clamp01(t);

            return prev.Pos + (cur.Pos - prev.Pos) * t;
        }

        private static double GetNearestNonZeroSpeed(List<FunscriptAction> actions, int segmentIndex, int searchRadius = 4)
        {
            double ownSpeed = GetSpeed(actions[segmentIndex - 1], actions[segmentIndex]);

            if (ownSpeed > 0)
                return ownSpeed;

            for (int offset = 1; offset <= searchRadius; offset++)
            {
                int leftIndex = segmentIndex - offset;
                int rightIndex = segmentIndex + offset;

                if (leftIndex >= 1)
                {
                    double leftSpeed = GetSpeed(actions[leftIndex - 1], actions[leftIndex]);

                    if (leftSpeed > 0)
                        return leftSpeed;
                }

                if (rightIndex < actions.Count)
                {
                    double rightSpeed = GetSpeed(actions[rightIndex - 1], actions[rightIndex]);

                    if (rightSpeed > 0)
                        return rightSpeed;
                }
            }

            return 0;
        }

        private static Color GetSegmentColor(List<FunscriptAction> actions, int segmentIndex, int smoothingRadius = 3, double minVisibleSpeed = 40, double softenAmount = 0.85, Color? background = null)
        {
            double speed = GetSmoothedSegmentSpeed(actions, segmentIndex, smoothingRadius);

            if (speed <= 0)
            {
                return Color.FromArgb(130, 30, 144, 255);
            }

            speed = Math.Max(speed, minVisibleSpeed);

            Color raw = GetColor(speed).ToColor();
            Color bg = background ?? Color.Black;

            return Blend(bg, raw, softenAmount);
        }

        private static double GetSmoothedSegmentSpeed(List<FunscriptAction> actions, int segmentIndex, int smoothingRadius)
        {
            if (actions.Count < 2)
                return 0;

            double weightedSum = 0;
            double weightTotal = 0;

            for (int offset = -smoothingRadius; offset <= smoothingRadius; offset++)
            {
                int idx = segmentIndex + offset;

                if (idx < 1 || idx >= actions.Count)
                    continue;

                double speed = GetSpeed(actions[idx - 1], actions[idx]);

                if (speed <= 0)
                {
                    speed = GetNearestNonZeroSpeed(
                        actions,
                        idx,
                        searchRadius: 4);
                }

                if (speed <= 0)
                    continue;

                double weight = smoothingRadius + 1 - Math.Abs(offset);

                weightedSum += speed * weight;
                weightTotal += weight;
            }

            if (weightTotal <= 0)
                return 0;

            return weightedSum / weightTotal;
        }

        private static Color Blend(Color a, Color b, double amount)
        {
            amount = Math.Max(0, Math.Min(1, amount));

            int r = (int)(a.R + (b.R - a.R) * amount);
            int g = (int)(a.G + (b.G - a.G) * amount);
            int bl = (int)(a.B + (b.B - a.B) * amount);
            int alpha = (int)(a.A + (b.A - a.A) * amount);

            return Color.FromArgb(alpha, r, g, bl);
        }

        public sealed class Funscript
        {
            [JsonPropertyName("actions")]
            public List<FunscriptAction> Actions { get; set; } = new();
        }

        public sealed class FunscriptAction
        {
            [JsonPropertyName("at")]
            public int At { get; set; }

            [JsonPropertyName("pos")]
            public int Pos { get; set; }
        }
        public sealed class HeatmapOptions
        {
            public Color? Background { get; set; } = null;

            public float LineWidth { get; set; } = 2f;

            public int ColorSmoothing { get; set; } = 5;

            public bool Solid { get; set; } = false;
        }
    }
}
