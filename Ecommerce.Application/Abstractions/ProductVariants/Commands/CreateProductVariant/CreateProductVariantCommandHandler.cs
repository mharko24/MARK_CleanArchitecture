using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;
using System.Runtime.CompilerServices;

namespace Ecommerce.Application.Abstractions.ProductVariants.Commands.CreateProductVariant
{
    public class CreateProductVariantCommandHandler : IRequestHandler<CreateProductVariantCommand, int>
    {
        private readonly IBaseRepository<ProductVariant> _baseRepository;
        private readonly IMapper _mapper;

        public CreateProductVariantCommandHandler(
            IBaseRepository<ProductVariant> baseRepository, 
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductVariantCommand request, CancellationToken cancellationToken)
        {
            //Add Validation Here
            var variant = _mapper.Map<ProductVariant>(request.dto);
            await _baseRepository.CreateAsync(variant, cancellationToken);
            return variant.ProductVariantId;
        }
    }
}
