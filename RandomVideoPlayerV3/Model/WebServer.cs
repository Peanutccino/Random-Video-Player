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
        public string Filepath { get; set; } = "";//0
        public byte State { get; set; } = 2; //1  - State: 1 == Pause State: 2 == Play
        public string Position { get; set; } = ""; //2
        public string Duration { get; set; } = ""; //3
        public byte Playbackrate { get; set; } = 1; //4
        //HTML data for MFP to read
        private string pageData =
            "<!DOCTYPE>\n" +
            "<html>\n" +
            "<head>\n" +
            "   <title>RVP Variables</title>\n" +
            "</head>\n" +
            "<body class=\"page-variables\">\n" +
            "       <p id=\"filepath\">{0}</p>\n" +
            "       <p id=\"state\">{1}</p>\n" +
            "       <p id=\"position\">{2}</p>\n" +
            "       <p id=\"duration\">{3}</p>\n" +
            "       <p id=\"playbackrate\">{4}</p>\n" +
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
                    byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, Filepath, State, Position, Duration, Playbackrate));
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
