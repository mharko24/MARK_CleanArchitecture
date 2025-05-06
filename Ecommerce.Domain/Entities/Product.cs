using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt{ get; set; }
    }
}
