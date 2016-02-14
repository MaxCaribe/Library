using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Repositories;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        DefaultLibraryRepository dlr = new DefaultLibraryRepository();
        public ActionResult Index()
        {

            return View(dlr.GetBooks());
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