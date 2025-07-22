using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace AspNetCoreMvcFirstProject.Controllers
{
    //This is defining route action method level.
    /*  public class HomeController : Controller
      {

          [Route("")]                 //define this kind of attribute route and on browser call "https://localhost:port", it will launch home controller and index page.
          //[Route("Home")]           //define this kind of attribute route and on browser call "https://localhost:port/Home", it will launch home controller and index page.
          //[Route("Home/Index")]     //define this kind of attribute route and on browser call "https://localhost:port/Home/Index", it will launch home controller and index page.

          //[Route("Test")] We can use alias name for action method like this.
          public IActionResult Index()
          {
              return View();
          }
      }  */



    // ==========================================================================================================


    /*
        //This is defining route controller level.

        [Route("Home")]     //you can define on top of controller like this, this will launch https://localhost:port/Home/Index, But under on action methos 
        //you hav to define differently. see below,
        public class HomeController : Controller
        {
            //all these 3 routes below should be defined when you define route on the controller level.
            [Route("/")]     
            [Route("")]         
            [Route("Index")] 

            //[Route("Test")] We can use alias name for action method like this.
            public IActionResult Index()
            {
                return View();
            }
        }
    */



    // ==========================================================================================================

    /*
        //This is defining route controller level.

        [Route("Test")]     // We can use alias name for action method like this.
        public class HomeController : Controller
        {
            //all these 3 routes below should be defined when you define route on the controller level.
            [Route("/")]
            [Route("")]
            [Route("Demo")]     // We can use alias name for action method like this.
            public IActionResult Index()
            {
                return View();
            }
        }
    */



    // ==========================================================================================================

    /*
    //This is defining route controller level.

    [Route("[Controller]")]     // We can just use controller like this also, this will call Home controller becoz we route it above Home controller.
    public class HomeController : Controller
    {
        //all these 3 routes below should be defined when you define route on the controller level.
        [Route("/")]
        [Route("")]
        [Route("[Action]")]     // We can also use on top of action method like this. This will call index action method.
        public IActionResult Index()
        {
            return View();
        }
    }  */



    // ==========================================================================================================
    /*
        //We can write like this also:

        //This is defining route controller level.

        [Route("[controller]/[action]")]  
        public class HomeController : Controller
        {
            //all these 3 routes below should be defined when you define route on the controller level.
            [Route("/")]        //https://localhost:port
            [Route("/Home")]    //https://localhost:port/Home
            [Route("")]         //https://localhost:port/Home/Index
            public IActionResult Index()
            {
                return View();
            }
            //You can write in different ways, try according to your scenario.
        }
    */



    // ==========================================================================================================


    //How to apply constraints on routes. This will make user to pass the correct values to route.
    [Route("[Controller]")]
    public class HomeController: Controller
    {
        [Route("Display1/{Id:int?}")]        //This part will make the end user to pass integre value only. if any other type is passed he gets error page.
        public string Display1(int Id)
        {
            return "The Interger value passed is: " + Id;
        }

        [Route("Display2/{num:double?}")]
        public double Display2(double num)
        {
            return num;
        }

        //In this way you can apply constraints for all types. please check asp.net mvc core class notes..
    }
}
