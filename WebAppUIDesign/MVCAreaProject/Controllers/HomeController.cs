using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinificationAndBundling.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Doctors()
        {
            ViewBag.Message = "Welcome to doctors page.";

            return View();
        }

        public ActionResult Patient()
        {
            ViewBag.Message = "Welcome to Patient page.";

            return View();
        }
        public ActionResult Staff()
        {
            ViewBag.Message = "Welcome to Staff page.";

            return View();
        }
    }
}