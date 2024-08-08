
namespace RandomVideoPlayer.Functions
{
    public static class Error
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");

        public static void Log(string customMessage)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine("Date: " + DateTime.Now.ToString());
                    writer.WriteLine("Custom Message: " + customMessage);
                    writer.WriteLine("---------------------------------------------------");
                }
            }
            catch (Exception loggingEx)
            {
                MessageBox.Show("An error occurred while logging: " + loggingEx.Message);
            }
        }
        public static void Log(Exception ex, string customMessage)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine("Date: " + DateTime.Now.ToString());
                    writer.WriteLine("Message: " + ex.Message);
                    writer.WriteLine("StackTrace: " + ex.StackTrace);
                    writer.WriteLine("Custom Message: " + customMessage);
                    writer.WriteLine("---------------------------------------------------");
                }
            }
            catch (Exception loggingEx)
            {
                MessageBox.Show("An error occurred while logging: " + loggingEx.Message);
            }
        }
    }
}
