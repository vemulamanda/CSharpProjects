using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebAppDataTransfer.Models;

namespace WebAppDataTransfer.Controllers
{
    public class HomeController : Controller
    {
        //View data can access data on same page only and cannot transfer data to all pages in a request and type conversion should be done..
        //viewbag can access data on same page only and cannot transfer data to all pages in a request but type conversion dont need to be done.. 
        //tempdata can transfer data to next page only using peek methos and can transfer to all pages needed using keep method.
        //cookies are use dto store values on client pc..
        #region ViewData  

        //To transfer one or two values to corresponding view, you can use view data
        public ActionResult Index(int? id, string item, double? price)
        {
            ViewData["id"] = id;
            ViewData["item"] = item;
            ViewData["price"] = price;
            return View();
        }

        public ActionResult Display1()
        {
            List<string> colors = new List<string>() { "red", "blue", "green", "violet", "orange" };
            ViewData["colors"] = colors;
            return View();
        }
        #endregion

        #region ViewBag

        //To transfer one or two values to corresponding view and also acheive type safety, you can use view data
        public ActionResult Index1(int? id, string item, double? price)
        {
            ViewBag.id = id;
            ViewBag.item = item;
            ViewBag.price = price;
            return View();
        }

        public ActionResult Display2()
        {
            List<string> colors = new List<string>() { "red", "blue", "green", "violet", "orange" };
            ViewBag.colors = colors;
            return View();
        }
        #endregion

        #region TempData

        //If you want to transfer data between multiple requests, use temdata.
        public RedirectToRouteResult Index2(int? id, string item, double? price)
        {
            TempData["id"] = id;
            TempData["item"] = item;
            TempData["price"] = price;
            return RedirectToAction("Index3");
        }

        public ViewResult Index3()
        {
            return View();
        }

        public RedirectToRouteResult Index4(int? id, string item, double? price)
        {
            TempData["id"] = id;
            TempData["item"] = item;
            TempData["price"] = price;
            return RedirectToAction("Index1", "Test");
        }
        #endregion

        #region Cookies

        //Want to store data on clients pc for easy login, use cookies.
        public ViewResult Index5(int? id, string item, double price)
        {
            HttpCookie cookie = new HttpCookie("Product Cookie");
            cookie["id"] = id.ToString();
            cookie["item"] = item;
            cookie["price"] = price.ToString();
            cookie.Expires = DateTime.Now.AddMonths(6);
            return View();
        }

        public ViewResult Display3()
        {
            return View();
        }
        #endregion

        #region Sessions

        //If you want these values to be accessible in al pages for this user use sessions
        public RedirectToRouteResult Index6(int? id, string item, double? price)
        {
            Session["id"] = id;
            Session["item"] = item;
            Session["price"] = price;
            return RedirectToAction("Display4");
        }

        public ViewResult Display4()
        {
            return View();
        }
        #endregion

        #region Application

        //want to store the values which can be accessible for all users, use application
        public ViewResult Index7(int? id, string item, double? price)
        {
            System.Web.HttpContext.Current.Application.Lock();
            System.Web.HttpContext.Current.Application["id"] = id;
            System.Web.HttpContext.Current.Application["item"] = item;
            System.Web.HttpContext.Current.Application["price"] = price;
            System.Web.HttpContext.Current.Application.UnLock();

            return View();
        }

        public ViewResult Display5()
        {
            return View();
        }

        #endregion

        #region Anonymous Types

        //Want to send bulk data temporarily to all the next pages, use anonymous types.

        public ViewResult Index8(int? id, string item, double? price)
        {
            //you can write this way or below code.
            //var product = new { id = id, item = item, price = price };
            //return View(product);

            return View(new { id = id, item = item, price = price });
        }

        public ViewResult Index9(int? id, string item, double? price)
        {
            var product = new { id = id, item = item, price = price };
            return View(product);
        }

        public RedirectToRouteResult Index10(int? id, string item, double? price)
        {
            //you can use dynamic instead of var

            dynamic product = new { id = id, item = item, price = price };
            return RedirectToAction("Display2", "Test", product);
        }

        #endregion

        #region Model

        //want to send data to all pages and also acheive type safety, name convention, intellisense, use Models.
        public ViewResult Index11(int? id, string item, double? price)
        {
            //Product p = new Product { id = id, item = item, price = price };
            //return View(p);

            var p = new Product { id = id, item = item, price = price };
            return View(p);
        }

        //Simlpified version,, use this

        public ViewResult Index12(Product p)
        {
            return View(p);
        }

        public RedirectToRouteResult Index13(Product p)
        {
            return RedirectToAction("Index3","Test",p);
        }

        #endregion

    }
}