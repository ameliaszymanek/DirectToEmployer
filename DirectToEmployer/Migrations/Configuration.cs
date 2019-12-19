namespace DirectToEmployer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DirectToEmployer.Models.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DirectToEmployer.Models.ApplicationDbContext db)
        {
            //new Models.Interest { Name = "Restaurant", Value = "restaurant" },
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            db.Companies.AddOrUpdate(
            new Models.Company { CompanyName = "Northwestern Mutual" },
            new Models.Company { CompanyName = "Rockwell Automation" },
            new Models.Company { CompanyName = "Brewers"}
        );
        }
    }
}
