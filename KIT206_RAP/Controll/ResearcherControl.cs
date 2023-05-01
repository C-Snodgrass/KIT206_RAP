using KIT206_RAP.DataBase;
using KIT206_RAP.Researchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206_RAP.View;

namespace KIT206_RAP.Controll
{
    internal class ResearcherControl
    {
        public static void DisplayResearchers()
        {
            // old version passed list objects for student and staff
            //List<Staff> StaList = DBAdapter.GetStaff();
            //List<Student> StuList = DBAdapter.GetStudent();
            List<Researcher> ResList = DBAdapter.GetResearcher();

            ResearcherView.PrintAllResearchers(ResList);
            //ResearcherView.PrintAllResearchers(StuList, StaList);
        }

        public static void DisplayResearcherDetails(Researcher Res)
        {
            //fetch publications
            List<Publication> PubList = DBAdapter.GetPubs(Res);

            Console.WriteLine(Res.Type);
            PublicationView.PrintAllPublication(PubList);


            Console.WriteLine(Res.Type);

            // is my logic the right way arround on this?? pretty important one...
            if (Res.Type == Researcher.ResearcherType.Student)
            {
                Console.WriteLine("is a student");
                // call the DB to get the additional info
                Student Sta = DBAdapter.GetStudent(Res.ID);
                // create the staff with all the additional stuff they need
                // probably need to pass the publicaitons lit
                //ResearcherDetailsView.DisplayResearcherDetailsViewStaff(staffMember);

            }
            else
            {
                Console.WriteLine("is a staff");
                // create student 
                Staff sta = DBAdapter.GetStaff(Res.ID);
                // call the DB to get the additiaonl info.

                // probably need to pass the publications list
                //ResearcherDetailsView.DisplayResearcherDetailsViewStudent(student);
            }

        }

        public static void DisplayPerformanceDetails(Researcher researcehr)
        {
            PerformaceDetailsView.PrintPerformanceView(researcehr);
        }


    }

}

