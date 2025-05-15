using CollegeSystem.Entities;

namespace CollegeSystem.Repositories
{
    public interface IStaffRepository
    {
        Task AddStaffAsync(Staff staff);
    }
}
