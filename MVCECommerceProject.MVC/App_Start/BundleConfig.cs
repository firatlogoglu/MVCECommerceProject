using System.Web;
using System.Web.Optimization;

namespace MVCECommerceProject.MVC
{
    public class BundleConfig
    {
        // Paketleme hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkId=301862 adresini ziyaret edin
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Geliştirme yapmak ve öğrenmek için Modernizr'ın geliştirme sürümünü kullanın. Daha sonra,
            // üretim için hazır. https://modernizr.com adresinde derleme aracını kullanarak yalnızca ihtiyacınız olan testleri seçin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/Content/Sb_Admin").Include(
               "~/Content/Sb_Admin_2/vendor/jquery/jquery.min.js",
               "~/Content/Sb_Admin_2/vendor/bootstrap/js/bootstrap.bundle.min.js",
               "~/Content/Sb_Admin_2/vendor/jquery-easing/jquery.easing.min.js",
               "~/Content/Sb_Admin_2/js/sb-admin-2.min.js"));

            bundles.Add(new ScriptBundle("~/Content/Sb_Admin_2/vendor/datatables").Include(
               "~/Content/Sb_Admin_2/vendor/datatables/jquery.dataTables.min.js",
               "~/Content/Sb_Admin_2/vendor/datatables/dataTables.bootstrap4.min.js",
               "~/Content/Sb_Admin_2/js/demo/datatables-demo.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Sb_Admin_2").Include(
                "~/Content/myCSS.css",
                      "~/Content/Sb_Admin_2/vendor/fontawesome-free/css/all.min.css",
                      "~/Content/Sb_Admin_2/css/sb-admin-2.min.css"));

            bundles.Add(new StyleBundle("~/Content/Sb_Admin_2/vendor/datatablescss").Include(
          "~/Content/Sb_Admin_2/vendor/datatables/dataTables.bootstrap4.min.css"));
        }
    }
}