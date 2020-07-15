namespace LocalImporter.Models
{
    public class TeamGoalMap
    {
        public int HTAwayGoals { get; set; }
        public int HTHomeGoals { get; set; }
        public int FTHomeGoals { get; set; }
        public int FTAwayGoals { get; set; }
        public int HomeMatchTeamId { get; set; }
        public int AwayMatchTeamId { get; set; }
        public bool HalfTimeDataExists { get; set; }
        public bool FullTimeDataExists { get; set; }
        public int MatchDataId { get; set; }
    }
}
