using CSGOHUD.Models.Player.Components;
using System.Collections.Generic;

namespace CSGOHUD.Models.Player
{
    public sealed class PlayerModel
    {
        public string Name { get; set; } = string.Empty;

        public string Clan { get; set; } = string.Empty;

        public string SteamId { get; set; } = string.Empty;

        public int Observer_slot { get; set; } = -1;

        public string Team { get; set; } = string.Empty;

        public string Activity { get; set; } = string.Empty;

        public StateModel State { get; set; } = new StateModel();

        public Match_StatsModel Match_Stats { get; set; } = new Match_StatsModel();

        public List<WeaponModel> Weapons { get; set; } = new List<WeaponModel>();

        public string Spectarget { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Forward { get; set; } = string.Empty;
    }
}
