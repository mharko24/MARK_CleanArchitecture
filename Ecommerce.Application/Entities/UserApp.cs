using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Entities
{
    public class UserApp:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
