using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP.Researchers

{
    internal class Student : Researcher
    {
        // public Staff Supervisor { get; set; }
        public string Supervisor { get; set; }
        public string Degree { get; set; }
        
        
        public Student(string firstName, string lastName, string title, bool isStudent, Campus campus, string schoolUnit, string email, string supervisor, string degree, Level level)
                : base(firstName, lastName, title, isStudent, campus, schoolUnit, email, level)
        {
            Supervisor = supervisor;
            Degree = degree;
        }
    }
}
