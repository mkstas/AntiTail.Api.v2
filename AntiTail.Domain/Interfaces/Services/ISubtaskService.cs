using AntiTail.Domain.Entities;
using AntiTail.Domain.Shared.Enums;

namespace AntiTail.Domain.Interfaces.Services
{
    public interface ISubtaskService
    {
        Task<Subtask> CreateSubtask(long exerciseId, string title);

        Task<List<Subtask>> GetAllSubtasks(long exerciseId);

        Task<Subtask> GetSubtaskById(long id);

        Task<bool> UpdateSubtask(long id, string title);

        Task<bool> UpdateSubtaskStatus(long id, Status status);

        Task<bool> DeleteSubtask(long id);
    }
}
