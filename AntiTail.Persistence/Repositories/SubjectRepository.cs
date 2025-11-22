using AntiTail.Domain.Interfaces.Repositories;
using AntiTail.Domain.Entities;
using AntiTail.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AntiTail.Persistence.Repositories
{
    public class SubjectRepository(AntiTailDbContext context) : ISubjectRepository
    {
        private readonly AntiTailDbContext _context = context;

        public async Task<Subject> Create(long userId, string title)
        {
            bool isExists = await _context.Subjects
                .AsNoTracking()
                .AnyAsync(u => u.UserId == userId && u.Title == title);

            if (isExists)
            {
                throw new ConflictException("Subject is already exists.");
            }

            var subject = new Subject(userId, title);

            await _context.AddAsync(subject);
            await _context.SaveChangesAsync();

            return subject;
        }

        public async Task<List<Subject>> GetAll(long userId)
        {
            return await _context.Subjects
                .AsNoTracking()
                .Where(s => s.UserId == userId)
                .ToListAsync() ?? throw new NotFoundException("Subjects are not found.");
        }

        public async Task<Subject> GetById(long id)
        {
            return await _context.Subjects
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id) ?? throw new NotFoundException("Subject is not found.");
        }

        public async Task<bool> Update(long id, long userId, string title)
        {
            bool isExists = await _context.Subjects
                .AsNoTracking()
                .AnyAsync(u => u.UserId == userId && u.Title == title);

            if (isExists)
            {
                throw new ConflictException("Subject is already exists.");
            }

            var updatedRows = await _context.Subjects
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(
                    s => s.SetProperty(s => s.Title, title));

            if (updatedRows == 0)
            {
                throw new NotFoundException("Subject is not found.");
            }

            return true;
        }

        public async Task<bool> Delete(long id)
        {
            var deletedRows = await _context.Subjects
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();

            if (deletedRows == 0)
            {
                throw new NotFoundException("Subject is not found.");
            }

            return true;
        }
    }
}
