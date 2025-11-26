using AntiTail.Domain.Entities;

namespace AntiTail.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(string login, string passwordHash);

        Task<User> GetById(long id);

        Task<User> GetByLogin(string login);
    }
}
