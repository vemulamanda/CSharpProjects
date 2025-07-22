using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AspNetCoreMvc_FinalProject.Models;

namespace AspNetCoreMvc_FinalProject.Models
{
    public class MvcCoreDBContext : IdentityDbContext
    {
        public MvcCoreDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }

        //The default data can be added using seed data process below.
        //You can update the default data using migration process also.
        //Just update new record here and run manual migration and that will update database.
        //This seeding is generally done during initial migration only.(optional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //If we want to use the identity data which microsoft provided for authentication and authorization purposes,
            //we need to implement logic present in parent also using base keyword.

            base.OnModelCreating(modelBuilder);

            //we are overriding below and writing our own logic, The below code is created for seeding our own data.
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Custid=101, Name="Sudheer", Balance=25000.00m, City="Melbourne", Status=true},
                new Customer { Custid = 102, Name = "Eswar", Balance = 26000.00m, City = "Sydney", Status = true },
                new Customer { Custid = 103, Name = "Siri", Balance = 27000.00m, City = "Perth", Status = true },
                new Customer { Custid = 104, Name = "Srija", Balance = 28000.00m, City = "Brisbane", Status = true }
            );
        }
        public DbSet<AspNetCoreMvc_FinalProject.Models.UserModel> UserModel { get; set; } = default!;
        public DbSet<AspNetCoreMvc_FinalProject.Models.LoginModel> LoginModel { get; set; } = default!;
        public DbSet<AspNetCoreMvc_FinalProject.Models.ChangePasswordModel> ChangePasswordModel { get; set; } = default!;
        public DbSet<AspNetCoreMvc_FinalProject.Models.ResetPasswordModel> ResetPasswordModel { get; set; } = default!;
    }
}
