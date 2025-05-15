using AutoMapper;
using Ecommerce.Application.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Abstractions.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IdentityResult>
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(
            UserManager<UserApp> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserApp
            {
                Email = request.user.Email,
                UserName = request.user.Email,
                FirstName = request.user.FirstName,
                LastName = request.user.LastName
            };


            var result = await _userManager.CreateAsync(user, request.user.Password);

            if (request.user.Roles is null)
            {
                var userRole = "User";
                if (!await _roleManager.RoleExistsAsync(userRole))
                {
                    await _roleManager.CreateAsync(new IdentityRole(userRole));
                }

                await _userManager.AddToRoleAsync(user, userRole);
            }
            else
            {
                foreach (var role in request.user.Roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }
                    await _userManager.AddToRoleAsync(user, role);
                }
            }
            return result;

        }
    }
}
