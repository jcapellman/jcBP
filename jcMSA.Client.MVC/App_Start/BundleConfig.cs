using System.Web.Optimization;

namespace jcMSA.Client.MVC {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/skel.min.js").Include("~/Scripts/skel-panels.min.js").Include("~/Scripts/init.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.min.css",
            "~/Content/Site.css"));
        }
    }
}