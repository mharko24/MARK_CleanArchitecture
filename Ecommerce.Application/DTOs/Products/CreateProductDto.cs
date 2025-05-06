namespace Ecommerce.Application.DTOs.Products
{
    public class CreateProductDto
    {
        //public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
