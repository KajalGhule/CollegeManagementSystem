using Microsoft.AspNetCore.Mvc;
using CollegeSystem.DTO;
using CollegeSystem.Services;

namespace CollegeSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _authService.Register(registerDto);
            if (result == "Registration successful")
            {
                return Ok(new { message = result });
            }
            return BadRequest(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.Login(loginDto);
            if (result == "Invalid credentials")
            {
                return Unauthorized(new { message = result });
            }

            return Ok(new { token = result });
        }
    }

}
