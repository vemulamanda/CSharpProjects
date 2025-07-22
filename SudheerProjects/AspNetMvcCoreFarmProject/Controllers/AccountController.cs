using AspNetMvcCoreFarmProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;
using System.Security.Claims;

namespace AspNetMvcCoreFarmProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel usermodel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityuser = new IdentityUser
                {
                    UserName = usermodel.Name,
                    Email = usermodel.Email,
                    PhoneNumber = usermodel.Mobile
                };
                var result = await userManager.CreateAsync(identityuser, usermodel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(identityuser, false);
                    return RedirectToAction("DisplayCustomers", "Farm");
                }
            }
            return View(usermodel);
        }
        #endregion 

        #region Login
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(loginModel.Name);

                if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
                {
                    // Successful login
                    var result = await signInManager.PasswordSignInAsync(loginModel.Name, loginModel.Password, loginModel.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if (string.IsNullOrEmpty(loginModel.ReturnUrl))
                            return RedirectToAction("DisplayCustomers", "Farm");
                        else
                            return LocalRedirect(loginModel.ReturnUrl);
                    }
                }

                // If credentials are wrong or sign-in failed
                ModelState.AddModelError("", "Invalid login credentials.");
            }

            // This returns the view with validation messages
            return View(loginModel);
        }

        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion

        #region Forgot Password
        [HttpGet]
        public ViewResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                var User = await userManager.FindByNameAsync(model.Name);

                if(User == null)
                {
                    TempData["Title"] = "Username is invalid.";
                    TempData["Message"] = "UserName you entered is not found.";
                    return View("DisplayMessages");
                }
                else
                {
                    return View("ChangePassword");
                }
            }
            return View(model);
        }
        #endregion

        #region Reset Password

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    var result = await userManager.HasPasswordAsync(user);
                    if (result)
                    {
                        var removeResult = await userManager.RemovePasswordAsync(user);
                        if(!removeResult.Succeeded)
                        {                            
                            ModelState.AddModelError("", "Failed to Reset password.. Please try again.");
                            return View(model);
                        }
                    }

                    var addResult = await userManager.AddPasswordAsync(user, model.Password);
                    if(addResult.Succeeded)
                    {
                        TempData["Title"] = "Reset password Success..";
                        TempData["Message"] = "Your password has been reset successfully.";
                        return View("DisplayMessages");
                    }
                    else
                    {
                        foreach (var error in addResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    TempData["Title"] = "Reset password Error..";
                    TempData["Message"] = "User name you entered doesnt exist in database.";
                    return View("DisplayMessages");
                }
            }
            return View(model);
        }
        #endregion
    }
}
