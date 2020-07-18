using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Matches;
using Common.Dto.Players;
using Common.Dto.Venues;

namespace Common.Dto.Teams
{
    [Table("Header", Schema = "team")]
    public partial class TeamHeader : NamedEntity
    {
        public TeamHeader()
        {
            MatchTeam = new HashSet<MatchTeam>();
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        [MaxLength(1000)]
        public string Logo { get; set; }
        public int? VenueId { get; set; }

        public virtual VenueHeader VenueHeader { get; set; }
        public virtual ICollection<MatchTeam> MatchTeam { get; set; }
        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; }
    }
}
