using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto;

namespace LocalImporter
{
    [Table("MatchData", Schema = "football")]
    public partial class MatchData_v1 : BaseEntity
    {
        [Key]
        public int MatchDataId { get; set; }
        public int MatchId { get; set; }
        public int? FTHomeGoals { get; set; }
        public int? FTAwayGoals { get; set; }
        [Required]
        [MaxLength(1)]
        public string FTResult { get; set; }
        public int? HTHomeGoals { get; set; }
        public int? HTAwayGoals { get; set; }
        [MaxLength(1)]
        public string HTResult { get; set; }
        public int? HomeShots { get; set; }
        public int? AwayShots { get; set; }
        public int? HomeShotsOnTarget { get; set; }
        public int? AwayShotsOnTarget { get; set; }

        public virtual Match_v1 Match { get; set; }
    }
}
