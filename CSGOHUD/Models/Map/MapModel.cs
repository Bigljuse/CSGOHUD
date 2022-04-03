namespace CSGOHUD.Models.Map
{
    public sealed class MapModel
    {
        public string Mode { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Phase { get; set; } = string.Empty;

        public int Round { get; set; } = 0;

        public TeamModel Team_CT { get; set; } = new TeamModel();

        public TeamModel Team_T { get; set; } = new TeamModel();

        public int Num_Matches_To_Win_Series { get; set; } = 0;

        public int Current_Spectators { get; set; } = 0;

        public int Souvenirs_Total { get; set; } = 0;
    }
}
