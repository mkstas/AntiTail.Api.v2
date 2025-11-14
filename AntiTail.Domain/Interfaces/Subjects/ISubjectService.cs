using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Subjects
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllSubjects(long userId);

        Task<Subject> GetSubjectById(long id);

        Task<Subject> CreateSubject(long userId, string title);

        Task<Subject> UpdateSubject(long userId, long id, string title);

        Task<bool> DeleteSubject(long id);
    }
}
