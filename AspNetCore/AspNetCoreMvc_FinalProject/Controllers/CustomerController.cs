using AspNetCoreMvc_FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_FinalProject.Controllers
{
    [Authorize]  //This keyword will require everyone to log in when they want to access any methods inside controller..
    public class CustomerController : Controller
    {
        ICustomer dal;

        public CustomerController(ICustomer dal)
        {
            this.dal = dal;
        }

        [AllowAnonymous] //This keyword will allow this specific method without authorization
        // CustomerXmlDAL dal = new CustomerXmlDAL();
        public IActionResult DisplayCustomers()
        {
           return View(dal.Customers_Select());
        }
        [AllowAnonymous] //This keyword will allow this specific method without authorization
        public IActionResult DisplayCustomer(int Custid)
        {
            Customer customer = dal.Customer_Select(Custid);
            if(customer == null)
            {
                throw new Exception("The customer you selected is not available.");
            }
            else
            {
                return View(customer);
            }
            //return View(dal.Customer_Select(Custid));
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            dal.Customer_Insert(customer);
            return RedirectToAction("DisplayCustomers");
        }

        public IActionResult EditCustomer(int Custid)
        {
            return View(dal.Customer_Select(Custid));
        }

        public IActionResult UpdateCustomer(Customer customer)
        {
            dal.Customer_Update(customer);
            return RedirectToAction("DisplayCustomers");
        }

        public IActionResult DeleteCustomer(int Custid)
        {
            dal.Customer_Delete(Custid);
            return RedirectToAction("DisplayCustomers");
        }
    }
}
