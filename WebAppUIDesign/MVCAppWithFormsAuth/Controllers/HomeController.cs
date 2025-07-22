using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppWithFormsAuth.Filters;

namespace MVCAppWithFormsAuth.Controllers
{
    [AuthenticateFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Display()
        {
            return View();
        }
    }
}