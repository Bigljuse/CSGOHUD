using CSGO.Models.Map;
using CSGO.Models.Player;

namespace CSGO.Models
{
    public sealed class GameStateModel
    {
        public ProviderModel Provider { get; set; } = new ProviderModel();

        public MapModel Map { get; set; } = new MapModel();

        public RoundModel Round { get; set; } = new RoundModel();

        public PlayerModel Player { get; set; } = new PlayerModel();

        public Dictionary<string, PlayerModel> AllPlayers { get; set; } = new Dictionary<string, PlayerModel>();

        public Phase_CountdownsModel Phase_Countdowns { get; set; } = new Phase_CountdownsModel();

        public BombModel Bomb { get; set; } = new BombModel();

        public PreviouslyModel Previously { get; set; } = new PreviouslyModel();
    }
}
