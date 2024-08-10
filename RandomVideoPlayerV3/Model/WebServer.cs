using System.Net;
using System.Text;
using RandomVideoPlayer.Functions;

namespace RandomVideoPlayer.Model
{
    public class WebServer
    {
        private HttpListener listener;
        private Thread serverThread;
        private bool isRunning = false;
        private object lockObject = new object();

        private const string prefix = "http://127.0.0.1:13579/";

        public string File { get; set; } = "";          // = 0
        public string FilePathArg { get; set; } = "";   // = 1
        public string Filepath { get; set; } = "";      // = 2
        public string FileDir { get; set; } = "";       // = 3
        public byte State { get; set; } = 2;            // = 4  || State: 1 == Pause, State: 2 == Play, (State: 0 == Stop)
        public string Position { get; set; } = "";      // = 5
        public string Duration { get; set; } = "";      // = 6
        public string VolumeLevel { get; set; } = "5";  // = 7  || Fixed as it's not needed
        public byte Playbackrate { get; set; } = 1;     // = 8  || Maybe sync
        //HTML data for MFP to read
        private string pageData =
            "<!DOCTYPE>\n" +
            "<html>\n" +
            "<head>\n" +
            "   <title>RVP Variables</title>\n" +
            "</head>\n" +
            "<body class=\"page-variables\">\n" +
            "       <p id=\"file\">{0}</p>\n" +
            "       <p id=\"filepatharg\">{1}</p>\n" +
            "       <p id=\"filepath\">{2}</p>\n" +
            "       <p id=\"filedir\">{3}</p>\n" +
            "       <p id=\"state\">{4}</p>\n" +
            "       <p id=\"position\">{5}</p>\n" +
            "       <p id=\"duration\">{6}</p>\n" +
            "       <p id=\"volumelevel\">{7}</p>\n" +
            "       <p id=\"playbackrate\">{8}</p>\n" +
            "</body></html>";

        public WebServer()
        {
            listener = new HttpListener();
            listener.Prefixes.Add(prefix);
        }

        public bool IsRunning
        {
            get
            {
                lock (lockObject)
                {
                    return isRunning;
                }
            }
        }

        public event Action<string> OnLog;

        public void Start()
        {
            if (!isRunning)
            {
                serverThread = new Thread(new ThreadStart(Run));
                lock (lockObject)
                {
                    isRunning = true;
                }
                serverThread.Start();
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                lock (lockObject)
                {
                    isRunning = false;
                }
                listener.Stop();
                serverThread.Join(); // Wait for the server thread to exit
            }
        }

        private void Run()
        {
            listener.Start();
            //Log("Server started, listening...");

            while (isRunning)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    //Log($"Connection from {context.Request.RemoteEndPoint}");
                    ProcessRequest(context);
                }
                catch (HttpListenerException) // Catch the exception when listener.Stop() is called
                {

                }
            }
            //Log("Server stopped.");
        }

        private async void ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;

            try
            {
                if (request.RawUrl.Equals("/variables.html", StringComparison.OrdinalIgnoreCase))
                {
                    byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, File, FilePathArg, Filepath, FileDir, State, Position, Duration, VolumeLevel, Playbackrate));
                    context.Response.ContentType = "text/html";
                    context.Response.ContentLength64 = data.LongLength;

                    await context.Response.OutputStream.WriteAsync(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                //Log($"Error processing request: {ex.Message}");
                Error.Log(ex, "Error creating timecode server");
                MessageBox.Show(string.Format("Error creating timecode server:\n\n{0}", ex));
            }
            finally
            {
                context.Response.Close();
            }
        }

        private void Log(string message) //For debugging purposes
        {
            OnLog?.Invoke($"{DateTime.Now}: {message}");
        }
    }
}
