using AutoMapper;
using Ecommerce.Application.DTOs.ProductVariants;
using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Abstractions.ProductVariants.Queries.GetProjectVariantById
{
    public class GetProductVariantByIdQueryHandler : IRequestHandler<GetProductVariantByIdQuery, ProductVariantDto>
    {
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IMapper _mapper;

        public GetProductVariantByIdQueryHandler(
            IProductVariantRepository productVariantRepository, IMapper mapper)
        {
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
        }
        public async Task<ProductVariantDto> Handle(GetProductVariantByIdQuery request, CancellationToken cancellationToken)
        {
            var variant = await _productVariantRepository.GetOneAsync(request.id);
            var mapVariant = _mapper.Map<ProductVariantDto>(variant);
            return mapVariant;
        }
    }
}
