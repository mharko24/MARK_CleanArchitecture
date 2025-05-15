using Ecommerce.Application.DTOs.ProductVariants;
using MediatR;

namespace Ecommerce.Application.Abstractions.ProductVariants.Queries.GetProjectVariantById
{
    public record class GetProductVariantByIdQuery(int id): IRequest<ProductVariantDto>;
}
