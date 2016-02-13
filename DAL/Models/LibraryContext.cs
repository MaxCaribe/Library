namespace DAL.Models
{
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }

        public LibraryContext()
            : base("LibraryContext")
        {
        }

        public static LibraryContext Create()
        {
            return new LibraryContext();
        }


    }
}