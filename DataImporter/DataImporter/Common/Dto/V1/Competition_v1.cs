using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalImporter
{
    [Table("Competition", Schema = "football")]
    public partial class Competition_v1
    {
        public Competition_v1()
        {
            Match = new HashSet<Match_v1>();
        }

        [Key]
        public int CompetitionId { get; set; }
        [Required]
        public string CompetitionName { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        public int? Tier { get; set; }

        public virtual ICollection<Match_v1> Match { get; set; }
    }
}
