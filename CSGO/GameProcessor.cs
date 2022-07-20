using CSGO.Models;
using CSGO.Models.Map;
using CSGO.Models.Player;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CSGO
{
    public static class GameProcessor
    {
        private static GameStateModel _gameState = new GameStateModel();

        public static GameStateModel ProcessGameState(string jsonMessage)
        {
            JsonNode? jsonCSGOData = JsonNode.Parse(jsonMessage);

            _gameState.Provider = GetProvider(jsonCSGOData["provider"]);
            _gameState.Map = GetMap(jsonCSGOData["map"]);
            _gameState.Round = GetRound(jsonCSGOData["round"]);
            _gameState.Player = GetPlayer(jsonCSGOData["player"]);
            _gameState.AllPlayers = GetAllPlayers(jsonCSGOData["allplayers"]);
            _gameState.Bomb = GetBomb(jsonCSGOData["bomb"]);
            _gameState.Phase_Countdowns = GetPhase(jsonCSGOData["phase_countdowns"]);

            return _gameState;
        }

        private static ProviderModel GetProvider(JsonNode? jsonProvider)
        {
            if (jsonProvider is null)
                return new ProviderModel();

            return jsonProvider.Deserialize<ProviderModel>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private static MapModel GetMap(JsonNode? jsonMap)
        {
            if (jsonMap is null)
                return new MapModel();

            return jsonMap.Deserialize<MapModel>(new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private static RoundModel GetRound(JsonNode? jsonRound)
        {
            if (jsonRound is null)
                return new RoundModel();

            return jsonRound.Deserialize<RoundModel>();
        }

        private static PlayerModel GetPlayer(JsonNode? jsonPlayer)
        {
            if (jsonPlayer is null)
                return new PlayerModel();

            return jsonPlayer.Deserialize<PlayerModel>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        private static BombModel GetBomb(JsonNode? jsonBomb)
        {
            if (jsonBomb is null)
                return new BombModel();

            return jsonBomb.Deserialize<BombModel>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        private static Phase_CountdownsModel GetPhase(JsonNode jsonPhase_CountdownsModel)
        {
            if (jsonPhase_CountdownsModel is null)
                return new Phase_CountdownsModel();

            return jsonPhase_CountdownsModel.Deserialize<Phase_CountdownsModel>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        private static Dictionary<string, PlayerModel> GetAllPlayers(JsonNode? jsonPlayers)
        {
            if (jsonPlayers is null)
                return new Dictionary<string, PlayerModel>();

            return jsonPlayers.Deserialize<Dictionary<string, PlayerModel>>(new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}