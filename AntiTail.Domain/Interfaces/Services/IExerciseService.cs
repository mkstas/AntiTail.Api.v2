using AntiTail.Domain.Entities;
using AntiTail.Domain.Shared.Enums;

namespace AntiTail.Domain.Interfaces.Services
{
    public interface IExerciseService
    {
        Task<Exercise> CreateExercise(long subjectId, string title, string description);

        Task<List<Exercise>> GetAllExercises(long subjectId);

        Task<Exercise> GetExerciseById(long id);

        Task<bool> UpdateExercise(long id, string title, string description);

        Task<bool> UpdateExerciseStatus(long id, Status status);

        Task<bool> DeleteExercise(long id);
    }
}
