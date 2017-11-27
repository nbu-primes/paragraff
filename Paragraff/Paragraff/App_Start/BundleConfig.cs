using System.Web;
using System.Web.Optimization;

namespace Paragraff
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/matrix-theme-js").Include(
                 "~/Content/MatrixTheme/js/bootstrap*",
                 "~/Content/MatrixTheme/js/excanvas*",
                 "~/Content/MatrixTheme/js/fullcalendar*",
                 "~/Content/MatrixTheme/js/jquery*",
                 "~/Content/MatrixTheme/js/masked*",
                 "~/Content/MatrixTheme/js/matrix*",
                 "~/Content/MatrixTheme/js/select2*",
                 "~/Content/MatrixTheme/js/wysihtml*"));

            bundles.Add(new StyleBundle("~/bundles/matrix-theme-css").Include(
                "~/Content/MatrixTheme/css/bootstrap*",
                "~/Content/MatrixTheme/css/font-awesome.css",
                "~/Content/MatrixTheme/css/fullcalendar.css",
                "~/Content/MatrixTheme/css/colorpicker.css",
                "~/Content/MatrixTheme/css/datepicker.css",
                "~/Content/MatrixTheme/css/jquery*",
                "~/Content/MatrixTheme/css/select2.css",
                "~/Content/MatrixTheme/css/uniform.css",
                "~/Content/MatrixTheme/css/matrix-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
