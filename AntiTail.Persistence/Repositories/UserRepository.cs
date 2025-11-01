using AntiTail.Domain.Interfaces.Users;
using AntiTail.Domain.Models;
using AntiTail.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AntiTail.Persistence.Repositories
{
    public class UserRepository(AntiTailDbContext dbContext) : IUserRepository
    {
        private readonly AntiTailDbContext _dbContext = dbContext;

        public async Task<User> GetByLogin(string login)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login) ?? throw new NotFoundException("User is not found");
        }

        public async Task<User> Create(string login, string passwordHash)
        {
            bool isExists = await _dbContext.Users
                .AsNoTracking()
                .AnyAsync(u => u.Login == login);

            if (isExists)
            {
                throw new ConflictException("Login is already exists");
            }

            var user = new User(login, passwordHash);

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
