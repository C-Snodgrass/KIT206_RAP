using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace KIT206_RAP.Researchers

{
    public enum Campus
    {
        Hobart,
        Launceston,
        Cradle_Coast
    }

    internal class Researcher
    {
        // Properties some of these are not necisary
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public bool IsStudent { get; set; }
        public string SchoolUnit { get; set; }
        public string Email { get; set; }
        public string CurrentJobTitle { get; set; }
        public DateTime CommenceCurrentPosition { get; private set; }
        public DateTime CommencedWithInstitution { get; private set; }
        public double Q1Percentage { get; private set; }
        public string JobTitle { get; set; }
        public double ExpectedNoPublications { get; set; }
        public Campus Campus { get; set; }
        public string photoPlaceHolder { get; set; }
        public double Tenure { get; private set; } // time in fractional years since the researcher commecned with the institution
        public Level positionLevle { get; set; }

        // Constructor
        public Researcher(string firstName, string lastName, String title, bool isStudent, Campus campus, string schoolUnit, string email, Level level)
        {
            FirstName = firstName;
            LastName = lastName;
            SchoolUnit = schoolUnit;
            IsStudent = isStudent;
            Email = email;
            positionLevle = level;
            photoPlaceHolder = FetchPhoto();
            Title = title;
            DeriveJobTitle(level);
        }
        
        public void DeriveJobTitle(Level level)
        {

            switch (level)
            {
                case Level.A:
                    JobTitle = "Research Associate";
                    ExpectedNoPublications = 0.5; 
                    break; 
                case Level.B:
                    JobTitle = "Lecturer";
                    ExpectedNoPublications = 1;
                    break;

                case Level.C:
                    JobTitle = "Assistant Professor";
                    ExpectedNoPublications = 2;
                    break;

                case Level.D:
                    JobTitle = "Associate Professor";
                    ExpectedNoPublications = 3.2;
                    break;

                case Level.E:
                    JobTitle = "Professor";
                    ExpectedNoPublications = 4;
                    break;

                default:
                    throw new ArgumentException("Invalid level character");
            }
            
        }
        
        // these do not happen in the constructor
        // if the db returns a list of positions with the researcher i say we itterate / loop through them
        // looking for what we need, if not we are calling the DB interface with a different query for each 
        // piece of data we need

        // overload constructor to deal with the position data
        // not sure how this will be defined, do they have poitions from other institutions in this list?
        // if so will have to check that the name matches the institution we are developing for presumably UTAS
        public static void CalcPositionInfo(Researcher researcher, List<Position> positions)
        {
            Console.WriteLine("\t\t\t\tthello in the funciton");
            foreach (Position positiona in positions)
            {
                Console.WriteLine(positiona.StartDate);
            }
            CalcEarliestPos(researcher, positions);
            CalcTenure(researcher, researcher.CommencedWithInstitution);
            CalcComencedCurrentPos(researcher, positions);

        }
        public static void CalcEarliestPos(Researcher researcher, List<Position> positions)
        {
            //Commenced with institution is the start date of their earliest position.
            // search the positions table for earliest start dat (min)
            // SELECT MIN(start_date) as earliest_start_date
            // FROM positions;
            // find lowest dat in the list

            // find lowest dat in the list
            DateTime lowest = DateTime.Today;
            foreach (Position position in positions)
            {
                if (position.StartDate < lowest)
                {
                    lowest = position.StartDate;
                }
            }
            researcher.CommencedWithInstitution = lowest;
        }
        public static void CalcTenure(Researcher researcher,DateTime CommCurPos)
        {
            //Tenure is the time in (fractional) years since the researcher commenced with the institution.
            // CommWithInstitution - current timeDate;

            TimeSpan difference = DateTime.Now - CommCurPos;
            double years = difference.TotalDays / 365.25;

            researcher.Tenure = years;
        }

        // want  this to return a Position void is placeholder
        public static void CalcComencedCurrentPos(Researcher researcher, List<Position> positions)
        {
            // search the positions table for latest start dat (max)
            // SELECT MAX(start_date) as earliest_start_date
            // FROM positions;
            // or
            // or are we looking for a position with a NULL end date, i.e. no end date???
            // find highest date in the list, this will be the current position
            DateTime highest = new DateTime(1, 1, 1);
            foreach( Position position in positions)
            {
                if (position.StartDate > highest)
                {
                    highest= position.StartDate;
                }
            }
            researcher.CommenceCurrentPosition = highest;
        }

        public String FetchPhoto()
        {
            // fetch photo url
            String placeHolder = "placeHolder";

            return placeHolder;
        }
        
        public static void Q1PercentageCalc(Researcher researcher, List<Publication> publications)
        {
            int q1Count = 0;
            int totalPublications = publications.Count;

            foreach (Publication publication in publications)
            {
                if (publication.Ranking == RankingType.Q1)
                {
                    q1Count++;
                }
            }

            double percentage = (double)q1Count / totalPublications * 100;
            // sets the top global var...
            researcher.Q1Percentage = percentage;
        }
    }
}

    
