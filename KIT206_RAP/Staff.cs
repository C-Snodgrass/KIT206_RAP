using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Staff : Researcher
    {
        public List<string> Positions { get; set; }
        public List<Student> Supervisions { get; set; }
        public int ThreeYearAverage
        {
            get
            {
                int count = 0;
                int sum = 0;
                DateTime threeYearsAgo = DateTime.Now.AddYears(-3);

                foreach (Publication publication in Publications)
                {
                    if (publication.PublicationYear >= threeYearsAgo)
                    {
                        count++;
                        sum += publication.Q1Ranked ? 4 : 1;
                    }
                }

                return count > 0 ? (int)Math.Round((double)sum / count, MidpointRounding.AwayFromZero) : 0;
            }
        }

        public Staff(string firstName, string lastName, string email) : base(firstName, lastName, title, schoolUnit, email, currentJobTitle, commencement, commenceCurrentPosition, publications, q1Percentagefirst)
        {
            Positions = new List<string>();
            Supervisions = new List<Student>();
        }
    }
}
