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
        public Staff(List<string> positions,List<Student> Supervisions, string firstName, string lastName, string title, string schoolUnit, string email, string currentJobTitle, DateTime commencement, DateTime commenceCurrentPosition, List<Publication> publications, int q1Percentage) : base(firstName, lastName, title, schoolUnit, email, currentJobTitle, commencement, commenceCurrentPosition, publications, q1Percentage)
        {
            // i think this is wrong as we are passing in a list of studenst and positions but then making a new list here??
            Positions = new List<string>();
            Supervisions = new List<Student>();
        }
    }
}
