using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;

namespace StudentAPI.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            
          
            return Ok(await _context.Students.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());  
        }
        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student student)
        {
            var dbStudent = await _context.Students.FindAsync(student.Id);
            if (dbStudent == null)
                return BadRequest();

            dbStudent.firstName = student.firstName;
            dbStudent.lastName = student.lastName;
            dbStudent.place = student.place;

            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var student =await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());

             

        }
    }
}
