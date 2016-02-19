using BLL.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private ILibraryService service;
        public int PageSize = 4;

        public HomeController(ILibraryService libraryService)
        {
            service = libraryService;
        }

        public ActionResult Index(int page = 1)
        {
            PagedBookListViewModel model = new PagedBookListViewModel{
                Books=service.getBooks().Books.OrderBy(x=>x.ISBN).Skip((page-1)*PageSize).Take(PageSize),
            PageInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = service.getBooks().Books.Count()
            }
        };
            return View(model);
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