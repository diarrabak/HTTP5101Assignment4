using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment4_B_Diarra.Models
{
    //This extended class allows getting teacher information and its teachings
    public class Teacher
    {
        public string firstName;
        public string surName;
        public string employeeNumber;
        public DateTime hireDate;
        public decimal salary;

        //Modules taught by the teacher
        public List<ClassModule> modulesTaught;
    }
}