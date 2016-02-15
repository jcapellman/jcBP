using System.Configuration;

namespace jcMSA.Client.MVC.Helpers {
    public static class SiteConfig {
        public static string SITE_URL => ConfigurationManager.AppSettings["SITE_URL"];

        public static string SITE_NAME => ConfigurationManager.AppSettings["SITE_NAME"];

        public static string SITE_FOOTER => ConfigurationManager.AppSettings["SITE_FOOTER"];

        public static string BASECONTENT_WEBAPI => ConfigurationManager.AppSettings["BASECONTENT_WEBAPI"];

        public static string POSTS_WEBAPI => ConfigurationManager.AppSettings["POSTS_WEBAPI"];
    }
}