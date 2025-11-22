using System.ComponentModel.DataAnnotations;

namespace AntiTail.API.Contracts.Users
{
    public record LoginUserRequest(
        [Required(ErrorMessage = "Login is required.")]
        [MinLength(2, ErrorMessage = "Login must be at least 2 characters long.")]
        [MaxLength(24, ErrorMessage = "Login cannot exceed 24 characters.")]
        string Login,

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [MaxLength(256, ErrorMessage = "Password cannot exceed 256 characters.")]
        string Password);
}
