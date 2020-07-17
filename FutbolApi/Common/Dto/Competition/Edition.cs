using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Dto;
using DataImporter.Common.Dto.Matches;

namespace DataImporter.Common.Dto.Competitions
{
    [Table("Edition", Schema = "competition")]
    public partial class Edition : BaseEntity
    {
        public Edition()
        {
            MatchCompetition = new HashSet<Competition>();
        }

        [Key]
        public int Id { get; set; }
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
