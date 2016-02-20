using System.Web.Mvc;

namespace jcMSA.Client.MVC.Controllers {
    public class ErrorController : Controller {
        public ActionResult NotFound() {
            ViewBag.Exception = $"That page or document does not exist anymore.";
            Response.TrySkipIisCustomErrors = true;

            return View("Index");
        }
    }
}