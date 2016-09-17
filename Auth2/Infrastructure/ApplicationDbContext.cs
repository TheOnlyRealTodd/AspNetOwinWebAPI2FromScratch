using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Auth2.Infrastructure
{
    /// <summary>
    /// Sets up the Database Connection as well as the Identity Account system, based upon
    /// what IdentityUser type that we pass into IndentityDbContext: here we passed ApplicationUser in.
    /// You would also add your own custom tables into this class as properties of type DbSet.
    /// These properties will be converted into Database tables when migrations are run.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            //NO LAZY LOADING!
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}