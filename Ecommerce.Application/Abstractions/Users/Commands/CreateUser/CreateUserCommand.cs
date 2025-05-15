using Ecommerce.Application.DTOs.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Abstractions.Users.Commands.CreateUser
{
    public record class CreateUserCommand(RegisterDto user) : IRequest<IdentityResult>;
}
