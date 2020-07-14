using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataImporter.Common.Dto.Matches
{
    [Table("Header", Schema = "match")]
    public partial class MatchHeader
    {
        public MatchHeader()
        {
            Competition = new HashSet<Competition>();
            MatchTeam = new HashSet<MatchTeam>();
            MatchVenue = new HashSet<Venue>();
        }

        [Key]
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? MatchDate { get; set; }

        public virtual ICollection<Competition> Competition { get; set; }
        public virtual ICollection<MatchTeam> MatchTeam { get; set; }
        public virtual ICollection<Venue> MatchVenue { get; set; }
    }
}
