using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Lookups;
using Common.Dto.Teams;

namespace Common.Dto.Players
{
    [Table("Team", Schema = "player")]
    public partial class PlayerTeam : BaseEntity
    {
        public PlayerTeam()
        {
        }

        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int TeamNumber { get; set; }
        public bool Active { get; set; }
        public int PositionId { get; set; }

        public virtual PlayerHeader PlayerHeader { get; set; }
        public virtual Position Position { get; set; }
        public virtual TeamHeader TeamHeader { get; set; }
    }
}
