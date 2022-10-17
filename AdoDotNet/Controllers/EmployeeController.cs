using AdoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public ActionResult GetConsumeService()
        {
            calculatorService1.CalculatorServiceSoapClient obj = new calculatorService1.CalculatorServiceSoapClient();
           var result= obj.Add(10, 20);
             
            return Content(result.ToString());
        }

        public ActionResult GetEmployees()
        {
            IEnumerable<EmployeeModel> ListEmployeeModel = null;
            using (HttpClient client  =new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51587/api/");
                var response = client.GetAsync("employeeDetailsApi/GetemployeeDetails");
                response.Wait();
                var result = response.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readresponse = result.Content.ReadAsAsync<IList<EmployeeModel>>();
                    readresponse.Wait();
                    ListEmployeeModel = readresponse.Result;
                }

            }
                return View(ListEmployeeModel);
        }

        [HttpPost]
        public ActionResult CreateEmp(EmployeeModel emp)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51587/api/");
                var response = client.PostAsJsonAsync("employeeDetailsApi/PostemployeeDetail",emp);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetEmployees");
                }

            }
            return View();
        }
    }
}