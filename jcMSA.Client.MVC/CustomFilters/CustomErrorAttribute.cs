using System.Web.Mvc;

namespace jcMSA.Client.MVC.CustomFilters {
    public class CustomErrorAttribute : HandleErrorAttribute {
        protected virtual ActionResult CreateActionResult(ExceptionContext filterContext) {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            var result = new ViewResult {
                ViewName = "~/Views/Error/Index.cshtml",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
            };

            result.ViewBag.StatusCode = 500;
            result.ViewBag.Exception = filterContext.Exception;

            return result;
        }

        public override void OnException(ExceptionContext filterContext) {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled) {
                return;
            }
            
            filterContext.Result = CreateActionResult(filterContext);
            
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }

    }
}