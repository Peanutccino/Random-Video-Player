using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                ApplicationConfiguration.Initialize();

                string filePath = args.Length > 0 ? args[0] : string.Empty;
                Application.Run(new MainForm(filePath));
            }
            catch (Exception ex)
            {
                Error.Log(ex, "Failed to start application");
                MessageBox.Show($"Exception: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}