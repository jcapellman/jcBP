using System.Configuration;

namespace jcMSA.Client.MVC.Helpers {
    public static class RazorHelper {
        public static string URL => ConfigurationManager.AppSettings["BASE_URL"];

        public static string SITE_NAME => ConfigurationManager.AppSettings["SITE_NAME"];
    }
}