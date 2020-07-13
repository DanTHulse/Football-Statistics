using System.Collections.Generic;
using DataImporter.Common.Dto.Matches;
using DataImporter.Common.Dto.Teams;

namespace DataImporter.Common.Dto.Venues
{
    public partial class VenueHeader
    {
        public VenueHeader()
        {
            TeamHeader = new HashSet<TeamHeader>();
            MatchVenue = new HashSet<Venue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public virtual ICollection<TeamHeader> TeamHeader { get; set; }
        public virtual ICollection<Venue> MatchVenue { get; set; }
    }
}
