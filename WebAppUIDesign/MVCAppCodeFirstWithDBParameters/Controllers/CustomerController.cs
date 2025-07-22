using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppCodeFirstWithDBParameters.Models;
using System.Data.Entity;

namespace MVCAppCodeFirstWithDBParameters.Controllers
{
    public class CustomerController : Controller
    {
        SupplierCustomerDB sc = new SupplierCustomerDB();
        public ViewResult GetCustomers()
        {
            sc.Configuration.LazyLoadingEnabled = true;
            var Customers = sc.Customers.ToList();

            return View(Customers);
        }

        public ViewResult GetCustomer(int CustomerId)
        {
            sc.Configuration.LazyLoadingEnabled = false;
            var customer = (sc.Customers.Include("Supplier").Where(C => C.Custid == CustomerId).Single());
            return View(customer);
        }

        [HttpGet]
        public ViewResult AddCustomer()
        {
            ViewBag.SupplierNames = new SelectList(sc.Suppliers, "Sid", "SupplierName");
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult AddCustomer(Customer customer)
        {
            sc.Customers.Add(customer);
            sc.SaveChanges();
            return RedirectToAction("GetCustomers");
        }

        public ViewResult EditCustomer(int CustomerId)
        {
            var customer = sc.Customers.Find(CustomerId);

            ViewBag.CustomerID = new SelectList(sc.Suppliers, "Sid", "SupplierName", customer.SupplierId);
         
            return View(customer);
        }

        public RedirectToRouteResult UpdateCustomer(Customer customer)
        {
            sc.Entry(customer).State = EntityState.Modified;
            sc.SaveChanges();
            return RedirectToAction("GetCustomers");
        }

        public RedirectToRouteResult DeleteCustomer(int customerId)
        {
            var customer = sc.Customers.Find(customerId);
            sc.Customers.Remove(customer);  
            sc.SaveChanges();

            return RedirectToAction("GetCustomers");
        }
    }
}