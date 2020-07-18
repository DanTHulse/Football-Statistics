using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Lookups;

namespace Common.Dto.Competitions
{
    [Table("Header", Schema = "competition")]
    public partial class CompetitionHeader : NamedEntity
    {
        public CompetitionHeader()
        {
            CompetitionEdition = new HashSet<Edition>();
        }

        public int CountryId { get; set; }
        public byte? Tier { get; set; }
        public bool IsLeagueCompetition { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Edition> CompetitionEdition { get; set; }
    }
}
