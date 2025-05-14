namespace CollegeSystem.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? StaffId { get; set; }
        public Staff Staff { get; set; }

        public ICollection<StaffSubject> StaffSubjects { get; set; }
    }

}
