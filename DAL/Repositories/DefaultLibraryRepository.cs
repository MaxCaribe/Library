using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;
using DAL.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

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

        public IList<InSubscription> GetAllSubscriptions()
        {
            using (var context = new LibraryContext())
            {
                DbSet<InSubscription> subs = context.InSubscriptions;
                return new List<InSubscription>(subs);
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

        public void MakeSubscription(Book book, string userId,bool isToTheLibrary)
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

        public void ReturnBook(InSubscription subscription)
        {
            throw new NotImplementedException();
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
                    IDbSet<ApplicationUser> users = context.Users;
                    return users.ToList();
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
    }
}
