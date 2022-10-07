using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionHanler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //[HandleError(View="MyError")]
        public ActionResult IronManBack(string id)
        {
            try
            {
                int a = 10, b = Convert.ToInt32(id), c;
                c = a / b;
            }
            catch (Exception ex)
            {
              
                throw ex;
            }


            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}