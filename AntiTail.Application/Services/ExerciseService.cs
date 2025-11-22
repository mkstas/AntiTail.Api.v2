using AntiTail.Domain.Interfaces.Repositories;
using AntiTail.Domain.Interfaces.Services;
using AntiTail.Domain.Entities;
using AntiTail.Domain.Shared.Enums;
using AntiTail.Infrastructure.Exceptions;

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

        public async Task<bool> UpdateExerciseStatus(long id, string status)
        {
            if (!Enum.TryParse(status, true, out Status statusEnum) || 
                !Enum.IsDefined(statusEnum))
            {
                throw new BadRequestException("Invalid status value.");
            }

            return await _exerciseRepository.UpdateStatus(id, statusEnum);
        }

        public async Task<bool> DeleteExercise(long id)
        {
            return await _exerciseRepository.Delete(id);
        }
    }
}
