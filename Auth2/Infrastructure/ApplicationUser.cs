using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Auth2.Infrastructure
{
    /// <summary>
    /// These are the custom properties that WE have defined for an ApplicationUser account.
    /// These properties in IN ADDITION to the default username, password, etc... properties.
    /// Those properties come with IdentityUser. Notice how this class inherits from IdentityUser.
    /// After creating this class, we must add it to the ApplicationDbContext ; IdentityDbContext.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public byte Level { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

    }
}