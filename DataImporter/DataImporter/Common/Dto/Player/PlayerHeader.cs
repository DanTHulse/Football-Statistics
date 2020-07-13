using System;
using System.Collections.Generic;
using DataImporter.Common.Dto.Matches;

namespace DataImporter.Common.Dto.Players
{
    public partial class PlayerHeader
    {
        public PlayerHeader()
        {
            GoalAssistedBy = new HashSet<Goal>();
            GoalScoredBy = new HashSet<Goal>();
            Team = new HashSet<PlayerTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Goal> GoalAssistedBy { get; set; }
        public virtual ICollection<Goal> GoalScoredBy { get; set; }
        public virtual ICollection<PlayerTeam> Team { get; set; }
    }
}
