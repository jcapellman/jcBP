using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using jcMSA.Client.MVC.Controllers;

namespace jcMSA.Client.MVC {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_EndRequest() {
            if (Context.Response.StatusCode != 404) {
                return;
            }

            Response.Clear();

            var routeData = new RouteData();
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = "NotFound";

            IController errorController = new ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }
    }
}