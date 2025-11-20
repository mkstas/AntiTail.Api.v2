using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Subjects
{
    public interface ISubjectRepository
    {
        Task<Subject> Create(long userId, string title);

        Task<List<Subject>> GetAll(long userId);

        Task<Subject> GetById(long id);

        Task<Subject> Update(long id, long userId, string title);

        Task<bool> Delete(long id);
    }
}
