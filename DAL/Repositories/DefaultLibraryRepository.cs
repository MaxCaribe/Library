using System;
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
    }
}
