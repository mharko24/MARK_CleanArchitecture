using Ecommerce.Application.DTOs.Products;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Command.CreateProduct
{
    public record CreateProductCommand(CreateProductDto product):IRequest<Guid>;

}
