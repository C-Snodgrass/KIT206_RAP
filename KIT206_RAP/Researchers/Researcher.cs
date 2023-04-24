using System;
using System.Collections.Generic;
using System.Linq;
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
        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string SchoolUnit { get; set; }
        public string Email { get; set; }
        public string CurrentJobTitle { get; set; }
        public DateTime CommenceCurrentPosition { get; set; }
        public DateTime CommencedWithInstitution { get; set; }
        public List<Publication> Publications { get; set; }
        public double Q1Percentage { get; set; }
        public string JobTitle { get; set; }
        public double ExpectedNoPublications { get; set; }
        public Campus Campus { get; set; }
        public string photoPlaceHolder { get; set; }
        public double Tenure { get; set; } // time in fractional years since the researcher commecned with the institution

        // Constructor
        public Researcher(string firstName, string lastName, Campus campus, string schoolUnit, string email, List<Publication> publications)
        {
            FirstName = firstName;
            LastName = lastName;
            SchoolUnit = schoolUnit;
            Email = email;
            //CurrentJobTitle = DeriveJobTitle();
            Publications = publications;
            Q1Percentage = Q1PercentageCalc();
            CommenceCurrentPosition = CommCurretnPos();
            CommencedWithInstitution = CommWithInstitution();
            photoPlaceHolder = FetchPhoto();
            Tenure = CalcTenure(CommencedWithInstitution);

        }


        
        public string DeriveJobTitle(Level level)
        {
            string JobTitle;

            switch (level)
            {
                case Level.A:
                    JobTitle = "Research Associate";
                    //ExpectedNoPublications = 0.5; 
                    break; 
                case Level.B:
                    JobTitle = "Lecturer";
                    //ExpectedNoPublications = 1;
                    break;

                case Level.C:
                    JobTitle = "Assistant Professor";
                    //ExpectedNoPublications = 2;
                    break;

                case Level.D:
                    JobTitle = "Associate Professor";
                    //ExpectedNoPublications = 3.2;
                    break;

                case Level.E:
                    JobTitle = "Professor";
                    //ExpectedNoPublications = 4;
                    break;

                default:
                    throw new ArgumentException("Invalid level character");
            }

                return JobTitle;
            
        }
        
        public double CalcTenure(DateTime CommCurPos)
        {
            TimeSpan difference = DateTime.Now - CommCurPos;
            double years = difference.TotalDays / 365.25;

            //Tenure is the time in (fractional) years since the researcher commenced with the institution.
            // CommWithInstitution - current timeDate;

            return years;

        }

        // want  this to return a Position void is placeholder
        public void CalcCurrentPos()
        {
            // does the database return an array of all positions held by the individual???
            // find lowest and return
            //Position position; 
            //return position;
        }

        public DateTime CommCurretnPos()
        {
            //Commenced current position is the start date of their current position.
            // hit database for most current position start date
            // Position currentPosition = CalcCurrentPos();
            // return currentPosition.StartDate;
            DateTime currentPosDate = new DateTime(1, 1, 1);

            return currentPosDate;
        }

        public DateTime CommWithInstitution()
        {
            //Commenced with institution is the start date of their earliest position.

            DateTime withInstitution = new DateTime(1, 1, 1);

            return withInstitution;

        }

        public String FetchPhoto()
        {
            // fetch photo url
            String placeHolder = "placeHolder";


            return placeHolder;
        }
        //methods here
        public double Q1PercentageCalc()
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
}

    
