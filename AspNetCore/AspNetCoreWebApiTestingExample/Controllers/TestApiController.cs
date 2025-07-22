using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApiTestingExample.Controllers
{
    public class TestApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
