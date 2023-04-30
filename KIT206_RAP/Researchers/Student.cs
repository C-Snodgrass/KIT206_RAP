﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP.Researchers

{
    internal class Student : Researcher
    {
        // public Staff Supervisor { get; set; }
        public int Supervisor { get; set; }
        public string Degree { get; set; }
        
        public Student(int id, string type,string firstName, string lastName, string title, string schoolUnit, string campHouse, string email, string photURL, int supervisorID, string degree, DateTime utas_start, DateTime curretn_start)
                : base(id,type, firstName, lastName, title, schoolUnit, campHouse, email, photURL, utas_start, curretn_start)
        {
            Supervisor = supervisorID;
            Degree = degree;
        }
    }
}
