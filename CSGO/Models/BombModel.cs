namespace CSGO.Models
{
    public sealed class BombModel
    {
        public bool StateChanged { get; private set; } = false;

        private string _state = string.Empty;

        public string State
        {
            get { return _state; }
            set
            {
                if (_state == value)
                    StateChanged = false;
                else
                {
                    StateChanged = true;
                    _state = value;
                }
            }
        }

        public string Position { get; set; } = string.Empty;

        public string countdown { get; set; } = string.Empty;

        public Int64 Player { get; set; } = 0;
    }
}
