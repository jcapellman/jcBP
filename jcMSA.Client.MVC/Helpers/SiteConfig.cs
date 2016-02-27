using System;
using System.Configuration;

namespace jcMSA.Client.MVC.Helpers {
    public static class SiteConfig {
        public static string SITE_URL => ConfigurationManager.AppSettings["SITE_URL"];

        public static string SITE_NAME => ConfigurationManager.AppSettings["SITE_NAME"];

        public static int SITE_POST_PAGE_SIZE => Convert.ToInt32(ConfigurationManager.AppSettings["SITE_POST_PAGE_SIZE"]);

        public static string SITE_FOOTER => ConfigurationManager.AppSettings["SITE_FOOTER"];

        public static string BASECONTENT_WEBAPI_ADDRESS => ConfigurationManager.AppSettings["BASECONTENT_WEBAPI_ADDRESS"];

        public static string POSTS_WEBAPI_ADDRESS => ConfigurationManager.AppSettings["POSTS_WEBAPI_ADDRESS"];
    }
}