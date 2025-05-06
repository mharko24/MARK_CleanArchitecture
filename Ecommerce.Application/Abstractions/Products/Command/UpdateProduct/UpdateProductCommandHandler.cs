using Ecommerce.Application.DTOs.Products;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                ProductId = request.dto.ProductId,
                Name = request.dto.Name,
                Description = request.dto.Description,
                CreatedAt = request.dto.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            };
            await _productRepository.UpdateAsync(product, product.ProductId, cancellationToken);
            return request.dto;

        }
    }
}
