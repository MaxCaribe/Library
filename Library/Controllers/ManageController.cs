using BLL.Services.Interfaces;
using BLL.ViewModels;
using Library.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ILibraryService service;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController(ILibraryService libraryService)
        {
            service = libraryService;
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ILibraryService libraryService)
        {
            service = libraryService;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpGet]
        public ActionResult GiveBook(int id)
        {
            service.GiveBook(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ReturnBook(int id)
        {
            service.ReturnBook(id);
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            InSubscriptionWithUsersViewModel model = new InSubscriptionWithUsersViewModel
            {
                Subscriptions = service.Subscriptions.Subscriptions,
                User = service.Users.Users.First(x => x.Id == userId)
            };
            return View(model);
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { });
            }
            AddErrors(result);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Вспомогательные приложения

        // Используется для защиты от XSRF-атак при добавлении внешних имен входа
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        #endregion Вспомогательные приложения
    }
}