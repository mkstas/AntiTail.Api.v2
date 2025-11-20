using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Subtasks
{
    public interface ISubtaskRepository
    {
        Task<Subtask> Create(long exerciseId, string title);

        Task<List<Subtask>> GetAll(long exerciseId);

        Task<Subtask> GetById(long subtaskId);

        Task<bool> Update(long subtaskId, string title);

        Task<bool> UpdateStatus(long subtaskId, Status status);

        Task<bool> Delete(long subtaskId);
    }
}
