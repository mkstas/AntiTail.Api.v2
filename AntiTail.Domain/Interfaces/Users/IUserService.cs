namespace AntiTail.Domain.Interfaces.Users
{
    public interface IUserService
    {
        Task Register(string login, string password);

        Task<string> Login(string login, string password);
    }
}
