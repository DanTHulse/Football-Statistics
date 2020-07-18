using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Players;

namespace Common.Dto.Lookups
{
    [Table("Position", Schema = "dbo")]
    public partial class Position : NamedEntity
    {
        public Position()
        {
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; }
    }
}
