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
               "~/Content/MatrixTheme/js/excanvas.js",
               "~/Content/MatrixTheme/js/bootstrap.js",
               "~/Content/MatrixTheme/js/jquery.js",
               "~/Content/MatrixTheme/js/jquery.ui.custom.js",
               "~/Content/MatrixTheme/js/jquery.flot.js",
               "~/Content/MatrixTheme/js/jquery.flot.resize.js",
               "~/Content/MatrixTheme/js/jquery.peity.js",
               "~/Content/MatrixTheme/js/fullcalendar.js",
               "~/Content/MatrixTheme/js/matrix.js",
               "~/Content/MatrixTheme/js/matrix.dashboard.js",
               "~/Content/MatrixTheme/js/jquery.gritter.js",
               "~/Content/MatrixTheme/js/matrix.interface.js",
               "~/Content/MatrixTheme/js/matrix.chat.js",
               "~/Content/MatrixTheme/js/matrix.form_validation.js",
               "~/Content/MatrixTheme/js/jquery.wizard.js",
               "~/Content/MatrixTheme/js/jquery.uniform.js",
               "~/Content/MatrixTheme/js/select2.js",
               "~/Content/MatrixTheme/js/matrix.popover.js",
               "~/Content/MatrixTheme/js/jquery.dataTables.js",
               "~/Content/MatrixTheme/js/matrix.tables.js"));

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

            bundles.Add(new ScriptBundle("~/bundles/jquery-ajax").Include(
                       "~/Scripts/jquery.unobtrusive*"));

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
                      "~/Content/Site.css"));
        }
    }
}
