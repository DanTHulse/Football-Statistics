using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataImporter.Common.Dto.Matches;
using DataImporter.Common.Dto.Teams;

namespace DataImporter.Common.Dto.Venues
{
    [Table("Header", Schema = "venue")]
    public partial class VenueHeader
    {
        public VenueHeader()
        {
            TeamHeader = new HashSet<TeamHeader>();
            MatchVenue = new HashSet<Venue>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(8, 8)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(8, 8)")]
        public decimal Longitude { get; set; }

        public virtual ICollection<TeamHeader> TeamHeader { get; set; }
        public virtual ICollection<Venue> MatchVenue { get; set; }
    }
}
