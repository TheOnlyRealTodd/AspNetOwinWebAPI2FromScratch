using Auth2.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Auth2.Migrations
{
    
    /// <summary>
    /// This class is created when you run "Enable-Migrations" for the first time. It is the EntityFramework's
    /// configuration class. Most importantly, it allows us to seed the database every time update-database is used
    /// with the below "Seed" method. Note that we are using this to create an Admin user every time.
    /// This method can be used to run ANY SQL or seeding command.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Auth2.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //Seed Method below will be run every time you Update-Database so that if you want to add data,
        //You can do so below. Make sure Seed data doesn't already exist!
        protected override void Seed(Auth2.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "SuperPowerUser",
                Email = "test@test.com",
                EmailConfirmed = true,
                FirstName = "Todd",
                LastName = "DaUltimateMastuh",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "MySuperP@ssword!");
        }
    }
}
