using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, int>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        public CreateBrandCommandHandler(
            IBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand()
            {
                Name = request.Brand.Name
            };

            await _brandRepository.CreateAsync(brand, cancellationToken);
            return brand.BrandId;
        }
    }
}
