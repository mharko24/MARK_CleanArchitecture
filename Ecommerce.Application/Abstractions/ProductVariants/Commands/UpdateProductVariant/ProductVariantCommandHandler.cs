using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using MediatR;

namespace Ecommerce.Application.Abstractions.ProductVariants.Commands.UpdateProductVariant
{
    public class ProductVariantCommandHandler : IRequestHandler<UpdateProductVariantCommand>
    {
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IMapper _mapper;
        public ProductVariantCommandHandler(
            IProductVariantRepository productVariantRepository, 
            IMapper mapper)
        {
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateProductVariantCommand request, CancellationToken cancellationToken)
        {
            //Validate the entity here..
            var mapVariant = _mapper.Map<ProductVariant>(request.dto);
            await _productVariantRepository.UpdateAsync(mapVariant, request.dto.ProductVariantId, cancellationToken);

        }
    }
}
