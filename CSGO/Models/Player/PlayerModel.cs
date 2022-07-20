namespace CSGO.Models.Player
{
    public sealed partial class PlayerModel
    {
        public bool ActivityChanged { get; private set; } = false;

        public bool NameChanged { get; private set; } = false;

        private string _activity = string.Empty;

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

        public Dictionary<string, WeaponModel> Weapons { get; set; } = new Dictionary<string, WeaponModel>();

        public string Spectarget { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Forward { get; set; } = string.Empty;
    }
}
