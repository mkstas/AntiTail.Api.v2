using AntiTail.Domain.Interfaces.Exercises;
using AntiTail.Domain.Models;

namespace AntiTail.Application.Services
{
    public class ExerciseService(
        IExerciseRepository exerciseRepository) : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

        public async Task<Exercise> CreateExercise(long subjectId, string title, string description)
        {
            return await _exerciseRepository.Create(subjectId, title, description);
        }

        public async Task<List<Exercise>> GetAllExercises(long subjectId)
        {
            return await _exerciseRepository.GetAll(subjectId);
        }

        public async Task<Exercise> GetExerciseById(long id)
        {
            return await _exerciseRepository.GetById(id);
        }

        public async Task<bool> UpdateExercise(long id, string title, string description)
        {
            return await _exerciseRepository.Update(id, title, description);
        }

        public async Task<bool> UpdateExerciseStatus(long id, Status status)
        {
            return await _exerciseRepository.UpdateStatus(id, status);
        }

        public async Task<bool> DeleteExercise(long id)
        {
            return await _exerciseRepository.Delete(id);
        }
    }
}
