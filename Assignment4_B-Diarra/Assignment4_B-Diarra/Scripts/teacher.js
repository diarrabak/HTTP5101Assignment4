// AJAX for adding teacher 
// This file is connected to the project via Shared/_Layout.cshtml


function AddTeacher() {

	//goal: send a request which looks like this:
	//POST : http://localhost:50452/api/TeacherData/AddNewTeacher
	//with POST data of authorname, bio, email, etc.

	var URL = "http://localhost:50452/api/TeacherData/AddNewTeacher/";

	var rq = new XMLHttpRequest();
	// where is this request sent to?
	// is the method GET or POST?
	// what should we do with the response?

	var teacherForm = document.forms.newTeacher;
	var teacherFname = teacherForm.fname.value;
	var teacherLname = teacherForm.lname.value;
	var teacherEmpId = teacherForm.employeenumber.value;
	var hiredate = teacherForm.hireDate.value;
	var salary = teacherForm.salary.value;

	var TeacherData = {
		"fname": teacherFname,
		"lname": teacherLname,
		"employeenumber": teacherEmpId,
		"hireDate": hiredate,
		"salary": salary
	};

	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished

			//nothing to render, the method returns nothing.


		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}


//NB: The original code of this function is from the Web Application professor Christine Bitt of Humber College.