namespace CSGO.Models
{
    public sealed class ProviderModel
    {
        public string Name { get; set; } = string.Empty;

        public int AppId { get; set; } = 0;

        public int Version { get; set; } = 0;

        public string SteamId { get; set; } = string.Empty;

        public int TimeStamp { get; set; } = 0;
    }
}
