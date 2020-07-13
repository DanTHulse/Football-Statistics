using System.Collections.Generic;
using DataImporter.Common.Dto.Matches;

namespace DataImporter.Common.Dto.Base
{
    public partial class Round
    {
        public Round()
        {
            MatchCompetition = new HashSet<Competition>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Competition> MatchCompetition { get; set; }
    }
}
