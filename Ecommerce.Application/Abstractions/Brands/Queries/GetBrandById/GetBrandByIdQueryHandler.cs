using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Brand?>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        public GetBrandByIdQueryHandler(
            IBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Brand?> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetOneAsync(request.id);
            return brand;
        }
    }
}
