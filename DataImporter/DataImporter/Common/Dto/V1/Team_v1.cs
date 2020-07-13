using System.Collections.Generic;

namespace LocalImporter
{
    public partial class Team_v1
    {
        public Team_v1()
        {
            MatchAwayTeam = new HashSet<Match_v1>();
            MatchHomeTeam = new HashSet<Match_v1>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string AlternateTeamName { get; set; }
        public string TeamLogo { get; set; }

        public virtual ICollection<Match_v1> MatchAwayTeam { get; set; }
        public virtual ICollection<Match_v1> MatchHomeTeam { get; set; }
    }
}
