using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApp.Controllers
{
    public class DemoController : Controller
    {
        public string Index()
        {
            return "Hi Sudheer. This is from Demo controller.";
        }
        public string Esw()
        {
            return "Hi Eswar. This is from Demo controller.";
        }
    }
}