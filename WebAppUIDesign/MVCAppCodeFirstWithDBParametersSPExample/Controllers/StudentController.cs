using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppCodeFirstWithDBParametersSPExample.Models;

namespace MVCAppCodeFirstWithDBParametersSPExample.Controllers
{
    public class StudentController : Controller
    {
        SchoolDBContext dc = new SchoolDBContext();

        public ActionResult Index()
        {
            Student s1 = new Student()
            {
                Sid = 101,
                StudentName = "Sudheer",
                StudentClass = 10,
                fees = 5000.00f,
                Address = "Madhapur, Hyderabad"
            };

            Student s2 = new Student()
            {
                Sid = 102,
                StudentName = "Eswar",
                StudentClass = 9,
                fees = 6000.00f,
                Address = "KPHB, Hyderabad"
            };

            Student s3 = new Student()
            {
                Sid = 103,
                StudentName = "Siri",
                StudentClass = 8,
                fees = 7000.00f,
                Address = "RR.Peta, Eluru"
            };

            Student s4 = new Student()
            {
                Sid = 104,
                StudentName = "Srija",
                StudentClass = 10,
                fees = 8000.00f,
                Address = "Nizampet, Hyderabad"
            };

            dc.Students.Add(s1);dc.Students.Add(s2);
            dc.Students.Add(s3);dc.Students.Add(s4);

            dc.SaveChanges();

            return View();
        }
    }
}