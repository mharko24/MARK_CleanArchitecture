using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Command.DeleteProduct
{
    public record class DeleteProductCommand(Guid id):IRequest;

}
