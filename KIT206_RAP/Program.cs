using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using KIT206_RAP.Researchers;
// uncomment when somehting added
//using KIT206_RAP.Controll;
using KIT206_RAP.View;
//using KIT206_RAP.DataBase;

namespace KIT206_RAP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Publication> pub_list= new List<Publication>();
            List<Researcher> researchers_list= new List<Researcher>();

            Publication pub1 = new Publication(false, new DateTime(1988, 3, 28), "Abbey Road", "doi:10.1234/abcd", researchers_list, "Dow,J. Smith, J. (2022). theresearch", new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2);
            Publication pub2 = new Publication(false, new DateTime(1988, 3, 28), "Revolver", "doi:10.1234/abcd", researchers_list, "Dow,J. Smith, J. (2022). theresearch", new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2);
            Publication pub3 = new Publication(false, new DateTime(1988, 3, 28), "Sg. Pepper", "doi:10.1234/abcd", researchers_list, "Dow,J. Smith, J. (2022). theresearch", new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2);
            Publication pub4 = new Publication(false, new DateTime(1988, 3, 28), "A Hard Day's Night", "doi:10.1234/abcd", researchers_list, "Dow,J. Smith, J. (2022). theresearch", new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2);
            pub_list.Add(pub1);
            pub_list.Add(pub2);
            pub_list.Add(pub3);
            pub_list.Add(pub4);
            
            Researcher researcher1 = new Researcher("Paul", "McCartney", Campus.Hobart, "computer_science", "email@gmail", pub_list);
            Researcher researcher2 = new Researcher("Ringo", "Star", Campus.Launceston, "Geography", "email@gmail",  pub_list);
            Researcher researcher3 = new Researcher("John", "Lennon", Campus.Launceston, "Math", "email@gmail", pub_list);
            Researcher researcher4 = new Researcher("George", "Harrison", Campus.Cradle_Coast, "Physics", "email@gmail", pub_list);
            researchers_list.Add(researcher1);
            researchers_list.Add(researcher2);
            researchers_list.Add(researcher3);
            researchers_list.Add(researcher4);

            ResearcherView view = new ResearcherView();
            PublicationView pub_view = new  PublicationView();

            view.PrintAllResearchers(researchers_list);
            pub_view.PrintAllPublication(pub_list);
        }
    }
}
