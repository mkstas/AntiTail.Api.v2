using AntiTail.Domain.Shared.Enums;

namespace AntiTail.Domain.Entities
{
    public class Subtask(long exerciseId, string title)
    {
        public long Id { get; set; }

        public long ExerciseId { get; set; } = exerciseId;

        public string Title { get; set; } = title;

        public Status Status { get; set; } = Status.Pending;

        public Exercise? Exercise { get; set; }
    }
}
