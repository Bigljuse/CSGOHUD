namespace CSGOHUD.Models.Player.Components
{
    public sealed class StateModel
    {
        public int Health { get; set; } = 0;

        public int Armor { get; set; } = 0;

        public bool Helmet { get; set; } = false;

        public int Flashed { get; set; } = 0;

        public int Smoked { get; set; } = 0;

        public bool defusekit { get; set; } = false;

        public int Burning { get; set; } = 0;

        public int Money { get; set; } = 0;

        public int Round_kills { get; set; } = 0;

        public int Round_killhs { get; set; } = 0;

        public int Round_totaldmg { get; set; } = 0;

        public int Equip_value { get; set; } = 0;
    }
}
