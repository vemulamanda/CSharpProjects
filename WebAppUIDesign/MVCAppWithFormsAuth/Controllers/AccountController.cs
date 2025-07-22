using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppWithFormsAuth.Models;

namespace MVCAppWithFormsAuth.Controllers
{
    public class AccountController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationModel model)
        {
            //!ModelState is important keyword, which checks if all the validations are passed in one go.
            if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                User user = new User
                {
                    UserId = model.UserId,
                    Name = model.Name,
                    Password = model.Password,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    Status = true
                };
                dc.Users.Add(user);
                dc.SaveChanges();
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var user = from u in dc.Users where u.UserId == model.UserId && u.Password == model.Password && u.Status == true select u;
                if ((user.Count() == 0))
                {
                    ModelState.AddModelError("", "Invalid Credentials"); // This piece of code will display this error message in validation summary(view).
                    return View(model);
                }
                else
                {
                    Session["UserKey"] = Guid.NewGuid();
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}