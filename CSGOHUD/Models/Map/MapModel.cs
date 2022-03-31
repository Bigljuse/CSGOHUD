namespace CSGOHUD.Models.Map
{
    public sealed class MapModel
    {
        public delegate void ModeHandler(string mode);
        public event ModeHandler ModeChanged = new ModeHandler((mode) => { });

        public delegate void NameHandler(string name);
        public event NameHandler NameChanged = new NameHandler((name) => { });

        public delegate void PhaseHandler(string phase);
        public event PhaseHandler PhaseChanged = new PhaseHandler((phase) => { });

        public delegate void RoundHandler(int round);
        public event RoundHandler RoundChanged = new RoundHandler((round) => { });

        public delegate void Num_Matches_To_Win_SeriesHandler(int num_Matches_To_Win_Series);
        public event Num_Matches_To_Win_SeriesHandler Num_Matches_To_Win_SeriesChanged = new Num_Matches_To_Win_SeriesHandler((num_Matches_To_Win_Series) => { });

        public delegate void Current_SpectatorsHandler(int num_Matches_To_Win_Series);
        public event Current_SpectatorsHandler Current_SpectatorsChanged = new Current_SpectatorsHandler((current_Spectators) => { });

        public delegate void Souvenirs_TotalHandler(int souvenirs_Total);
        public event Souvenirs_TotalHandler Souvenirs_TotalChanged = new Souvenirs_TotalHandler((souvenirs_Total) => { });

        public string _mode { get; set; } = string.Empty;

        public string Mode
        {
            get { return _mode; }
            set
            {
                if (_mode == value)
                    return;
                _mode = value;
                ModeChanged?.Invoke(_mode);
            }
        }

        public string _name { get; set; } = string.Empty;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                NameChanged?.Invoke(_name);
            }
        }

        public string _phase { get; set; } = string.Empty;

        public string Phase
        {
            get { return _phase; }
            set
            {
                if (_phase == value)
                    return;
                _phase = value;
                PhaseChanged?.Invoke(_phase);
            }
        }

        public int _round { get; set; } = 0;

        public int Round
        {
            get { return _round; }
            set
            {
                if (_round == value)
                    return;
                _round = value;
                RoundChanged?.Invoke(_round);
            }
        }

        public TeamModel Team_CT { get; set;} = new TeamModel();

        public TeamModel Team_T { get; set;} = new TeamModel();

        public int _num_Matches_To_Win_Series { get; set; } = 0;

        public int Num_Matches_To_Win_Series
        {
            get { return _num_Matches_To_Win_Series; }
            set
            {
                if (_num_Matches_To_Win_Series == value)
                    return;
                _num_Matches_To_Win_Series = value;
                Num_Matches_To_Win_SeriesChanged?.Invoke(_num_Matches_To_Win_Series);
            }
        }

        public int _current_Spectators { get; set; } = 0;

        public int Current_Spectators
        {
            get { return _current_Spectators; }
            set
            {
                if (_current_Spectators == value)
                    return;
                _current_Spectators = value;
                Current_SpectatorsChanged?.Invoke(_current_Spectators);
            }
        }

        public int _souvenirs_Total { get; set; } = 0;

        public int Souvenirs_Total
        {
            get { return _souvenirs_Total; }
            set
            {
                if (_souvenirs_Total == value)
                    return;
                _souvenirs_Total = value;
                Souvenirs_TotalChanged?.Invoke(_souvenirs_Total);
            }
        }
    }
}
