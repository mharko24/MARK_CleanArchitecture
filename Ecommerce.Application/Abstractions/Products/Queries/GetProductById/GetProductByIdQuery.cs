using Ecommerce.Application.DTOs.Products;
using MediatR;

namespace Ecommerce.Application.Abstractions.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(Guid id):IRequest<ProductDto?>;

}
