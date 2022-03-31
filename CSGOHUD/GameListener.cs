using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Linq;

using Newtonsoft.Json.Linq;

using CSGOHUD.Models;
using CSGOHUD.Models.Map;
using CSGOHUD.Models.Player;
using System.Collections.Generic;
using System.Reflection;

namespace CSGOHUD
{
    public class GameListener
    {
        private readonly AutoResetEvent _waitForConnection = new AutoResetEvent(false);
        private HttpListener _listener;
        private string _json = String.Empty;
        private GameStateModel _gamestate = new GameStateModel();


        public delegate void GameStateHandler(GameStateModel gameState);
        public event GameStateHandler GameStateChanged;

        public delegate void TextHandler(string text);
        public event TextHandler TextChanged;

        public GameListener()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:3000/");

            Thread thread = new Thread(Run);
            _listener.Start();
            thread.Start();
        }

        private void Run()
        {
            while (true)
            {
                _listener.BeginGetContext(ReceiveGameState, _listener);
                _waitForConnection.WaitOne();
                _waitForConnection.Reset();
            }
        }

        private void ReceiveGameState(IAsyncResult asyncResult)
        {
            HttpListenerContext httpListenerContext = _listener.EndGetContext(asyncResult);
            HttpListenerRequest request = httpListenerContext.Request;
            using (Stream inputStream = request.InputStream)
            {
                using (StreamReader streamReader = new StreamReader(inputStream))
                {
                    _json = streamReader.ReadToEnd();
                }
            }
            using (HttpListenerResponse httpListenerResponse = httpListenerContext.Response)
            {
                httpListenerResponse.StatusCode = (int)HttpStatusCode.OK;
                httpListenerResponse.StatusDescription = "OK";
                httpListenerResponse.Close();
            }

            ProcessGameState();
        }

        private void ProcessGameState()
        {
            ProcessProvider();
            _gamestate.Map = ProcessMap();
            _gamestate.Round = ProcessRound();
            _gamestate.Player = ProcessPlayer();
            _gamestate.AllPlayers = ProcessAllplayers();
            _gamestate.Phase_Countdowns = ProcessPreviously();

            GameStateChanged?.Invoke(_gamestate);
            TextChanged?.Invoke(_json);
            _waitForConnection.Set();
        }

        private void ProcessProvider()
        {
            JObject providerJObject = JObject.Parse(_json)["provider"] as JObject;
            ProviderModel provider = providerJObject?.ToObject<ProviderModel>() ?? new ProviderModel();
            
            PropertyInfo[] provider_Properties = typeof(ProviderModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo provider_Property in provider_Properties)
            {
                PropertyInfo gameState_Property = _gamestate.Provider.GetType().GetProperty(provider_Property.Name);

                if (gameState_Property is null)
                    continue;

                gameState_Property.SetValue(_gamestate.Provider, provider_Property.GetValue(provider));
            }
        }

        private MapModel ProcessMap()
        {
            JObject map = JObject.Parse(_json)["map"] as JObject;
            return map?.ToObject<MapModel>() ?? new MapModel();
        }

        private RoundModel ProcessRound()
        {
            JObject round = JObject.Parse(_json)["round"] as JObject;
            return round?.ToObject<RoundModel>() ?? new RoundModel();
        }

        private PlayerModel ProcessPlayer()
        {
            JObject player = JObject.Parse(_json)["player"] as JObject;
            return player?.ToObject<PlayerModel>() ?? new PlayerModel();
        }

        private Phase_CountdownsModel ProcessPreviously()
        {
            JObject player = JObject.Parse(_json)["phase_countdowns"] as JObject;
            return player?.ToObject<Phase_CountdownsModel>() ?? new Phase_CountdownsModel();
        }

        private AllPlayersModel ProcessAllplayers()
        {
            AllPlayersModel allPlayers = new AllPlayersModel();
            JObject allPlayersObjects = JObject.Parse(_json)["allplayers"] as JObject;
            List<JToken> jTokenList = allPlayersObjects?.Values().ToList() ?? new List<JToken>();

            foreach (JToken jToken in jTokenList)
            {
                PlayerModel playerModel = jToken.ToObject<PlayerModel>();
                playerModel.SteamId = jToken.Path.Split(".")[1];
                ((List<PlayerModel>)allPlayers.Players).Add(playerModel);
            }

            return allPlayers;
        }
    }
}
