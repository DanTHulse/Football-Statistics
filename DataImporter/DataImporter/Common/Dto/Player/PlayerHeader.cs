using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataImporter.Common.Dto.Matches;

namespace DataImporter.Common.Dto.Players
{
    [Table("Header", Schema = "player")]
    public partial class PlayerHeader
    {
        public PlayerHeader()
        {
            GoalAssistedBy = new HashSet<Goal>();
            GoalScoredBy = new HashSet<Goal>();
            Team = new HashSet<PlayerTeam>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Goal> GoalAssistedBy { get; set; }
        public virtual ICollection<Goal> GoalScoredBy { get; set; }
        public virtual ICollection<PlayerTeam> Team { get; set; }
    }
}
