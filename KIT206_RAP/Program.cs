using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
// uncomment when somehting added
using KIT206_RAP.DataBase;
using KIT206_RAP.Controll;
using KIT206_RAP.Researchers;
using KIT206_RAP.View;
//using KIT206_RAP.DataBase;

namespace KIT206_RAP
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // fetch all staff
            // SELECT * FROM students;
            // SELECT name, age FROM students;

            ResearcherControl.DisplayResearchers();

            // fetch all students 
            // SELECT * FROM staff;
            // SELECT name, age FROM students;
            
        }
    }
}
