using Ecommerce.Application.DTOs.Brands;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Commands.UpdateBrand
{
    public record class UpdateBrandCommand(BrandDto brand) : IRequest<Brand>;
}
