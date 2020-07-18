using System.ComponentModel.DataAnnotations;

namespace Common.Dto.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
