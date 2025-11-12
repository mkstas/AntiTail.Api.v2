namespace AntiTail.Domain.Models
{
    public class User(string login, string passwordHash)
    {
        public long Id { get; set; }

        public string Login { get; set; } = login;

        public string PasswordHash { get; set; } = passwordHash;

        public List<Subject> Subjects { get; set; } = [];
    }
}
