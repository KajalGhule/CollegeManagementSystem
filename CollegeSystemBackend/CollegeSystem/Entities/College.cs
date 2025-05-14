namespace CollegeSystem.Entities
{
    public class College
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Department> Departments { get; set; }
    }

}
