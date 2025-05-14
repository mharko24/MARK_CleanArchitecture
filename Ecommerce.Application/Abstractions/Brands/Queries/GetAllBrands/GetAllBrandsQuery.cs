using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Queries.GetAllBrands
{
    public record class GetAllBrandsQuery():IRequest<IEnumerable<Brand>>;
}
