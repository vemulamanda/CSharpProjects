using MVCDataAnnotations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDataAnnotations.Controllers
{
    public class UserController : Controller
    {
        public ActionResult GetUser()
        {
            return View();
        }

        public ActionResult UserDetails(User User)
        {
            if(ModelState.IsValid)
            {
                return View(User);
            }    
            else
            {
                return View("GetUser", User);
            }
        }

        public JsonResult IsDateValid(DateTime DOB)
        {
            bool Status = false;
            if(DOB > DateTime.Now.AddYears(-18))
            {
                Status = false;
            }
            else
            {
                Status = true;
            }

            return Json(Status, JsonRequestBehavior.AllowGet);
        }
    }
}