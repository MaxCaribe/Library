using AutoMapper;
using BLL.Services.Interfaces;
using BLL.ViewModels;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BLL.Services
{
    internal class LibraryService : ILibraryService
    {
        private ILibraryRepository repository;

        public LibraryService(ILibraryRepository someRepository)
        {
            repository = someRepository;
        }

        public BookListViewModel Books
        {
            get
            {
                IList<Book> books = repository.Books;
                BookListViewModel booksViewModel = new BookListViewModel
                {
                    Books = new List<BookViewModel>(books.Select(
                        x => Mapper.Map<BookViewModel>(x)))
                };
                return booksViewModel;
            }
        }

        public void Add(BookViewModel book)
        {
            Book model = Mapper.Map<Book>(book);
            repository.AddBook(model);
        }

        public void Edit(BookViewModel book)
        {
            Book model = Mapper.Map<Book>(book);
            repository.EditBook(model);
        }

        public void Remove(string isbn)
        {
            repository.RemoveBook(isbn);
        }

        public UserListViewModel Users
        {
            get
            {
                IList<ApplicationUser> users = repository.Users;
                IList<SelectListItem> roles = repository.Roles;
                UserListViewModel usersViewModel = new UserListViewModel
                {
                    Users = new List<UserViewModel>(users.Select(
                        x => Mapper.Map<UserViewModel>(x))),
                    Roles = new List<SelectListItem>(roles)
                };

                return usersViewModel;
            }
        }

        public bool? MakeSubscription(BookViewModel book, string userId, bool isToTheLibrary)
        {
            if (repository.isSubscribedAlready(book.ISBN, userId))
            {
                return null;
            }
            else
            {
                if ((book.Quantity > 0 & isToTheLibrary) || (book.Quantity > 1 & !isToTheLibrary))
                {
                    Book model = Mapper.Map<Book>(book);
                    repository.MakeSubscription(model, userId, isToTheLibrary);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public InSubscriptionsListViewModel Subscriptions
        {
            get
            {
                IList<InSubscription> subscriptions = repository.Subscriptions;
                InSubscriptionsListViewModel subscriptionsViewModel = new InSubscriptionsListViewModel
                {
                    Subscriptions = new List<InSubscriptionsViewModel>(subscriptions.Select(
                         x => Mapper.Map<InSubscriptionsViewModel>(x)))
                };
                return subscriptionsViewModel;
            }
        }

        public void GiveBook(int subscriptionId)
        {
            repository.GiveBook(subscriptionId);
        }

        public void ReturnBook(int subscriptionId)
        {
            repository.ReturnBook(subscriptionId);
        }
    }
}