using ASPCoreWebAPICRUD.AppDbContext;
using ASPCoreWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly StudentDBContext _db;

        public StudentApiController(StudentDBContext db)
        {
            _db = db; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Students>>> GetStudent()
        {
            var data = await _db.Student.ToListAsync();
            return Ok(data);//200
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudentById(int id)
        {
            var student = await _db.Student.FindAsync(id);
            if(student== null)
            {
                return NotFound();//404 statuscode response
            }
            return student;
        }

        [HttpPost]
        public async Task<ActionResult<Students>> CreateStudent(Students student)
        {
            if (student == null)
            {
                return NotFound();//404 statuscode response
            }
            await _db.Student.AddAsync(student);
            await _db.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Students>> UpdateStudent(int id,Students student)
        {
            if (id != student.Id)
            {
                return BadRequest();//400 
            }
            _db.Entry(student).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Students>> DeleteStudent(int id)
        {
            
            var stdid = await _db.Student.FindAsync(id);
            if (stdid == null)
            {
                return NotFound();
            }
            _db.Student.Remove(stdid);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
