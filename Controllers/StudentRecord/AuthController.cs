using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Models.DTO;
using StudentRecordSystem.Services.Interfaces;

namespace StudentRecordSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("register-student")]
        public async Task<IActionResult> RegisterStudent(RegisterStudentDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterStudentAsync(dto);

            if (result == "User creation failed")
                return BadRequest(new { message = result });

            return Ok(new { message = result });
        }

        [HttpPost("register-instructor")]
        public async Task<IActionResult> RegisterInstructor(RegisterInstructorDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterInstructorAsync(dto);

            if (result == "User creation failed")
                return BadRequest(new { message = result });

            return Ok(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var loginResponse = await _authService.LoginAsync(dto); 

            // return loginResponse; if u send like this it would throw everything as success 
            return loginResponse.Success ? Ok(loginResponse) : Unauthorized(loginResponse); 
        }

    }
}