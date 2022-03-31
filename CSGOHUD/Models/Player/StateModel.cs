namespace CSGOHUD.Models.Player
{
    public sealed class StateModel
    {
        public delegate void HealthHandler(int health);
        public event HealthHandler NameChanged = new HealthHandler((health) => { });

        public delegate void ArmorHandler(int armor);
        public event ArmorHandler ArmorChanged = new ArmorHandler((armor) => { });

        public delegate void HelmetHandler(bool helmet);
        public event HelmetHandler HelmetChanged = new HelmetHandler((helmet) => { });

        public delegate void FlashedHandler(int flashed);
        public event FlashedHandler FlashedChanged = new FlashedHandler((flashed) => { });

        public delegate void SmokedHandler(int smoked);
        public event SmokedHandler SmokedChanged = new SmokedHandler((smoked) => { });

        public delegate void BurningHandler(int burning);
        public event BurningHandler BurningChanged = new BurningHandler((burning) => { });

        public delegate void MoneyHandler(int money);
        public event MoneyHandler MoneyChanged = new MoneyHandler((money) => { });

        public delegate void Round_killsHandler(int round_kills);
        public event Round_killsHandler Round_killsChanged = new Round_killsHandler((round_kills) => { });

        public delegate void Round_killhsHandler(int round_killhs);
        public event Round_killhsHandler Round_killhsChanged = new Round_killhsHandler((round_killhs) => { });

        public delegate void Round_totaldmgHandler(int round_totaldmg);
        public event Round_totaldmgHandler Round_totaldmgChanged = new Round_totaldmgHandler((round_kills) => { });

        public delegate void Equip_valueHandler(int equip_value);
        public event Equip_valueHandler Equip_valueChanged = new Equip_valueHandler((round_kills) => { });

        public int _health { get; set; } = 0;

        public int Health
        {
            get { return _health; }
            set
            {
                if (_health == value)
                    return;
                _health = value;
                NameChanged?.Invoke(value);
            }
        }

        public int _armor { get; set; } = 0;

        public int Armor
        {
            get { return _armor; }
            set
            {
                if (_armor == value)
                    return;
                _armor = value;
                ArmorChanged?.Invoke(value);
            }
        }

        public bool _helmet { get; set; } = false;

        public bool Helmet
        {
            get { return _helmet; }
            set
            {
                if (_helmet == value)
                    return;
                _helmet = value;
                HelmetChanged?.Invoke(value);
            }
        }

        public int _flashed { get; set; } = 0;

        public int Flashed
        {
            get { return _flashed; }
            set
            {
                if (_flashed == value)
                    return;
                _flashed = value;
                FlashedChanged?.Invoke(value);
            }
        }

        public int _smoked { get; set; } = 0;

        public int Smoked
        {
            get { return _smoked; }
            set
            {
                if (_smoked == value)
                    return;
                _smoked = value;
                SmokedChanged?.Invoke(value);
            }
        }

        public int _burning { get; set; } = 0;

        public int Burning
        {
            get { return _burning; }
            set
            {
                if (_burning == value)
                    return;
                _burning = value;
                BurningChanged?.Invoke(value);
            }
        }

        public int _money { get; set; } = 0;

        public int Money
        {
            get { return _money; }
            set
            {
                if (_money == value)
                    return;
                _money = value;
                MoneyChanged?.Invoke(value);
            }
        }

        public int _round_kills { get; set; } = 0;

        public int Round_kills
        {
            get { return _round_kills; }
            set
            {
                if (_round_kills == value)
                    return;
                _round_kills = value;
                Round_killsChanged?.Invoke(value);
            }
        }

        public int _round_killhs { get; set; } = 0;

        public int Round_killhs
        {
            get { return _round_killhs; }
            set
            {
                if (_round_killhs == value)
                    return;
                _round_killhs = value;
                Round_killhsChanged?.Invoke(value);
            }
        }

        public int _round_totaldmg { get; set; } = 0;

        public int Round_totaldmg
        {
            get { return _round_totaldmg; }
            set
            {
                if (_round_totaldmg == value)
                    return;
                _round_totaldmg = value;
                Round_totaldmgChanged?.Invoke(value);
            }
        }

        public int _equip_value { get; set; } = 0;

        public int Equip_value
        {
            get { return _equip_value; }
            set
            {
                if (_equip_value == value)
                    return;
                _equip_value = value;
                Equip_valueChanged?.Invoke(value);
            }
        }
    }
}
