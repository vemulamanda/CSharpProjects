using AspMvcCoreAppTagHelpersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspMvcCoreAppTagHelpersExample.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Login(LoginModel Login)
        {
            return View(Login);
        }

        //Below code is example of how to use asp-route tag helper method
        [Route("/Account/TestLogin", Name="LoginTesting")]
        public ViewResult TestLogin()
        {
            return View();

            //Now check the code in the Login.cshtml view.
        }

        public ViewResult Registration()
        {
            return View();
        }
    }
}
