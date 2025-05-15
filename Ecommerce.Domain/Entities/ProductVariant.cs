using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entities
{
    public class ProductVariant
    {
        public int ProductVariantId { get; set; }
        public Guid ProductId { get; set; }
        [NotMapped]
        //[ForeignKey("ProductId")]
        public Product Products { get; set; }
        [StringLength(50)]
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int Stock { get; set; }
        [StringLength(30)]
        public string Color { get; set; }
        [StringLength(30)]
        public string Size { get; set; }
        public int IsActive { get; set; }

    }
}
