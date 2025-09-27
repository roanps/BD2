using EFTest.Models;
using EFTest.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFTest.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
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

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var student =
                await _courseRepository.GetById(id.Value);

            if (student is null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Course course)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != course.ID)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _courseRepository.Update(course);
                return RedirectToAction("Index");
            }

            return View(course);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
