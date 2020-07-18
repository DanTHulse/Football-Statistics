using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto.Base;
using Common.Dto.Matches;

namespace Common.Dto.Competitions
{
    [Table("Edition", Schema = "competition")]
    public partial class Edition : BaseEntity
    {
        public Edition()
        {
            MatchCompetition = new HashSet<Competition>();
        }

        public int CompetitionId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int? SeasonId { get; set; }

        public virtual CompetitionHeader CompetitionHeader { get; set; }
        public virtual ICollection<Competition> MatchCompetition { get; set; }
    }
}
