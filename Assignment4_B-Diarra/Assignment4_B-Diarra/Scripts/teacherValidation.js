// JavaScript source code for form validation
//window.onload = verify;

//This function verifies all the fields of the new teacher to know if they are empty or if they follow the right pattern.
//If these conditions are not satisfied, the form cannot be submitted!
function verify() {

    var teacherForm = document.forms.newTeacher;
    var teacherFname = teacherForm.fname;
    var teacherLname = teacherForm.lname;
    var teacherEmpId = teacherForm.employeenumber;
    var hiredate = teacherForm.hireDate;
    var salary = teacherForm.salary;
    //name pattern, only normal characters
    var nameRegex = /^([A-Za-z])+$/;
    //Salary
    var salaryRegex = /^\d{1,6}(\.\d{0,2})?$/;
    //Pattern for the date (2020-12-03 10:30:40)
    var dateRegex = /^\d{4}\-\d{2}\-\d{2}\s\d{2}\:\d{2}\:\d{2}$/;
    //Pattern for employee number Txxx (T123, T385)
    var employeeRegex = /^\T\d{3}$/;

    //This function checks that the date and time are in the right range
    function checkdate() {
        var dateTest = true;
        var realDate = hiredate.value;
        var year = parseInt(realDate.split('-')[0]);
        var month = parseInt(realDate.split('-')[1]);
        var day = parseInt(realDate.split('-')[2]);
        var timeHMS = realDate.split(' ')[1];
        var hour = parseInt(timeHMS.split(':')[0]);
        var minute = parseInt(timeHMS.split(':')[1]);
        var second = parseInt(timeHMS.split(':')[2]);

        //Years are between 1900-2030 and months 1-12, days 1-31 and hours 0-23, minutes and seconds 0-59
        if (year < 1900 || year > 2030 || month < 1 || month > 12 || day < 1 || day > 31 || hour < 0 || hour > 23 || minute < 0 || minute > 59 || second < 0 || second > 59) {
            var dateTest = false;
        }
        //April, June and September should be maximum 30 days
        if (month === 4 || month === 6 || month === 9 || month === 11 && day > 30) {
            var dateTest = false;
        }
        //February is fixed to 29 days maximum
        if (month === 2 && day > 29) {
            var dateTest = false;
        }
        return dateTest;
    }

    //This function checks all the fields one by one
    function validation() {
        //Teacher first name checking
        if (!nameRegex.test(teacherFname.value)) {
            teacherFname.style.backgroundColor = "red";
            teacherFname.focus();
            return false;
        } else {
            teacherFname.style.backgroundColor = "white";
        }
        //Teacher last name checking
        if (!nameRegex.test(teacherLname.value)) {
            teacherLname.style.backgroundColor = "red";
            teacherLname.focus();
            return false;
        } else {
            teacherLname.style.backgroundColor = "white";
        }
        //Teacher employee number checking
        if (!employeeRegex.test(teacherEmpId.value)) {
            teacherEmpId.style.backgroundColor = "red";
            teacherEmpId.focus();
            return false;
        } else {
            teacherEmpId.style.backgroundColor = "white";
        }
        //Teacher hire date checking
        if (!dateRegex.test(hiredate.value)) {
            hiredate.style.backgroundColor = "red";
            hiredate.focus();
            return false;
        } else if (!checkdate()) {
            hiredate.style.backgroundColor = "red";
            hiredate.focus();
            return false;
        }else {
            hiredate.style.backgroundColor = "white";
        }
        //Teacher salary checking
        if (!salaryRegex.test(salary.value)) {
            salary.style.backgroundColor = "red";
            salary.focus();

            return false;
        } else {
            salary.style.backgroundColor = "white";
        }
    }

    teacherForm.onsubmit = validation;

}

//Deletion confirmation
function confirmation() {

    var deleteForm = document.forms.deleteTeacher;

    function confirmDelete() {
        //If user clicks "Cancel", the deletion is cancelled
        var question = confirm("Do you really want to delete this teacher and his classes?");
        if (!question) {
            return false;
        }
    }
    deleteForm.onsubmit = confirmDelete;
}