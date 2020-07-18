using System.ComponentModel.DataAnnotations;

namespace Common.Dto.Base
{
    public class NamedEntity : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
