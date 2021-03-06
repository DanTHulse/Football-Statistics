﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto;
using DataImporter.Common.Dto.Teams;
using LocalImporter;

namespace DataImporter.Common.Dto.Matches
{
    [Table("Team", Schema = "match")]
    public partial class MatchTeam : BaseEntity
    {
        public MatchTeam()
        {
            TeamGoal = new HashSet<TeamGoal>();
        }

        [Key]
        public int Id { get; set; }
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
        public virtual MatchData_v1 MatchData { get; set; }
    }
}
