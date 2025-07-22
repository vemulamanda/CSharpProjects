using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcCoreFarmProject.Controllers
{
    public class ErrorController : Controller
    {
        [Route("ClientError/{StatusCode}")]
        public ViewResult ClientErrorHandler(int StatusCode)
        {
            switch (StatusCode)
            {
                case 400:
                    ViewBag.ErrorTitle = "Bad Request";
                    ViewBag.ErrorMessage = "The server cant return response due to error on clients end";
                    break;
                case 401:
                    ViewBag.ErrorTitle = "UnAuthorized and autorization required.";
                    ViewBag.ErrorMessage = "Returned by server when the targer resource lacks authentication credentials.";
                    break;
                case 402:
                    ViewBag.ErrorTitle = "Payment required.";
                    ViewBag.ErrorMessage = "Payment is required defnitely..";
                    break;
                case 403:
                    ViewBag.ErrorTitle = "Forbidden.";
                    ViewBag.ErrorMessage = "You are attempting to access resource you dont have permissions to.";
                    break;
                case 404:
                    ViewBag.ErrorTitle = "Not Found.";
                    ViewBag.ErrorMessage = "The requested resource doesnt exist and server doesnt know if it ever existed.";
                    break;
                case 405:
                    ViewBag.ErrorTitle = "Method Not Allowed.";
                    ViewBag.ErrorMessage = "You are attempting to access method you are trying to access.";
                    break;
                default:
                    ViewBag.ErrorTitle = "Client errro occured.";
                    ViewBag.ErrorMessage = "There is a error in client sending the request. This is error possibly from client side";
                    break;
            }

            return View("ClientErrorView");
        }

        [Route("ServerError")]
        public ViewResult ServerErrorHandler()
        {
            var ExceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ErrorTitle = ExceptionDetails.Error.GetType().Name;
            ViewBag.Path = ExceptionDetails.Path;
            ViewBag.ErrorMessage = ExceptionDetails.Error.Message;

            return View("ServerErrorView");
        }
    }
}
