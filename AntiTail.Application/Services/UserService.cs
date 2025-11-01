using AntiTail.Domain.Interfaces.Auth;
using AntiTail.Domain.Interfaces.Users;
using AntiTail.Domain.Models;

namespace AntiTail.Application.Services
{
    public class UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IJwtProvider _jwtProvider = jwtProvider;

        public async Task<string> Login(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            var isVerified = _passwordHasher.Verify(password, user.PasswordHash);

            if (isVerified == false)
            {
                throw new Exception();
            }

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }

        public async Task Register(string login, string password)
        {
            var passwordHash = _passwordHasher.Generate(password);

            await _userRepository.Create(login, passwordHash);
        }
    }
}
