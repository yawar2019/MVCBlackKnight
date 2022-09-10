using AdoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoDotNet.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.GetAllEmployees());
        }

        //going to be call at the time loading our Create page
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(EmployeeModel emp)//FormCollection frm
        {
            //string EmpName = frm["EmpName"];
            //int EmpSalary = Convert.ToInt32(frm["EmpSalary"]);

            int i = db.SaveEmployee(emp);

            if (i > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            EmployeeModel emp = db.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)//FormCollection frm
        {
            //string EmpName = frm["EmpName"];
            //int EmpSalary = Convert.ToInt32(frm["EmpSalary"]);

            int i = db.UpdateEmployee(emp);

            if (i > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            EmployeeModel emp = db.GetEmployeeById(id);
            return View(emp);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)//FormCollection frm
        {
            int i = db.DeleteEmployee(id);

            if (i > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}