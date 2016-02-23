namespace DAL.Models
{
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Validation;
    using System.Text;

    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<InSubscription> InSubscriptions { get; set; }

        public LibraryContext()
            : base("LibraryContext")
        {
            Database.SetInitializer(new LibraryInitializer());  
        }

        public static LibraryContext Create()
        {
            return new LibraryContext();
        }


    }

}
