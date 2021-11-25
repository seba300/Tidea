using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tidea.Core.Entities;

namespace Tidea.Infrastructure.Data
{
    public class TideaDbContext : IdentityDbContext<ApplicationUser>
    {
        public TideaDbContext(DbContextOptions<TideaDbContext> options)
            : base(options)
        {
        }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Media> Medias { get; set; }
    }
}