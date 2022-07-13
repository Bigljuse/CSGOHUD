namespace CSGOHUD.Models
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

        public int countdown { get; set; } = 0;

        public string Player { get; set; } = string.Empty;
    }
}
