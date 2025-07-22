using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppUIDesign.Models;

namespace WebAppUIDesign.Controllers
{
    public class CustomerController : Controller
    {
        public ViewResult DisplayCustomers()
        {
            Customer c1 = new Customer()
            {
                Custid = 1001,
                Name = "Sudheer",
                Account = "Savings",
                Balance = 12453.21,
                City = "Hyderabad",
                Status = true,
                Photo = "/Images/Baby01.jpg"
            };
            Customer c2 = new Customer()
            {
                Custid = 1002,
                Name = "Eswar",
                Account = "Savings",
                Balance = 124698.21,
                City = "Hyderabad",
                Status = true,
                Photo = "/Images/Baby02.jpg"
            };
            Customer c3 = new Customer()
            {
                Custid = 1003,
                Name = "Satyanarayana Raju",
                Account = "Savings",
                Balance = 12498553.21,
                City = "Gundugolanu",
                Status = true,
                Photo = "/Images/Baby03.jpg"
            };
            Customer c4 = new Customer()
            {
                Custid = 1004,
                Name = "Krishna Veni",
                Account = "Current",
                Balance = 89753.21,
                City = "Gundugolanu",
                Status = false,
                Photo = "/Images/Baby04.jpg"
            };            
            Customer c5 = new Customer()
            {
                Custid = 1005,
                Name = "Siri",
                Account = "Savings",
                Balance = 126553.21,
                City = "Kovvuru",
                Status = true,
                Photo = "/Images/Baby05.jpg"
            };            
            Customer c6 = new Customer()
            {
                Custid = 1006,
                Name = "Srija",
                Account = "Savings",
                Balance = 1248753.21,
                City = "Ravulapalem",
                Status = false,
                Photo = "/Images/Baby06.jpg"
            };

            List<Customer> Customers = new List<Customer> { c1, c2, c3, c4, c5, c6 };

            return View(Customers);
        }
    }
}