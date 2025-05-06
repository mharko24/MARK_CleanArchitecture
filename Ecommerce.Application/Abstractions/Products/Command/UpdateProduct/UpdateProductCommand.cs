using Ecommerce.Application.DTOs.Products;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Command.UpdateProduct
{
    public record UpdateProductCommand(ProductDto dto):IRequest<ProductDto>;

}
