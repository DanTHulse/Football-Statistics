using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Competitions;

namespace Common.Dto.Lookups
{
    [Table("Country", Schema = "dbo")]
    public partial class Country : NamedEntity
    {
        public Country()
        {
            CompetitionHeader = new HashSet<CompetitionHeader>();
        }

        [Required]
        [MaxLength(50)]
        public string ShortName { get; set; }

        public virtual ICollection<CompetitionHeader> CompetitionHeader { get; set; }
    }
}
