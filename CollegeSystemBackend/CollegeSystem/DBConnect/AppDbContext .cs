using CollegeSystem.Entities;
using Microsoft.EntityFrameworkCore;


namespace CollegeSystem.DBConnect
{
    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StaffSubject> StaffSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many: Staff <-> Subject
            modelBuilder.Entity<StaffSubject>()
                .HasKey(ss => new { ss.StaffId, ss.SubjectId });

            modelBuilder.Entity<StaffSubject>()
                .HasOne(ss => ss.Staff)
                .WithMany(s => s.StaffSubjects)
                .HasForeignKey(ss => ss.StaffId);

            modelBuilder.Entity<StaffSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StaffSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            // One-to-Many: College -> Departments
            modelBuilder.Entity<Department>()
                .HasOne(d => d.College)
                .WithMany(c => c.Departments)
                .HasForeignKey(d => d.CollegeId);

            // One-to-Many: Department -> Staff
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Department)
                .WithMany(d => d.StaffMembers)
                .HasForeignKey(s => s.DepartmentId);

            // One-to-Many: Department -> Students
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId);

            // One-to-One: Department -> HOD (Staff)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.HOD)
                .WithMany()
                .HasForeignKey(d => d.HODId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many: Subject -> Staff (optional direct relation)
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Staff)
                .WithMany(st => st.Subjects)
                .HasForeignKey(s => s.StaffId)
                .OnDelete(DeleteBehavior.SetNull);

            // One-to-one: User <-> Student
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId);

            // One-to-one: User <-> Staff
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.User)
                .WithOne(u => u.Staff)
                .HasForeignKey<Staff>(s => s.UserId);
        }
    }

}
