using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using KIT206_RAP.Researchers;
using KIT206_RAP.View;
using MySql.Data.MySqlClient;


namespace KIT206_RAP.DataBase
{

    class testResearch
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        public testResearch(int id, string type, string fname, string lname, string title)
        {
            ID = id;
            Type = type;
            FirstName = fname;
            LastName = lname;
            Title = title;
        }
    }
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
        public List<testResearch> ReadData()
        {
            MySqlDataReader rdr = null;

            List<testResearch> researchers = new List<testResearch>();
            List<Staff> testStaff = new List<Staff>();
            List<Student> testStudents = new List<Student>();
            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select  * from researcher", conn);
                //MySqlCommand pubs = new MySqlCommand("select  * from publications where id is xxxxx", conn);
                //MySqlCommand supervisors = new MySqlCommand("select  * from rese where sup is xxxxx", conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                // print the CategoryName of each record
                while (rdr.Read())
                {
                    string type = rdr[1].ToString();
                    if (type.Equals("Student"))
                    {
                        var id = rdr.GetInt32("id");
                        var firstName = rdr.GetString("given_name");
                        var lastName = rdr.GetString("family_name");
                        var title = rdr.GetString("title");
                        var unit = rdr.GetString("unit");
                        var campus = rdr.GetString("campus");
                        var email = rdr.GetString("email");
                        var photo = rdr.GetString("photo");
                        var degree = rdr.GetString("degree");
                        var superID = rdr.GetInt32("supervisor_id");
                        var utas_start = rdr.GetDateTime("utas_start");
                        var cur_start = rdr.GetDateTime("current_start");

                        Student stu = new Student(id, type, firstName, lastName, title, unit, campus, email, photo, superID, degree, utas_start, cur_start);
                        testStudents.Add(stu);

                        Console.WriteLine("we ahve a student");

                    }
                    else
                    {
                        var id = rdr.GetInt32("id");
                        var firstName = rdr.GetString("given_name");
                        var lastName = rdr.GetString("family_name");
                        var title = rdr.GetString("title");
                        var unit = rdr.GetString("unit");
                        var campus = rdr.GetString("campus");
                        var email = rdr.GetString("email");
                        var photo = rdr.GetString("photo");
                        var lev = rdr.GetString("level");
                        var utas_start = rdr.GetDateTime("utas_start");
                        var cur_start = rdr.GetDateTime("current_start");
                        Console.WriteLine("teacher");
                        Staff sta = new Staff(id, type, firstName, lastName, title, unit, campus, email, photo, lev, utas_start, cur_start);
                        testStaff.Add(sta);

                    }
                       

                    //researchers.Add(new testResearch(id, type, firstName, lastName, title));

                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                    Console.WriteLine("{0} {1}", rdr[0], rdr.GetString(1));
                }
                    Console.WriteLine("\n\t\t Students");
                    foreach (Student stu in testStudents)
                    {
                        Console.WriteLine(stu.Type +" "+ stu.FirstName +" "+ stu.LastName);
                    }

                    Console.WriteLine("\n\t\t StAff");
                     foreach (Staff sta in testStaff)
                    {
                        Console.WriteLine(sta.Type +" "+ sta.FirstName +" "+ sta.LastName);
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
            foreach (testResearch res in researchers)
            {
                Console.WriteLine(res.ID +" "+res.Type+res.LastName+ res.FirstName);
            }
            return researchers;
                                
                    //if (rdr[10]!= null && rdr[9] != null) // Creates a student
                    //{
                    //    researcher.Add(new Researcher(/*ID*/Convert.ToInt32(rdr[0]), 
                    //        /*is stu??*/rdr[1].ToString(), 
                    //        /*fname*/rdr[2].ToString(),
                    //        /*lname*/rdr[3].ToString(), 
                    //        /*title*/rdr[4].ToString(), 
                    //        /*unit*/rdr[5].ToString(),
                    //    /*camphouse*/rdr[6].ToString(), 
                    //    /*email*/rdr[7].ToString(), /*photo*/rdr[8].ToString(), /*degree*/rdr[9].ToString(), /*supID*/Convert.ToInt32(rdr[10]), /*Level*/"NULL", new DateTime(2022, 1, 1), new DateTime(2022, 1, 1)));
                        
                    //}else if (rdr[10]== null && rdr[9] == null) // CREATES A teacher
                    //{
                    //     researcher.Add(new Researcher(/*ID*/Convert.ToInt32(rdr[0]), /*is stu??*/rdr[1].ToString(), /*fname*/rdr[2].ToString(), /*lname*/rdr[3].ToString(), /*title*/rdr[4].ToString(), /*unit*/rdr[5].ToString(),
                    //     /*camphouse*/rdr[6].ToString(), /*email*/rdr[7].ToString(), /*photo*/rdr[8].ToString(), /*degree*/"NULL", /*supID 0000 is null value*/0000, /*Level*/rdr[11].ToString(), new DateTime(2022, 1, 1), new DateTime(2022, 1, 1)));
                        
                    //}
                                            //researcher.Add(new Researcher(Convert.ToInt32(rdr[0]), rdr[1].ToString(), rdr[2].ToString(), rdr[2].ToString(), rdr[4].ToString(), rdr[5].ToString(), resCamp, rdr[6].ToString(), Level.A););)
                       
                    
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
        }


        /*
         * Using the ExecuteReader method to select from a single table */
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
               // new Researcher("Paul", "McCartney", "DR", false, Campus.Hobart, "Computers", "email@email", Level.A),
                //new Researcher("Chris", "Snodgrass", "DR", true, Campus.Hobart, "Computers", "email@email.com", Level.D),
                //new Researcher("Ringo", "Star", "MR", false, Campus.Hobart, "Computers", "email@email",  Level.B),
                //new Researcher("Jane", "Snodgrass", "MR", true, Campus.Launceston, "Bio", "email@email.com", Level.D)
            };

        }
/*
        public static Staff GenerateStaffMember(Researcher researcher)
        {

            // this will be a LINQ / SQL statement to hit the DB for the appropriate researcher
            Staff staffMember = new Staff(researcher.ID, researcher.Type, researcher.FirstName, researcher.LastName, researcher.Title, researcher.IsStudent, researcher.Camp, researcher.SchoolUnit, researcher.Email, 1000, new List<string> { "Stu_coordinator", "Cleaning", "groundsman" }, new List<string> { "Jim", "Jane", "Joe" }, researcher.positionLevle);
            return staffMember;
        }

        public static Student GenerateStudentMember(Researcher researcher)
        {
            
            Student studentMember = new Student(researcher.ID, researcher.Type, researcher.FirstName, researcher.LastName, researcher.Title, researcher.IsStudent, researcher.Camp, researcher.SchoolUnit, researcher.Email, "John Lennon", "computer Science",  researcher.positionLevle);
            return studentMember;
        }
*/
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
