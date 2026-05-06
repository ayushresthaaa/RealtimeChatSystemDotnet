using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Models; 
using StudentRecordSystem.Models.DTO; 
using StudentRecordSystem.Data;
using StudentRecordSystem.Services.Interfaces;
using StudentRecordSystem.Models.DTO.APIResponse;
namespace StudentRecordSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController(IModuleService moduleService) : ControllerBase
    {

        //if you keep validations on the DTO then you can send out the error messages to the client if the validation fails.
        //but the entity validation will just throw an exception and the client will not know what went wrong.
        [HttpPost]
        public async Task<ApiResponse<Module>> AddModule(ModuleCreationDTO moduleCreationDTO)
        {
            var response = await  moduleService.AddModuleAsync(moduleCreationDTO);
            return new ApiResponse <Module>()
            {
                Success = true,
                Message = response,
                Data = null
            };
        }
    }
}