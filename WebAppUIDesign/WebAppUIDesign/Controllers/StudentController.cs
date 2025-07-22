using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppUIDesign.Models;

namespace WebAppUIDesign.Controllers
{
    
    public class StudentController : Controller
    {
        #region Html elements Not strongly typed
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddStudent(Student s)
        {
            return View("DisplayStudent", s);
        }
        #endregion



        #region Strongly typed HTML Elements
        [HttpGet]
        public ViewResult AddStudentST()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddStudentST(Student s)
        {
            return View("DisplayStudentST", s);
        }

        #endregion

        public PartialViewResult Header()
        {
            return PartialView("_Header");
        }
    }

}