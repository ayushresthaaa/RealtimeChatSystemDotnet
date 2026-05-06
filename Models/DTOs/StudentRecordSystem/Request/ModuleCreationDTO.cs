using System.ComponentModel.DataAnnotations; 
namespace StudentRecordSystem.Models.DTO
{
    public class ModuleCreationDTO
    {
        [Required]

        public string Name { get; set;} = string.Empty;
        [Required]
        [Range(1, 60, ErrorMessage = "Credits must be between 1 and 60.")]
        public int Credits { get; set;}
        [Required]
        public int CourseId { get; set;}
    } 
}