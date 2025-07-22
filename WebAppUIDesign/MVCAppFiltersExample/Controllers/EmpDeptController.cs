using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MVCAppFiltersExample.Models;

namespace MVCAppFiltersExample.Controllers
{
    //[HandleError]  //you can also apply this at application level, so that it will be applied to all controllers and all action methods.
    public class EmpDeptController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();

        #region ChildActionOnly Filter
        //This filter executes before action method.
        //ChildActionOnly filter will not allow direct calls to this action method from browser.
        public ViewResult DisplayDepts()
        {
            var Depts = dc.Departments;
            return View(Depts);
        }

        [ChildActionOnly]      
        
        public ViewResult DisplayEmpsByDept(int Did)
        {
            var Emps = from E in dc.Employees where E.Did == Did select E;
            return View(Emps);
        }
        #endregion

        #region OutputCache Filter

        //Creates cache copy and stores for 30 seconds on the server.
        //[OutputCache(Duration = 30, Location = OutputCacheLocation.Server)]  You can mention this in web.config file and write below code here.
        [OutputCache(CacheProfile = "MyCacheProfile01")]
        public ViewResult DisplayStudents01()
        {
            return View(dc.Students);
        }
        //Creates cache copy for 45 seconds on the sever and creates each copy using "class" parameter.
        //[OutputCache(Duration = 45, Location = OutputCacheLocation.Server, VaryByParam = "Class")]
        [OutputCache(CacheProfile = "MyCacheProfile02")]
        public ViewResult DisplayStudents02(int Class)
        {
            return View(dc.Students.Where(C => C.Class == Class));
        }
        //Creates cache copy and stores for 30 seconds on server and creates copy one each for browser.
        //[OutputCache(Duration =30, Location = OutputCacheLocation.Server, VaryByCustom = "browser")]
        [OutputCache(CacheProfile = "MyCacheProfile03")]
        public ViewResult DisplayStudents03()
        {
            return View(dc.Students);
        }

        #endregion

        #region ValidateInput Filter
        [HttpGet]
        public ViewResult GetComments()
        {
            return View();
        }
        [HttpPost, ValidateInput(true)]  //ValidateInput(true) is not needed here because it is by default set to true. you can set it to false if you want to allow html code to be injected from browser.
        public string GetComments(string txtComments)
        {
            return txtComments;
        }

        #endregion

        #region ValidateAntiForgeryToken Filter  
        //With this filter someone cannot copy your html form source code and add it to their sites and load your sitre from their websites.
        [HttpGet]
        public ViewResult AddEmployee()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public string AddEmployee(Employee employee)
        {
            employee.Status = true;
            dc.Employees.Add(employee);
            dc.SaveChanges();
            return "record inserted";
        }

        #endregion

        #region HandleError Filter
        //This filter displays the respective error pages when exception is occured.
        //You have to create controller with action methods and views(error pages) and mention the paths under web.config file.
        [HttpGet]
        public ViewResult DivideNums()
        {
            return View();
        }

        //[HttpPost, HandleError] //you can apply handle error on action method level like this. But this will be applied only to this action method.
        //if you want tit to be applied for all action methods in this controller, apply it on controller level.
        [HttpPost]
        public string DivideNums(int num1, int num2)
        {
            int result = num1 / num2;
            return "Final Result: " + result;
        }
        
        public ViewResult ShowView()
        {
            return View();
        }
        #endregion
    }
}