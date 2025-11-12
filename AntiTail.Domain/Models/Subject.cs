namespace AntiTail.Domain.Models
{
    public class Subject(long userId, string title)
    {
        public long Id { get; set; }

        public long UserId { get; set; } = userId;

        public string Title { get; set; } = title;

        public User? User { get; set; }

        public List<Task> Tasks = [];
    }
}
