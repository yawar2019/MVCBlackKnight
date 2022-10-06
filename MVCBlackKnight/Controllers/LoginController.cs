using MVCBlackKnight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCBlackKnight.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDetail userObj)
        {
            string requestUrl = Request.QueryString["ReturnUrl"];
            StaffEntities db = new Models.StaffEntities();
            var user = db.UserDetails.Where(u => u.UserName == userObj.UserName && u.Password == userObj.Password).SingleOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(userObj.UserName, false);
                return RedirectToAction("Dashboard");
            }
            return View();
        }
        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]//prema
        public ActionResult AboutUs()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]//Manager
        public ActionResult ContactUs()
        {
            return View();
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Login/Login");
        }
    }
}