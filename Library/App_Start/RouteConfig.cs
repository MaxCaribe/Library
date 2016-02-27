using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Details",
                url: "{controller}/Details/{isbn}",
                defaults: new { controller = "Home", action = "Details", isbn = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{page}",
                 defaults: new { controller = "Home", action = "Index", page = UrlParameter.Optional },
                 constraints: new { page = @"\d*" }
             );
            
        }
    }
}
