using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Teams;

namespace Common.Dto.Matches
{
    [Table("Team", Schema = "match")]
    public partial class MatchTeam : BaseEntity
    {
        public MatchTeam()
        {
            TeamGoal = new HashSet<TeamGoal>();
        }

        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int? Shots { get; set; }
        public int? ShotsOnTarget { get; set; }
        public int? YellowCards { get; set; }
        public int? RedCards { get; set; }
        public bool IsHomeTeam { get; set; }
        public int MatchDataId { get; set; }

        public virtual MatchHeader MatchHeader { get; set; }
        public virtual TeamHeader TeamHeader { get; set; }
        public virtual ICollection<TeamGoal> TeamGoal { get; set; }
    }
}
