using API.Models.Domain;

namespace API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(User user);
        Task<User> GetUserData(int userId);
        Task<User> RegisterAsync(User user);
    }
}
