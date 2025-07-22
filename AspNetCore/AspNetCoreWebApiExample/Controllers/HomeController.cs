using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApiExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
