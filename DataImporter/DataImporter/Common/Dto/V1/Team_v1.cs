using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalImporter
{
    [Table("Team", Schema = "football")]
    public partial class Team_v1
    {
        public Team_v1()
        {
            MatchAwayTeam = new HashSet<Match_v1>();
            MatchHomeTeam = new HashSet<Match_v1>();
        }

        [Key]
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
        public string AlternateTeamName { get; set; }
        public string TeamLogo { get; set; }

        public virtual ICollection<Match_v1> MatchAwayTeam { get; set; }
        public virtual ICollection<Match_v1> MatchHomeTeam { get; set; }
    }
}
