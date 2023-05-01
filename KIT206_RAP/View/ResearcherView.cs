using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206_RAP.Controll;
using KIT206_RAP.Researchers;

namespace KIT206_RAP.View
{
    internal class ResearcherView
    {

// take list of researchers and students
        public static void PrintAllResearchers(List<Student> StuList, List<Staff> StaList)
        {
            /*Upon application start up, the user shall be presented with an interactive list of researchers (consisting of both staff and research
             students), known hereafter as the Researcher List view.

             This list should display names in the format ‘Family Name, Given Name (Title)’, as in ‘Einstein, Albert (Dr)’.
             The employment levels correspond to the following job titles: A, Research Associate; B, Lecturer; C, Assistant Professor; D,
             Associate Professor; E, Professor.

             The user shall be able to filter the Researcher List view based on a researcher’s employment level or student status.

             The user should be able to list all researchers, students only, level A, level B, level C, level D and level E

             It would enhance the system’s utility if the user could filter the list by entering part of a researcher’s name.

             The list contents would be restricted to show only those staff whose given name or family name contains the text entered by the
             user.

             Partial matches that span combinations of given and family name do not need to be supported.
            */

            Console.WriteLine("---\t---\tThis is the MainView\t---\t---");
            Console.WriteLine("Family Name | Given Name (title) | Employment level | student status |");
            foreach (Staff sta in StaList)
            {
                Console.WriteLine(sta.Type +" "+ sta.FirstName +" "+ sta.LastName);
            }

            foreach (Student stu in StuList)
            {
                Console.WriteLine(stu.Type + " " + stu.FirstName + "" + " " + stu.LastName);
            }

            /* below works, sorts researchers by first name, would need to add an option to the menu to 
             * call below function
            SortResearchersByFirstName(ResearcherList);
            Console.WriteLine("sorted list is...);
            foreach (Researcher researcher in ResearcherList)
            {

                Console.WriteLine("     " + researcher.FirstName + "\t" + researcher.LastName + "(" + researcher.Title + ")\t" + researcher.positionLevle + "\t" + researcher.IsStudent);
            }
            */
            Console.WriteLine("Select researcher form the list wil line no");
            // get user input for the desired line number
            int count = StaList.Count + StuList.Count;

            int selectedLine;
            while (!int.TryParse(Console.ReadLine(), out selectedLine) || selectedLine < 1 || selectedLine > count)
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {count}.");
            }
            if (selectedLine <= StuList.Count)
            {
                Student selectedStudent = StuList[selectedLine - 1];
                //ResearcherControl.DisplayStudentDetails(selectedStudent);
            }
            else
            {
                Staff selectedStaff = StaList[selectedLine - 1];
                //ResearcherControl.DisplayStaffDetails(selectedStaff);
            }

        } 
            
                
        public static List<Researcher> SortResearchersByFirstName(List<Researcher> researchers)
        {
            researchers.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
            return researchers;
        }
        //more sorting and filtering functionality here



    }


}
