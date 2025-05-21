using Ecommerce.Application.DTOs.Brands;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Commands.CreateBrand
{
    public record CreateBrandCommand(BrandDto Brand) : IRequest<Result<string>> ;

}
