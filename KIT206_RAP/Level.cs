using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Level
    {
        public char EmpLevel { get; set; }
        public string JobTitle { get; set; }
        public double ExpectedNoPublications { get; set; }


        public Level(char empLevel)
        {
            EmpLevel = empLevel;

            switch (empLevel)
            {
                case 'A':
                    JobTitle = "Research Associate";
                    ExpectedNoPublications = 0.5;
                    break;
                    
                case 'B':
                    JobTitle = "Lecturer";
                    ExpectedNoPublications = 1;
                    break;
                    
                case 'C':
                    JobTitle = "Assistant Professor";
                    ExpectedNoPublications = 2;
                    break;

                case 'D':
                    JobTitle = "Associate Professor";
                    ExpectedNoPublications = 3.2;
                    break;

                case 'E':
                    JobTitle = "Professor";
                    ExpectedNoPublications = 4;
                    break;

                default:
                    throw new ArgumentException("Invalid level character");

            }
        }
    }


}
