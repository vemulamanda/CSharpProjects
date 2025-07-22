using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVCAppUsingAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public string GetScore()
        {
            string physicalpath = Server.MapPath("~/Matches/Score.xml");
            var document = XElement.Load(physicalpath);
            string score = document.Element("Score").Value;
            return score;
        }
    }
}