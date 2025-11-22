using AntiTail.API.Contracts.Users;
using AntiTail.Domain.Interfaces.Services;
using AntiTail.Infrastructure.Exceptions;
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
            try
            {
                var token = await _usersService.Login(request.Login, request.Password);

                HttpContext.Response.Cookies.Append("very-non-secret-cookie", token);

                return Results.NoContent();
            }
            catch (NotFoundException ex)
            {
                return Results.NotFound(new { message = ex.Message });
            }
            catch (BadRequestException ex)
            {
                return Results.BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }

        [HttpPost("register")]
        public async Task<IResult> Register([FromBody] RegisterUserRequest request)
        {
            try
            {
                await _usersService.Register(request.Login, request.Password);

                return Results.NoContent();
            }
            catch (ConflictException ex)
            {
                return Results.Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return Results.InternalServerError();
            }
        }
    }
}
