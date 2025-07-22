using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppCreateModelsUsingDesigner.Models;

namespace MVCAppCreateModelsUsingDesigner.Controllers
{
    public class CompanyController : Controller
    {
        EmpDeptContainer dc = new EmpDeptContainer();
        public ActionResult Index()
        {
            Employee e1 = new Employee { Ename = "Sudheer", Location = "Melbourne", Salary = 12000.00, Did = 10 };
            Employee e2 = new Employee { Ename = "Eswar", Location = "Sydney", Salary = 150000.00, Did = 20 };
            Employee e3 = new Employee { Ename = "Siri", Location = "Toronto", Salary = 110000.00, Did = 10 };
            Employee e4 = new Employee { Ename = "Srija", Location = "Perth", Salary = 100000.00, Did = 30 };

            dc.Employees.Add(e1); dc.Employees.Add(e2); dc.Employees.Add(e3); dc.Employees.Add(e4);
            dc.SaveChanges();
           

            return View(dc.Employees.Include("Departments"));
        }
    }
}