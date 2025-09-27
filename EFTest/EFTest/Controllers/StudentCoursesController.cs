using EFTest.Repository;
using EFTest.ViewModels.StudentCourses;
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new StudentCoursesViewModel();
            viewModel.Students = await _studentRepository.GetAllNotEnrolled();

            viewModel.SetCourses(await _courseRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCoursesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                foreach(var c in viewModel.Courses)
                {
                   if(c.IsSelected)
                    {
                        await _studentCoursesRepository.Create(new Models.StudentCourses
                        {
                            StudentID = viewModel!.StudentId!,
                            CourseID = c.Id!,
                            SignDate = DateTime.Now
                        });
                    }
                }
                return RedirectToAction("Index");
            }
            
        }

    }
}
