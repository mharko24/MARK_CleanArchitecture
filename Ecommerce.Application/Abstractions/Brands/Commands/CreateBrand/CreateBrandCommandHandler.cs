
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Exception.Brands;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Result<string>>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        public CreateBrandCommandHandler(
            IBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Result<string>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Brand.Name))
            {
                var brand = new Brand()
                {
                    Name = request.Brand.Name
                };

                await _brandRepository.CreateAsync(brand, cancellationToken);
                return Result<string>.Success("Successfully create a new brand");
            }
            return Result<string>.Failure(BrandErrors.BrandNameIsNull);
        }
    }
}
