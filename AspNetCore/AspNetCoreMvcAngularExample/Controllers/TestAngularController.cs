using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcAngularExample.Controllers
{
    public class TestAngularController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
