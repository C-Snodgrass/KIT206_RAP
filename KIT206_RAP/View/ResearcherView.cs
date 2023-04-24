using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206_RAP.Researchers;

namespace KIT206_RAP.View
{
    internal class ResearcherView
    {
        

        public  void PrintAllResearchers(List<Researcher> researcher_list)
        {
           /*Upon application start up, the user shall be presented with an interactive list of researchers (consisting of both staff and research
            students), known hereafter as the Researcher List view.
            
            SW UC8_User_views_ResearcherList
            This list should display names in the format ‘Family Name, Given Name (Title)’, as in ‘Einstein, Albert (Dr)’. SWC 8
            The employment levels correspond to the following job titles: A, Research Associate; B, Lecturer; C, Assistant Professor; D,
            Associate Professor; E, Professor.

            The user shall be able to filter the Researcher List view based on a researcher’s employment level or student status. SWC 8
            The user should be able to list all researchers, students only, level A, level B, level C, level D and level E. SWC 8
            It would enhance the system’s utility if the user could filter the list by entering part of a researcher’s name. NTH SWC 8
            The list contents would be restricted to show only those staff whose given name or family name contains the text entered by the
            user.

            Partial matches that span combinations of given and family name do not need to be supported.
           */
            Console.WriteLine("---\t---\tThis is the MainView\t---\t---");
            foreach (Researcher researcher in researcher_list)
            {
                // could send this to an overloaded print fuction in the researcher class if we wanted.
                Console.WriteLine("Name: " + researcher.FirstName);
                Console.WriteLine("Title: " + researcher.Title);

            }
        }

    }


}
