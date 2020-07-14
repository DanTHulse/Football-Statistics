using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataImporter.Common.Dto.Players;

namespace DataImporter.Common.Dto.Base
{
    [Table("Position", Schema = "dbo")]
    public partial class Position
    {
        public Position()
        {
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; }
    }
}
