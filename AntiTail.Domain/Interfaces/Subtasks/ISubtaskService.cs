using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Subtasks
{
    public interface ISubtaskService
    {
        Task<Exercise> CreateSubtask(long exerciseId, string title);

        Task<List<Subtask>> GetAllSubtasks(long exerciseId);

        Task<Subtask> GetSubtaskById(long subtaskId);

        Task<bool> UpdateSubtask(long subtaskId, string title);

        Task<bool> UpdateSubtaskStatus(long subtaskId, Status status);

        Task<bool> DeleteSubtask(long subtaskId);
    }
}
