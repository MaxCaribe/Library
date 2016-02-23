using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface ILibraryRepository
    {
        IList<Book> Books {get;}
        IList<InSubscription> GetAllSubscriptions();
        IList<ApplicationUser> GetUsers();
        void AddBook(Book book);
        void MadeSubscription(Book book, ApplicationUser user);
        void ReturnBook(InSubscription subscription);
        void EditBook(Book book);
        void RemoveBook(string isbn);
    }
}
