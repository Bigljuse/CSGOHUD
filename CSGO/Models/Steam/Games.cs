namespace CSGO.Models.Steam
{
    public sealed class Games
    {
        public static readonly Dictionary<GameID, string> Dictionary = new Dictionary<GameID, string>()
        {
            {GameID.CSGO, "Counter-Strike Global Offensive" }
        };
    }
}
