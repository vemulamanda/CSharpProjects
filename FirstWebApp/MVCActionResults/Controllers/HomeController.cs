using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCActionResults.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult Register()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public bool Login(string username, string password)
        {
            if (username == "sudheer" && password == "Sudh8143")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ViewResult ForgotPassword()
        {
            return View("ForgotPwd");  //We can pass view name here, so viewname and action method
                                       //dont need to be same.
        }
        public ViewResult ResetPassword()
        {
            return View("~/Views/Home/ResetPwd.cshtml");
            //you can pass path of the view (~ refers to home directory). This is one of the way.
        }

        public ViewResult Mission()
        {
            return View("~/Views/Test/Mission.cshtml");
            //Your view can be in any folder under views simply you just .can pass path of the view (~ refers to home directory). This is one of the way.
        }
        public ViewResult Contact()
        {
            return View();
            //return View("~/Views/Home/Contact.cshtml");
        }
        public ViewResult Show(int id)
        {
            if(id == 1)
            {
                return View("Show1");
            }
            return View("Show2"); 
        }
    }
}