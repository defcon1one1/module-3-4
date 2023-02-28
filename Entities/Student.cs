using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_3_4.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Course> EnrolledCourses { get; set; }
        public List<Course> CompletedCourses { get; set; }
        public List<StudentGrade> StudentGrades { get; set; }



        //// Possible implementation of grades using Dictionary instead of a separate table

        /* private Dictionary<int, int> _grades = new Dictionary<int, int>();

        public void AddGrade(int moduleId, int mark)
        {
            // Check if the module is in one of the student's enrolled courses
            if (EnrolledCourses.Any(c => c.Modules.Any(m => m.ModuleId == moduleId)))
            {
                _grades[moduleId] = mark;
            }
            else
            {
                throw new InvalidOperationException("Cannot add grade for module that is not in an enrolled course.");
            }
        }

        public int GetGrade(int moduleId)
        {
            // Check if the module is in one of the student's enrolled courses
            if (EnrolledCourses.Any(c => c.Modules.Any(m => m.ModuleId == moduleId)))
            {
                int grade;
                _grades.TryGetValue(moduleId, out grade);
                return grade;
            }
            else
            {
                throw new InvalidOperationException("Cannot get grade for module that is not in an enrolled course.");
            }
        } */
    }
}

