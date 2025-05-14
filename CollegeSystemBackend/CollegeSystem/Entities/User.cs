namespace CollegeSystem.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Student, Staff, HOD, CollegeAdmin

        public Student Student { get; set; }
        public Staff Staff { get; set; }
    }

}
