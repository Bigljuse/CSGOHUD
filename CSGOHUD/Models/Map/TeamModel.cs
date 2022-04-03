namespace CSGOHUD.Models.Map
{
    public sealed class TeamModel
    {
        public int Score { get; set; } = 0;

        public int Consecutive_Round_Losses { get; set; } = 0;

        public int Timeouts_Remaining { get; set; } = 0;

        public int Matches_Won_This_Series { get; set; } = 0;
    }
}
