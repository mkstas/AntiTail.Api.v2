using System.ComponentModel.DataAnnotations;

namespace AntiTail.API.Contracts.Users
{
    public record RegisterUserRequest(
        [Required] string Login,
        [Required] string Password);
}
