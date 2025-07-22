using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using WebAppUIDesign.Models;

namespace WebAppUIDesign.Controllers
{
    public class HomeController : Controller
    {
        #region Using HTML controls
        //we use http get and http post if we have the action method with same name.
        //Http get will serve one request and http post will serve another request.

        [HttpGet]
       public ViewResult AddEmp()
        {
            return View();
        }

        /* 
         //This is one type of passing the values to form in the view,, using parameters. 
          [HttpPost]
         public ViewResult AddEmp(int? id, string name, string job, double? salary)
         {
             ViewBag.id = id;
             ViewBag.name = name;
             ViewBag.job = job;
             ViewBag.salary = salary;

             return View("EmpForm1");
         }

        //This is second type of passing the values to form in the view,, using Form Collection.

        public ViewResult AddEmp(FormCollection fc)
        {
            ViewBag.id = fc["id"];
            ViewBag.name = fc["name"];
            ViewBag.job = fc["job"];
            ViewBag.salary = fc["salary"];

            return View("EmpForm1");
        }
        */

        //This is Third type of passing the values to form in the view,, using Model.

        public ViewResult AddEmp(Employee e)
        {
            return View("EmpForm2", e);
        }
        #endregion

        #region HTML Helper Methods
         
        public ViewResult Login()
        {
            return View();
        }

        public ViewResult Validate()
        {
            string Name = Request["txtName"];
            string Pwd = Request["txtPwd"];

            if(Name == "Sudheer" && Pwd == "Sudh@8143")
            {
                Session["User"] = Name;
                return View("Success");
            }
            else
            {
                ViewData["User"] = Name;
                return View("Failure");
            }              
        }

        #endregion
    }
}