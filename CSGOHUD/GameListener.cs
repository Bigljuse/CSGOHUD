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
using CSGOHUD.Models.Player.Components;

namespace CSGOHUD
{
    public class GameListener
    {
        private readonly AutoResetEvent _waitForConnection = new AutoResetEvent(false);
        private HttpListener _listener;
        private string _json = String.Empty;
        private JObject _jString = new JObject();
        private GameStateModel _gamestate = new GameStateModel();


        public delegate void GameStateHandler(GameStateModel gameState);
        public event GameStateHandler GameStateChanged;

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
            _jString = JObject.Parse(_json) as JObject;

            if (_jString["provider"] != null)
                _gamestate.Provider = ProcessProvider(_jString["provider"] as JObject);

            if (_jString["map"] != null)
                _gamestate.Map = ProcessMap(_jString["map"] as JObject);

            if (_jString["round"] != null)
                _gamestate.Round = ProcessRound(_jString["round"] as JObject);

            if (_jString["player"] != null)
                _gamestate.Player = ProcessPlayer(_jString["player"] as JObject);

            //if (_jString["allplayers"] != null)
            //    _gamestate.AllPlayers = ProcessAllplayers();

            if (_jString["phase_countdowns"] != null)
                _gamestate.Phase_Countdowns = ProcessPreviously(_jString["phase_countdowns"] as JObject);

            GameStateChanged?.Invoke(_gamestate);
            _waitForConnection.Set();
        }

        private ProviderModel ProcessProvider(JObject jProvider)
        {
            return jProvider.ConvertToType(new ProviderModel());
        }

        private MapModel ProcessMap(JObject jMap)
        {
            JObject jTeam_CT = jMap["team_ct"] as JObject;
            JObject jTeam_T = jMap["team_t"] as JObject;
            MapModel map = jMap.ConvertToType(new MapModel());
            map.Team_CT = jTeam_CT.ConvertToType(new TeamModel());
            map.Team_T = jTeam_T.ConvertToType(new TeamModel());

            return map;
        }

        private RoundModel ProcessRound(JObject jRound)
        {
            return jRound.ConvertToType(new RoundModel());
        }

        private PlayerModel ProcessPlayer(JObject jPlayer)
        {
            JObject? jState = jPlayer["state"] as JObject;
            JObject? jMatch_stats = jPlayer["match_stats"] as JObject;
            JObject? jWeapons = jPlayer["weapons"] as JObject;

            PlayerModel player = jPlayer.ConvertToType(new PlayerModel());
            player.State = jState?.ConvertToType(new StateModel()) ?? new StateModel();
            player.Match_Stats = jMatch_stats?.ConvertToType(new Match_StatsModel()) ?? new Match_StatsModel();

            List<WeaponModel> weapons = new List<WeaponModel>();

            if (jWeapons == null || jWeapons.Count == 0)
                return player;

            for (int weaponNumber = 0; weaponNumber <= jWeapons.Count - 1; weaponNumber++)
            {
                JObject jWeapon = jWeapons[$"weapon_{weaponNumber}"] as JObject;

                if (jWeapon == null)
                    return player;

                WeaponModel weapon = jWeapon.ToObject<WeaponModel>();
                weapons.Add(weapon);
            }

            player.Weapons = weapons;

            return player;
        }

        private Phase_CountdownsModel ProcessPreviously(JObject jPreviousy)
        {
            return jPreviousy.ConvertToType(new Phase_CountdownsModel());
        }

        //private AllPlayersModel ProcessAllplayers(JObject jAllPlayers)
        //{
        //    AllPlayersModel allPlayers = new AllPlayersModel();
        //    JObject allPlayersObjects = JObject.Parse(_json)["allplayers"] as JObject;
        //    List<JToken> jTokenList = allPlayersObjects?.Values().ToList() ?? new List<JToken>();

        //    foreach (JToken jToken in jTokenList)
        //    {
        //        PlayerModel playerModel = jToken.ToObject<PlayerModel>();
        //        playerModel.SteamId = jToken.Path.Split(".")[1];
        //        ((List<PlayerModel>)allPlayers.Players).Add(playerModel);
        //    }

        //    return allPlayers;
        //}
    }
}
