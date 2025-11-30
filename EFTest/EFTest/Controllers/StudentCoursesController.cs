using EFTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentCoursesRepository _studentCoursesRepository;

        public StudentCoursesController(
            ICourseRepository courseRepository, 
            IStudentRepository studentRepository, 
            IStudentCoursesRepository studentCoursesRepository
        )
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _studentCoursesRepository = studentCoursesRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _studentRepository.GetAll();

            return View(data);
        }
    }
}
