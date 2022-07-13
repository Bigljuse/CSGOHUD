using CSGOHUD.Models;
using System;
using System.IO;
using System.Net;
using System.Threading;
using Settings = CSGOHUD.Properties.Settings;

namespace CSGOHUD
{
    public class GameListener
    {
        private readonly AutoResetEvent _ThreadState = new AutoResetEvent(false);
        private bool _stopThread = false;
        private HttpListener _httpListener = new HttpListener();
        private Thread _threadListener;

        private GameProcessor _gameProcessor = new GameProcessor();

        public delegate void GameStateHandler(GameStateModel gameState);
        public event GameStateHandler GameStateProcessedEvent = (gameState) => { };

        public GameListener()
        {
            _threadListener = new Thread(Listen);
            _httpListener.Prefixes.Add(Settings.Default.HTTPAdress);
        }

        public void Start()
        {
            if (_httpListener.IsListening == false)
                _httpListener.Start();

            if (_threadListener.ThreadState == ThreadState.Unstarted)
                _threadListener.Start();

            if (_threadListener.ThreadState == ThreadState.Stopped)
            {
                _stopThread = false;
                _threadListener = new Thread(Listen);
                _threadListener.Start();
            }
        }

        public void Stop()
        {
            _stopThread = true;
            _httpListener.Stop();
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
            string jsonMessage = streamReader.ReadToEnd();

            using HttpListenerResponse httpListenerResponse = httpListenerContext.Response;
            httpListenerResponse.StatusCode = (int)HttpStatusCode.OK;
            httpListenerResponse.StatusDescription = "OK";
            httpListenerResponse.Close();

            GameStateProcessedEvent.Invoke(_gameProcessor.ProcessGameState(jsonMessage));
            _ThreadState.Set();
        }
    }
}
