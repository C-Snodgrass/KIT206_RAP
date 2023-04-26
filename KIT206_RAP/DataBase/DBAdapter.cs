using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206_RAP.Researchers;
using KIT206_RAP.View;
using MySql.Data.MySqlClient;


namespace KIT206_RAP.DataBase
{
    class DBAdapter 
    {
        //Note that ordinarily these would (1) be stored in a settings file and (2) have some basic encryption applied
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private MySqlConnection conn;

        public DBAdapter()
        {
            /*
             * Create the connection object (does not actually make the connection yet)
             * Note that the RAP case study database has the same values for its name, user name and password (to keep things simple)
             */
            string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
            conn = new MySqlConnection(connectionString);
        }
        public static void TestData()
        {
            Console.WriteLine("testing has begun");

            DBAdapter demo = new DBAdapter();

            int count = demo.GetNumberOfRecords();
            Console.WriteLine("Number of researcher records: {0}", count);
            Console.WriteLine();
            Console.WriteLine("Names from researcher table:");
            demo.ReadData();
            Console.WriteLine();
            Console.WriteLine("Names read into a DataSet (should be the same as above):");
            demo.ReadIntoDataSet();

            Console.ReadLine();
        }

        /*
         * Using the ExecuteReader method to select from a single table
         */
        public void ReadData()
        {
            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select given_name, family_name from researcher", conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                    Console.WriteLine("{0} {1}", rdr[0], rdr.GetString(1));
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        /*
         * Using the ExecuteReader method to select from a single table
         */
        public void ReadIntoDataSet()
        {
            try
            {
                var researcherDataSet = new DataSet();
                var researcherAdapter = new MySqlDataAdapter("select * from researcher", conn);
                researcherAdapter.Fill(researcherDataSet, "researcher");

                foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                {
                    //Again illustrating that indexer (based on column name) gives access to whatever data
                    //type was obtained from a given column, but can call ToString() on an entry if needed.
                    Console.WriteLine("Name: {0} {1}", row["given_name"], row["family_name"].ToString());
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        /*
         * Using the ExecuteScalar method
         * returns number of records
         */
        public int GetNumberOfRecords()
        {
            int count = -1;
            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command
                MySqlCommand cmd = new MySqlCommand("select COUNT(*) from researcher", conn);

                // 2. Call ExecuteScalar to send command
                // This convoluted approach is safe since cannot predict actual return type
                count = int.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return count;
        }


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

        public static List<Publication> GeneratePublications(String name)
        {
            return new List<Publication>()
            {
                new Publication(false, new DateTime(1988, 3, 28), "Abbey Road", "doi:10.1234/abcd",new List<string>{"Jimm","Jande"},  name, new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q1),
                new Publication(false, new DateTime(1988, 3, 28), "Revolver", "doi:10.1234/abcd", new List<string>{"Jimm","Jande"}, name, new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q1),
                new Publication(false, new DateTime(1988, 3, 28), "Sg. Pepper", "doi:10.1234/abcd",  new List<string>{"Jimm","Jande"}, name, new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2),
                new Publication(false, new DateTime(1988, 3, 28), "A Hard Day's Night", "doi:10.1234/abcd", new List<string>{"Jimm","Jande"}, name, new DateTime(2022, 1, 1), 190, PublicationType.Journal, RankingType.Q2)
            
            };
        }

        public static List<Position> GeneratePositions()
        {
            return new List<Position>()
            {
                new Position {StartDate = new DateTime(1986,1,1), Level = Level.A, EndDate = new DateTime(1987,2,2)},
                new Position {StartDate = new DateTime(1988,1,1), Level = Level.A, EndDate = new DateTime(1999,2,2)},
                new Position {StartDate = new DateTime(2001,1,1), Level = Level.A, EndDate = new DateTime(2002,2,2)},
                new Position {StartDate = new DateTime(2020,1,1), Level = Level.A, EndDate = new DateTime()},
            };
        }

    }
}
