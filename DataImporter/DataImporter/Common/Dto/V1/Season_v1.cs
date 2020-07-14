using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalImporter
{
    [Table("Season", Schema = "football")]
    public partial class Season_v1
    {
        public Season_v1()
        {
            Match = new HashSet<Match_v1>();
        }

        [Key]
        public int SeasonId { get; set; }
        [Required]
        [MaxLength(10)]
        public string SeasonPeriod { get; set; }

        public virtual ICollection<Match_v1> Match { get; set; }
    }
}
