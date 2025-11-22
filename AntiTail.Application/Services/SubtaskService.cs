using AntiTail.Domain.Entities;
using AntiTail.Domain.Interfaces.Repositories;
using AntiTail.Domain.Interfaces.Services;
using AntiTail.Domain.Shared.Enums;
using AntiTail.Infrastructure.Exceptions;

namespace AntiTail.Application.Services
{
    public class SubtaskService(ISubtaskRepository subtaskRepository) : ISubtaskService
    {
        private readonly ISubtaskRepository _subtaskRepository = subtaskRepository;

        public async Task<Subtask> CreateSubtask(long exerciseId, string title)
        {
            return await _subtaskRepository.Create(exerciseId, title);
        }

        public async Task<List<Subtask>> GetAllSubtasks(long exerciseId)
        {
            return await _subtaskRepository.GetAll(exerciseId);
        }

        public async Task<Subtask> GetSubtaskById(long id)
        {
            return await _subtaskRepository.GetById(id);
        }

        public async Task<bool> UpdateSubtask(long id, string title)
        {
            return await _subtaskRepository.Update(id, title);
        }

        public async Task<bool> UpdateSubtaskStatus(long id, string status)
        {
            if (!Enum.TryParse(status, true, out Status statusEnum) &&
                !Enum.IsDefined(statusEnum))
            {
                throw new BadRequestException("Invalid status value.");
            }

            return await _subtaskRepository.UpdateStatus(id, statusEnum);
        }

        public async Task<bool> DeleteSubtask(long id)
        {
            return await _subtaskRepository.Delete(id);
        }
    }
}
