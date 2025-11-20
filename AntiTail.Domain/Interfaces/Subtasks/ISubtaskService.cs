using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Subtasks
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
