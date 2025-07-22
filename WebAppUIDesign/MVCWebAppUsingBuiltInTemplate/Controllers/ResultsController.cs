using MVCWebAppUsingBuiltInTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCWebAppUsingBuiltInTemplate.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployees()
        {
            Employee e1 = new Employee { id = 101, name = "Scott", job = "CEO", salary = 50000, status = false };
            Employee e2 = new Employee { id = 102, name = "Micheal", job = "CTO", salary = 40000, status = true };
            Employee e3 = new Employee { id = 103, name = "Ryan", job = "Manager", salary = 30000, status = false };
            Employee e4 = new Employee { id = 104, name = "Paul", job = "Team Lead", salary = 20000, status = true };
            Employee e5 = new Employee { id = 105, name = "Brad", job = "Infra Engineer", salary = 10000, status = true };

            List<Employee> Employees = new List<Employee>() { e1, e2, e3, e4, e5 };
            
            return Json(Employees, JsonRequestBehavior.AllowGet);
        }

        public FileResult DownloadPdf()
        {
            return File("~/Downloads/Srija_driver_license.pdf", "application/pdf");
        }

        public FileResult DownloadWord()
        {
            return File("~/Downloads/FactFind.doc", "application/msword");
        }

        public RedirectResult OpenFacebook()
        {
            return Redirect("https://www.facebook.com");
        }

        
        public string SendDate1()
        {
            return "Current Date: " + DateTime.Now.ToString();
        }
        //          OR:  Both codes retrn strings
        public ContentResult SendDate2()
        {
            return Content("Current Date: " + DateTime.Now.ToString());
        }

        //If you want to return unicode text
        public ContentResult SayHello()
        {
            return Content("శుభోదయం", "text/plain", Encoding.Unicode);
        }

        public JavaScriptResult AlertUser()
        {
            return JavaScript("alert('Hello, How are you.')");      //Dont work now in newer browsers
        }

        public EmptyResult Test()
        {
            string str = "Hello World";
            str = str.ToUpper();
            //Ex: Write code for saving string to database.
            return new EmptyResult();       //you are creating instance using new keyword becoz you dont have helper method for Empty result.
        }
    }
}