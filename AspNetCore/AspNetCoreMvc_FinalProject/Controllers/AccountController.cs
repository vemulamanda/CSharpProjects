using AspNetCoreMvc_FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;
using System.Security.Claims;

namespace AspNetCoreMvc_FinalProject.Controllers
{
    public class AccountController : Controller
    {
        //These are fields created to use in the constructor.
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        //This constructor is created to register the usermanager and signin manager.
        //These is kind of dependency injection. you dont nned to register usermanager and signin manager under program.cs because,
        //these are inbuilt registered. 
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #region Register 

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        //here we are passing usermodel we created, this should be made async to not block front end user pc.
        //async will run in background. 
        public async Task<IActionResult> Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = new IdentityUser
                {
                    UserName = userModel.Name,
                    Email = userModel.Email,
                    PhoneNumber = userModel.Mobile
                };
                //this part below is to create a user and password in database.
                var result = await userManager.CreateAsync(identityUser, userModel.Password);
                if(result.Succeeded)
                {
                    //this below part will sign in you to site using credentials.
                    //But below code will directly signin you into site without email confirmation.

                    //await signInManager.SignInAsync(identityUser, false);
                    //return RedirectToAction("Index", "Home");

                    //To send email confirmation token to user to confirm email and then sign in, write below code.
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                    var ConfirmationUrlLink = Url.Action("ConfirmEmail", "Account", new { UserId = identityUser.Id, Token = token }, Request.Scheme);
                    SendMail(identityUser, ConfirmationUrlLink, "Email Confirmation Link");

                    TempData["Title"] = "Email Confirmation Link";
                    TempData["Message"] = "A confirmation email link has been sent to your registered email address, Click on it to confirm..";
                    return View("DisplayMessages");
                }
                else
                {
                    //this part will send error detaoils to user if any errors occured.
                    string errorString = "";
                    foreach(var Error in result.Errors)
                    {
                        errorString += Error.Description + "<br/>";
                    }
                    //Displaying error details to user
                    ModelState.AddModelError("", errorString);
                }
            }
            
