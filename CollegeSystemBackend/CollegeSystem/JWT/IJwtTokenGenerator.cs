using CollegeSystem.Entities;

namespace CollegeSystem.JWT
{
    public interface IJwtTokenGenerator
    {
        String GenerateToken(User user);
    }
}
