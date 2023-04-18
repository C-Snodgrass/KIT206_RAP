using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP
{
    internal class Researcher
    {
        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string SchoolUnit { get; set; }
        public string Email { get; set; }
        public string CurrentJobTitle { get; set; }
        public DateTime Commencement { get; set; }
        public DateTime CommenceCurrentPosition { get; set; }
        public List<Publication> Publications { get; set; }
        //public int Q1Percentage { get; set; }

        // Constructor
        public Researcher(string firstName, string lastName, string title, string schoolUnit, string email, string currentJobTitle, DateTime commencement, DateTime commenceCurrentPosition, List<Publication> publications, int q1Percentage)
        {
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            SchoolUnit = schoolUnit;
            Email = email;
            CurrentJobTitle = currentJobTitle;
            Commencement = commencement;
            CommenceCurrentPosition = commenceCurrentPosition;
            Publications = publications;
            //_Q1Percentage = Q1Percentage();
        }

        //methods here
        public double Q1Percentage()
        {
            int q1Count = 0;
            int totalPublications = Publications.Count;

            foreach (Publication publication in Publications)
            {
                if (publication.Ranking == RankingType.Q1)
                {
                    q1Count++;
                }
            }

            double percentage = (double)q1Count / totalPublications * 100;
            return percentage;
        }


    }

    public enum Campus
    {
        Hobart,
        Launceston,
        Cradle_Coast
    }
}


