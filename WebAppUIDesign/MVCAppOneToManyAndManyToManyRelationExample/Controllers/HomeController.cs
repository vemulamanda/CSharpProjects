using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppOneToManyAndManyToManyRelationExample.Models;

namespace MVCAppOneToManyAndManyToManyRelationExample.Controllers
{
    public class HomeController : Controller
    {
        StoreDbContext dc = new StoreDbContext();
        public ActionResult Index()
        {
            Customer c1 = new Customer { CustomerId = 101, CustomerName = "Sudheer" };
            Customer c2 = new Customer { CustomerId = 102, CustomerName = "Eswar" };
            Customer c3 = new Customer { CustomerId = 103, CustomerName = "Siri" };
            Customer c4 = new Customer { CustomerId = 104, CustomerName = "Srija" };

            Product p1 = new Product { ProductId = 1001, ProductName = "Soap" };
            Product p2 = new Product { ProductId = 1002, ProductName = "Shampoo" };
            Product p3 = new Product { ProductId = 1003, ProductName = "Brush" };

            dc.Customers.Add(c1); dc.Customers.Add(c2); dc.Customers.Add(c3);
            dc.Products.Add(p1); dc.Products.Add(p2); dc.Products.Add(p3);

            dc.SaveChanges();

            return View();
        }
    }
}