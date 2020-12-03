using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Assignment4_B_Diarra.Models;

namespace Assignment4_B_Diarra.Controllers
{
    public class ClassesDataController : ApiController
    {
        // The school database context class allow us to access our MySQL school Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the classes table of our school database.
        /// <summary>
        /// Returns a list of modules in the system
        /// </summary>
        /// <example>GET api/classesData/ListClasses</example>
        /// <returns>
        /// A list of classes with assigned teachers name
        /// </returns>
        [HttpGet]
        public IEnumerable<ClassModule> ListClasses()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //This query will get informatiom from classes and teachers tables
            cmd.CommandText = "SELECT classes.*,teacherfname,teacherlname FROM classes Left JOIN teachers ON classes.teacherid=teachers.teacherid";

            //This variable will contain the ghathered results
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of classes and teacher information
            List<ClassModule> classes = new List<ClassModule> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                ClassModule classe = new ClassModule();   //A temporary variable to store current class
                classe.classCode = ResultSet["classcode"].ToString();
                classe.className = ResultSet["classname"].ToString();
                classe.startDate = (DateTime)ResultSet["startdate"];  //Cast the result to date type
                classe.finishDate = (DateTime)ResultSet["finishdate"];  //Cast the result to date type
                //Add the module to the List
                classes.Add(classe);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of modules and their teachers
            return classes;
        }
    }
}


//NB:The original code of this function is from the Web Application professor Christine Bittle of Humber College.