using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCBlackKnight
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            


            routes.MapRoute(
                name: "Default2",
                url: "Students/MVC",
                defaults: new { controller = "Employee", action = "Index", EmpId = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{EmpId}",
                defaults: new { controller = "Home", action = "Index", EmpId = UrlParameter.Optional }
            );
        }
    }
}
