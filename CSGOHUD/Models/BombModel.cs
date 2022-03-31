using CSGOHUD.Models.Player;
namespace CSGOHUD.Models
{
    public sealed class BombModel
    {
        public string State { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public PlayerModel Player { get; set; } = new PlayerModel();
    }
}
