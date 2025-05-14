using CollegeSystem.DTO;
using CollegeSystem.Entities;
using CollegeSystem.JWT;
using CollegeSystem.Repositories;

namespace CollegeSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IAuthRepository authRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _authRepository = authRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Register(RegisterDto dto)
        {
            var existingUser = await _authRepository.GetUserByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return "Email already exists";
            }

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            await _authRepository.AddUserAsync(user);

            return "Registration successful";
        }

        public async Task<string> Login(LoginDto dto)
        {
            var user = await _authRepository.GetUserByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return "Invalid credentials";
            }

            return _jwtTokenGenerator.GenerateToken(user);
        }
    }

}
