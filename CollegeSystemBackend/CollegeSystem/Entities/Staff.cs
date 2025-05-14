namespace CollegeSystem.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Admin, Faculty

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<StaffSubject> StaffSubjects { get; set; }
    }

}
