namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DAL.Models;
    using Properties;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }       
    }
}
