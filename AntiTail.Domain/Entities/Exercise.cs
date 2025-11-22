using AntiTail.Domain.Shared.Enums;

namespace AntiTail.Domain.Entities
{
    public class Exercise(long subjectId, string title, string description = "")
    {
        public long Id { get; set; }

        public long SubjectId { get; set; } = subjectId;

        public string Title { get; set; } = title;

        public string Description { get; set; } = description;

        public Status Status { get; set; } = Status.Pending;

        public Subject? Subject { get; set; }

        public List<Subtask> Subtasks { get; set; } = [];
    }
}
