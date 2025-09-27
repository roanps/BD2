using ef_teste.Data;
using ef_teste.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ef_teste.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;
        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task Create(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAll()
        {
            var data = await _context.Courses.ToListAsync();
            return data;
        }

        public async Task<Course?> GetById(int id)
        {
            var course = 
                await _context
                .Courses
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
            return course;
        }

        public async Task<List<Course>> GetByName(string name)
        {
            var courses =
                await _context
                .Courses
                .Where(c => c.Name!
                .ToLower()
                .Contains(name.ToLower())
                )
                .ToListAsync();
            return courses;
        }

        public async Task Update(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
