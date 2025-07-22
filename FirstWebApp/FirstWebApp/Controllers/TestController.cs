using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebApp.Controllers
{
    public class TestController : Controller
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