using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tidea.Infrastructure.Data
{
    public class TideaDbContext : IdentityDbContext<ApplicationUser>
    {
        public TideaDbContext(DbContextOptions<TideaDbContext> options)
            : base(options)
        {
        }
    }
}