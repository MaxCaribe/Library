using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL.Repositories.Interfaces
{
    public interface ILibraryRepository
    {
        IList<Book> Books { get; }

        IList<InSubscription> Subscriptions { get; }

        void AddBook(Book book);

        void MakeSubscription(Book book, string userId, bool isToTheLibrary);

        void ReturnBook(int subscriptionId);

        void GiveBook(int subscriptionId);

        void EditBook(Book book);

        void RemoveBook(string isbn);

        IList<ApplicationUser> Users { get; }

        bool isSubscribedAlready(string isbn, string userId);

        IList<SelectListItem> Roles { get; }
    }
}