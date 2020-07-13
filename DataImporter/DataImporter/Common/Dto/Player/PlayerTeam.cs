using DataImporter.Common.Dto.Base;
using DataImporter.Common.Dto.Teams;

namespace DataImporter.Common.Dto.Players
{
    public partial class PlayerTeam
    {
        public int Id { get; set; }
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
