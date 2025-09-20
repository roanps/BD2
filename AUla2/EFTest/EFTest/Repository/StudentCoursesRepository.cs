using EFTest.Data;
using EFTest.Models;

namespace EFTest.Repository
{
    public class StudentCoursesRepository : IStudentCoursesRepository
    {
        private readonly SchoolContext _schoolContext;

        public StudentCoursesRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public Task Create(StudentCoursesRepository studentCourses);
        public Task Update(StudentCoursesRepository studentCourses);
        public Task Delete(StudentCoursesRepository studentCourses);

        public Task<StudentCoursesRepository> GetByStudentId(int id);
        public  Task<StudentCoursesRepository> GetByCourseId(int id);
        public async Task<StudentCoursesRepository> Get(int studentId, int courseId)
        {
            var data = await _schoolContext.StudentCourses
                .Include(x => x.Course)
                .Include(x => x.Student)
                .Where(w => w.StudentOd == studentId && w.CourseId == courseId)
                .FirstOrDefaulAsync();
        }
        public Task<List<StudentCoursesRepository>> GetAll();
        public Task<List<StudentCoursesRepository>> GetByCourseName(string name);
        public Task<List<StudentCoursesRepository>> GetByStudentName(string name);
    }
}
}
