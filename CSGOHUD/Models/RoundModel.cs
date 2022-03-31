using CSGOHUD.Models.Player;

namespace CSGOHUD.Models
{
    public sealed class RoundModel
    {
        public string Phase { get; set; } = string.Empty;

        public string Win_Team { get; set; } = string.Empty;

        public string Bomb { get; set; } = string.Empty;

        public PlayerModel Player { get; set; } = new PlayerModel();
    }
}
