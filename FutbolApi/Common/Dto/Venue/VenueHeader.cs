using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Matches;
using Common.Dto.Teams;

namespace Common.Dto.Venues
{
    [Table("Header", Schema = "venue")]
    public partial class VenueHeader : NamedEntity
    {
        public VenueHeader()
        {
            TeamHeader = new HashSet<TeamHeader>();
            MatchVenue = new HashSet<Venue>();
        }

        [Column(TypeName = "decimal(8, 8)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(8, 8)")]
        public decimal Longitude { get; set; }

        public virtual ICollection<TeamHeader> TeamHeader { get; set; }
        public virtual ICollection<Venue> MatchVenue { get; set; }
    }
}
