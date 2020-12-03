using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Assignment4_B_Diarra.Models;
using MySql.Data.MySqlClient;
using System.Web.Http.Cors;

namespace Assignment4_B_Diarra.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The school database context class allow us to access our MySQL school Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the teachers table of our school database.
        /// <summary>
        /// Returns a list of teachers in the system
        /// </summary>
        /// <example>GET api/teacherData/ListTeachers/Sam</example>
        /// <example>GET api/teacherData/ListTeachers/John</example>
        /// <returns>
        /// A list of teachers with the subjects they teach as well
        /// </returns>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{keyword?}")]
        public IEnumerable<Teacher> ListTeachers( string keyword=null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //This query will get teachers which names are related to the keyword used for the search
            cmd.CommandText = "SELECT * FROM  teachers WHERE LOWER(teacherfname) LIKE LOWER(@keyword) OR LOWER(teacherlname) LIKE LOWER(@keyword) OR LOWER(CONCAT(teacherfname,' ',teacherlname)) LIKE LOWER(@keyword)";
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            cmd.Prepare();

            //This variable will contain the ghathered results
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of teacher information and modules taught
            List<Teacher> teacherAndModules = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information 
                Teacher professor = new Teacher();   //A temporary variable to store current teacher
                professor.firstName = ResultSet["teacherfname"].ToString();
                professor.surName = ResultSet["teacherlname"].ToString();
                professor.employeeNumber = ResultSet["employeenumber"].ToString();
                professor.hireDate = (DateTime)ResultSet["hiredate"];  //Cast the result to date type
                professor.salary = (Decimal)ResultSet["salary"];       // Cast result to decimal type
                //Add the teacher and his module to the List
                teacherAndModules.Add(professor);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teachers and their modules
            return teacherAndModules;
        }


        /// <summary>
        /// This method displays a teacher selected by his employee number. It also shows the modules taught by the teacher.
        /// </summary>
        /// <param name="id"></param>
        /// <example>api/Teacher/displayTeacher/T381 </example>
        /// <example>api/Teacher/displayTeacher/T378 </example>
        /// <returns>Teacher with the name, employee number, hire date and modules taught</returns>
        // 
       [Route("api/TeacherData/displayTeacher/{id}")]

        [HttpGet]
        public Teacher displayTeacher(string id)
        {
            string employeeNumber = id;
            Teacher professor = new Teacher();
            if (employeeNumber == "")
            {
                employeeNumber = "T378";  //Set to the first teacher
            }

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //This query will get teachers and modules taught
            cmd.CommandText = "SELECT teachers.*,classcode,classname, startdate, finishdate FROM teachers LEFT JOIN classes ON classes.teacherid = teachers.teacherid WHERE employeenumber=\""+ employeeNumber + "\"";

            //This variable will contain the ghathered results
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of the teacher modules taught
             professor.modulesTaught = new List<ClassModule> { };
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                //Teacher professor = new Teacher();   //A temporary variable to store current teacher
                professor.firstName = ResultSet["teacherfname"].ToString();
                professor.surName = ResultSet["teacherlname"].ToString();
                professor.employeeNumber = ResultSet["employeenumber"].ToString();
                professor.hireDate = (DateTime)ResultSet["hiredate"];  //Cast the result to date type
                professor.salary = (Decimal)ResultSet["salary"];       // Cast result to decimal type
                //Modules taught by the teacher
                ClassModule module = new ClassModule();
                module.classCode = ResultSet["classcode"].ToString();
                module.className = ResultSet["classname"].ToString();
                if (module.classCode != "")  //If no teaching, no need to fill module list
                {
                    module.startDate = (DateTime)ResultSet["startdate"];
                    module.finishDate = (DateTime)ResultSet["finishdate"];
                    //Add the teacher classes to module list
                    professor.modulesTaught.Add(module);
                }
               
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the teacher and his modules
            return professor;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fname">Teacher's first name</param>
        /// <param name="lname">Teacher's last name</param>
        /// <param name="employeenumber">Teacher's employee number </param>
        /// <param name="hireDate">Teacher's hire date</param>
        /// <param name="salary">Teacher's salary</param>

        [HttpPost]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void AddNewTeacher([FromBody] string fname, string lname,string employeenumber, DateTime hireDate, decimal salary)
        {
            //Inputs validation before saving in database
            if (fname == ""|| fname==null)
            {
                fname = "Unknown";
            }
            if (lname == "" || lname==null)
            {
                fname = "Unknown";
            }
            if (employeenumber.Length !=4 ||!employeenumber[0].Equals("T") ||employeenumber==null)
            {
                employeenumber = "Unknown";
            }
            if(salary<0 || salary > 900000 ||salary.Equals(null))
            {
                salary = 0;
            }
            if (hireDate==null)
            {
                hireDate = DateTime.Now;
            }
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //This query will get teachers and modules taught
            cmd.CommandText = "INSERT INTO teachers (teacherfname,teacherlname,employeenumber,hiredate,salary) VALUES(@fname, @lname,@employeenumber, @hiredate, @salary)";

            //The keys are added with their values in the table
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@employeenumber", employeenumber);
            cmd.Parameters.AddWithValue("@hiredate", hireDate);
            cmd.Parameters.AddWithValue("@salary",salary);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();

        }

        /// <summary>
        /// This function deletes a teacher and all his modules
        /// </summary>
        /// <param name="id">Parameter representing the employee number of the teacher</param>
        /// <example>/api/TeacherData/deleteTeacher/T378</example>
        /// /// <example>/api/TeacherData/deleteTeacher/T381</example>

        [HttpPost]
        public void deleteTeacher(string id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //This query deletes the teachers and all variables for which his references (Foreign Key) for referential integrity
            cmd.CommandText = "DELETE teachers, classes FROM teachers LEFT JOIN classes ON classes.teacherid=teachers.teacherid WHERE employeenumber=@id";
            //cmd.CommandText = "DELETE FROM teachers WHERE employeenumber=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();


        }



    }
    
}


//NB: The original code of this function is from the Web Application professor Christine Bitt of Humber College.