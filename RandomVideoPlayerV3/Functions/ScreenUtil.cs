using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomVideoPlayer.Functions
{
    public static class ScreenUtil
    {
        public static Screen GetScreenForFormThreadSafe(Form form, Screen fallback = null)
        {
            fallback ??= Screen.PrimaryScreen;
            if (form == null) return fallback;

            try
            {
                if (form.IsDisposed || form.Disposing) return fallback;

                Func<Screen> get = () =>
                {
                    if (form.IsDisposed || form.Disposing) return fallback;

                    if (form.IsHandleCreated)
                        return Screen.FromHandle(form.Handle);

                    return Screen.FromRectangle(form.Bounds);
                };

                if (form.IsHandleCreated && form.InvokeRequired)
                    return (Screen)form.Invoke(get);

                return get();
            }
            catch (ObjectDisposedException)
            {
                Error.Log("Form was disposed while trying to get screen. Returning fallback.", LogLevel.Debug);
                return fallback;
            }
            catch (InvalidOperationException)
            {
                Error.Log("Form was in an invalid state while trying to get screen. Returning fallback.", LogLevel.Debug);
                return fallback;
            }
        }
    }
}
