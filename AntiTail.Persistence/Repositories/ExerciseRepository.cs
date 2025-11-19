using AntiTail.Domain.Interfaces.Exercises;
using AntiTail.Domain.Models;
using AntiTail.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AntiTail.Persistence.Repositories
{
    public class ExerciseRepository(AntiTailDbContext Context) : IExerciseRepository
    {
        private readonly AntiTailDbContext _context = Context;

        public async Task<Exercise> Create(long subjectId, string title, string description)
        {
            var exercise = new Exercise(subjectId, title, description);

            await _context.AddAsync(exercise);
            await _context.SaveChangesAsync();

            return exercise;
        }

        public async Task<List<Exercise>> GetAll(long subjectId)
        {
            var exercises = await _context.Exercises
                .AsNoTracking()
                .Where(e => e.SubjectId == subjectId)
                .ToListAsync();

            if (exercises.Count == 0)
            {
                throw new NotFoundException("Exercises are not found.");
            }

            return exercises;
        }

        public async Task<Exercise> GetById(long id)
        {
            return await _context.Exercises
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id) ?? throw new NotFoundException("Exercise is not found.");
        }

        public async Task<bool> Update(long id, string title, string description)
        {
            var rows = await _context.Exercises
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(
                    e => e
                    .SetProperty(e => e.Title, title)
                    .SetProperty(e => e.Description, description));

            if (rows == 0)
            {
                throw new NotFoundException("Exercise is not found.");
            }

            return true;
        }

        public async Task<bool> UpdateStatus(long id, Status status)
        {
            var rows = await _context.Exercises
                .Where(e => e.Id == id)
                .ExecuteUpdateAsync(
                    e => e
                    .SetProperty(e => e.Status, status));

            if (rows == 0)
            {
                throw new NotFoundException("Exercise is not found.");
            }

            return true;
        }

        public async Task<bool> Delete(long id)
        {
            var rows = await _context.Exercises
                .Where(e => e.Id == id)
                .ExecuteDeleteAsync();

            if (rows == 0)
            {
                throw new NotFoundException("Exercise is not found.");
            }

            return true;
        }
    }
}
