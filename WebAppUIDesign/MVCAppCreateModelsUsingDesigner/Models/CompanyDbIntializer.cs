using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAppCreateModelsUsingDesigner.Models
{
    public class CompanyDbIntializer : DropCreateDatabaseIfModelChanges<EmpDeptContainer>
    {
        protected override void Seed(EmpDeptContainer context)
        {
            Department d1 = new Department { Did = 10 , Dname = "IT" };
            Department d2 = new Department { Did = 20, Dname = "Medical" };
            Department d3 = new Department { Did = 30, Dname = "HR" };

            context.Departments.Add(d1); context.Departments.Add(d2); context.Departments.Add(d3);
            context.SaveChanges();
        }
    }
}