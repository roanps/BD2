using ef_teste.Models;

namespace ef_teste.Repository
{
    public interface IStudentCoursesRepository
    {
        public Task Create(StudentCourses student);
        public Task Update(StudentCourses student);
        public Task Delete(StudentCourses student);

        public Task<List<StudentCourses?>> GetByStudentId(int studentId);
        public Task<List<StudentCourses?>> GetByCourseId(int courseId);
        public Task<List<StudentCourses?>> Get(int studentId, int courseId);
        public Task<List<StudentCourses>> GetAll();
        public Task<List<StudentCourses>> GetByCourseName(string name);
        public Task<List<StudentCourses>> GetByStudentName(string name);
    }
}
