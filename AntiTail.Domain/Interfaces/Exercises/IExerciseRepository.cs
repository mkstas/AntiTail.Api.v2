using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Exercises
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
