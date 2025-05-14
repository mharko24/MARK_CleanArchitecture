using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IBaseRepository<Product> _productRepository;
        public DeleteProductCommandHandler(
            IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetOneAsync(request.id);
            if(product != null)
            {
                await _productRepository.DeleteAsync(request.id, cancellationToken);
            }
        }
    }
}
