using AntiTail.API.Contracts.Users;
using AntiTail.Domain.Interfaces.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AntiTail.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController(
        IUserService userService) : ControllerBase
    {
        private readonly IUserService _usersService = userService;

        [HttpPost("login")]
        public async Task<IResult> Login([FromBody] LoginUserRequest request)
        {
            var context = HttpContext;

            var token = await _usersService.Login(request.Login, request.Password);

            context.Response.Cookies.Append("very-non-secret-cookie", token);

            return Results.Ok(token);
        }

        [HttpPost("register")]
        public async Task<IResult> Register([FromBody] RegisterUserRequest request)
        {
            await _usersService.Register(request.Login, request.Password);

            return Results.Ok();
        }
    }
}
