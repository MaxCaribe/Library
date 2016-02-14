﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Interfaces;
using DAL.Models;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class DefaultLibraryRepository : ILibraryRepository
    {
        public IList<Book> GetBooks()
        {
            using (var context = new LibraryContext())
            {
                DbSet<Book> books = context.Books;
                return new List<Book>(books);
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

        public IList<ApplicationUser> GetUsers()
        {
            using (var context = new LibraryContext())
            {
                IDbSet<ApplicationUser> users = context.Users;
                return new List<ApplicationUser>(users);
            }
        }



        public void AddBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                context.Books.Add(book);
            }
        }

        public void MadeSubscription(Book book, ApplicationUser user)
        {
            using (var context = new LibraryContext())
            {
                context.InSubscriptions.Add(new InSubscription
                {
                    ISBN = book.ISBN,
                    IsInUse = true,
                    UserId = user.Id,
                    DateOfReceipt = DateTime.Today,
                    ReturnDate = DateTime.Today.AddDays(14)
                });
            }
        }

        public void ReturnBook(InSubscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}