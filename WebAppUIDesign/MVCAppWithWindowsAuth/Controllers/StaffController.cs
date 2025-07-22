using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppWithWindowsAuth.Controllers
{
    //The below code is applied to give authorized access to any methods in staff controller.
    //[Authorize(Users = "Server\\Staff01,Server\\Staff02")] //you can apply this at action method or controller level.
    [Authorize(Roles = "Server\\StaffGroup")]
    public class StaffController : Controller
    {
        public ViewResult Home()
        {
            return View();
        }
        public ViewResult Help()
        {
            return View();
        }
    }
}