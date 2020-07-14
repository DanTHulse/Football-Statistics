using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataImporter.Common.Dto.Base;

namespace DataImporter.Common.Dto.Competitions
{
    [Table("Header", Schema = "competition")]
    public partial class CompetitionHeader
    {
        public CompetitionHeader()
        {
            CompetitionEdition = new HashSet<Edition>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public byte? Tier { get; set; }
        public bool IsLeagueCompetition { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Edition> CompetitionEdition { get; set; }
    }
}
