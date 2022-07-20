namespace CSGO.Models.Steam
{
    public sealed class LibraryModel
    {
        public string Path { get; set; } = String.Empty;

        public string Label { get; set; } = String.Empty;

        public string Contentid { get; set; } = String.Empty;

        public string Totalsize { get; set; } = String.Empty;

        public string Update_clean_bytes_tally { get; set; } = String.Empty;

        public string Time_last_update_corruption { get; set; } = String.Empty;

        public Dictionary<string, string> Apps { get; set; } = new Dictionary<string, string>();
    }
}
