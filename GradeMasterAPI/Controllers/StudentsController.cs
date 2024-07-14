using GradeMasterAPI.Controllers.DB;
using GradeMasterAPI.Controllers.DB.DBModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradeMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/<StudentsController>
        [HttpGet]
        public IActionResult Get()
        {
            StudentsRepository studentsRepo = new StudentsRepository();
            List<Student> students = studentsRepo.GetAllStudents();
            return Ok(students);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            StudentsRepository studentsRepo = new StudentsRepository();
            Student student = studentsRepo.GetStudent(id);
            if(student != null)
                return Ok(student);
            return NotFound("Student Not Found!");
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] Student studentInput)
        {
            StudentsRepository studentRepo=new StudentsRepository();
            string errors = await studentRepo.InsertStudentAsync(studentInput);
            if (errors == string.Empty)
                return studentInput;
            return BadRequest("student not inserted: "+errors);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student studentInput)
        {
            StudentsRepository studentRepo = new StudentsRepository();
            studentRepo.UpdateStudent(id,studentInput);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
