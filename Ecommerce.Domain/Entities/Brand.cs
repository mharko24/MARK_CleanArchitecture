using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public sealed class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        //public int IsActive { get; set; }
    }
}
