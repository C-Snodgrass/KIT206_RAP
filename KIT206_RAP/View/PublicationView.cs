using KIT206_RAP.Researchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_RAP.View
{
    internal class PublicationView
    {

        public  void PrintAllPublication(List<Publication> publication_list)
        {
            foreach (Publication publication in publication_list)
            {
                 // could send this to an overloaded print fuction in the publication class if we wanted.
                Console.WriteLine("Publicaiton Name: " + publication.Title);

            }
        }
    }
}
