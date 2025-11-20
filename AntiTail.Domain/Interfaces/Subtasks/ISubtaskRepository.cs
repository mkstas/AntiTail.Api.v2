using AntiTail.Domain.Models;

namespace AntiTail.Domain.Interfaces.Subtasks
{
    public interface ISubtaskRepository
    {
        Task<Subtask> Create(long exerciseId, string title);

        Task<List<Subtask>> GetAll(long exerciseId);

        Task<Subtask> GetById(long id);

        Task<bool> Update(long id, string title);

        Task<bool> UpdateStatus(long id, Status status);

        Task<bool> Delete(long id);
    }
}
