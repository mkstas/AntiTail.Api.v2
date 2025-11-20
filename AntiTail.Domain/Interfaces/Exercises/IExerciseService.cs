using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Exercises
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
