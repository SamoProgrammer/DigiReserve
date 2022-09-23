using DigiReserve.Authentication;
using DigiReserve.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigiReserve.Database
{
    public class DatabaseContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<ReserveTime> ReservedTimes { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
