using System; 
using StudentRecordSystem.Models.DTO; 
using StudentRecordSystem.Models; 

namespace StudentRecordSystem.Services.Interfaces
{
    public interface IModuleService
    {
        public Task<string> AddModuleAsync(ModuleCreationDTO moduleCreationDTO);  //never write async on the interface, only on the implementation.
        

    }
}