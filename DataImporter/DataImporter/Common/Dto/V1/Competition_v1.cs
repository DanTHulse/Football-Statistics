using System.Collections.Generic;

namespace LocalImporter
{
    public partial class Competition_v1
    {
        public Competition_v1()
        {
            Match = new HashSet<Match_v1>();
        }

        public int CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public string Country { get; set; }
        public int? Tier { get; set; }

        public virtual ICollection<Match_v1> Match { get; set; }
    }
}
