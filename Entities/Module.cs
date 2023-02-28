namespace module_3_4.Entities
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<StudentGrade> StudentGrades { get; set; }
    }
}