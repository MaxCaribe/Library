using BLL.Services.Interfaces;
using Library.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Library.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private ILibraryService service;

        public UsersController(ILibraryService libraryService)
        {
            service = libraryService;
        }

        public ActionResult Index()
        {
            return View(service.Users);
        }
    }
}