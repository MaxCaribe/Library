using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ILibraryRepository
    {
        IList<Book> Books { get; }

        IList<InSubscription> Subscriptions { get; }

        void AddBook(Book book);

        void MakeSubscription(Book book, string userId, bool isToTheLibrary);

        void ReturnBook(InSubscription subscription);

        void EditBook(Book book);

        void RemoveBook(string isbn);

        IList<ApplicationUser> Users { get; }

        bool isSubscribedAlready(string isbn, string userId);
    }
}