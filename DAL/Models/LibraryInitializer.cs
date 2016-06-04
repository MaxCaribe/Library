using DAL.Properties;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LibraryInitializer : CreateDatabaseIfNotExists<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            context.Books.Add(new Book
            {
                Name = "Gotta Love This Country! : Great Stories from Around Australia to Lift Your Heart, Make You Laugh and Puff Out Your Chest",
                Author = "Peter Fitzsimons",
                Format = "paperback",
                ISBN = "9781760290481",
                Publisher = "Alien & Unwin",
                PublicationDate = new DateTime(2016, 3, 1, 0, 0, 0),
                Pages = 272,
                Quantity = 1,
                Description = Resources.Text1,
                Language = "English",
                Image = null,
                ImageMime = null
            });
            context.Books.Add(new Book
            {
                Name = "Reckoning : A Memoir",
                Author = "Magda Szubanski",
                Format = "hardback",
                ISBN = "9781925240436",
                Publisher = "Text Publishing Co",
                PublicationDate = new DateTime(2015, 9, 23, 0, 0, 0),
                Pages = 400,
                Quantity = 2,
                Description = Resources.Text2,
                Language = "English",
                ImageMime = null,
                Image = null
            });
            context.Roles.Add(new IdentityRole("user"));
            context.Roles.Add(new IdentityRole("admin"));
            context.Roles.Add(new IdentityRole("librarian"));
            base.Seed(context);
        }
    }
}