namespace CSGOHUD.Models
{
    public sealed class RoundModel
    {
        public bool BombChanged { get; private set; } = false;
        public bool PhaseChanged { get; private set; } = false;

        public string Win_Team { get; set; } = string.Empty;

        private string _phase = string.Empty;
        public string Phase
        {
            get { return _bomb; }
            set
            {
                if (_phase == value)
                    PhaseChanged = false;
                else
                {
                    PhaseChanged = true;
                    _phase = value;
                }
            }
        }

        private string _bomb = string.Empty;
        public string Bomb
        {
            get { return _bomb; }
            set
            {
                if (_bomb == value)
                    BombChanged = false;
                else
                {
                    BombChanged = true;
                    _bomb = value;
                }
            }
        }
    }
}
