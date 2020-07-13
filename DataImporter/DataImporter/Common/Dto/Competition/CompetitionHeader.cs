using System.Collections.Generic;
using DataImporter.Common.Dto.Base;

namespace DataImporter.Common.Dto.Competitions
{
    public partial class CompetitionHeader
    {
        public CompetitionHeader()
        {
            CompetitionEdition = new HashSet<Edition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public byte? Tier { get; set; }
        public bool IsLeagueCompetition { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Edition> CompetitionEdition { get; set; }
    }
}
