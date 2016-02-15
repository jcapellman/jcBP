using System.Configuration;

namespace jcMSA.Client.MVC.Helpers {
    public static class RazorHelper {
        public static string SITE_URL => ConfigurationManager.AppSettings["SITE_URL"];

        public static string SITE_NAME => ConfigurationManager.AppSettings["SITE_NAME"];

        public static string SITE_FOOTER => ConfigurationManager.AppSettings["SITE_FOOTER"];
    }
}