using CSGOHUD.Models.Enums;
using CSGOHUD.Models.Player;

namespace CSGOHUD.Models.Extensions
{
    public static class PlayerModelExtension
    {
        public static PlayerTeam GetTeam(this PlayerModel player)
        {
            if (player.Team == "CT")
                return PlayerTeam.CT;
            if (player.Team == "T")
                return PlayerTeam.T;
            if (string.IsNullOrWhiteSpace(player.Team))
                return PlayerTeam.None;
            return PlayerTeam.None;
        }
    }
}
