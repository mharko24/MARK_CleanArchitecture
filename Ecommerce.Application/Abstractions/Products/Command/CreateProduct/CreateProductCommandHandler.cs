using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(
            IBaseRepository<Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //var product = new Product()
            //{
            //    Name = request.product.Name,
            //    Description = request.product.Description,
            //    CreatedAt = DateTime.UtcNow,
            //    UpdatedAt = request.product.UpdatedAt,
            //};
            var product = _mapper.Map<Product>(request.product);
            await _productRepository.CreateAsync(product, cancellationToken);
            return product.ProductId;

        }
    }
}
