using System.ComponentModel.DataAnnotations.Schema;
using DataImporter.Common.Dto.Venues;

namespace DataImporter.Common.Dto.Matches
{
    [Table("Venue", Schema = "match")]
    public partial class Venue
    {
        public int MatchId { get; set; }
        public bool IsNeutral { get; set; }
        public int VenueId { get; set; }

        public virtual MatchHeader MatchHeader { get; set; }
        public virtual VenueHeader VenueHeader { get; set; }
    }
}
