using System.Collections.Generic;
using DataImporter.Common.Dto.Matches;

namespace DataImporter.Common.Dto.Base
{
    public partial class SetPiece
    {
        public SetPiece()
        {
            MatchGoal = new HashSet<Goal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Goal> MatchGoal { get; set; }
    }
}