                return View(userModel);
        }
        #endregion
        #region Mailing code
        public void SendMail(IdentityUser identityUser, string requestLink, string EmailSubject)
        {
            StringBuilder mailbody = new StringBuilder();
            mailbody.Append("Hello" + identityUser.UserName + "<br/><br/>");

            if (EmailSubject == "Email Confirmation Link")
            {
                mailbody.Append("Click on below link to confirm your email.");
            }
            else if (EmailSubject == "Change Password Link")
            {
                mailbody.Append("Click on the below link to reset your password.");
            }
            mailbody.Append("<br/>");
            mailbody.Append(requestLink);
            mailbody.Append("<br/><br/>");
            mailbody.Append("Regards");
            mailbody.Append("<br/><br/>");
            mailbody.Append("Customer Support");

            BodyBuilder bodybuilder = new BodyBuilder();
            bodybuilder.HtmlBody = mailbody.ToString();

            MailboxAddress FromAddress = new MailboxAddress("Customer Support", "sudheerkumar.v3@gmail.com");
            MailboxAddress ToAddress = new MailboxAddress(identityUser.UserName, identityUser.Email);

            MimeMessage mailmessage = new MimeMessage();
            mailmessage.From.Add(FromAddress);
            mailmessage.To.Add(ToAddress);
            mailmessage.Subject = EmailSubject;
            mailmessage.Body = bodybuilder.ToMessageBody();

            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Connect("smtp.gmail.com", 465, true);
            //in below line of code the first parameter takes the "from" username and second parameter is password for that username.
            //To get this password you have to register your account in gmail first and gmail will provide you a password and you have to use that password here in 2nd parameter.
            //To register login to gmail -> click manage account -> and search for "app passwords" -> Enter your project name -> and click done and it will give you a password.
            //Now copy that password and paste it in the second parameter place below. This will send emails using this id and password from your app.
            smtpclient.Authenticate("sudheerkumar.v3@gmail.com", "kvvw qvkl fibs rmrb");
            smtpclient.Send(mailmessage);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId !=  null && token != null)
            {
                var user = await userManager.FindByIdAsync(userId);
                if(user != null)
                {
                    var result = await userManager.ConfirmEmailAsync(user, token);
                    if(result.Succeeded)
                    {
                        TempData["Title"] = "Registration succeded.";
                        TempData["Message"] = "Email confirmation complete. Please login to your application.";
                        return View("DisplayMessages");
                    }
                    else
                    {
                        StringBuilder Errors = new StringBuilder();
                        foreach(var error in result.Errors)
                        {
                            Errors.Append(error.Description + ".");
                        }
                        TempData["Title"] = "Confirmation Email Failure.";
                        TempData["Message"] = Errors.ToString();
                        return View("DisplayMessages");
                    }
                }
                else
                {
                    TempData["Title"] = "Invalid user ID.";
                    TempData["Message"] = "User Id doesnt exist in database or link is invalid.";
                    return View("DisplayMessages");
                }
            }
            else
            {
                TempData["Title"] = "Invalid email confirmation link.";
                TempData["Message"] = "Email confirmation link is invalid or expired.";
                return View("DisplayMessages");
            }
        }
        #endregion
        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(loginModel.Name);
                if(user != null && (await userManager.CheckPasswordAsync(user, loginModel.Password)) && user.EmailConfirmed == false)
                {
                    ModelState.AddModelError("", "Your Email is not confirmed.");
                    return View(loginModel);
                }

                var result = await signInManager.PasswordSignInAsync(loginModel.Name, loginModel.Password, loginModel.RememberMe, false);
                if(result.Succeeded)
                {
                    if(string.IsNullOrEmpty(loginModel.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(loginModel.ReturnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials");
                }
            }

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
        #region Password reset
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var User = await userManager.FindByNameAsync(model.Name);
                if (User != null && await userManager.IsEmailConfirmedAsync(User))
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(User);
                    var confirmationUrlLink = Url.Action("ChangePassword", "Account", new { UserId = User.Id, token = token }, Request.Scheme);
                    SendMail(User, confirmationUrlLink, "Change Password Link");
                    TempData["Title"] = "Change Password Link.";
                    TempData["Message"] = "Change password link has been sent to your mail, please click on it to reset your password..";
                    return View("DisplayMessages");
                }
                else
                {
                    TempData["Title"] = "Change password mail generation failed.";
                    TempData["Message"] = "Either user name you entered is wrong or email is not confirmed.";
                    return View("DisplayMessages");
                }
            }
            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var User = await userManager.FindByIdAsync(model.UserId);
                if(User != null)
                {
                    var result = await userManager.ResetPasswordAsync(User, model.Token, model.Password);
                    if(result.Succeeded)
                    {
                        TempData["Title"] = "Reset password Success..";
                        TempData["Message"] = "Your password has been reset successfully.";
                        return View("DisplayMessages");
                    }
                    else
                    {
                        foreach(var error in result.Errors)
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
        #region Open Authentication
        public IActionResult ExternalLogin(string Provider, string returnUrl)
        {
            //This below will create complete call back url which google will authenticate and redirect.
            var url = Url.Action("CallBack", "Account", new { ReturnUrl = returnUrl });
            //This will collect provider and url properties.
            var properties = signInManager.ConfigureExternalAuthenticationProperties(Provider, url);
            //This will connect to google for authentication and once signed in , you will be redirected to site again.
            return new ChallengeResult(Provider, properties);
        }

        //In the above you have mentioned "CallBack" which is our action method. so now it will return to this action method after authentication at third party provider.
        public async Task<IActionResult> CallBack(string returnUrl)
        {
            //The return Url you passed below comes from view as you metioned return url in view and passing it using asp-route-returnUrl
            if(string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = "~/";
            }

            LoginModel model = new LoginModel();
            //This below code will get all external login info. if it doesnt return anything it gives error.
            var info = await signInManager.GetExternalLoginInfoAsync();
            if(info == null)
            {
                ModelState.AddModelError("", "Error getting external login information.");
                return View("Login", model);
            }
            //below code tries to sign in using that external login info.
            //it fails if the user is signed in for first time or it logs in.
            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false, true);
            if(signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                //when user login is failed at "signinResult",
                //it come here and below code gets email from external info 
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if(email != null)
                {
                    //below code ,Using the external email it checks the database.
                    var user = await userManager.FindByEmailAsync(email);
                    if(user == null)
                    {
                        user = new IdentityUser
                        {
                            //This below code finds the values returned from external providers and is used for creation of record.
                            UserName = info.Principal.FindFirstValue(ClaimTypes.GivenName),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                            PhoneNumber = info.Principal.FindFirstValue(ClaimTypes.MobilePhone),
                        };
                        var identityResult = await userManager.CreateAsync(user);
                    }
                    //below code creates a record in "AspNetUsers"(normal users table) and "AspNetUsersLogins"(provider table) tables.
                    await userManager.AddLoginAsync(user, info);
                    //Below code will sign you in to app using these details
                    await signInManager.SignInAsync(user, false);
                    //below code will redirect your app to returnUrl .
                    return LocalRedirect(returnUrl);
                }
                TempData["Title"] = "Error";
                TempData["Message"] = "Email claim not received from third party provider.";
                return View("DisplayMessages");
            }
        }
        #endregion
    }
}
