using CSGOHUD.Models.Player.Components;
using System.Collections.Generic;

namespace CSGOHUD.Models.Player
{
    public sealed partial class PlayerModel
    {
        public bool ActivityChanged { get; private set; } = false;
        public bool NameChanged { get; private set; } = false;

        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    NameChanged = false;
                else
                {
                    NameChanged = true;
                    _name = value;
                }
            }
        }

        public string Clan { get; set; } = string.Empty;

        public string SteamId { get; set; } = string.Empty;

        public int Observer_slot { get; set; } = -1;

        public string Team { get; set; } = string.Empty;

        private string _activity = string.Empty;
        public string Activity
        {
            get { return _activity; }
            set
            {
                if (_activity == value)
                    ActivityChanged = false;
                else
                {
                    ActivityChanged = true;
                    _activity = value;
                }
            }
        }

        public StateModel State { get; set; } = new StateModel();

        public Match_StatsModel Match_Stats { get; set; } = new Match_StatsModel();

        public List<WeaponModel> Weapons { get; set; } = new List<WeaponModel>();

        public string Spectarget { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Forward { get; set; } = string.Empty;
    }
}
