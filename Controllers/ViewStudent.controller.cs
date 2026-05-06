// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Options;
// [ApiController]
// [Route("api/[controller]")]
// public class StudentController : ControllerBase
// {
//     List<Student> students = new List<Student>();

//     IConfiguration _configuration; //this is a private field that will hold the configuration settings for the controller. The IConfiguration interface is used to access configuration values from various sources (e.g., appsettings.json, environment variables, etc.) in a consistent way. By declaring it as a private field, we can use it within the controller methods to retrieve configuration values when needed.
//     public StudentController(IConfiguration configuration) 
//     {
//         students.Add(new Student { Id = 1, Name = "Ayush", Age = 20, Grade = "A", Course = "Computer Science" });
//         students.Add(new Student { Id = 2, Name = "Raman", Age = 22, Grade = "B", Course = "Mathematics" });
//         students.Add(new Student { Id = 3, Name = "Ram", Age = 21, Grade = "A", Course = "Physics" });
//         // _configuration = configuration; //this can be done with primary constructor as well, but here we are using the traditional way of assigning the configuration to a private field. The IConfiguration interface is used to access configuration settings in the application, such as connection strings, app settings, etc. By injecting it into the constructor, we can use it to retrieve configuration values when needed within the controller.
//         //to do from the primary constructor, we can simply declare the constructor parameter as public and assign it directly to a property, like this:
//         //public StudentController(IConfiguration configuration) 
//         //{
//         //    Configuration = configuration;
//         //}
//         _configuration = configuration;

//     }

//     [HttpGet("getAll")]
//     public List<Student> getAllStudents()
//     {   return students; 
//     }

//     [HttpGet("{id}")]
//     public string getStudentById(int id)

//     {   
       
//         return students.FirstOrDefault(s => s.Id == id)? .Name ?? "no student found for that id";
//     }
//     [HttpPost("add")]
//     public IActionResult addStudent(Student student)
//     {
//         students.Add(student);
//         return CreatedAtAction(nameof(getStudentById), new { id = student.Id }, student);
//     }

//     [HttpDelete("{id}")]
//     public IActionResult deleteStudent(int id)
//     {
//         if (id < 0 || id >= students.Count)
//         {
//             return NotFound("No student found for that id");
//         }
        
//         students.RemoveAt(id);
//         return Ok("Student deleted successfully");
//     }


//     [HttpPut("{id}")]
//     public IActionResult updateStudent(int id, Student updatedStudent)
//     {
//         Student? student = students.FirstOrDefault(s => s.Id == id) ;
//         if (student == null)
//         {
//             return NotFound("No student found for that id");
//         }
//         student.Name = updatedStudent.Name;
//         student.Age = updatedStudent.Age;
//         student.Grade = updatedStudent.Grade;
//         student.Course = updatedStudent.Course;
//         return Ok("Student updated successfully");
//     }

//     [HttpGet("config")]
//     public IActionResult GetSomethingFromSetting(IOptions<Student> options) { 
//         Student student = options.Value; 
//         return student != null ? Ok(student) : NotFound("Student configuration not found"); 
//     }
// }


