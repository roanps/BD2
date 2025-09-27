namespace ef_teste.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<StudentCourses>? StudentCourses { get; set; }
    }
}
