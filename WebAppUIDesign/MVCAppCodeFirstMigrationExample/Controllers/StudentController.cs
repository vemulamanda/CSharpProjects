using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppCodeFirstMigrationExample.Models;

namespace MVCAppCodeFirstMigrationExample.Controllers
{
    public class StudentController : Controller
    {
        SchoolDbContext dc = new SchoolDbContext();
        public ActionResult Index()
        {
            Student s1 = new Student { Sname = "Sudheer", Class = 10, Section = "A" };
            Student s2 = new Student { Sname = "Eswar", Class = 10, Section = "B" };
            Student s3 = new Student { Sname = "siri", Class = 10, Section = "C" };
            Student s4 = new Student { Sname = "Srija", Class = 10, Section = "D" };

            dc.Students.Add(s1); dc.Students.Add(s2);
            dc.Students.Add(s3); dc.Students.Add(s4);

            dc.SaveChanges();

            return View();
        }
    }
}