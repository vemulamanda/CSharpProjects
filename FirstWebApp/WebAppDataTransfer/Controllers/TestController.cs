using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDataTransfer.Models;

namespace WebAppDataTransfer.Controllers
{
    public class TestController : Controller
    {
        public ViewResult Index1()
        {
            return View();
        }

        public ViewResult Display1()
        {
            return View();
        }

        public ViewResult Index2()
        {
            return View();
        }

        public ViewResult Display2(int? id, string item, double? price)
        {
            dynamic product = new { id = id, item = item, price = price };
            return View(product);
        }

        public ViewResult Index3(Product p)
        {
            return View(p);
        }
    }
}