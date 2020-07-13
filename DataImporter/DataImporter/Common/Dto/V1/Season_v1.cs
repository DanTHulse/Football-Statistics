using System.Collections.Generic;

namespace LocalImporter
{
    public partial class Season_v1
    {
        public Season_v1()
        {
            Match = new HashSet<Match_v1>();
        }

        public int SeasonId { get; set; }
        public string SeasonPeriod { get; set; }

        public virtual ICollection<Match_v1> Match { get; set; }
    }
}
