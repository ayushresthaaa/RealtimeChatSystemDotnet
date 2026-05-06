using StudentRecordSystem.Data.Entities;

namespace StudentRecordSystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateOnly HireDate { get; set; } = DateOnly.MinValue;

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public List<ModuleInstructor> ModuleInstructors { get; set; } = new();
    }
}