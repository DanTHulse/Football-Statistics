using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto;
using DataImporter.Common.Dto.Matches;
using DataImporter.Common.Dto.Players;
using DataImporter.Common.Dto.Venues;

namespace DataImporter.Common.Dto.Teams
{
    [Table("Header", Schema = "team")]
    public partial class TeamHeader : BaseEntity
    {
        public TeamHeader()
        {
            MatchTeam = new HashSet<MatchTeam>();
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Logo { get; set; }
        public int? VenueId { get; set; }

        public virtual VenueHeader VenueHeader { get; set; }
        public virtual ICollection<MatchTeam> MatchTeam { get; set; }
        public virtual ICollection<PlayerTeam> PlayerTeam { get; set; }
    }
}
