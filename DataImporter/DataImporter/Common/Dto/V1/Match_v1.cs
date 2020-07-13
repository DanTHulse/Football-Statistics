using System;
using System.Collections.Generic;

namespace LocalImporter
{
    public partial class Match_v1
    {
        public Match_v1()
        {
            MatchData = new HashSet<MatchData_v1>();
        }

        public int MatchId { get; set; }
        public int CompetitionId { get; set; }
        public int SeasonId { get; set; }
        public DateTime MatchDate { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string MatchUid { get; set; }

        public virtual Team_v1 AwayTeam { get; set; }
        public virtual Competition_v1 Competition { get; set; }
        public virtual Team_v1 HomeTeam { get; set; }
        public virtual Season_v1 Season { get; set; }
        public virtual ICollection<MatchData_v1> MatchData { get; set; }
    }
}
