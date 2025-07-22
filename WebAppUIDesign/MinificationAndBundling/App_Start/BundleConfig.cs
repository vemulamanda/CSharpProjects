using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace MinificationAndBundling
{
    //The below commented code is created when we select MVC project directly using template.
    //But if we create a empty blank project we have to do bundling, we can do it as below or we can write as uncommented code below.
     public class BundleConfig
     {
        /*  // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
          public static void RegisterBundles(BundleCollection bundles)
          {
              bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                          "~/Scripts/jquery-{version}.js"));

              bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                          "~/Scripts/jquery.validate*"));

              // Use the development version of Modernizr to develop with and learn from. Then, when you're
              // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
              bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                          "~/Scripts/modernizr-*"));

              bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

              bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css"));
        }  */

        public static void RegisterBundles(BundleCollection Bundles)
        {
            StyleBundle Style_B = new StyleBundle("~/Content/CSS_Bundle");
            Style_B.Include("~/Content/Header.min.css", "~/Content/Paragraph.min.css");

            //ScriptBundle Scripts_B = new ScriptBundle("~/Scripts/JS_Bundle");
            //Scripts_B.Include("~/Scripts/File1.js", "~/Scripts/File2.js", "~/Scripts/File3.js");

            Bundles.Add(Style_B);
            //Bundles.Add(Scripts_B);

            //To work in debug mode, i.e to reduce the requests to the server, use below code:

            BundleTable.EnableOptimizations = true;
        }
    }
}
