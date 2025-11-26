using AntiTail.Domain.Interfaces.Repositories;
using AntiTail.Domain.Entities;
using AntiTail.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AntiTail.Persistence.Repositories
{
    public class UserRepository(AntiTailDbContext context) : IUserRepository
    {
        private readonly AntiTailDbContext _context = context;

        public async Task<User> Create(string login, string passwordHash)
        {
            bool isExists = await _context.Users
                .AsNoTracking()
                .AnyAsync(u => u.Login == login);

            if (isExists)
            {
                throw new ConflictException("Login is already exists.");
            }

            var user = new User(login, passwordHash);

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetById(long id)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id) ?? throw new NotFoundException("User is not found.");
        }

        public async Task<User> GetByLogin(string login)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == login) ?? throw new NotFoundException("User is not found.");
        }
    }
}
