using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Competitions;
using Common.Dto.Lookups;

namespace Common.Dto.Matches
{
    [Table("Competition", Schema = "match")]
    public partial class Competition : BaseEntity
    {
        public int EditionId { get; set; }
        public int RoundId { get; set; }

        public virtual Edition CompetitionEdition { get; set; }
        public virtual MatchHeader MatchHeader { get; set; }
        public virtual Round Round { get; set; }
    }
}
