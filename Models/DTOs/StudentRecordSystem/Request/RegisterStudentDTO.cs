using System.ComponentModel.DataAnnotations;

namespace StudentRecordSystem.Models.DTO
{
    public class RegisterStudentDTO
{
    [Required, StringLength(50)]
    public string FirstName { get; set;} = string.Empty;

    [Required, StringLength(50)]
    public string LastName { get; set;} = string.Empty;

    [Required]
    public DateOnly DateOfBirth { get; set;} = DateOnly.MinValue;

    [Required, EmailAddress]
    public string Email { get; set;} = string.Empty;

    [Required, StringLength(10)]
    public string Phone { get; set;} = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
}
}