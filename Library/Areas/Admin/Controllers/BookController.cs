using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL.Services.Interfaces;
using Library.Models;
using BLL.ViewModels;

namespace Library.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class BookController : Controller
    {
        private ILibraryService service;
        public int PageSize = 4;

        public BookController(ILibraryService libraryService)
        {
            service = libraryService;
        }

        public ActionResult Index(int page = 1)
        {
            PagedBookListViewModel model = new PagedBookListViewModel
            {
                Books = service.Books.Books.OrderBy(x => x.ISBN).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = service.Books.Books.Count()
                }
            };
            return View(model);
        }

        public ViewResult Details(string isbn)
        {
            BookViewModel book = service.Books.Books.FirstOrDefault(x => x.ISBN == isbn);
            return View(book);
        }
        

        public ViewResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add([Bind(Include = "ISBN,Name,Author,Description,Publisher,Language,Format,Pages,PublicationDate,Quantity")] BookViewModel book, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    book.ImageMime = image.ContentType;
                    book.Image = new byte[image.ContentLength];
                    image.InputStream.Read(book.Image, 0, image.ContentLength);
                }
                service.Add(book);  
                return RedirectToAction("Index");
            }
            return View();
        }

        public ViewResult Edit(string isbn)
        {
            BookViewModel book = service.Books.Books.FirstOrDefault(x => x.ISBN  == isbn);
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ISBN,Name,Author,Description,Publisher,Language,Format,Pages,PublicationDate,Quantity")] BookViewModel book, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    book.ImageMime = image.ContentType;
                    book.Image = new byte[image.ContentLength];
                    image.InputStream.Read(book.Image, 0, image.ContentLength);
                }
                service.Edit(book);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(book);
            }
        }

        [HttpGet]
        public ActionResult Delete(string isbn)
        {
            service.Remove(isbn);
            return RedirectToAction("Index");
        }


        public FileContentResult GetImage(string isbn)
        {
            BookViewModel book = service.Books.Books.FirstOrDefault(p => p.ISBN == isbn);
            if (book != null)
            {
                return File(book.Image, book.ImageMime);
            }
            else
            {
                return null;
            }
        }
    }
}