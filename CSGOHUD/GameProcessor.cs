using CSGOHUD.Models;
using CSGOHUD.Models.Player;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace CSGOHUD
{
    public class GameProcessor
    {
        private JObject _jGameState = new JObject();
        private GameStateModel _gameState = new GameStateModel();

        public GameProcessor()
        {
        }

        public GameStateModel ProcessGameState(string jsonMessage)
        {
            _jGameState = JObject.Parse(jsonMessage);

            if (_jGameState["provider"] != null)
                ProcessProvider(_jGameState["provider"] as JObject);

            if (_jGameState["map"] != null)
                ProcessMap(_jGameState["map"] as JObject);

            if (_jGameState["round"] != null)
                ProcessRound(_jGameState["round"] as JObject);

            if (_jGameState["player"] != null)
                ProcessPlayer(_jGameState["player"] as JObject, true);

            if (_jGameState["bomb"] != null)
                ProcessBomb(_jGameState["bomb"] as JObject);

            if (_jGameState["allplayers"] != null)
                ProcessPlayers(_jGameState["allplayers"] as JObject);

            if (_jGameState["phase_countdowns"] != null)
                ProcessPhaseCountdowns(_jGameState["phase_countdowns"] as JObject);

            return _gameState;
        }

        private void ProcessProvider(JObject jProvider) => jProvider.ExtractSimpleDataTo(_gameState.Provider);

        private void ProcessBomb(JObject jProvider) => jProvider.ExtractSimpleDataTo(_gameState.Bomb);

        private void ProcessMap(JObject jMap)
        {
            JObject jTeam_CT = jMap["team_ct"] as JObject;
            JObject jTeam_T = jMap["team_t"] as JObject;

            jMap.ExtractSimpleDataTo(_gameState.Map);
            jTeam_CT.ExtractSimpleDataTo(_gameState.Map.Team_CT);
            jTeam_T.ExtractSimpleDataTo(_gameState.Map.Team_T);
        }

        private void ProcessRound(JObject jRound)
        {
            jRound.ExtractSimpleDataTo(_gameState.Round);
        }

        private PlayerModel ProcessPlayer(JObject jPlayer, bool processSpectatedPlayer = false)
        {
            PlayerModel? player = null;

            string jPlayerName = jPlayer.Property("name")?.Value.ToString() ?? string.Empty;

            if (processSpectatedPlayer == true)
                player = _gameState.Player;
            else
                player = _gameState.Players.Find(x => x.Name == jPlayerName) ?? new PlayerModel();

            if (player == null)
                return new PlayerModel();

            jPlayer.ExtractSimpleDataTo(player);

            JObject? jState = jPlayer["state"] as JObject;
            if (jState != null)
                jState?.ExtractSimpleDataTo(player.State);

            JObject? jMatch_stats = jPlayer["match_stats"] as JObject;
            if (jMatch_stats != null)
                jMatch_stats?.ExtractSimpleDataTo(player.Match_Stats);

            JObject? jWeapons = jPlayer["weapons"] as JObject;
            if (jWeapons != null)
                player.Weapons = JObjectConverter.ExtractPlayerWeapons(jWeapons);

            return player;
        }

        private void ProcessPhaseCountdowns(JObject jPreviousy)
        {
            jPreviousy.ExtractSimpleDataTo(_gameState.Phase_Countdowns);
        }

        private void ProcessPlayers(JObject jPlayers)
        {
            List<JToken> jChildren = jPlayers.Children().ToList();
            List<PlayerModel> players = new List<PlayerModel>();

            foreach (JToken jPlayer in jChildren)
                players.Add(ProcessPlayer(jPlayer.First as JObject));

            _gameState.Players = players;
        }
    }
}
