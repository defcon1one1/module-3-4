namespace module_3_4.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public bool IsDeprecated { get; set; }
        public List<Module> Modules { get; set; }

        public List<Student> Students { get; set; }
    }
}