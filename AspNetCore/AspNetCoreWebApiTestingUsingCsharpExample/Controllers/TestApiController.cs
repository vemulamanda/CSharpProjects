using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebApiTestingUsingCsharpExample.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace AspNetCoreWebApiTestingUsingCsharpExample.Controllers
{
    public class TestApiController : Controller
    {
        HttpClient client = new HttpClient();
        string serviceUri = "http://localhost/AspNetCoreWebApiExample/api/";

        public async Task<IActionResult> DisplayCustomers()
        {
            List<Customer> customers = new List<Customer>();
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.GetAsync("Customer");
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customer>>(result);  
            }
            return View(customers);
        }

        public async Task<IActionResult> DisplayCustomer(int Custid)
        {
            Customer customer = new Customer();
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.GetAsync("Customer/" +  Custid);
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
            }
            return View(customer);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.PostAsJsonAsync("Customer", customer);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("DisplayCustomers");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditCustomer()
        {
            return View();
        }
        public async Task<IActionResult> UpdateCuatomer(Customer customer)
        {
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.PutAsJsonAsync("Customer", customer);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("DisplayCustomers");
            }
            else
            {
                return View("EditCustomer");
            }
        }

        public async Task<IActionResult> DeleteCustomer(int custid)
        {
            client.BaseAddress = new Uri(serviceUri);
            HttpResponseMessage response = await client.DeleteAsync("Customer/" + custid);
            if(response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Delete action resulted in error");
            }
                return RedirectToAction("DisplayCustomers");
        }

    }
}
