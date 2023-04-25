using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206_RAP.Researchers;
using KIT206_RAP.View;

namespace KIT206_RAP.DataBase
{       // should this string supervisor be a staff supervisor. I'm struggling to generate all these interdependent objects, presumably when i
        // pull them form the data base the researcher will already exist somewhere wlse in th DB
        // this of course will come from the real db, but for now we generate some staff students publications and positions here
    abstract class Agency
    {

        public static List<Researcher> GenerateReserchers()
        {
            return new List<Researcher>() {
                new Researcher("Paul", "McCartney", "DR", false, Campus.Hobart, "Computers", "email@email", Level.A),
                new Researcher("Chris", "Snodgrass", "DR", true, Campus.Hobart, "Computers", "email@email.com", Level.D),
                new Researcher("Ringo", "Star", "MR", false, Campus.Hobart, "Computers", "email@email",  Level.B),
                new Researcher("Jane", "Snodgrass", "MR", true, Campus.Launceston, "Bio", "email@email.com", Level.D)
            };

        }

        public static Staff GenerateStaffMember(Researcher researcher)
        {
            // this will be a LINQ / SQL statement to hit the DB for the appropriate researcher
            Staff staffMember = new Staff(researcher.FirstName, researcher.LastName, researcher.Title, researcher.IsStudent, researcher.Campus, researcher.SchoolUnit, researcher.Email, 1000, new List<string> { "Stu_coordinator", "Cleaning", "groundsman" }, new List<string> { "Jim", "Jane", "Joe" }, researcher.positionLevle);
            return staffMember;
        }

        public static Student GenerateStudentMember(Researcher researcher)
        {
            
            Student studentMember = new Student(researcher.FirstName, researcher.LastName, researcher.Title, researcher.IsStudent, researcher.Campus, researcher.SchoolUnit, researcher.Email, "John Lennon", "computer Science",  researcher.positionLevle);
            return studentMember;
        }

        /*
        public static List<Staff> GenerateStaff()
        {
            return new List<Staff>() {
                    new Staff("Paul", "McCartney", "DR", Campus.Hobart, "Computers", "email@email", 10000, new List<string> {"Stu_coordinator", "Cleaning", "groundsman"},  new List<string> {"Jim", "Jane", "Joe"}),
                    new Staff("Ringo", "Star", "MR", Campus.Hobart, "Computers", "email@email", 10000, new List<string> {"Stu_coordinator", "Cleaning", "groundsman"},  new List<string> {"Jim", "Jane", "Joe"}),
                    new Staff("John", "Lennon", "MRS", Campus.Hobart, "Computers", "email@email", 10000, new List<string> {"Stu_coordinator", "Cleaning", "groundsman"},  new List<string> {"Jim", "Jane", "Joe"}),
                    new Staff("George", "Harrison", "DR", Campus.Hobart, "Computers", "email@email", 10000, new List<string> {"Stu_coordinator", "Cleaning", "groundsman"},  new List<string> {"Jim", "Jane", "Joe"}),

            };
        }

        public static List<Student> GenerateStudents()
        {
            return new List<Student>()
            {
                new Student("Chris", "Snodgrass", "DR", Campus.Hobart, "Computers", "email@email.com", "McCartney", "BA Science"),
                new Student("Jim", "Snodgrass", "MR", Campus.Hobart, "Computers", "email@email.com", "McCartney", "BA Science"),
                new Student("Jane", "Snodgrass", "MR", Campus.Launceston, "Bio", "email@email.com", "McCartney", "BA Science"),
                new Student("Joe", "Lake", "MR", Campus.Cradle_Coast, "Chem", "email@email.com", "McCartney", "BA Science")
            };

        }
        */

        public static List<Publication> GeneratePublications()
        {
            return new List<Publication>()
            {
                new Publication(false, new DateTime(1988, 3, 28), "Abbey Road", "doi:10.1234/abcd",new List<string>{"Jimm","Jande"},  "Dow,J. Smith, J. (2022). theresearch", new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2),
                new Publication(false, new DateTime(1988, 3, 28), "Revolver", "doi:10.1234/abcd", new List<string>{"Jimm","Jande"}, "Dow,J. Smith, J. (2022). theresearch", new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2),
                new Publication(false, new DateTime(1988, 3, 28), "Sg. Pepper", "doi:10.1234/abcd",  new List<string>{"Jimm","Jande"}, "Dow,J. Smith, J. (2022). theresearch", new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2),
                new Publication(false, new DateTime(1988, 3, 28), "A Hard Day's Night", "doi:10.1234/abcd", new List<string>{"Jimm","Jande"}, "Dow,J. Smith, J. (2022). theresearch", new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2)
            
            };
        }

        public static List<Position> GeneratePositions()
        {
            return new List<Position>()
            {
                new Position {StartDate = new DateTime(1,1,1), Level = Level.A, EndDate = new DateTime(2,2,2)},
                new Position {StartDate = new DateTime(1,1,1), Level = Level.A, EndDate = new DateTime(2,2,2)},
                new Position {StartDate = new DateTime(1,1,1), Level = Level.A, EndDate = new DateTime(2,2,2)},
                new Position {StartDate = new DateTime(1,1,1), Level = Level.A, EndDate = new DateTime(2,2,2)},

            };
        }

    }
}
