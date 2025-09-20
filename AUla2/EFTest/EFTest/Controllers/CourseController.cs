using EFTest.Models;
using EFTest.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EFTest.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IActionResult Index()
        {         
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student course)
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
        {//editar
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var student = await _courseRepository.GetById(id.Value);

            if (student is null)
                return NotFound();

            return View(course);
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

            

    }
}
