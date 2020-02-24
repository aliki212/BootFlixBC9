using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BootFlixBC9.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Viewer> Viewers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        public ApplicationDbContext()
            : base("BootFlixBC9DBContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
    }

}