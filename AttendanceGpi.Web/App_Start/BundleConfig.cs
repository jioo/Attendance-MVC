using System.Web;
using System.Web.Optimization;

namespace AttendanceGpi.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate.unobtrusive.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js",
                        "~/Scripts/DataTables/dataTables.responsive.js",
                        "~/Scripts/nprogress.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/picker").Include(
                        "~/Scripts/moment.js",
                        "~/Scripts/bootstrap-datetimepicker.js",
                        "~/Scripts/daterangepicker.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/particle").Include(
                        "~/Scripts/clock.js",
                        "~/Scripts/particle.js",
                        "~/Scripts/script-particle.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-clockpicker.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-clockpicker.min.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/DataTables/css/responsive.bootstrap.css",
                      "~/Content/daterangepicker.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/responsive.css",
                      "~/Content/font-awesome.css",
                      "~/Content/nprogress.css",
                      "~/Content/toastr.css",
                      "~/Content/custom.css"));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
