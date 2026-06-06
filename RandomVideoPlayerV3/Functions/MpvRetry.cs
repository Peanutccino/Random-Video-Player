using Mpv.NET.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class MpvRetry
    {
        public static async Task<double> GetPropertyDoubleRetryAsync(MpvPlayer mpv, string propertyName, int pollDelayMs = 25, int timeoutMs = 500, CancellationToken ct = default)
        {
            var sw = Stopwatch.StartNew();
            Exception lastError = null;

            while (sw.ElapsedMilliseconds < timeoutMs)
            {
                ct.ThrowIfCancellationRequested();

                try
                {
                    return mpv.API.GetPropertyDouble(propertyName);
                }
                catch (Exception ex)
                {
                    Error.Log(ex, $"Error getting mpv property '{propertyName}'", LogLevel.Debug);
                    lastError = ex;
                }

                await Task.Delay(pollDelayMs, ct).ConfigureAwait(false);
            }

            throw new TimeoutException(
                $"Timed out after {timeoutMs} ms waiting for mpv property '{propertyName}'.",
                lastError);
        }

    }
}
