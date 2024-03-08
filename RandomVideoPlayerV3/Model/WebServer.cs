using System.Net;
using System.Text;

namespace RandomVideoPlayer.Model
{
    public class WebServer
    {
        private HttpListener listener;
        private Thread serverThread;
        private bool isRunning = false;
        private const string prefix = "http://127.0.0.1:13579/";
        public string filepath { get; set; } = "";//0
        public byte state { get; set; } = 2; //1  - State: 1 == Pause State: 2 == Play
        public string position { get; set; } = ""; //2
        public string duration { get; set; } = ""; //3
        public byte playbackrate { get; set; } = 1; //4
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

        public void Start()
        {
            if (!isRunning)
            {
                serverThread = new Thread(new ThreadStart(Run));
                isRunning = true;
                serverThread.Start();
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                isRunning = false;
                listener.Stop();
                serverThread.Join(); // Wait for the server thread to exit
            }
        }

        private void Run()
        {
            listener.Start();
            Console.WriteLine("Listening...");

            while (isRunning)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();

                    ProcessRequest(context);
                }
                catch (HttpListenerException) // Catch the exception when listener.Stop() is called
                {

                }
            }
        }

        private async void ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;

            try
            {
                if (request.RawUrl.Equals("/variables.html", StringComparison.OrdinalIgnoreCase))
                {
                    byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, filepath, state, position, duration, playbackrate));
                    context.Response.ContentType = "text/html";
                    context.Response.ContentLength64 = data.LongLength;

                    await context.Response.OutputStream.WriteAsync(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error creating timecode server:\n\n{0}", ex));
            }
            finally
            {
                context.Response.Close();
            }
        }
    }
}
