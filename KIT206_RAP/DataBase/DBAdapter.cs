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

        public static List<Publication> GetPubs(Researcher res)
        {
            MySqlDataReader rdr = null;
            DBAdapter demo = new DBAdapter();
            // get list of DOI strings which match resercher_id

            List<String> DOIS = new List<String>();
            try
            {
                // Open the connection
                demo.conn.Open();
                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select DOI from researcher_publication where researcher_id = @id", demo.conn);
                cmd.Parameters.AddWithValue("@id", res.ID.ToString());

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                // print the CategoryName of each record
                while (rdr.Read())
                {
                    var DOI = rdr.GetString("doi");
                    DOIS.Add(DOI);
                    //Console.WriteLine(rdr.GetInt32("researcher_id"));
                }
                Console.WriteLine("the doi's are");
                foreach (var DOI in DOIS)
                {
                    Console.WriteLine(DOI.ToString());
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
                if (demo.conn != null)
                {
                    demo.conn.Close();
                }
            }
            Console.WriteLine("PAUSE;");
            return GetPublications(DOIS);
        }

        public static List<Publication> GetPublications(List<string> TheDOIS)
        {
            MySqlDataReader rdr = null;
            DBAdapter demo = new DBAdapter();
            // get list of DOI strings which match resercher_id

            List<String> DOIS = new List<String>();
            List<Publication> pubs = new List<Publication>();
            foreach (string doi in TheDOIS)
            {
                try
                {
                    Console.WriteLine("the doi is " + doi);
                    // Open the connection
                    demo.conn.Open();

                    // 1. Instantiate a new command with a query and connection
                    MySqlCommand cmd = new MySqlCommand("select * from publication where doi = @doi", demo.conn);
                    cmd.Parameters.AddWithValue("@doi", doi);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read()) 
                    {
        
                        var title = rdr.GetString("title");
                        var authors = rdr.GetString("authors"); // thisis just a string of authors, not researcchers
                        var year = rdr.GetInt32("year");
                        var type = rdr.GetString("type");
                        var cite_as = rdr.GetString("cite_as");
                        var available = rdr.GetDateTime("available");
                        cmd = new MySqlCommand("select * from publication where doi = @doi", demo.conn);
                        cmd.Parameters.AddWithValue("@id", doi);
                        Publication pub = new Publication(title, doi, authors, cite_as, available, type);
                        pubs.Add(pub);

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
                    if (demo.conn != null)
                    {
                        demo.conn.Close();
                    }
                }
            }
            foreach(Publication pub in pubs)
            {
                Console.WriteLine("pub name is " + pub.Title);
            }
            Console.WriteLine("PAUSE;");
            return pubs;

        }

        public static List<Researcher> GetResearcher()
        {
            MySqlDataReader rdr = null;
            DBAdapter demo = new DBAdapter();

            List<Researcher> Researchers = new List<Researcher>();
            try
            {
                 
                // Open the connection
                demo.conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select  * from researcher", demo.conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                // print the CategoryName of each record
                while (rdr.Read())
                {
                    var id = rdr.GetInt32("id");
                    var type = rdr.GetString("type");
                    var firstName = rdr.GetString("given_name");
                    var lastName = rdr.GetString("family_name");
                    var title = rdr.GetString("title");
                    var unit = rdr.GetString("unit");
                    var campus = rdr.GetString("campus");
                    var email = rdr.GetString("email");
                    var photo = rdr.GetString("photo");
                    var utas_start = rdr.GetDateTime("utas_start");
                    var cur_start = rdr.GetDateTime("current_start");

                    Researcher res = new Researcher(id, type, firstName, lastName, title, unit, campus, email, photo, utas_start, cur_start);
                    Console.WriteLine("researcher added = " + res.LastName);
                    Researchers.Add(res);
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
                if (demo.conn != null)
                {
                    demo.conn.Close();
                }
            }
            return Researchers;
        }


        public static List<Staff> GetStaff()
        {
            MySqlDataReader rdr = null;
            DBAdapter demo = new DBAdapter();

            List<Staff> Staff = new List<Staff>();
            try
            {
                 
                // Open the connection
                demo.conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select  * from researcher", demo.conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();
                // print the CategoryName of each record
                while (rdr.Read())
                {
                    string type = rdr[1].ToString();

                    if (type.Equals("Staff"))
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

                        Staff sta = new Staff(id, type, firstName, lastName, title, unit, campus, email, photo, lev, utas_start, cur_start);
                        Staff.Add(sta);
                    }
                }
                
                Console.WriteLine("\n\t\t StAff");
                foreach (Staff sta in Staff)
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
                if (demo.conn != null)
                {
                    demo.conn.Close();
                }
            }
            return Staff;
        }


        /*
         * Using the ExecuteReader method to select from a single table
         */
        public static List<Student> GetStudent()
        {
            MySqlDataReader rdr = null;
            DBAdapter demo = new DBAdapter();
            List<Student> Students = new List<Student>();

            try
            {
                // Open the connection
                demo.conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select  * from researcher", demo.conn);
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
                        Students.Add(stu);

                        Console.WriteLine("we ahve a student");
                    }
                      
                }
                    Console.WriteLine("\n\t\t Students");
                    foreach (Student stu in Students)
                    {
                        Console.WriteLine(stu.Type +" "+ stu.FirstName +" "+ stu.LastName);
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
                if (demo.conn != null)
                {
                    demo.conn.Close();
                }
            }
            return Students;
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
        
        public static List<Publication> GeneratePublications(String name)
        {
            return new List<Publication>()
            {
            
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
