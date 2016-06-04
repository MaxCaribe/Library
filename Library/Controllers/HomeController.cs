using BLL.Services.Interfaces;
using BLL.ViewModels;
using Library.Models;
using System.Linq;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private ILibraryService service;
        public int PageSize = 12;

        public HomeController(ILibraryService libraryService)
        {
            service = libraryService;
        }

        public ViewResult Details(string isbn = "9781853262715")
        {
            BookViewModel book = service.Books.Books.FirstOrDefault(x => x.ISBN == isbn);
            return View(book);
        }

        public ActionResult Search(string search, int page = 1)
        {
            PagedBookListViewModel model = null;
            try
            {
                var books = service.Books.Books.Where(x => x.Name.ToLower().Contains(search.ToLower())
                    || x.Author.ToLower().Contains(search.ToLower())).OrderBy(x => x.Name).Skip((page - 1) * PageSize).Take(PageSize);

                model = new PagedBookListViewModel
                {
                    Books = books,
                    PageInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = books.Count()
                    }
                };
            }
            catch
            {
                return View("NothingFound");
            }
            return View(model);
        }

        public ActionResult Index(string Sort = "Name", int page = 1, string SortType = "Asc")
        {
            PagedBookListViewModel model = null;
            if (SortType == "Asc")
            {
                switch (Sort)
                {
                    case "Name":
                        model = new PagedBookListViewModel
                        {
                            Books = service.Books.Books.OrderBy(x => x.Name).Skip((page - 1) * PageSize).Take(PageSize),
                            PageInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = PageSize,
                                TotalItems = service.Books.Books.Count()
                            }
                        };
                        break;

                    case "Author":
                        model = new PagedBookListViewModel
                            {
                                Books = service.Books.Books.OrderBy(x => x.Author).Skip((page - 1) * PageSize).Take(PageSize),
                                PageInfo = new PagingInfo
                                {
                                    CurrentPage = page,
                                    ItemsPerPage = PageSize,
                                    TotalItems = service.Books.Books.Count()
                                }
                            };
                        break;

                    case "Publisher":
                        model = new PagedBookListViewModel
                            {
                                Books = service.Books.Books.OrderBy(x => x.Publisher).Skip((page - 1) * PageSize).Take(PageSize),
                                PageInfo = new PagingInfo
                                {
                                    CurrentPage = page,
                                    ItemsPerPage = PageSize,
                                    TotalItems = service.Books.Books.Count()
                                }
                            };
                        break;

                    case "PublishDate":
                        model = new PagedBookListViewModel
                            {
                                Books = service.Books.Books.OrderBy(x => x.PublicationDate).Skip((page - 1) * PageSize).Take(PageSize),
                                PageInfo = new PagingInfo
                                {
                                    CurrentPage = page,
                                    ItemsPerPage = PageSize,
                                    TotalItems = service.Books.Books.Count()
                                }
                            };
                        break;
                }
            }
            else
            {
                switch (Sort)
                {
                    case "Name":
                        model = new PagedBookListViewModel
                        {
                            Books = service.Books.Books.OrderByDescending(x => x.Name).Skip((page - 1) * PageSize).Take(PageSize),
                            PageInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = PageSize,
                                TotalItems = service.Books.Books.Count()
                            }
                        };
                        break;

                    case "Author":
                        model = new PagedBookListViewModel
                        {
                            Books = service.Books.Books.OrderByDescending(x => x.Author).Skip((page - 1) * PageSize).Take(PageSize),
                            PageInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = PageSize,
                                TotalItems = service.Books.Books.Count()
                            }
                        };
                        break;

                    case "Publisher":
                        model = new PagedBookListViewModel
                        {
                            Books = service.Books.Books.OrderByDescending(x => x.Publisher).Skip((page - 1) * PageSize).Take(PageSize),
                            PageInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = PageSize,
                                TotalItems = service.Books.Books.Count()
                            }
                        };
                        break;

                    case "PublishDate":
                        model = new PagedBookListViewModel
                        {
                            Books = service.Books.Books.OrderByDescending(x => x.PublicationDate).Skip((page - 1) * PageSize).Take(PageSize),
                            PageInfo = new PagingInfo
                            {
                                CurrentPage = page,
                                ItemsPerPage = PageSize,
                                TotalItems = service.Books.Books.Count()
                            }
                        };
                        break;
                }
            }
            return View(model);
        }

        public FileContentResult GetImage(string isbn)
        {
            BookViewModel book = service.Books.Books.First(p => p.ISBN == isbn);
            if (book != null)
            {
                return File(book.Image, book.ImageMime);
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public ActionResult Subscribe(string isbn, string userName, bool isToTheLibrary)
        {
            try
            {
                bool? result = service.MakeSubscription(service.Books.Books.First(x => x.ISBN == isbn),
                    service.Users.Users.First(x => x.UserName == userName).Id, isToTheLibrary);
                if (result == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    if (result == false)
                    {
                        return View("IncorrectQuantity");
                    }
                    else
                    {
                        return View("AlreadyHave");
                    }
                }
            }
            catch
            {
                return View("Error");
            }
        }
    }
}