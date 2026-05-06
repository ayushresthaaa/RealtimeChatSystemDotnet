using StudentRecordSystem.Models; 
using StudentRecordSystem.Models.DTO;
using StudentRecordSystem.Services.Interfaces;
using StudentRecordSystem.Data; 
namespace StudentRecordSystem.Services.Implementations
{
    public class ModuleService(StudentRecordDbContext _context) : IModuleService
    {
        public async Task<string> AddModuleAsync( ModuleCreationDTO moduleCreationDTO)
        {
            Module module = new Module()
            {
                Name = moduleCreationDTO.Name,
                Credits = moduleCreationDTO.Credits,
                CourseId = moduleCreationDTO.CourseId
            }; 
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();
            return "Module added successfully";
        }
    }
}