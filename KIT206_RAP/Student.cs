using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Student : Researcher
    {
        public Staff Supervisor { get; set; }
        public Position Postition { get; set; }
        public string Degree { get; set; }

        public Student(string firstName, string lastName, string email) : base (firstName, lastName, email) { }
    }
}
