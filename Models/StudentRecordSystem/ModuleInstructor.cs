namespace StudentRecordSystem.Models
{
    public class ModuleInstructor
    {
        public int ModuleId { get; set; }
        public int InstructorId { get; set; }

        public Module? Module { get; set; }
        public Instructor? Instructor { get; set; }
    }
}