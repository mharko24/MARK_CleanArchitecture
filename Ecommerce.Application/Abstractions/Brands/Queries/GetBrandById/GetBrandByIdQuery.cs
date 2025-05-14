using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Queries.GetBrandById
{
    public record class GetBrandByIdQuery(int id): IRequest<Brand>;

}
