namespace CSGOHUD.Models.Player
{
    public sealed class PlayerModel
    {
        public delegate void NameHandler(string name);
        public event NameHandler NameChanged = new NameHandler((name) => { });

        public delegate void SteamIdHandler(string steamId);
        public event SteamIdHandler SteamIdChanged = new SteamIdHandler((steamId) => { });

        public delegate void Observer_slotHandler(int observer_slot);
        public event Observer_slotHandler Observer_slotChanged = new Observer_slotHandler((observer_slot) => { });

        public delegate void TeamHandler(string team);
        public event TeamHandler TeamChanged = new TeamHandler((team) => { });

        public delegate void ActivityHandler(string activity);
        public event ActivityHandler ActivityChanged = new ActivityHandler((activity) => { });

        public delegate void VersionHandler(int version);
        public event VersionHandler VersionChanged = new VersionHandler((version) => { });

        public delegate void TimeStampHandler(int steamId);
        public event TimeStampHandler TimeStampChanged = new TimeStampHandler((timeStamp) => { });


        public string _name { get; set; } = string.Empty;

        public string Name 
        {
            get { return _name; } 
            set
            {
                if (_name == value)
                    return;
                _name = value;
                NameChanged?.Invoke(value);
            } 
        }

        private string _steamId { get; set; } = string.Empty;

        public string SteamId
        {
            get { return _steamId; }
            set
            {
                if (_steamId == value)
                    return;
                _steamId = value;
                SteamIdChanged?.Invoke(value);
            }
        }

        private int _observer_slot { get; set; } = 0;

        public int Observer_slot 
        {
            get { return _observer_slot; }
            set
            {
                if (_observer_slot == value)
                    return;
                _observer_slot = value;
                Observer_slotChanged?.Invoke(_observer_slot);
            }
        }

        public string _team { get; set; } = string.Empty;

        public string Team
        {
            get { return _team; }
            set
            {
                if (_team == value)
                    return;
                _team = value;
                TeamChanged?.Invoke(value);
            }
        }

        public string _activity { get; set; } = string.Empty;

        public string Activity
        {
            get { return _activity; }
            set
            {
                if (_activity == value)
                    return;
                _activity = value;
                ActivityChanged?.Invoke(value);
            }
        }

        public StateModel State { get; set; } = new StateModel();
    }
}
