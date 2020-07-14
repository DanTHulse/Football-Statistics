﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DataImporter.Common.Dto.Matches
{
    [Table("TeamGoal", Schema = "match")]
    public partial class TeamGoal
    {
        public int MatchTeamId { get; set; }
        public int GoalId { get; set; }

        public virtual Goal Goal { get; set; }
        public virtual MatchTeam MatchTeam { get; set; }
    }
}
