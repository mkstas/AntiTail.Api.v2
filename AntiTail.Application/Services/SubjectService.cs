using AntiTail.Domain.Interfaces.Subjects;
using AntiTail.Domain.Models;

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

        public async Task<Subject> UpdateSubject(long userId, long id, string title)
        {
            return await _subjectRepository.Update(userId, id, title);
        }

        public async Task<bool> DeleteSubject(long id)
        {
            return await _subjectRepository.Delete(id);
        }
    }
}
