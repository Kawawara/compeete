using CompeeteData.Models;

namespace CompeeteData.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string mail);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task CreateNewUserAsync(User user);

    }
}
