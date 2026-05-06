namespace StudentRecordSystem.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set;} = string.Empty;
        public int Credits { get; set;}
        public int CourseId { get; set;}
        public Course? Course { get; set;} = null!; 
         public List<ModuleInstructor> ModuleInstructors { get; set;} = new List<ModuleInstructor>();
    }
}