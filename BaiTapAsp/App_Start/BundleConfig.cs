using System.Web;
using System.Web.Optimization;

namespace BaiTapAsp
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Assets/Admin/vendor/jquery/jquery.min.js",
                "~/Assets/Admin/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Assets/Admin/vendor/jquery-easing/jquery.easing.min.js",
                "~/Assets/Admin/js/sb-admin-2.min.js",
                "~/Assets/Admin/vendor/datatables/jquery.dataTables.min.js",
                "~/Assets/Admin/vendor/datatables/dataTables.bootstrap4.min.js",
                "~/Scripts/select2.min.js",
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css",
                        "~/Assets/Admin/vendor/datatables/dataTables.bootstrap4.min.css",
                        "~/Content/select2.min.css",
                        "~/Content/datepicker.css"));

        }
    }
}
