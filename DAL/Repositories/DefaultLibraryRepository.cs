using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL.Repositories
{
    public class DefaultLibraryRepository : ILibraryRepository
    {
        public IList<Book> Books
        {
            get
            {
                using (var context = new LibraryContext())
                {
                    DbSet<Book> books = context.Books;
                    return new List<Book>(books);
                }
            }
        }

        public IList<InSubscription> Subscriptions
        {
            get
            {
                using (var context = new LibraryContext())
                {
                    List<InSubscription> subs = context.InSubscriptions.Include(x => x.Book).Include(x => x.User).ToList();
                    return subs;
                }
            }
        }

        public void AddBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public void MakeSubscription(Book book, string userId, bool isToTheLibrary)
        {
            using (var context = new LibraryContext())
            {
                DateTime returnDate;
                if (isToTheLibrary)
                {
                    returnDate = DateTime.Today;
                }
                else
                {
                    returnDate = DateTime.Today.AddDays(14);
                }
                context.InSubscriptions.Add(new InSubscription
                {
                    ISBN = book.ISBN,
                    IsInUse = true,
                    UserId = userId,
                    DateOfReceipt = DateTime.Today,
                    ReturnDate = returnDate
                });
                book.Quantity -= 1;
                EditBook(book);
                context.SaveChanges();
            }
        }

        public void ReturnBook(int subscriptionId)
        {
            using (var context = new LibraryContext())
            {
                var original = context.InSubscriptions.Find(subscriptionId);
                original.ReturnDate = DateTime.Today.Date;
                original.IsInUse = false;
                var book = context.Books.First(x => x.ISBN == original.ISBN);
                book.Quantity += 1;
                context.SaveChanges();
            }
        }

        public void EditBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                var original = context.Books.Find(book.ISBN);
                context.Entry(original).CurrentValues.SetValues(book);
                context.SaveChanges();
            }
        }

        public void RemoveBook(string isbn)
        {
            using (var context = new LibraryContext())
            {
                Book bookToRemove = context.Books.Find(isbn);
                context.Books.Remove(bookToRemove);
                context.SaveChanges();
            }
        }

        public IList<ApplicationUser> Users
        {
            get
            {
                using (var context = new LibraryContext())
                {
                    IList<ApplicationUser> users = context.Users.Include(x => x.Roles).ToList();
                    return users;
                }
            }
        }

        public bool isSubscribedAlready(string isbn, string userId)
        {
            using (var context = new LibraryContext())
            {
                InSubscription model = context.InSubscriptions.FirstOrDefault(x => x.ISBN == isbn && x.UserId == userId);
                if (model == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public IList<SelectListItem> Roles
        {
            get
            {
                using (var context = new LibraryContext())
                {
                    List<SelectListItem> model = context.Roles.Select(m => new SelectListItem
                    {
                        Value = m.Id,
                        Text = m.Name
                    }).ToList();
                    return model;
                }
            }
        }

        public void GiveBook(int subscriptionId)
        {
            using (var context = new LibraryContext())
            {
                var original = context.InSubscriptions.Find(subscriptionId);
                original.IsAccepted = true;
                context.SaveChanges();
            }
        }
    }
}