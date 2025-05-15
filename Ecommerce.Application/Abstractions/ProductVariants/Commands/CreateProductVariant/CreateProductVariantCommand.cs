using Ecommerce.Application.DTOs.ProductVariants;
using MediatR;

namespace Ecommerce.Application.Abstractions.ProductVariants.Commands.CreateProductVariant
{
    public record class CreateProductVariantCommand(CreateProductVariantDto dto):IRequest<int>;
}
