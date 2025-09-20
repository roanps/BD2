namespace EFTest.Repository
{
    public interface IStudentCoursesRepository
    {
        public Task Create(StudentCoursesRepository studentCourses);
        public Task Update(StudentCoursesRepository studentCourses);
        public Task Delete( StudentCoursesRepository studentCourses);
        
        public Task<StudentCoursesRepository> GetByStudentId(int id);
        public Task<StudentCoursesRepository> GetByCourseId(int id);
        public Task<StudentCoursesRepository> Get(int studentId, int courseId);
        public Task<List<StudentCoursesRepository>> GetAll();
        public Task<List<StudentCoursesRepository>> GetByCourseName(string name);
        public Task<List<StudentCoursesRepository>> GetByStudentName(string name);
    }
}
