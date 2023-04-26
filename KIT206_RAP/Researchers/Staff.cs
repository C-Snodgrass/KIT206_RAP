using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
3-year Average is the total number of publications in the previous three whole calendar years, divided by three. SWC 27
Performance by Publication is the average number of publications per year since commencement. SWC 27
Performance by Funding Received is the average amount of funding per year since commencement. SWC 27
Supervisions is the number of students the staff member is currently or has previously supervised. 
*/
namespace KIT206_RAP.Researchers
{
    internal class Staff : Researcher
    {
        //public List<Position> Positions { get; set; }
        public List<String> Positions {  get; set; }
        //public List<Student> Supervisions { get; set; }
        public List<String> Supervisions { get; set; }
        public double FundingRecieved { get; set; }
        public double PerformanceByFunding { get; set; }
        public int ThreeYearAverage { get; set; }
        public int PerformanceByPublication { get; set; }
            
       // Constructor
        public Staff(string firstName, string lastName, string title,bool isStudent, Campus campus, string schoolUnit, string email, int FundingRecieved,  
            List<String> positions, List<String> supervisions, Level level)
            : base(firstName, lastName, title, isStudent, campus, schoolUnit, email, level)
        {
            List<String> Positions = positions;
            List<String> Supervisions = supervisions;
            // i think this is wrong as we are passing in a list of studenst and positions but then making a new list here??
            // will have to ping the database with something like get all students with "researcher name" as supervisor
            //ThreeYearAverage = AverageThreeYear();
            //double funding = 100;

        }
        
       /* 
        public int AverageThreeYear()
        {
            //3-year Average is the total number of publications in the previous three whole calendar years, divided by three.
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
*/
        // calculate performance by funding
        public double PerforByFund(double fundingRecieved)
        {
            //Performance by Funding Received is the average amount of funding per year since commencement.

            double performaceFunding = 100;
            return performaceFunding;

        }

        //3-year average
        //performance by publication
        //performance by fundgin
       
        public static void supervisions()
        {
            // this will probably have to be it's own SQL / LINQ query as we have
            // question each student table for it's supervisor
            // not sure how supervisor is recorded in the DB, maybe they have ID's???
            // FROM students
            // GET *
            // WHERE supervisor = Researcher.lastName


        }
        //supervisions


        // calculate performance
        // calculate perfomeance by publication


    }
}
