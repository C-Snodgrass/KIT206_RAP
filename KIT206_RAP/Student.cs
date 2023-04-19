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

        public Student(string firstName, string lastName, string title, string schoolUnit, string email, string currentJobTitle, DateTime commencement, DateTime commenceCurrentPosition, List<Publication> publications, int q1Percentage, Staff supervisor, Position position, string degree) : base(firstName, lastName, title, schoolUnit, email, currentJobTitle, commencement, commenceCurrentPosition, publications, q1Percentage)
        {
            Supervisor = supervisor;
            Postition = position;
            Degree = degree;
        }
    }
}
