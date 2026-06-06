using RandomVideoPlayer.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class VrDetection
    {
        public static int maxShiftWide { get; set; } = 16;
        public static int maxShiftTall { get; set; } = 5;
        public static VrDetectionResults Detect(Bitmap frame)
        {
            if (frame == null)
                throw new ArgumentNullException(nameof(frame));

            if (frame.Width < 64 || frame.Height < 64)
            {
                return new VrDetectionResults
                {
                    Layout = VrDetectionLayout.Unknown
                };
            }

            maxShiftWide = SettingsHandler.VrMaxShiftWide;
            maxShiftTall = SettingsHandler.VrMaxShiftTall;

            double sbsScore = CompareSideBySide(frame);
            double tbScore = CompareTopBottom(frame);

            const double minimumUsefulScore = 0.58;
            const double minimumDifference = 0.06;

            double bestScore = Math.Max(sbsScore, tbScore * 0.85);
            double difference = Math.Abs(sbsScore - tbScore);

            VrDetectionLayout layout = VrDetectionLayout.Unknown;

            if (bestScore >= minimumUsefulScore && difference >= minimumDifference)
            {
                layout = sbsScore > tbScore
                    ? VrDetectionLayout.SideBySide
                    : VrDetectionLayout.TopBottom;
            }

            double confidence = ComputeConfidence(bestScore, difference);

            return new VrDetectionResults
            {
                Layout = layout,
                SbsScore = sbsScore,
                TopBottomScore = tbScore,
                Confidence = confidence
            };
        }

        private static double CompareSideBySide(Bitmap frame)
        {
            int halfWidth = frame.Width / 2;
            int quarterWidth = frame.Width / 4;

            var leftRect = new Rectangle(0, 0, quarterWidth, frame.Height);
            var rightRect = new Rectangle(halfWidth, 0, quarterWidth, frame.Height);

            leftRect = Shrink(leftRect, 0.02);
            rightRect = Shrink(rightRect, 0.02);

            double wholeScore = CompareRegions(frame, leftRect, rightRect, maxShiftX: maxShiftWide, maxShiftY: maxShiftTall);

            double topScore = CompareRegions(frame, HorizontalSlice(leftRect, 0), HorizontalSlice(rightRect, 0), maxShiftX: maxShiftWide, maxShiftY: maxShiftTall);
            double bottomScore = CompareRegions(frame, HorizontalSlice(leftRect, 1), HorizontalSlice(rightRect, 1), maxShiftX: maxShiftWide, maxShiftY: maxShiftTall);
            double highestScore = Math.Max(topScore, bottomScore);
            double lowestScore = Math.Min(topScore, bottomScore);

            double sectionAverage = lowestScore * 0.3 + highestScore * 0.7;

            double width = frame.Width;
            double height = frame.Height;

            double aspectRatio = Math.Max(width, height) / Math.Min(width, height);
            double penalty = AspectBasedPenalty(aspectRatio);

            return (wholeScore * 0.5 + sectionAverage * 0.5) * penalty;
        }

        private static double CompareTopBottom(Bitmap frame)
        {
            int halfHeight = frame.Height / 2;
            int quarterHeight = frame.Height / 4;

            var topRect = new Rectangle(0, 0, frame.Width, quarterHeight);

            var bottomRect = new Rectangle(0, halfHeight, frame.Width, quarterHeight);

            topRect = Shrink(topRect, 0.02);
            bottomRect = Shrink(bottomRect, 0.02);

            double wholeScore = CompareRegions(frame, topRect, bottomRect, maxShiftX: maxShiftWide, maxShiftY: maxShiftTall);

            double leftScore = CompareRegions(frame, VerticalSlice(topRect, 0), VerticalSlice(bottomRect, 0), maxShiftX: maxShiftWide, maxShiftY: maxShiftTall);
            double rightScore = CompareRegions(frame, VerticalSlice(topRect, 1), VerticalSlice(bottomRect, 1), maxShiftX: maxShiftWide, maxShiftY: maxShiftTall);

            double highestScore = Math.Max(leftScore, rightScore);
            double lowestScore = Math.Min(leftScore, rightScore);

            double sectionAverage = lowestScore * 0.3 + highestScore * 0.7;

            double width = frame.Width;
            double height = frame.Height;

            double aspectRatio = Math.Max(width, height) / Math.Min(width, height);
            double penalty = AspectBasedPenalty(aspectRatio);

            return (wholeScore * 0.5 + sectionAverage * 0.5) * penalty;
        }

        private static double CompareRegions(Bitmap frame, Rectangle rectA, Rectangle rectB, int maxShiftX, int maxShiftY)
        {
            //Comparison Size
            const int sampleWidth = 128;
            const int sampleHeight = 128;

            byte[] a = ExtractResizedLuma(frame, rectA, sampleWidth, sampleHeight);
            byte[] b = ExtractResizedLuma(frame, rectB, sampleWidth, sampleHeight);

            return BestNormalizedCorrelation(a, b, sampleWidth, sampleHeight, maxShiftX, maxShiftY);
        }

        private static byte[] ExtractResizedLuma(Bitmap source, Rectangle sourceRect, int outputWidth, int outputHeight)
        {
            Bitmap workingBitmap = null;

            try
            {
                if (source.PixelFormat != PixelFormat.Format32bppArgb)
                {
                    workingBitmap = new Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);

                    using (Graphics g = Graphics.FromImage(workingBitmap))
                    {
                        g.DrawImageUnscaled(source, 0, 0);
                    }
                }
                else
                {
                    workingBitmap = source;
                }

                var fullRect = new Rectangle(0, 0, workingBitmap.Width, workingBitmap.Height);

                BitmapData data = workingBitmap.LockBits(fullRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                try
                {
                    int stride = data.Stride;
                    int byteCount = Math.Abs(stride) * workingBitmap.Height;

                    byte[] pixels = new byte[byteCount];
                    Marshal.Copy(data.Scan0, pixels, 0, byteCount);

                    byte[] output = new byte[outputWidth * outputHeight];

                    for (int y = 0; y < outputHeight; y++)
                    {
                        double normalizedY = (y + 0.5) / outputHeight;
                        int srcY = sourceRect.Top + (int)(normalizedY * sourceRect.Height);

                        if (srcY < sourceRect.Top)
                            srcY = sourceRect.Top;

                        if (srcY >= sourceRect.Bottom)
                            srcY = sourceRect.Bottom - 1;

                        for (int x = 0; x < outputWidth; x++)
                        {
                            double normalizedX = (x + 0.5) / outputWidth;
                            int srcX = sourceRect.Left + (int)(normalizedX * sourceRect.Width);

                            if (srcX < sourceRect.Left)
                                srcX = sourceRect.Left;

                            if (srcX >= sourceRect.Right)
                                srcX = sourceRect.Right - 1;

                            int pixelIndex = srcY * stride + srcX * 4;

                            byte b = pixels[pixelIndex + 0];
                            byte g = pixels[pixelIndex + 1];
                            byte r = pixels[pixelIndex + 2];

                            byte luma = (byte)((77 * r + 150 * g + 29 * b) >> 8);

                            output[y * outputWidth + x] = luma;
                        }
                    }

                    return output;
                }
                finally
                {
                    workingBitmap.UnlockBits(data);
                }
            }
            finally
            {
                if (workingBitmap != null && !ReferenceEquals(workingBitmap, source))
                {
                    workingBitmap.Dispose();
                }
            }
        }

        private static double BestNormalizedCorrelation(byte[] a, byte[] b, int width, int height, int maxShiftX, int maxShiftY)
        {
            double best = -1.0;

            for (int shiftY = -maxShiftY; shiftY <= maxShiftY; shiftY++)
            {
                for (int shiftX = -maxShiftX; shiftX <= maxShiftX; shiftX++)
                {
                    double score = NormalizedCorrelationAtShift(a, b, width, height, shiftX, shiftY);

                    if (score > best)
                        best = score;
                }
            }

            // Convert from [-1, 1] to [0, 1].
            if (best < -0.999)
                return 0.0;

            return Math.Max(0.0, Math.Min(1.0, (best + 1.0) * 0.5));
        }

        private static double NormalizedCorrelationAtShift(byte[] a, byte[] b, int width, int height, int shiftX, int shiftY)
        {
            int startX = Math.Max(0, -shiftX);
            int endX = Math.Min(width, width - shiftX);

            int startY = Math.Max(0, -shiftY);
            int endY = Math.Min(height, height - shiftY);

            double sumA = 0.0;
            double sumB = 0.0;
            double sumAA = 0.0;
            double sumBB = 0.0;
            double sumAB = 0.0;

            int count = 0;

            for (int y = startY; y < endY; y++)
            {
                int yB = y + shiftY;

                int rowA = y * width;
                int rowB = yB * width;

                for (int x = startX; x < endX; x++)
                {
                    int xB = x + shiftX;

                    byte valueA = a[rowA + x];
                    byte valueB = b[rowB + xB];

                    //Ignore Black pixels
                    if (valueA < 8 && valueB < 8)
                        continue;

                    double da = valueA;
                    double db = valueB;

                    sumA += da;
                    sumB += db;
                    sumAA += da * da;
                    sumBB += db * db;
                    sumAB += da * db;

                    count++;
                }
            }

            if (count < 256)
                return -1.0;

            double numerator = sumAB - (sumA * sumB / count);

            double varianceA = sumAA - (sumA * sumA / count);
            double varianceB = sumBB - (sumB * sumB / count);

            double denominator = Math.Sqrt(varianceA * varianceB);

            if (denominator < 0.000001)
                return -1.0;

            return numerator / denominator;
        }

        private static double ComputeConfidence(double bestScore, double difference)
        {
            double scorePart = Clamp01((bestScore - 0.50) / 0.35); //0.55

            double differencePart = Clamp01(difference / 0.20);

            return scorePart * differencePart * 100.0;
        }
        private static Rectangle Shrink(Rectangle rect, double amount)
        {
            int dx = (int)(rect.Width * amount);
            int dy = (int)(rect.Height * amount);

            return new Rectangle(
                rect.Left + dx,
                rect.Top + dy,
                rect.Width - dx * 2,
                rect.Height - dy * 2
            );
        }
        private static Rectangle VerticalSlice(Rectangle rect, int index)
        {
            int sliceWidth = rect.Width / 4;
            int halfWidth = rect.Width / 2;

            int x = rect.Left + index * halfWidth + (halfWidth / 4);
            int width = sliceWidth;

            return new Rectangle(x, rect.Top, width, rect.Height);
        }
        private static Rectangle HorizontalSlice(Rectangle rect, int index)
        {
            int sliceHeight = rect.Height / 4;
            int halfHeight = rect.Height / 2;

            int y = rect.Top + index * halfHeight + (halfHeight / 4);
            int height = sliceHeight;

            return new Rectangle(rect.Left, y, rect.Width, height);
        }

        private static double Average(params double[] values)
        {
            if (values == null || values.Length == 0)
                return 0.0;

            double sum = 0.0;

            foreach (double value in values)
                sum += value;

            return sum / values.Length;
        }
        private static double Clamp01(double value)
        {
            if (value < 0.0)
                return 0.0;

            if (value > 1.0)
                return 1.0;

            return value;
        }
        private static double AspectBasedPenalty(double value, double maxPenalty = 0.50)
        {
            const double ideal = 2.00;
            const double lowerLimit = 1.70;
            const double upperLimit = 2.20;
            //const double maxPenalty = 0.50;

            double normalizedDifference;

            if (value == 1.00)
            {
                normalizedDifference = 0;
            }
            else if (value < ideal)
            {
                normalizedDifference = (ideal - value) / (ideal - lowerLimit);
            }
            else
            {
                normalizedDifference = (value - ideal) / (upperLimit - ideal);
            }

            normalizedDifference = Math.Clamp(normalizedDifference, 0.0, 1.0);

            double curvedDifference = normalizedDifference * normalizedDifference;

            double penalty = curvedDifference * maxPenalty;

            return (1.1 - penalty);
        }
        public static Bitmap GetVideoThumbnail(string filePath, int maxSize)
        {
            return GetVideoThumbnail(filePath, new System.Drawing.Size(maxSize, maxSize));
        }

        public static Bitmap GetVideoThumbnail(string filePath, System.Drawing.Size maxSize)
        {
            IntPtr hBitmap = IntPtr.Zero;
            IShellItemImageFactory? factory = null;

            try
            {
                Guid iid = typeof(IShellItemImageFactory).GUID;

                int hr = SHCreateItemFromParsingName(
                    filePath,
                    IntPtr.Zero,
                    ref iid,
                    out factory);

                if (hr != 0 || factory == null)
                    return SystemIcons.Application.ToBitmap();

                var size = new SIZE
                {
                    cx = maxSize.Width,
                    cy = maxSize.Height
                };

                const SIIGBF flags =
                    SIIGBF.SIIGBF_RESIZETOFIT |
                    SIIGBF.SIIGBF_THUMBNAILONLY;

                hr = factory.GetImage(size, flags, out hBitmap);

                if (hr != 0 || hBitmap == IntPtr.Zero)
                    return SystemIcons.Application.ToBitmap();

                using Bitmap temp = Image.FromHbitmap(hBitmap);

                // Clone it so the returned Bitmap is independent of the HBITMAP handle.
                return new Bitmap(temp);
            }
            catch
            {
                return null;
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                    DeleteObject(hBitmap);

                if (factory != null)
                    Marshal.ReleaseComObject(factory);
            }
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("BCC18B79-BA16-442F-80C4-8A59C30C463B")]
        private interface IShellItemImageFactory
        {
            int GetImage(SIZE size, SIIGBF flags, out IntPtr phbm);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE
        {
            public int cx;
            public int cy;
        }

        [Flags]
        private enum SIIGBF
        {
            SIIGBF_RESIZETOFIT = 0x00,
            SIIGBF_BIGGERSIZEOK = 0x01,
            SIIGBF_MEMORYONLY = 0x02,
            SIIGBF_ICONONLY = 0x04,
            SIIGBF_THUMBNAILONLY = 0x08,
            SIIGBF_INCACHEONLY = 0x10,
            SIIGBF_CROPTOSQUARE = 0x20,
            SIIGBF_WIDETHUMBNAILS = 0x40,
            SIIGBF_ICONBACKGROUND = 0x80,
            SIIGBF_SCALEUP = 0x100
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        private static extern int SHCreateItemFromParsingName(string pszPath, IntPtr pbc, ref Guid riid, out IShellItemImageFactory ppv);

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
    }

    public enum VrDetectionLayout
    {
        Unknown,
        SideBySide,
        TopBottom
    }

    public sealed class VrDetectionResults
    {
        public VrDetectionLayout Layout { get; set; }
        public double SbsScore { get; set; }
        public double TopBottomScore { get; set; }
        public double Confidence { get; set; }

        public override string ToString()
        {
            return $"{Layout} | SBS={SbsScore:0.000}, TB={TopBottomScore:0.000}, Confidence={Confidence:0.0}%";
        }
    }
}
