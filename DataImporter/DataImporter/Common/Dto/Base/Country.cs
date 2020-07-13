using System.Collections.Generic;
using DataImporter.Common.Dto.Competitions;

namespace DataImporter.Common.Dto.Base
{
    public partial class Country
    {
        public Country()
        {
            CompetitionHeader = new HashSet<CompetitionHeader>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<CompetitionHeader> CompetitionHeader { get; set; }
    }
}
