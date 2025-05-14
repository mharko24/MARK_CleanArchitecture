using AutoMapper;
using Ecommerce.Application.DTOs.Products;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IBaseRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IBaseRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetOneAsync(request.id);
            var mapProduct =  _mapper.Map<ProductDto>(product);
            return mapProduct;
        }
    }
}
