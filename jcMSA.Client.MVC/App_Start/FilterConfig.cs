using System.Web.Mvc;

using jcMSA.Client.MVC.CustomFilters;

namespace jcMSA.Client.MVC {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new CustomErrorAttribute());
        }
    }
}