using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Matches;

namespace Common.Dto.Lookups
{
    [Table("SetPiece", Schema = "dbo")]
    public partial class SetPiece : NamedEntity
    {
        public SetPiece()
        {
            MatchGoal = new HashSet<Goal>();
        }

        public virtual ICollection<Goal> MatchGoal { get; set; }
    }
}
