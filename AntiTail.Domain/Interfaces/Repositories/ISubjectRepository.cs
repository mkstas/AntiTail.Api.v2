using AntiTail.Domain.Entities;

namespace AntiTail.Domain.Interfaces.Repositories
{
    public interface ISubjectRepository
    {
        Task<Subject> Create(long userId, string title);

        Task<List<Subject>> GetAll(long userId);

        Task<Subject> GetById(long id);

        Task<bool> Update(long id, long userId, string title);

        Task<bool> Delete(long id);
    }
}
