namespace CollegeSystem.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CollegeId { get; set; }
        public College College { get; set; }

        public int? HODId { get; set; }
        public Staff HOD { get; set; }

        public ICollection<Staff> StaffMembers { get; set; }
        public ICollection<Student> Students { get; set; }
    }

}
