using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    //Home is default controller, so in url if we dont mention /Home and just mention 
    //(i.e, http:localhost:port) this Home controller will be executed.

    {
        public string Index()  //Index is default method, so in url if we dont mention /Index and just mention controller
                               //name (i.e, http:localhost:port/controllername) this index method will be executed.
        {
            return "Hi Sudheer. This is from sud method.";
        }
        public string Esw()
        {
            return "Hi Eswar. This is from esw. method.";
        }
    }
}