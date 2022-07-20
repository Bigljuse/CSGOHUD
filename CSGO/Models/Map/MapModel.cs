namespace CSGO.Models.Map
{
    public sealed class MapModel
    {
        public bool RoundChanged { get; private set; } = true;

        public string Mode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Phase { get; set; } = string.Empty;

        private int _round = -1;

        public int Round
        {
            get { return _round; }
            set
            {
                if (_round == value)
                    RoundChanged = false;
                else
                {
                    RoundChanged = true;
                    _round = value;
                }
            }
        }

        public Dictionary<string, string> Round_wins { get; set; } = new Dictionary<string, string>();

        public TeamModel Team_CT { get; set; } = new TeamModel();

        public TeamModel Team_T { get; set; } = new TeamModel();

        public int Num_Matches_To_Win_Series { get; set; } = 0;

        public int Current_Spectators { get; set; } = 0;

        public int Souvenirs_Total { get; set; } = 0;
    }
}
