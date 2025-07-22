using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppUsing_AjaxWithDatabase.Models;

namespace MVCAppUsing_AjaxWithDatabase.Controllers
{
    public class ProductController : Controller
    {
        NorthWindEntities dc = new NorthWindEntities();
        public ActionResult DisplayProducts()
        {
            return View(dc.Products);
        }
        public ActionResult SearchProduct(string SearchItem)
        {
            List<Product> products = new List<Product>();
            if (SearchItem.Trim().Length == 0)
            {
                products = dc.Products.ToList();
            }
            else
            {
               products = dc.Products.Where(P => P.ProductName.Contains(SearchItem)).ToList();
            }
            return View("DisplayProducts", products);
        }

        public JsonResult GetProducts(string term)
        {
            List<string> products = dc.Products.Where(P => P.ProductName.StartsWith(term)).Select(P => P.ProductName).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}