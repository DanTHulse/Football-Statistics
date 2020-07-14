using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto;
using DataImporter.Common.Dto.Base;
using DataImporter.Common.Dto.Competitions;

namespace DataImporter.Common.Dto.Matches
{
    [Table("Competition", Schema = "match")]
    public partial class Competition : BaseEntity
    {
        [Key]
        public int MatchId { get; set; }
        public int EditionId { get; set; }
        public int RoundId { get; set; }

        public virtual Edition CompetitionEdition { get; set; }
        public virtual MatchHeader MatchHeader { get; set; }
        public virtual Round Round { get; set; }
    }
}
