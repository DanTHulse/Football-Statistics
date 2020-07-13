using DataImporter.Common.Dto.Base;
using DataImporter.Common.Dto.Competitions;

namespace DataImporter.Common.Dto.Matches
{
    public partial class Competition
    {
        public int EditionId { get; set; }
        public int MatchId { get; set; }
        public int RoundId { get; set; }

        public virtual Edition CompetitionEdition { get; set; }
        public virtual MatchHeader MatchHeader { get; set; }
        public virtual Round Round { get; set; }
    }
}
