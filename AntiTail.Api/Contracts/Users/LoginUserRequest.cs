using System.ComponentModel.DataAnnotations;

namespace AntiTail.API.Contracts.Users
{
    public record LoginUserRequest(
        [Required] string Login,
        [Required] string Password);
}
