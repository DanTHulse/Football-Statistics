using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Venues;

namespace Common.Dto.Matches
{
    [Table("Venue", Schema = "match")]
    public partial class Venue : BaseEntity
    {
        public bool IsNeutral { get; set; }
        public int VenueId { get; set; }

        public virtual MatchHeader MatchHeader { get; set; }
        public virtual VenueHeader VenueHeader { get; set; }
    }
}
