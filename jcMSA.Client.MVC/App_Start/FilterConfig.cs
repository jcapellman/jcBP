using System.Web;
using System.Web.Mvc;

namespace jcMSA.Client.MVC {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
