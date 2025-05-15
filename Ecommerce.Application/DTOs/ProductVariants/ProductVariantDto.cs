using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs.ProductVariants
{
    public class ProductVariantDto
    {
        public int ProductVariantId { get; set; }
        public Guid ProductId { get; set; }
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
