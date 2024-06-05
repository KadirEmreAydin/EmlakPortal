

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EmlakPortal.API.Models;

namespace EmlakPortal.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Estate> Properties { get; set; }


    }
}
