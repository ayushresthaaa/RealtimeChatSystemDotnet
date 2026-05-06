namespace StudentRecordSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set;} = string.Empty;
        public int DurationYears { get; set;}
        public List<Module> Modules { get; set;} = new List<Module>();
        public List<Enrollment> Enrollments { get; set;} = new List<Enrollment>();
    }
}