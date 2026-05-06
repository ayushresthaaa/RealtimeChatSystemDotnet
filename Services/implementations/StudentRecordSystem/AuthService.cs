using Microsoft.AspNetCore.Identity;
using StudentRecordSystem.Data;
using StudentRecordSystem.Data.Entities;
using StudentRecordSystem.Models;
using StudentRecordSystem.Models.DTO;
using StudentRecordSystem.Services.Interfaces;

namespace StudentRecordSystem.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly StudentRecordDbContext _context;
        private readonly SignInManager<User> _signInManager ; 
        private readonly JwtService _jwtService; 

        public AuthService(UserManager<User> userManager,
                           StudentRecordDbContext context, SignInManager<User> signInManager, JwtService jwtService)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager; 
            _jwtService = jwtService; 
        }

        public async Task<string> RegisterStudentAsync(RegisterStudentDTO dto)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var user = new User
                {
                    UserName = dto.Email.Split('@').First(),
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                };

                var result = await _userManager.CreateAsync(user, dto.Password);

                if (!result.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return "User creation failed";
                }

                var roleResult = await _userManager.AddToRoleAsync(user, "Student");

                if (!roleResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return "Role assignment failed";
                }

                var student = new StudentRecordSystem.Models.Student
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Phone = dto.Phone,
                    DateOfBirth = dto.DateOfBirth,
                    UserId = user.Id
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return "Student registered successfully";
            }
            catch
            {
                await transaction.RollbackAsync();
                return "Student registration failed";
            }
        }
        public async Task<string> RegisterInstructorAsync(RegisterInstructorDTO dto)
        {
            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return "User creation failed";

            await _userManager.AddToRoleAsync(user, "Instructor");

            var instructor = new Instructor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                UserId = user.Id
            };

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();

            return "Instructor registered successfully";
        }

        // public async Task<string> LoginAsync(LoginDTO dto)
        // {
        //     var user = await _userManager.FindByEmailAsync(dto.Email);

        //     if (user == null)
        //         return "Invalid credentials";

        //     var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);

        //     if (!passwordValid)
        //         return "Invalid credentials";

        //     var roles = await _userManager.GetRolesAsync(user);
        //     var role = roles.FirstOrDefault() ?? "No Role";

        //     return $"Login successful as {role}";
        // }

        public async Task<LoginResponse> LoginAsync(LoginDTO dto)
        {
            User? user = await _userManager.FindByEmailAsync(dto.Email);  //could throw error 
            if (user == null) return new LoginResponse {Success = false, Message = "User with that email doesnt exist", Token = ""}; 
            
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure:false); 

            if(!signInResult.Succeeded)
            {
                return new LoginResponse
                {
                    Success = false, Message = "Password is incorrect", 
                }; 
            }

            return new LoginResponse { Success = true, Message = "Login success", Token = _jwtService.GenerateToken()} ; 
        }
     }
}