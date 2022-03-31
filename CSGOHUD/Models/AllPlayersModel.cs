using CSGOHUD.Models.Player;
using System.Collections.Generic;

namespace CSGOHUD.Models
{
    public sealed class AllPlayersModel
    {
        public IEnumerable<PlayerModel> Players { get; set; } = new List<PlayerModel>();
    }
}
