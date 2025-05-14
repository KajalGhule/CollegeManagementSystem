using CollegeSystem.DTO;

namespace CollegeSystem.Services
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto dto);
        Task<string> Login(LoginDto dto);
    }
}
