using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto;
using DataImporter.Common.Dto.Competitions;

namespace DataImporter.Common.Dto.Base
{
    [Table("Country", Schema = "dbo")]
    public partial class Country : BaseEntity
    {
        public Country()
        {
            CompetitionHeader = new HashSet<CompetitionHeader>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShortName { get; set; }

        public virtual ICollection<CompetitionHeader> CompetitionHeader { get; set; }
    }
}
