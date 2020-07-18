using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Matches;

namespace Common.Dto.Lookups
{
    [Table("Round", Schema = "dbo")]
    public partial class Round : NamedEntity
    {
        public Round()
        {
            MatchCompetition = new HashSet<Competition>();
        }

        public virtual ICollection<Competition> MatchCompetition { get; set; }
    }
}
