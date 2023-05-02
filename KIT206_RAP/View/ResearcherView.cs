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
            /*UC8
             * Upon application start up, the user shall be presented with an interactive list of researchers (consisting of both staff and research
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

        // currrently we can not show the researcher's level. I guess we go back to the DB and 
        public static void PrintAllResearchers(List<Researcher> ResList)
        {
            Console.WriteLine("---\t---\tThis is the MainView\t---\t---");
            Console.WriteLine("Family Name | Given Name (title) | Employment level | student status |");
            // here we will display different infor depending on if they are a student or not
            
            foreach (Researcher res in ResList)
            {
                if (res is Staff staff)
                {
                    // display specific student stuff... they have a degree and a super, but not type???
                    Console.WriteLine($"Staff {staff.FirstName} {staff.LastName}, Level {staff.level}");
                }
                if (res is Student student)
                {
                    Console.WriteLine($"Student {student.FirstName} {student.LastName}, Supervisor {student.Supervisor}");
                }
            }
            /*
            // below is just to demonstrate that these work
            Console.WriteLine("sort by first");
            SortByFirstName(ResList);
            Console.WriteLine("sort by Last");
            SortByLastName(ResList);
            Console.WriteLine(" reverse sort by first");
            ReverseSortByFirstName(ResList);
            Console.WriteLine("reverse sort by Last");
            ReverseSortByLastName(ResList);
           */ 

            Console.WriteLine("Select researcher form the list wil line no");
            // get user input for the desired line number
               
            int selectedLine;
            while (!int.TryParse(Console.ReadLine(), out selectedLine) || selectedLine < 1 || selectedLine > ResList.Count())
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {ResList.Count()}.");
            }
            Researcher selectedResearcher = ResList[selectedLine - 1];
            Console.WriteLine("you sleected " + selectedLine + "which is " + selectedResearcher.FirstName);
            Console.WriteLine(selectedResearcher.ID);
            ResearcherControl.DisplayResearcherDetails(selectedResearcher);
        }
        // sorts a list of researchers by first name
        public static List<Researcher> SortByFirstName(List<Researcher> ResList){
            ResList.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
            foreach(Researcher res in ResList)
            {
                Console.WriteLine(res.FirstName);
            }
            return ResList;
        }

        // sorts a list of researchers by Last name
        public static List<Researcher> SortByLastName(List<Researcher> ResList)
        {
            ResList.Sort((x, y) => x.LastName.CompareTo(y.LastName));
            foreach(Researcher res in ResList)
            {
                Console.WriteLine(res.LastName);
            }return ResList;
        }
        // reverse sort i.e. (z - a) a list of researchers by first name 
        public static List<Researcher> ReverseSortByFirstName(List<Researcher> ResList){
            ResList.Sort((x, y) => y.FirstName.CompareTo(x.FirstName));
            foreach(Researcher res in ResList)
            {
                Console.WriteLine(res.FirstName);
            }return ResList;
        }
        // reverse sort i.e. (z - a) a list of researchers by last name 
       public static List<Researcher> ReverseSortByLastName(List<Researcher> ResList)
        {
            ResList.Sort((x, y) => y.LastName.CompareTo(x.LastName));
            foreach(Researcher res in ResList)
            {
                Console.WriteLine(res.LastName);
            }
            return ResList;
        }

    }
}
