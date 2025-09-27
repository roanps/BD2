namespace EFTest.Controllers
{
    public class StudentCoursesController
    {
        [HttpGet]   
        public IActionResult GetAllStudentCourses()
        {
            return Ok();
        }


    }
}
