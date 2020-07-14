using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataImporter.Common.Dto.Matches;

namespace DataImporter.Common.Dto.Base
{
    [Table("Round", Schema = "dbo")]
    public partial class Round
    {
        public Round()
        {
            MatchCompetition = new HashSet<Competition>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Competition> MatchCompetition { get; set; }
    }
}
