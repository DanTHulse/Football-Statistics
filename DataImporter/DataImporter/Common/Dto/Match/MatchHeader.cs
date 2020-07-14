using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto;

namespace DataImporter.Common.Dto.Matches
{
    [Table("Header", Schema = "match")]
    public partial class MatchHeader : BaseEntity
    {
        public MatchHeader()
        {
            MatchTeam = new HashSet<MatchTeam>();
        }

        [Key]
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? MatchDate { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual Venue MatchVenue { get; set; }
        public virtual ICollection<MatchTeam> MatchTeam { get; set; }

    }
}
