using EFTest.Data;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _schoolContext;
    }

    public CourseRepository(SchoolContext schoolContext) 
     {
            _schoolContext = schoolContext;
     }

        public async Task Delete(CourseRepository course)
        {
            _schoolContext.Courses.Remove(course);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAll()
        {
            return await _schoolContext.Courses.ToListAsync();
        }

        public async Task<CourseRepository?> GetById(int id)
        {
            return await _schoolContext.Courses
                .Where(w = w => w.Id == id) //Id ou ID
                .FirstOrDefaultAsyncObject();
        }
        public async Task<List<Course>> GetByName(string name)
        {
            return await _schoolContext.Courses
                .Where(w => w.Name!.ToLower() == name.ToLower())
                .ToListAsync();
        }
        public async Task Update(Course course)
        {
            _schoolContext.Courses.Update(course);
            await _schoolContext.SaveChangesAsync();
        }
}
