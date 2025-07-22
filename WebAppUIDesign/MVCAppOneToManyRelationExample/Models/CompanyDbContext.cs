using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAppOneToManyRelationExample.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("ConStr")
        {
            Database.SetInitializer(new CompanyDbInitializer());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}