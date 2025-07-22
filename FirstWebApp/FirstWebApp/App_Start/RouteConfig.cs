using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ParamsRoute",
                url: "{controller}/{action}/{id}/{name}",
                defaults: new { controller = "Params", action = "Index1", id = UrlParameter.Optional, name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "StudentRoute",
                url: "Programmed/Test",
                defaults: new { controller = "Test", action = "Esw", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "Programmed/{controller}/{action}/{id}",
                defaults: new { controller = "Demo", action = "Esw", id = UrlParameter.Optional }
            );
        }
    }
}
