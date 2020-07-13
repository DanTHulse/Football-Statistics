using System;
using System.Collections.Generic;

namespace DataImporter.Common.Dto.Matches
{
    public partial class MatchHeader
    {
        public MatchHeader()
        {
            Competition = new HashSet<Competition>();
            MatchTeam = new HashSet<MatchTeam>();
            MatchVenue = new HashSet<Venue>();
        }

        public int Id { get; set; }
        public DateTime? MatchDate { get; set; }

        public virtual ICollection<Competition> Competition { get; set; }
        public virtual ICollection<MatchTeam> MatchTeam { get; set; }
        public virtual ICollection<Venue> MatchVenue { get; set; }
    }
}
