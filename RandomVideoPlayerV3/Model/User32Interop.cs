using System.ComponentModel;
using System.Runtime.InteropServices;

namespace RandomVideoPlayerV3.Model
{
    public static class User32Interop
    {
        public static TimeSpan GetLastInput()
        {
            var plii = new LASTINPUTINFO();
            plii.cbSize = (uint)Marshal.SizeOf(plii);

            if (GetLastInputInfo(ref plii))
                return TimeSpan.FromMilliseconds(Environment.TickCount - plii.dwTime);
            else
                throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }
    }
}
