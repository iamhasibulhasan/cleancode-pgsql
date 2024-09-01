using System.ComponentModel.DataAnnotations;

namespace CleanCode.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid? Uid { get; set; } = Guid.NewGuid();
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int StatusId { get; set; }
    }
}
