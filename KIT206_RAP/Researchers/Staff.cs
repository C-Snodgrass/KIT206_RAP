﻿using System;
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
        public double FundingRecieved { get; set; }
        public double PerformanceByFunding { get; set; }
        public int ThreeYearAverage { get; set; }
        public int PerformanceByPublication { get; set; }
            
       // Constructor
        public Staff(int id, string type, string firstName, string lastName, string title, string schoolUnit, string campHouse, string email, string photURL, string lev, DateTime utas_start, DateTime curretn_start)
            : base( id, type, firstName, lastName, title, schoolUnit, campHouse, email, photURL, utas_start, curretn_start)
        {
            // i think this is wrong as we are passing in a list of studenst and positions but then making a new list here??
            // will have to ping the database with something like get all students with "researcher name" as supervisor
            //ThreeYearAverage = AverageThreeYear();
            //double funding = 100;

        }
        public Level CalcPosLevel(string lev)
        {
            if (lev.Equals("A"))
            {
                return Level.A;
            }else if (lev.Equals("B"))
            {
                return Level.B;
            }else if (lev.Equals("C"))
            {
                return Level.C;
            }
            return Level.D;
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

  /*
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
            Console.WriteLine(researcher.Q1Percentage);
            Console.WriteLine(researcher.Q1Percentage);
            Console.WriteLine(researcher.Q1Percentage);
        }
        */

    }
}
