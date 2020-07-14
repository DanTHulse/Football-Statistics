using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataImporter.Common.Dto.Base;
using DataImporter.Common.Dto.Players;

namespace DataImporter.Common.Dto.Matches
{
    [Table("Goal", Schema = "match")]
    public partial class Goal
    {
        public Goal()
        {
            TeamGoal = new HashSet<TeamGoal>();
        }

        [Key]
        public int Id { get; set; }
        public int? ScoredBy { get; set; }
        public int? AssistedBy { get; set; }
        public int? SetPieceId { get; set; }
        public int? TimeScored { get; set; }

        public virtual PlayerHeader AssistedByPlayer { get; set; }
        public virtual PlayerHeader ScoredByPlayer { get; set; }
        public virtual SetPiece SetPiece { get; set; }
        public virtual ICollection<TeamGoal> TeamGoal { get; set; }
    }
}
