using System.Collections.Generic;
using DataImporter.Common.Dto.Matches;
using DataImporter.Common.Dto.Players;
using DataImporter.Common.Dto.Venues;

namespace DataImporter.Common.Dto.Teams
{
    public partial class TeamHeader
    {
        public TeamHeader()
        {
            MatchTeam = new HashSet<MatchTeam>();
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int? VenueId { get; set; }

        public virtual VenueHeader VenueHeader { get; set; }
        public virtual ICollection<MatchTeam> MatchTeam { get; set; }
        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; }
    }
}
