namespace CSGOHUD.Models.Player
{
    public sealed class PlayerModel
    {
        public string Name { get; set; } = string.Empty;

        public string SteamId { get; set; } = string.Empty;

        public int Observer_slot { get; set; } = 0;

        public string Team { get; set; } = string.Empty;

        public string Activity { get; set; } = string.Empty;

        public StateModel State { get; set; } = new StateModel();
    }
}
