using AntiTail.Domain.Interfaces.Repositories;
using AntiTail.Domain.Entities;
using AntiTail.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using AntiTail.Domain.Shared.Enums;

namespace AntiTail.Persistence.Repositories
{
    public class SubtaskRepository(AntiTailDbContext context) : ISubtaskRepository
    {
        private readonly AntiTailDbContext _context = context;

        public async Task<Subtask> Create(long exerciseId, string title)
        {
            var subtask = new Subtask(exerciseId, title);

            await _context.AddAsync(subtask);
            await _context.SaveChangesAsync();

            return subtask;
        }

        public async Task<List<Subtask>> GetAll(long exerciseId)
        {
            var subtasks = await _context.Subtasks
                .AsNoTracking()
                .Where(s => s.ExerciseId == exerciseId)
                .ToListAsync();

            if (subtasks.Count == 0)
            {
                throw new NotFoundException("Subtasks are not found.");
            }

            return subtasks;
        }

        public async Task<Subtask> GetById(long id)
        {
            return await _context.Subtasks
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id) ?? throw new NotFoundException("Subtask is not found.");
        }

        public async Task<bool> Update(long id, string title)
        {
            var rows = await _context.Subtasks
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(
                    s => s
                    .SetProperty(s => s.Title, title));

            if (rows == 0)
            {
                throw new NotFoundException("Subtask is not found.");
            }

            return true;
        }

        public async Task<bool> UpdateStatus(long id, Status status)
        {
            var rows = await _context.Subtasks
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(
                    s => s
                    .SetProperty(s => s.Status, status));

            if (rows == 0)
            {
                throw new NotFoundException("Subtask is not found.");
            }

            return true;
        }

        public async Task<bool> Delete(long id)
        {
            var rows = await _context.Subtasks
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();

            if (rows == 0)
            {
                throw new NotFoundException("Subtask is not found.");
            }

            return true;
        }
    }
}
