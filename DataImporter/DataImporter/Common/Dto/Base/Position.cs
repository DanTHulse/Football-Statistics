using System.Collections.Generic;
using DataImporter.Common.Dto.Players;

namespace DataImporter.Common.Dto.Base
{
    public partial class Position
    {
        public Position()
        {
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; }
    }
}
