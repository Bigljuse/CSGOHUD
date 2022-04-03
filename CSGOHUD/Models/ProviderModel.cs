namespace CSGOHUD.Models
{
    public sealed class ProviderModel
    {
        private string Name { get; set; } = string.Empty;

        private int AppId { get; set; } = 0;

        private int Version { get; set; } = 0;

        private string SteamId { get; set; } = string.Empty;

        private int TimeStamp { get; set; } = 0;
    }
}
