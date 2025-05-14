using Ecommerce.Application.DTOs.Products;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery:IRequest<IEnumerable<ProductDto>>;
}
