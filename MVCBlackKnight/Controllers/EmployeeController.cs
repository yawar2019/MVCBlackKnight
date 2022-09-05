using MVCBlackKnight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlackKnight.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ViewResult Index()
        {
            EmployeeModel emp = new Models.EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "Test";
            emp.EmpSalary = 10000;

            return View("~/Views/Admin/Test.cshtml", emp);
        }

        public ActionResult ShowMeJsonDataInTable()
        {
            return View();
        }
        public JsonResult Getjson()
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


            return Json(listEmp, JsonRequestBehavior.AllowGet);
        }

        public FileResult GetFile()
        {
            return File("~/Web.config", "text");
        }

        public FileResult GetFile2()
        {
            return File("~/Web.config", "application/xml");
        }
        public FileResult GetFile3()
        {
            return File("~/ActionResult.pdf", "application/pdf", "ActionResult.pdf");
        }


        public PartialViewResult GetPartialView()
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


            return PartialView("_StudentPartialView", listEmp);
        }

        public RedirectToRouteResult GetmeRoute()
        {
            return RedirectToRoute("Default2");
        }


        public RedirectToRouteResult GetmeRoute2()
        {
            return RedirectToAction("GetData","Admin",new {id=1211 });
        }
    }
}
//