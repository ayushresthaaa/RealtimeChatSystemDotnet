using StudentRecordSystem.Services.Interfaces; 
using StudentRecordSystem.Models.DTO;
namespace StudentRecordSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterStudentAsync(RegisterStudentDTO dto);
        Task<string> RegisterInstructorAsync(RegisterInstructorDTO dto);
        Task<LoginResponse> LoginAsync(LoginDTO dto);
    }
}