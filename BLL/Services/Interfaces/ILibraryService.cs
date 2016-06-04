using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.Services.Interfaces
{
    public interface ILibraryService
    {
        BookListViewModel Books { get; }

        void Add(BookViewModel book);

        void Edit(BookViewModel book);

        //remove book
        void Remove(string isbn);

        UserListViewModel Users { get; }

        bool? MakeSubscription(BookViewModel book, string userId, bool isToTheLibrary);

        InSubscriptionsListViewModel Subscriptions { get; }

        void GiveBook(int subscriptionId);

        void ReturnBook(int subscriptionId);
    }
}