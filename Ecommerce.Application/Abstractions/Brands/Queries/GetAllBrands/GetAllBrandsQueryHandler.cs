using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<Brand>>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        public GetAllBrandsQueryHandler(
            IBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _brandRepository.GetAllAsync();
        }
    }
}
