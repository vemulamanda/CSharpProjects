using Microsoft.EntityFrameworkCore;
using AspNetCoreMvc_FinalProject.Models;
using AspNetCoreWebApiExample.Models;

namespace AspNetCoreMvc_FinalProject.Models
{
    public class MvcCoreDBContext : DbContext
    {
        public MvcCoreDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
