using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs.Users
{
    public class RegisterDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<string>? Roles { get; set; }
    }
}
