using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<User> GetByLogin(string login);

        Task<User> Create(string login, string passwordHash);
    }
}
