using AntiTail.Domain.Interfaces.Subtasks;
using AntiTail.Domain.Models;

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

        public async Task<bool> UpdateSubtaskStatus(long id, Status status)
        {
            return await _subtaskRepository.UpdateStatus(id, status);
        }

        public async Task<bool> DeleteSubtask(long id)
        {
            return await _subtaskRepository.Delete(id);
        }
    }
}
