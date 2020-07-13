namespace LocalImporter
{
    public partial class MatchData_v1
    {
        public int MatchDataId { get; set; }
        public int MatchId { get; set; }
        public int? FthomeGoals { get; set; }
        public int? FtawayGoals { get; set; }
        public string Ftresult { get; set; }
        public int? HthomeGoals { get; set; }
        public int? HtawayGoals { get; set; }
        public string Htresult { get; set; }
        public int? HomeShots { get; set; }
        public int? AwayShots { get; set; }
        public int? HomeShotsOnTarget { get; set; }
        public int? AwayShotsOnTarget { get; set; }

        public virtual Match_v1 Match { get; set; }
    }
}
