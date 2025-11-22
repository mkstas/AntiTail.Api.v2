using AntiTail.Domain.Entities;

namespace AntiTail.Domain.Interfaces.Services
{
    public interface IExerciseService
    {
        Task<Exercise> CreateExercise(long subjectId, string title, string description);

        Task<List<Exercise>> GetAllExercises(long subjectId);

        Task<Exercise> GetExerciseById(long id);

        Task<bool> UpdateExercise(long id, string title, string description);

        Task<bool> UpdateExerciseStatus(long id, string status);

        Task<bool> DeleteExercise(long id);
    }
}
