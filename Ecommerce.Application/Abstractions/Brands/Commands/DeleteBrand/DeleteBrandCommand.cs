using MediatR;

namespace Ecommerce.Application.Abstractions.Brands.Commands.DeleteBrand
{
    public record class DeleteBrandCommand(int id): IRequest;

}
