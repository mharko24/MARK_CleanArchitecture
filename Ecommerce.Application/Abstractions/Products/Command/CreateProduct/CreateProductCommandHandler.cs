using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.product.Name,
                Description = request.product.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = request.product.UpdatedAt,
            };
            await _productRepository.CreateAsync(product, cancellationToken);
            return product.ProductId;

        }
    }
}
