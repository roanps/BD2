using System.ComponentModel.DataAnnotations;

namespace ef_teste.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstMidName { get; set; }
        public DateTime EnrollmentDate {  get; set; }
        public List<StudentCourses>? StudentCourses { get; set; }

    }
}
