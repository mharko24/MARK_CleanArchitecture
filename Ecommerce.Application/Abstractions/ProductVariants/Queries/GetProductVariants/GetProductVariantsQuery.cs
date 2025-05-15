using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Abstractions.ProductVariants.Queries.GetProductVariants
{
    public record class GetProductVariantsQuery():IRequest<IEnumerable<ProductVariant>>;

}
