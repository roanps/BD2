using System.Diagnostics;
using EFTest.Data;
using EFTest.Models;
using EFTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IStudentRepository studentRepository
        )
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _studentRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        { 
            if (ModelState.IsValid)
            {
                await _studentRepository.Create(student);
                return RedirectToAction("Index");
            }
            return View(student);
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
                await _studentRepository.GetById(id.Value);

            if (student is null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Student student)
        {
            if (!id.HasValue)
                return BadRequest();

            if(id.Value != student.ID)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _studentRepository.Update(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            await _studentRepository.Delete(student);
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
