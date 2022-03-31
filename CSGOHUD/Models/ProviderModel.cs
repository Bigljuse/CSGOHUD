namespace CSGOHUD.Models
{
    public sealed class ProviderModel
    {
        public delegate void NameHandler(string name);
        public event NameHandler NameChanged = new NameHandler((name) => { });

        public delegate void AppIdHandler(int appId);
        public event AppIdHandler AppIdChanged = new AppIdHandler((appId) => { });

        public delegate void VersionHandler(int version);
        public event VersionHandler VersionChanged = new VersionHandler((version) => { });

        public delegate void SteamIdHandler(string steamId);
        public event SteamIdHandler SteamIdChanged = new SteamIdHandler((steamId) => { });

        public delegate void TimeStampHandler(int steamId);
        public event TimeStampHandler TimeStampChanged = new TimeStampHandler((timeStamp) => { });

        private string _name { get; set; } = string.Empty;
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

        private int _appId { get; set; } = 0;
        public int AppId
        {
            get { return _appId; }
            set
            {
                if (_appId == value)
                    return;
                _appId = value;
                AppIdChanged?.Invoke(value);
            }
        }

        private int _version { get; set; } = 0;
        public int Version
        {
            get { return _version; }
            set
            {
                if (_version == value)
                    return;
                _version = value;
                AppIdChanged?.Invoke(value);
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

        private int _timeStamp { get; set; } = 0;
        public int TimeStamp
        {
            get { return _timeStamp; }
            set
            {
                if (_timeStamp == value)
                    return;
                _timeStamp = value;
                TimeStampChanged?.Invoke(value);
            }
        }
    }
}
