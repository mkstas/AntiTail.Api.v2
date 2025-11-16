namespace AntiTail.Domain.Models
{
    public class Subtask(long taskId, string title)
    {
        public long Id { get; set; }

        public long ExerciseId { get; set; } = taskId;

        public string Title { get; set; } = title;

        public Status Status { get; set; } = Status.Pending;

        public Exercise? Exercise { get; set; }
    }
}
