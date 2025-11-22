using AntiTail.Domain.Interfaces.Repositories;
using AntiTail.Domain.Interfaces.Services;
using AntiTail.Domain.Entities;

namespace AntiTail.Application.Services
{
    public class SubjectService(
        ISubjectRepository subjectRepository) : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository = subjectRepository;

        public async Task<List<Subject>> GetAllSubjects(long userId)
        {
            return await _subjectRepository.GetAll(userId);
        }

        public async Task<Subject> GetSubjectById(long id)
        {
            return await _subjectRepository.GetById(id);
        }

        public async Task<Subject> CreateSubject(long userId, string title)
        {
            return await _subjectRepository.Create(userId, title);
        }

        public async Task<bool> UpdateSubject(long id, long userId, string title)
        {
            return await _subjectRepository.Update(id, userId, title);
        }

        public async Task<bool> DeleteSubject(long id)
        {
            return await _subjectRepository.Delete(id);
        }
    }
}
