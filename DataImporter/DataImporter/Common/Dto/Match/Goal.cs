using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto;
using DataImporter.Common.Dto.Base;
using DataImporter.Common.Dto.Players;

namespace DataImporter.Common.Dto.Matches
{
    [Table("Goal", Schema = "match")]
    public partial class Goal : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? ScoredBy { get; set; }
        public int? AssistedBy { get; set; }
        public int? SetPieceId { get; set; }
        public int? TimeScored { get; set; }
        public Guid Junk { get; set; }

        public virtual PlayerHeader AssistedByPlayer { get; set; }
        public virtual PlayerHeader ScoredByPlayer { get; set; }
        public virtual SetPiece SetPiece { get; set; }
        public virtual TeamGoal TeamGoal { get; set; }
    }
}
