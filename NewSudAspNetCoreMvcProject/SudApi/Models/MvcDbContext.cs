using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SudApi.Models
{
    public class MvcDbContext : IdentityDbContext
    {
        public MvcDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Farmer> Farmers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
