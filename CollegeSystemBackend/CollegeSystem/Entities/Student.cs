namespace CollegeSystem.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // Link to User
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
