using BLL.Services.Interfaces;
using BLL.ViewModels;
using Library.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private ILibraryService service;
        private ApplicationUserManager userManager;

        public UsersController(ILibraryService libraryService)
        {
            service = libraryService;
        }

        public UsersController(ILibraryService libraryService, ApplicationUserManager userManager)
        {
            service = libraryService;
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        public ActionResult Index()
        {
            return View(service.Users);
        }

        public ActionResult Fines()
        {
            NewViewModel model = new NewViewModel
            {
                Subscriptions = service.Subscriptions.Subscriptions,
                Users = service.Users.Users
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult ChangeRole(string id, string role)
        {
            string toId = id.Trim();
            if (role != service.Users.Users.First(x => x.Id == toId).Roles.ElementAt(0).RoleId)
            {
                UserManager.RemoveFromRole(toId, service.Users.Roles.First(
                    x => x.Value == service.Users.Users.First(y => y.Id == toId).Roles.ElementAt(0).RoleId).Text);
                UserManager.AddToRole(toId, service.Users.Roles.First(x => x.Value == role).Text);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (userManager != null)
                {
                    userManager.Dispose();
                    userManager = null;
                }
            }
        }
    }
}