using CollegeSystem.Entities;

namespace CollegeSystem.Repositories
{
    public interface IAuthRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
