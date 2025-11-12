namespace AntiTail.Domain.Models
{
    public enum Status
    {
        Pending,
        Succeeded,
    }

    public class Task(long subjectId, string title, string? description = null)
    {
        public long Id { get; set; }

        public long SubjectId { get; set; } = subjectId;

        public string Title { get; set; } = title;

        public string? Description { get; set; } = description;

        public Status Status { get; set; } = Status.Pending;

        public Subject? Subject { get; set; }

        public List<Subtask> Subtasks { get; set; } = [];
    }
}
