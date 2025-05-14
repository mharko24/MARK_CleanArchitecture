using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
    {
        private readonly IBaseRepository<Brand> _brandRepository;
        public DeleteBrandCommandHandler(
            IBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandRepository.DeleteAsync(request.id, cancellationToken);
        }
    }
}
