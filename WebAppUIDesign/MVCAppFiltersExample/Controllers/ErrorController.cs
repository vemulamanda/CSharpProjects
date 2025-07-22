using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppFiltersExample.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult BadRequest()
        {
            return View();
        }
        public ViewResult UnAuthorized()
        {
            return View();
        }
        public ViewResult PaymentRequired()
        {
            return View();
        }
        public ViewResult Forbidden()
        {
            return View();
        }
        public ViewResult NotFound()
        {
            return View();
        }
    }
}