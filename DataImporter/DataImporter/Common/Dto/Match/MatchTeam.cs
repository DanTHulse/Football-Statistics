using System.Collections.Generic;
using DataImporter.Common.Dto.Teams;

namespace DataImporter.Common.Dto.Matches
{
    public partial class MatchTeam
    {
        public MatchTeam()
        {
            TeamGoal = new HashSet<TeamGoal>();
        }

        public int Id { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int? Shots { get; set; }
        public int? ShotsOnTarget { get; set; }
        public int? YellowCards { get; set; }
        public int? RedCards { get; set; }
        public bool IsHomeTeam { get; set; }

        public virtual MatchHeader MatchHeader { get; set; }
        public virtual TeamHeader TeamHeader { get; set; }
        public virtual ICollection<TeamGoal> TeamGoal { get; set; }
    }
}
