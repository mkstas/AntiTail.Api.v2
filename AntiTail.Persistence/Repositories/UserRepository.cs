using AntiTail.Domain.Interfaces.Users;
using AntiTail.Domain.Models;
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
                .FirstOrDefaultAsync(u => u.Login == login) ?? throw new Exception();
        }

        public async Task<User> Create(string login, string passwordHash)
        {
            var user = new User(login, passwordHash);

            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
