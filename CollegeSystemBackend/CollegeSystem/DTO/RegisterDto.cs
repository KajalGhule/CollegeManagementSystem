namespace CollegeSystem.DTO
{
    public class RegisterDto
    {
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string Role { get; set; } // E.g., "Student", "Admin", "Staff", "HOD"

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Student, Faculty, HOD, Admin

        public string Name { get; set; }
        public string Email { get; set; }
        public int? DepartmentId { get; set; } // Nullable for Admin
    }

}
