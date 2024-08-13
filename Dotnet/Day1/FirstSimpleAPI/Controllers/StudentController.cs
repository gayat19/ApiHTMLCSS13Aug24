using FirstSimpleAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstSimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //static string studentName = string.Empty;
        static List<Student> students = new List<Student>();
        [ProducesResponseType(typeof(List<Student>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            if(students.Count == 0)
                return NotFound(new ErrorModel { ErrorCode=404,Message="The student list is empty at this moment"});
            return Ok(students);
        }
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<Student> Post(Student student)
        {
            if (student.Id == 0)
                return BadRequest(new ErrorModel{ ErrorCode=401, Message  = "Id cannot be Zero" });
            students.Add(student);
            return Ok(student);
        }
    }
}
