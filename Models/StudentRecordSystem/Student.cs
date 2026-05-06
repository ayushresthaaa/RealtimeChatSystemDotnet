using StudentRecordSystem.Data.Entities;
namespace StudentRecordSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string UserId { get; set;} = null!; 
        public string FirstName { get; set;} = string.Empty;
        public string LastName { get; set;} = string.Empty;
        public DateOnly DateOfBirth { get; set;} = DateOnly.MinValue;
        public string Email { get; set;} = string.Empty;
        public string Phone { get; set;} = string.Empty;
        public List<Enrollment> Enrollments { get; set;} = new List<Enrollment>();
        public User user { get; set;} = null!; 
    }
}