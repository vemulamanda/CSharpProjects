using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using SudApi.Models;
using System.IdentityModel.Tokens.Jwt;
//using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Security.Claims;
using System.Text;
using System.Net;
using AspNetCoreMvc_FinalProject.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration _config;
        public string message;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration _config)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._config = _config;
        }

        #region Verify Email if not verified.
        [HttpPost("useremailverification")]
        public async Task<object> UserEmailVerification([FromForm] string email)
        {
            var CheckuserWithEmail = await userManager.FindByEmailAsync(email);

            if (CheckuserWithEmail != null)
            {              
                var code = await userManager.GenerateUserTokenAsync(CheckuserWithEmail, "SixDigit", "EmailConfirmation");

                var ConfirmationTokenLink = new { UserId = CheckuserWithEmail.Id, Token = code };
                SendMail(CheckuserWithEmail, ConfirmationTokenLink.UserId, ConfirmationTokenLink.Token, "Token Confirmation Link");

                //This below block is creating a record in aspnetuserstoken table in identity database..
                await userManager.SetAuthenticationTokenAsync(CheckuserWithEmail, "SixDigit", "EmailConfirmation", code);

                //return Ok(identityuser.Id);
                return Ok(new { userid = CheckuserWithEmail.Id, message = "Details Registered." });
            }
            else
            {
                return BadRequest("Email Adress not found in database. Please register again.");
            }
        }

        #endregion

        #region Register

        [HttpPost("register")]
        public async Task<object> Register([FromForm] UserModel userModel)
        {
            var Check_Email = await userManager.FindByEmailAsync(userModel.Email);

            if (Check_Email == null)
            {
                if (ModelState.IsValid)
                {
                    IdentityUser identityuser = new IdentityUser
                    {
                        UserName = userModel.Username,
                        Email = userModel.Email,
                        PhoneNumber = userModel.Mobile
                    };

                    var result = await userManager.CreateAsync(identityuser, userModel.Password);
                    if (result.Succeeded)
                    {
                        //await signInManager.SignInAsync(identityuser, false);  not needed

                        var code = await userManager.GenerateUserTokenAsync(identityuser, "SixDigit", "EmailConfirmation");

                        //var token = await userManager.GenerateEmailConfirmationTokenAsync(identityuser);
                        //var ConfirmationUrlLink = Url.Action("ConfirmEmail", "Account", new { UserId = identityuser.Id, Token = code }, Request.Scheme);
                        var ConfirmationTokenLink = new { UserId = identityuser.Id, Token = code };
                        SendMail(identityuser, ConfirmationTokenLink.UserId, ConfirmationTokenLink.Token, "Token Confirmation Link");

                        //This below block is creating a record in aspnetuserstoken table in identity database..
                        await userManager.SetAuthenticationTokenAsync(identityuser, "SixDigit", "EmailConfirmation", code);

                        //return Ok(identityuser.Id);
                        return Ok(new { userid = identityuser.Id, message = "Details Registered."});

                    } 
                    else
                    {
                        string error_msg = "";

                        foreach (var error in result.Errors)
                        {
                            error_msg += error.Description;
                        }

                        return BadRequest(new { error_msg });
                    }
                }

                else
                {
                    string error_msg = "";

                    foreach (var error in ModelState)
                    {
                        error_msg += error.Key;
                    }

                    return BadRequest(new { error_msg });
                }
            }
            else
            {
                return BadRequest(new { error_msg = "Email Address already registered. Please use another Email address." });
            }
        }
   
        #endregion

        #region Mailing code

        private void SendMail(IdentityUser identityUser, string userId, string token, string EmailSubject)
        {
            StringBuilder mailbody = new StringBuilder();
            mailbody.Append("Hello " + identityUser.UserName + "<br/><br/>");

            if (EmailSubject == "Token Confirmation Link")
            {
                mailbody.Append("Please use token to confirm your email.");
            }
            else if (EmailSubject == "Change Password Token")
            {
                mailbody.Append("Please use token to reset your password.");
            }
            mailbody.Append("<br/><br/>");
            mailbody.Append($"<h1> {token} </h1>");
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
            smtpclient.Authenticate("sudheerkumar.v3@gmail.com", "eoxm aiun qukn wjgo");
            smtpclient.Send(mailmessage);
        }

        #endregion

        #region Confirm Email

        [HttpPost("confirmemail")]
        public async Task<object> ConfirmEmail([FromForm] string userId, [FromForm] string SubmittedToken)
        {
            if (userId != null && SubmittedToken != null)
            {
                var TokenConfirmingUser = await userManager.FindByIdAsync(userId);
                if (TokenConfirmingUser != null)
                {
                    //var result = await userManager.ConfirmEmailAsync(user, token);
                    //var result = await userManager.VerifyUserTokenAsync(user, "SixDigit", "EmailConfirmation", token);
                    var StoredUserToken = await userManager.GetAuthenticationTokenAsync(TokenConfirmingUser, "SixDigit", "EmailConfirmation");

                    //if (result.Succeeded)
                    if(StoredUserToken == SubmittedToken)
                    {
                        TokenConfirmingUser.EmailConfirmed = true;
                        await userManager.UpdateAsync(TokenConfirmingUser);

                        await userManager.RemoveAuthenticationTokenAsync(TokenConfirmingUser, "SixDigit", "EmailConfirmation");

                        return $"Hi {TokenConfirmingUser}. Registration Successful. Thank You. \n\nPlease login now with registered username and password.";
                    }
                    else
                    {
                        /* StringBuilder Errors = new StringBuilder();
                         foreach (var error in result.Errors)
                         {
                             Errors.Append(error.Description + ".");
                         }

                         return BadRequest("Confirmation Email Failure." + Errors.ToString());
                        */
                        return BadRequest("Invalid or expired confirmation code.");
                    }
                }
                else
                {
                    return BadRequest("Invalid user ID. User Id doesnt exist in database or link is invalid.");
                }
            }
            else
            {
                return BadRequest("Invalid user or Token is invalid or expired..");
            }
        }
        #endregion

        #region Login

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user?.UserName != null)
            {
                if (await userManager.IsEmailConfirmedAsync(user))
                {
                    if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                    {
                        // ✅ Use config to get JWT signing info
                        var token = GenerateJwtToken(user);
                        return Ok(new { Token = token, Identity = model.Username, UserId = user.Id });
                    }

                    return Unauthorized("Username or Password is Incorrect");
                }
                else
                {
                    return BadRequest("Email registration not completed.");
                }
            }
            else
            {
                return BadRequest("Username not found or Incorrect.");
            }      
        }


        private string GenerateJwtToken(IdentityUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, user.UserName) },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        #endregion

        #region Forgot Password

        [HttpPost("forgotpassword")]
        public async Task<object> ForgotPassword([FromForm] ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    if (await userManager.IsEmailConfirmedAsync(user))
                    {
                        var code = await userManager.GenerateUserTokenAsync(user, "SixDigit", "ResetPassword");
                        var confirmationTokenLink = new { userId = user.Id, Token = code };
                        SendMail(user, confirmationTokenLink.userId, confirmationTokenLink.Token, "Change Password Token");

                        //This below block is creating a record in aspnetuserstoken table in identity database..
                        await userManager.SetAuthenticationTokenAsync(user, "SixDigit", "ResetPassword", code);

                        return Ok(new { userid = user.Id, message = "Details Registered." });
                    }
                    else
                    {
                        return BadRequest(new { error_msg = "OTP generation failed. Email you entered is wrong or not verified." });
                    }
                }
                else
                {
                    return BadRequest(new { error_msg = "Email you entered is not found. Please register if not registered." });
                }
            }
            else
            {                
                return BadRequest("Please enter valid Email Address.");
            }
        }

        #endregion

        /* #region Confirm Reset Password Token
         [HttpPost("verifyresetpasswordtoken")]
         public async Task<object> VerifyResetPasswordToken([FromForm] string userId, [FromForm] string SubmittedToken)
         {
             if (userId != null && SubmittedToken != null)
             {
                 var TokenConfirmingUser = await userManager.FindByIdAsync(userId);
                 if (TokenConfirmingUser != null)
                 {
                     //var result = await userManager.ConfirmEmailAsync(user, token);
                     //var result = await userManager.VerifyUserTokenAsync(user, "SixDigit", "EmailConfirmation", token);
                     var StoredUserToken = await userManager.GetAuthenticationTokenAsync(TokenConfirmingUser, "SixDigit", "ResetPassword");

                     //if (result.Succeeded)
                     if (StoredUserToken == SubmittedToken)
                     {
                         //TokenConfirmingUser.EmailConfirmed = true;
                         //await userManager.UpdateAsync(TokenConfirmingUser);

                         //await userManager.RemoveAuthenticationTokenAsync(TokenConfirmingUser, "SixDigit", "EmailConfirmation");

                         //return new { userId = TokenConfirmingUser.Id, Token = StoredUserToken };
                         return Ok("OTP token matched successfully.");
                     }
                     else
                     {
                         return BadRequest("Invalid Token. Please re-enter the token sent to your registered Email Address");
                     }
                 }
                 else
                 {
                     return BadRequest("User not found. UserId is missing. Please re-enter registered email address.");
                 }
             }
             else
             {
                 return BadRequest("UserId or submitted token is missing. Please try again.");
             }
         }
         #endregion*/

        #region Confirm Token and Change Password

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromForm] ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { error_msg = "Password can have only alphabets and numbers and minimum 5 characters length and NO spaces" });

            var user = await userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return BadRequest(new { error_msg = "User does not exist." });

            var StoredUserToken = await userManager.GetAuthenticationTokenAsync(user, "SixDigit", "ResetPassword");

            if (StoredUserToken != model.SubmittedToken)
                return BadRequest(new { error_msg = "OTP Invalid. Please enter the correct OTP sent to your registered email." });

            await userManager.RemovePasswordAsync(user);
            await userManager.AddPasswordAsync(user, model.Password);

            await userManager.RemoveAuthenticationTokenAsync(user, "SixDigit", "ResetPassword");          

            return Ok("Your password has been reset successfully. Please login with new password.");
        }

        #endregion

        #region Delete user Account

        [HttpDelete("deleteaccount/{userguid}")]
        public async Task<IActionResult> DeleteAccount(string userguid)
        {
            var DeletingUser = await userManager.FindByIdAsync(userguid);

            if(DeletingUser == null)
                return BadRequest(new { error_msg = "User does not exist." });

            var DeletedUser = await userManager.DeleteAsync(DeletingUser);

            if(DeletedUser.Succeeded)
            {
                return Ok("User Account removed Successfully.");
            }
            else
            {
                return BadRequest(new { errors = DeletedUser.Errors });
            }
        }

        #endregion
    }
}

