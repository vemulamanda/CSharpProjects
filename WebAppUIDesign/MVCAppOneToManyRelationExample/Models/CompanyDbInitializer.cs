using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAppOneToManyRelationExample.Models
{
    public class CompanyDbInitializer : DropCreateDatabaseIfModelChanges<CompanyDbContext>
    {
        protected override void Seed(CompanyDbContext context)
        {
            Department d1 = new Department { Did = 10, Dname = "Sales", Location = "Hyderabad" };
            Department d2 = new Department { Did = 20, Dname = "Research", Location = "Delhi" };
            Department d3 = new Department { Did = 30, Dname = "HR", Location = "Mumbai" };
            Department d4 = new Department { Did = 40, Dname = "Finance", Location = "Chennai" };

            context.Departments.Add(d1); context.Departments.Add(d2); context.Departments.Add(d3); context.Departments.Add(d4);
            context.SaveChanges();
        }
    }
}