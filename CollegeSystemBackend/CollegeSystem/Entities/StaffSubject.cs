namespace CollegeSystem.Entities
{
    public class StaffSubject
    {
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

}
