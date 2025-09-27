using ef_teste.Models;
using ef_teste.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ef_teste.Controllers
{
    public class CourseController1 : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController1(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _courseRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseRepository.Create(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            await _courseRepository.Delete(course);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Course course)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id != course.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _courseRepository.Update(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (!id.HasValue)
                return BadRequest();

            var course = await _courseRepository.GetById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
