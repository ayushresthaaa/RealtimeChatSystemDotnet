using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using StudentRecordSystem.Models;
using StudentRecordSystem.Data;
using System.Runtime.CompilerServices;
namespace StudentRecordSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(StudentRecordDbContext _context) : ControllerBase
    {
        // private readonly StudentRecordDbContext _context;

        // public CoursesController(StudentRecordDbContext context) 
        // {
        //     _context = context;
            
        // }
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();

            return Ok("Sucessfully added course");
        }

        [HttpGet]
        public async  Task<IActionResult> GetAllCourses()
        {
            var courses = await _context.Courses.Select(c => new {c.Name, c.Modules}).ToListAsync(); 
            return Ok(courses);
        }
    }
}