using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto;
using DataImporter.Common.Dto.Matches;

namespace DataImporter.Common.Dto.Base
{
    [Table("SetPiece", Schema = "dbo")]
    public partial class SetPiece : BaseEntity
    {
        public SetPiece()
        {
            MatchGoal = new HashSet<Goal>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Goal> MatchGoal { get; set; }
    }
}
