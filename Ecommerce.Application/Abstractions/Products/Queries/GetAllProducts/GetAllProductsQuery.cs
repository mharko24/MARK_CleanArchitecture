using Ecommerce.Application.DTOs.Products;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery:IRequest<IEnumerable<ProductDto>>;
}
