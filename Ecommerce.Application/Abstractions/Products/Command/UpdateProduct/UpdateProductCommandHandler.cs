using AutoMapper;
using Ecommerce.Application.DTOs.Products;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;
using System.Runtime.CompilerServices;

namespace Ecommerce.Application.Abstractions.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(
            IBaseRepository<Product> productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            //var product = new Product()
            //{
            //    ProductId = request.dto.ProductId,
            //    Name = request.dto.Name,
            //    Description = request.dto.Description,
            //    CreatedAt = request.dto.CreatedAt,
            //    UpdatedAt = DateTime.UtcNow
            //};
            var product = _mapper.Map<Product>(request.dto);
            await _productRepository.UpdateAsync(product, product.ProductId, cancellationToken);
            return request.dto;

        }
    }
}
