using Ecommerce.Application.DTOs.Brands;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Commands.CreateBrand
{
    public record CreateBrandCommand(BrandDto Brand) : IRequest<int>;

}
