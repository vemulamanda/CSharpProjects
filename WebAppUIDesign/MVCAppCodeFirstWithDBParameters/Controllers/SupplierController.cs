using MVCAppCodeFirstWithDBParameters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAppCodeFirstWithDBParameters.Controllers
{
    public class SupplierController : Controller
    {
        SupplierCustomerDB sc = new SupplierCustomerDB();
        public ViewResult GetSuppliers()
        {
            var suppliers = sc.Suppliers.ToList();
            return View(suppliers);
        }
        
        [HttpGet]
        public ViewResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddSupplier(Supplier supplier)
        {
            sc.Suppliers.Add(supplier);
            sc.SaveChanges();
            return RedirectToAction("GetSuppliers");
        }
    }
}