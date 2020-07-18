using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;

namespace Common.Dto.Matches
{
    [Table("Header", Schema = "match")]
    public partial class MatchHeader : NamedEntity
    {
        public MatchHeader()
        {
            MatchTeam = new HashSet<MatchTeam>();
        }

        [DataType(DataType.DateTime)]
        public DateTime? MatchDate { get; set; }

        public virtual Competition Competition { get; set; }
        public virtual Venue MatchVenue { get; set; }
        public virtual ICollection<MatchTeam> MatchTeam { get; set; }
    }
}
