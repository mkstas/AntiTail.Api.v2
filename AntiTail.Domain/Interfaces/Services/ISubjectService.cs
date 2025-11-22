using AntiTail.Domain.Entities;

namespace AntiTail.Domain.Interfaces.Services
{
    public interface ISubjectService
    {
        Task<Subject> CreateSubject(long userId, string title);

        Task<List<Subject>> GetAllSubjects(long userId);

        Task<Subject> GetSubjectById(long id);

        Task<bool> UpdateSubject(long id, long userId, string title);

        Task<bool> DeleteSubject(long id);
    }
}
