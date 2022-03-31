namespace CSGOHUD.Models.Map
{
    public sealed class TeamModel
    {
        public delegate void ScoreHandler(string score);
        public event ScoreHandler ScoreChanged = new ScoreHandler((score) => { });

        public delegate void Consecutive_Round_LossesHandler(string consecutive_Round_Losses);
        public event Consecutive_Round_LossesHandler Consecutive_Round_LossesChanged = new Consecutive_Round_LossesHandler((consecutive_Round_Losses) => { });

        public delegate void Timeouts_RemainingHandler(string timeouts_Remaining);
        public event Timeouts_RemainingHandler Timeouts_RemainingChanged = new Timeouts_RemainingHandler((timeouts_Remaining) => { });
        
        public delegate void Matches_Won_This_SeriesHandler(string matches_Won_This_Series);
        public event Matches_Won_This_SeriesHandler Matches_Won_This_SeriesChanged = new Matches_Won_This_SeriesHandler((matches_Won_This_Series) => { });

        public int Score { get; set; } = 0;

        public int Consecutive_Round_Losses { get; set; } = 0;

        public int Timeouts_Remaining { get; set; } = 0;

        public int Matches_Won_This_Series { get; set; } = 0;
    }
}
