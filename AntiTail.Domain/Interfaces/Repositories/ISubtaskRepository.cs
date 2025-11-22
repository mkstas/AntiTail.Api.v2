using AntiTail.Domain.Entities;
using AntiTail.Domain.Shared.Enums;

namespace AntiTail.Domain.Interfaces.Repositories
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
