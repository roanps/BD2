using ef_teste.Data;
using ef_teste.Models;

namespace ef_teste.Repository
{
    public class StudentCoursesRepository : IStudentCoursesRepository
    {
        private readonly SchoolContext _schollContext;
        public async Task Create(StudentCourses student)
        {
            await _schollContext.StudentCourses.AddAsync(student);
            await _schollContext.SaveChangesAsync();
        }

        public async Task Delete(StudentCourses student)
        {

        }

        public async Task<StudentCourses?> Get(int studentId, int courseId)
        {
            var data = await _schollContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(w => w.StudentId == studentId && w.CourseId == courseId)
                .FirstOrDefault();

            return data;
        }

        public async Task<List<StudentCourses>> GetAll()
        {
            var data = await _schollContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .ToListAsync();

            return data;
        }

        public async Task<StudentCourses?> GetByCourseId(int courseId)
        {

        }

        public async Task<List<StudentCourses>> GetByCourseName(string name)
        {
            var data = await _schollContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(w => w.Course!.Name!.ToLower().Contains(name.ToLower()))
                .ToListAsync();

            return data;
        }

        public async Task<StudentCourses?> GetByStudentId(int studentId)
        {

        }

        public async Task<List<StudentCourses>> GetByStudentName(string name)
        {

        }

        public async Task Update(StudentCourses student)
        {
            _schollContext.StudentCourses.AddAsync(student);
            await _schollContext.SaveChangesAsync();
        }
    }
}
