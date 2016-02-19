using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace jcMSA.Client.MVC {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e) {
            var exception = Server.GetLastError();
            Response.Clear();
            
            Server.ClearError();
                
            Response.Redirect($"~/Error/{HttpServerUtility.UrlTokenEncode(Helpers.Encryption.Encrypt(exception.ToString()))}", true);
        }
    }
}