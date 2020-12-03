using Assignment4_B_Diarra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment4_B_Diarra.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/Index
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// This View is used to enter the information to be searched in the database
        /// </summary>
        /// <returns></returns>
        // GET: Teacher/SearchIndex
        public ActionResult SearchTeacher()
        {
            return View();
        }
        /// <summary>
        /// This method puts in a list all teachers returned by the Query
        /// <example>GET: Teacher/List/Sam </example>
        /// </summary>
        /// <returns>it returns the list of teachers with name, employee number and hire date</returns>
        // 
        public ActionResult List(string keyword=null)
        {
            TeacherDataController list = new TeacherDataController();
            List<Teacher> teacherList = list.ListTeachers(keyword).ToList();
            return View(teacherList);
        }


        /// <summary>
        /// This method displays a teacher selected by his employee number. It also shows the modules taught by the teacher.
        /// </summary>
        /// <param name="id"></param>
        /// <example>Teacher/Show/T378 </example>
		/// <example>Teacher/Show/T381 </example>
        /// <returns>Teacher name, employee number, hire date and modules taught to view</returns>
        // 
        
        public ActionResult Show(string id)
        {
            string employeeNumber = id;
            TeacherDataController controller = new TeacherDataController();
            Teacher selectedTeacher = controller.displayTeacher(employeeNumber);

            return View(selectedTeacher);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fname">Teacher's first name</param>
        /// <param name="lname">Teacher's last name</param>
        /// <param name="employeenumber">Teacher's employee number </param>
        /// <param name="hireDate">Teacher's hire date</param>
        /// <param name="salary">Teacher's salary</param>
        /// <returns>Go back to the list of teachers</returns>

        //POST : /Teacher/Add
        [HttpPost]
        public ActionResult Add(string fname, string lname,string employeenumber, DateTime hireDate, decimal salary)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.AddNewTeacher(fname, lname, employeenumber, hireDate, salary);
            return RedirectToAction("List");
        }


        // GET: Teacher/NewTeacher
        public ActionResult NewTeacher()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Teacher's employee number</param>
        /// <returns>Go back to the list of teachers</returns>

        //POST : /Teacher/removeTeacher
        [HttpPost]
        public ActionResult removeTeacher(string id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.deleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Author/Ajax_NewTeacher
        public ActionResult Ajax_NewTeacher()
        {
            return View();

        }

    }
}