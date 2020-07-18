using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Matches;

namespace Common.Dto.Players
{
    [Table("Header", Schema = "player")]
    public partial class PlayerHeader : NamedEntity
    {
        public PlayerHeader()
        {
            GoalAssistedBy = new HashSet<Goal>();
            GoalScoredBy = new HashSet<Goal>();
            Team = new HashSet<PlayerTeam>();
        }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Goal> GoalAssistedBy { get; set; }
        public virtual ICollection<Goal> GoalScoredBy { get; set; }
        public virtual ICollection<PlayerTeam> Team { get; set; }
    }
}
