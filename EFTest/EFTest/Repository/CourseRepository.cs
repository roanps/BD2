using EFTest.Data;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _schoolContext;

        public CourseRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task Create(Course course)
        {
            await _schoolContext.Courses.AddAsync(course);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _schoolContext.Courses.Remove(course);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAll()
        {
            return await _schoolContext.Courses.ToListAsync();
        }

        public async Task<Course?> GetById(int id)
        {
            return await _schoolContext.Courses
                .Where(w => w.ID == id)
                .FirstOrDefaultAsync();
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
}
