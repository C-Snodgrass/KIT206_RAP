using KIT206_RAP.DataBase;
using KIT206_RAP.Researchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP.View
{
    /*
     *It will show the following basic details, some of which are only available for staff and others only for students:
     *Name (both); 
     *Title (both); 
     *School/Unit (both); 
     *Campus (both); 
     *Email (both); 
     *Photo (both); 
     *Current Job Title (both); 
     *Commenced with the institution (both);
     *Commenced current position (both); 
     *Tenure (both); 
     *Publications (both);
     *Supervisions (staff);
     *Degree (students); Supervisor (students),
        and Performance details button

        Photo is stored as the URL of an image, but must be presented as an image. SWC 16
        Current Job Title is a label derived from their current position's level. SWC 16
        Commenced with institution is the start date of their earliest position. SWC 16
        Commenced current position is the start date of their current position. SWC 16
        Tenure is the time in (fractional) years since the researcher commenced with the institution. SWC 16
        It would enhance the application if the Researcher Details view also includes a table of a staff member’s previous positions and
        those positions' start and end dates (not required for students).

        The expected number of publications per year for each level is as follows: A, 0.5; B, 1; C, 2; D, 3.2; E, 4. SWC 
     */
    internal class ResearcherDetailsView
    {
        public static void DisplayResearcherDetailsViewStudent(Student student)
        {
            
            // fetch publications form DB??
            List <Publication> publications = Agency.GeneratePublications(student.LastName);
            List<Position> posisions = Agency.GeneratePositions();
            Researcher.CalcPositionInfo(student, posisions);
            Researcher.Q1PercentageCalc(student, publications);


            Console.WriteLine("---\t---\tWelcome to Researcher Details View\t---\t---");
            Console.WriteLine("---\t---\tYou Have Selected a Student\t---\t---");

            Console.WriteLine("Name: " + student.FirstName + " " + student.LastName);
            Console.WriteLine("Tite: " + student.Title);
            Console.WriteLine("School/Unit: " + student.SchoolUnit);
            Console.WriteLine("Campus: " + student.Campus);
            Console.WriteLine("Email: " + student.Email);
            Console.WriteLine("Photo: " + student.photoPlaceHolder);
            Console.WriteLine("Current Job Title" + student.CurrentJobTitle);
            Console.WriteLine("Commenced with Institution: " + student.CommencedWithInstitution);
            Console.WriteLine("Commecnce curr Pos: " + student.CommenceCurrentPosition);
            Console.WriteLine("Tenure: " + student.Tenure);
                       
            foreach (Publication publciacion in publications)
            {
                Console.WriteLine("Publications: " + publciacion.Title);
            }

            Console.WriteLine("Degree: " + student.Degree);
            Console.WriteLine("Tenure: " + student.Supervisor);


        }

        public static void DisplayResearcherDetailsViewStaff(Staff staff)
        {
            // fetch publications form DB?? 
            //Console.WriteLine("Publications: " + staff.Publications);
            List <Publication> publications = Agency.GeneratePublications(staff.LastName);
            List<Position> posisions = Agency.GeneratePositions();
            Researcher.CalcPositionInfo(staff, posisions);
            Researcher.Q1PercentageCalc(staff, publications);
            // this would call the DB and do something like...
            // someting like this to get th 
            // SELECT *
            // FROM Students
            // WHERE Supervisor = staff.lastName;
            List<string> supervisions = new List<string>();
            supervisions.Add("These are");
            supervisions.Add("Hard Coded");
            supervisions.Add("Supervisions");

            Console.WriteLine("---\t---\tWelcome to Researcher Details View\t---\t---");
            Console.WriteLine("---\t---\tYOU HAVE SELECTED A STAFF MEMBER\t---\t---");
            Console.WriteLine("Name: " + staff.FirstName + " " + staff.LastName);
            Console.WriteLine("Tite: " + staff.Title);
            Console.WriteLine("School/Unit: " + staff.SchoolUnit);
            Console.WriteLine("Campus: " + staff.Campus);
            Console.WriteLine("Email: " + staff.Email);
            Console.WriteLine("Photo: " + staff.photoPlaceHolder);
            //Console.WriteLine("Current Job Title" + staff.CurrentJobTitle);
            Console.WriteLine("Commenced with Institution: " + staff.CommencedWithInstitution);
            Console.WriteLine("Commecnce curr Pos: " + staff.CommenceCurrentPosition);
            Console.WriteLine("Tenure: " + staff.Tenure);
            
            foreach (Publication publciacion in publications)
            {
                Console.WriteLine("Publications: " + publciacion.Title);
            }
            
            Console.WriteLine("Supervisions: ");

        }
    }
}
