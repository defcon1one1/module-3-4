using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_3_4.Entities
{
    public class StudentGrade
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public int Grade { get; set; }

    }
}
