using MVCAppAutomaticMigrationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCAppAutomaticMigrationExample.Controllers
{
    public class SchoolController : Controller
    {
        SchoolDbContext dc = new SchoolDbContext();
        public ActionResult Index()
        {
            Student s1 = new Student { SId = 1, Sname = "Sudheer" };
            dc.students.Add(s1);
            dc.SaveChanges();
            return View();
        }
    }
}