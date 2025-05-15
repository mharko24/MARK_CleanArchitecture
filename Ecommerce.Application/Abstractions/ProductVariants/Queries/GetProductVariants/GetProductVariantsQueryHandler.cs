using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Abstractions.ProductVariants.Queries.GetProductVariants
{
    public class GetProductVariantsQueryHandler : IRequestHandler<GetProductVariantsQuery, IEnumerable<ProductVariant>>
    {
        private readonly IProductVariantRepository _productVariantRepository;
        public GetProductVariantsQueryHandler(IProductVariantRepository productVariantRepository)
        {
            _productVariantRepository = productVariantRepository;
        }
        public async Task<IEnumerable<ProductVariant>> Handle(GetProductVariantsQuery request, CancellationToken cancellationToken)
        {
            return await _productVariantRepository.GetAllAsync();
        }
    }
}
