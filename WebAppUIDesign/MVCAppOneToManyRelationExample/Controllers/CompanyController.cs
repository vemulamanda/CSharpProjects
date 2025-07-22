using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppOneToManyRelationExample.Models;

namespace MVCAppOneToManyRelationExample.Controllers
{
    public class CompanyController : Controller
    {
        CompanyDbContext dc = new CompanyDbContext();
        public ActionResult Index()
        {
            Employee e1 = new Employee { Ename = "Sudheer", Job = "Devops", Salary = 120000.00, Did = 10 };
            Employee e2 = new Employee { Ename = "Eswar", Job = "Test Manager", Salary = 100000.00, Did = 20 };
            Employee e3 = new Employee { Ename = "Siri", Job = "Tester", Salary = 90000.00, Did = 40 };
            Employee e4 = new Employee { Ename = "Srija", Job = "Customer Service", Salary = 750000.00, Did = 30 };

            dc.Employees.Add(e1); dc.Employees.Add(e2); dc.Employees.Add(e3); dc.Employees.Add(e4);

            dc.SaveChanges();

            return View(dc.Employees.Include("Departments"));
        }
    }
}