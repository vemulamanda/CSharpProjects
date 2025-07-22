using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppWithWindowsAuth.Controllers
{
    //Authorize: This filter can be used to give specific users access to action methods.Only those users are authorized to acces this methods. 
    // [Authorize(Users = "Server\\Manager01,Server\\Manager02")] //you can apply this at action method or controller level.
    //Instead of adding users individually, you can use groups.
    [Authorize(Roles = "Server\\ManagersGroup")]
    public class ManagerController : Controller
    {
        public ViewResult Home()
        {
            return View();
        }
        //Allow Anonymous filter is used to allow specific methods access to any user without login.
        //Best scenario is to use authorize on controller level and then use this allow anonymous at action method level.
        [AllowAnonymous]
        public ViewResult Help()
        {
            return View();
        }
    }
}