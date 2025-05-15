using CollegeSystem.DTO;
using CollegeSystem.Entities;
using CollegeSystem.JWT;
using CollegeSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CollegeSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IStudentRepository _studentRepository;
        private readonly IStaffRepository _staffRepository;

        public AuthService(IAuthRepository authRepository, IJwtTokenGenerator jwtTokenGenerator, IStaffRepository staffRepository, IStudentRepository studentRepository)
        {
            _authRepository = authRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _staffRepository = staffRepository;
            _studentRepository = studentRepository;
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

            if (dto.Role == "Student")
            {
                var student = new Student
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    DepartmentId = dto.DepartmentId.Value,
                    UserId = user.Id
                };
                await _studentRepository.AddStudentAsync(student);
            }
            else if (dto.Role == "Faculty" || dto.Role == "HOD")
            {
                var staff = new Staff
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    DepartmentId = dto.DepartmentId.Value,
                    UserId = user.Id
                };
                await _staffRepository.AddStaffAsync(staff);
            }
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
