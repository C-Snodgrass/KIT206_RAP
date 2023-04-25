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
            // now just pass researcher for first view
            //List<Staff> StaffList =  Agency.GenerateStaff();
            //List<Student> studentList= Agency.GenerateStudents();
            //ResearcherView.PrintAllResearchers(studentList, StaffList);

            List<Researcher> ResearcherList = Agency.GenerateReserchers();

            ResearcherView.PrintAllResearchers(ResearcherList);
        }

        public static void DisplayResearcherDetails(Researcher researcher)
        {
            // can this if else be handled with researcher.Level == D... i.e. do all students have Level D and no staff have level D?
            // if so can remove the IsStudent field which would be good
            if (researcher.IsStudent ==  false)
            {
                // get researcher details for staff DB
                Console.WriteLine("is a staff");
                Staff staffMember = Agency.GenerateStaffMember(researcher);
                ResearcherDetailsView.DisplayResearcherDetailsViewStaff(staffMember);

            }
            else
            {
                Console.WriteLine("is a student");
                // get researcher details for student DB
                Student student = Agency.GenerateStudentMember(researcher);
                ResearcherDetailsView.DisplayResearcherDetailsViewStudent(student);
            }

        }
        


    }
}
