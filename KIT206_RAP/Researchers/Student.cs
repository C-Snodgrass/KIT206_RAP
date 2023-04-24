using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP.Researchers

{
    internal class Student : Researcher
    {
        public Staff Supervisor { get; set; }
        public string Degree { get; set; }

        public Student(string firstName, string lastName, Campus campus, string schoolUnit, string email, List<Publication> publications, Staff supervisor, string degree)
                : base(firstName, lastName, campus, schoolUnit, email, publications)
        {
            Supervisor = supervisor;
            Degree = degree;
        }
    }
}
