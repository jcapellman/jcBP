using System.Web.Optimization;

namespace jcMSA.Client.MVC {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-2.1.3.min.js").Include("~/Scripts/bootstrap.min.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.min.css",
            "~/Content/Site.css"));
        }
    }
}