using System;
using System.Collections.Generic;
using DataImporter.Common.Dto.Matches;

namespace DataImporter.Common.Dto.Competitions
{
    public partial class Edition
    {
        public Edition()
        {
            MatchCompetition = new HashSet<Competition>();
        }

        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SeasonId { get; set; }

        public virtual CompetitionHeader CompetitionHeader { get; set; }
        public virtual ICollection<Competition> MatchCompetition { get; set; }
    }
}
