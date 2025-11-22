using AntiTail.Domain.Entities;
using AntiTail.Domain.Shared.Enums;

namespace AntiTail.Domain.Interfaces.Repositories
{
    public interface IExerciseRepository
    {
        Task<Exercise> Create(long subjectId, string title, string description);

        Task<List<Exercise>> GetAll(long subjectId);

        Task<Exercise> GetById(long id);

        Task<bool> Update(long id, string title, string description);

        Task<bool> UpdateStatus(long id, Status status);

        Task<bool> Delete(long id);
    }
}
