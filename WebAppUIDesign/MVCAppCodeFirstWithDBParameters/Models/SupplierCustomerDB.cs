using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MVCAppCodeFirstWithDBParameters.Models
{
    public class SupplierCustomerDB : DbContext
    {
        public SupplierCustomerDB() : base("SC_DB")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SupplierCustomerDB>());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}