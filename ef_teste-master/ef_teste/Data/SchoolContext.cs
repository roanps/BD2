using ef_teste.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_teste.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) 
        { 

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<StudentCourses>().ToTable("StudentCourse");
        }
        //Comando para criar a migration
        //dotnet ef migrations add initial

    }
}
