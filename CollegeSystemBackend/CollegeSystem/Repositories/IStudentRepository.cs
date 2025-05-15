using CollegeSystem.Entities;

namespace CollegeSystem.Repositories
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
    }
}
