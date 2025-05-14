using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Brand>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        public UpdateBrandCommandHandler(
            IBaseRepository<Brand> brandRepository,
            IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<Brand> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request.brand);
            await _brandRepository.UpdateAsync(brand, brand.BrandId, cancellationToken);
            return brand;

        }
    }
}
