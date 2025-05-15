using Ecommerce.Application.Abstractions.Users.Commands.CreateUser;
using Ecommerce.Application.DTOs.Users;
using Ecommerce.Application.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IMediator _mediator;
        public AccountController(
            IMediator mediator, 
            UserManager<UserApp> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;

        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(new CreateUserCommand(registerDto));
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Account created successfully");
        }
    }
}
