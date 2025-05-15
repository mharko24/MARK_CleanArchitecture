using Ecommerce.Application.DTOs.ProductVariants;
using MediatR;

namespace Ecommerce.Application.Abstractions.ProductVariants.Commands.UpdateProductVariant
{
    public record class UpdateProductVariantCommand(ProductVariantDto dto): IRequest;
}
