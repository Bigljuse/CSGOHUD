using System.Net;

namespace CSGO
{
    public class Listener
    {
        private readonly AutoResetEvent _ThreadState = new AutoResetEvent(false);
        private readonly HttpListener _httpListener = new HttpListener();

        private object locker = new();
        private bool _stopThread = false;
        private Thread? _thread = null;
        public IPEndPoint? IPEndPoint { get; private set; } = null;

        public delegate void MessageHandler(string jsonMessage);
        public event MessageHandler MessageRecieved = (gameState) => { };

        public Listener(string ip, int port)
        {
            IPEndPoint = IPEndPoint.Parse($"{ip}:{port}");
            _httpListener.Prefixes.Add(@$"http://{ip}:{port}/");
        }

        public void Start()
        {
            lock (locker)
            {
                if (_thread == null)
                    CreateNewThread();

                if (_httpListener.IsListening == false)
                    _httpListener.Start();

                if (_thread.ThreadState == ThreadState.Unstarted)
                    _thread.Start();

                if (_thread.ThreadState == ThreadState.Stopped)
                    RestartThread();
            }
        }

        public void Stop()
        {
            lock (locker)
            {
                _stopThread = true;
                _httpListener.Stop();
            }
        }

        private void CreateNewThread()
        {
            _thread = new Thread(Listen);
        }

        private bool WaitForThreadSopped()
        {
            while (true)
                if (_thread.ThreadState == ThreadState.Stopped)
                    return true;
        }

        private async void RestartThread()
        {
            _stopThread = false;
            await Task.Run(WaitForThreadSopped);
            CreateNewThread();
            _thread.Start();
        }

        private void Listen()
        {
            while (true)
            {
                if (_stopThread == true)
                    return;

                _httpListener.BeginGetContext(ReceiveGameState, _httpListener);

                _ThreadState.WaitOne();
                _ThreadState.Reset();
            }
        }

        private void ReceiveGameState(IAsyncResult asyncResult)
        {
            HttpListenerContext httpListenerContext = _httpListener.EndGetContext(asyncResult);
            HttpListenerRequest request = httpListenerContext.Request;

            using Stream inputStream = request.InputStream;
            using StreamReader streamReader = new StreamReader(inputStream);
            string _jsonMessage = streamReader.ReadToEnd();

            using HttpListenerResponse httpListenerResponse = httpListenerContext.Response;
            httpListenerResponse.StatusCode = (int)HttpStatusCode.OK;
            httpListenerResponse.StatusDescription = "OK";
            httpListenerResponse.Close();

            MessageRecieved.Invoke(_jsonMessage);
            _ThreadState.Set();
        }
    }
}
