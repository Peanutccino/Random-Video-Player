
using System.Text;

namespace RandomVideoPlayer.Functions
{
    public static class Error
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
        private static readonly object logLock = new object();
        public static void Log(string customMessage) =>
        WriteLog(writer =>
        {
            writer.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            writer.WriteLine("Custom Message: " + customMessage);
            writer.WriteLine("---------------------------------------------------");
        });

        public static void Log(Exception ex, string customMessage)=>
        WriteLog(writer =>
        {
            writer.WriteLine("Date: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            writer.WriteLine("Message: " + ex.Message);
            writer.WriteLine("StackTrace: " + ex.StackTrace);
            writer.WriteLine("Custom Message: " + customMessage);
            writer.WriteLine("---------------------------------------------------");
        });

        private static void WriteLog(Action<StreamWriter> logAction)
        {
            try
            {
                lock (logLock)
                {
                    using StreamWriter writer = new StreamWriter(logFilePath, true, Encoding.UTF8);
                    logAction(writer);
                }
            }
            catch (Exception loggingEx)
            {
                MessageBox.Show("An error occurred while logging: " + loggingEx.Message);
            }
        }
    }
}
