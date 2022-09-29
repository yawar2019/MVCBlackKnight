using MVCBlackKnight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlackKnight.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public string GetData(int id)
        {
            return "Hello World";
        }

        public string GetData2(int? EmpId)
        {
            return "Hello World MY Id is "+EmpId;
        }


        public string GetData3(int? EmpId,string Name,string Designation)
        {
            return "Hello World MY Id is " + EmpId+" and Name is "+Name+" Designation"+Designation;
        }



        public string GetData4()
        {
            return "Hello World MY Id is " +Request.QueryString["EmpId"] +
                " and Name is " + Request.QueryString["Name"]
                + " Designation" +Request.QueryString["Designation"];
        }


        public ActionResult GetView()
        {
            return Redirect("http://www.google.com");
        }

        public ActionResult GetView2()
        {
            return Redirect("~/Admin/GetData");
        }

        public ActionResult GetContent()
        {
            return Content("James Bond");
        }

        public ActionResult SendInfo()
        {
            
            ViewBag.tata = "Shradha";
            return View();
        }
        public ActionResult SendInfo2()
        {
            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "james";
            obj.EmpSalary = 456000;


            ViewBag.data = obj;
            return View();
        }


        public ActionResult SendInfo3()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "james";
            obj.EmpSalary = 456000;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Gaurav";
            obj1.EmpSalary = 656000;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "priti";
            obj2.EmpSalary = 756000;

            listEmp.Add(obj);
            listEmp.Add(obj1);
            listEmp.Add(obj2);


            ViewBag.data = listEmp;



            return View();
        }

        public ActionResult SendDataByModel()
        {
            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "james";
            obj.EmpSalary = 456000;


            //object model=obj;
            return View(obj);
        }

        public ActionResult SendDataByModel2()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "james";
            obj.EmpSalary = 456000;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Gaurav";
            obj1.EmpSalary = 656000;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "priti";
            obj2.EmpSalary = 756000;

            listEmp.Add(obj);
            listEmp.Add(obj1);
            listEmp.Add(obj2);
            


            return View(listEmp);
        }


        public ActionResult SendDataByModel3()
        {
            List<EmployeeModel> listEmp = new List<EmployeeModel>();

            EmployeeModel obj = new EmployeeModel();
            obj.EmpId = 1;
            obj.EmpName = "james";
            obj.EmpSalary = 456000;

            EmployeeModel obj1 = new EmployeeModel();
            obj1.EmpId = 2;
            obj1.EmpName = "Gaurav";
            obj1.EmpSalary = 656000;

            EmployeeModel obj2 = new EmployeeModel();
            obj2.EmpId = 3;
            obj2.EmpName = "priti";
            obj2.EmpSalary = 756000;

            listEmp.Add(obj);
            listEmp.Add(obj1);
            listEmp.Add(obj2);



            List<DepartmentModel> listdept = new List<DepartmentModel>();


            DepartmentModel dept1 = new DepartmentModel();
            dept1.DeptId = 1211;
            dept1.DeptName = "IT";

            DepartmentModel dept2 = new DepartmentModel();
            dept2.DeptId = 1212;
            dept2.DeptName = "Network";


            listdept.Add(dept1);
            listdept.Add(dept2);

            EmpDept ed = new EmpDept();
            ed.listEmp = listEmp;
            ed.listDept = listdept;




            return View(ed);
        }


        public ActionResult HtmlHelperExampe()
        {
            EmployeeModel emp = new Models.EmployeeModel();
            emp.EmpName = "jiva";
            StaffEntities db = new StaffEntities();
            ViewBag.EmployeeList = new SelectList(db.employeeDetails, "EmpId", "EmpName",76043);
            return View(emp);
        }

        public ActionResult RegistrationForm()
        {
            StaffEntities db = new StaffEntities();
            ViewBag.EmployeeList = new SelectList(db.employeeDetails, "EmpId", "EmpName", 76043);

            return View();
        }

        [HttpPost]
        public ActionResult RegistrationForm(RegisterModel reg)
        {
            StaffEntities db = new StaffEntities();
            ViewBag.EmployeeList = new SelectList(db.employeeDetails, "EmpId", "EmpName", 76043);

            return View();
        }
    }
}