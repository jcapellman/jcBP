using System.Web;
using System.Web.Mvc;

namespace jcMSA.Client.MVC.Controllers {
    public class ErrorController : Controller {
        public ActionResult Index(string errorString)
        {
            var result = HttpServerUtility.UrlTokenDecode(errorString);


            return View(Helpers.Encryption.Decrypt(result));
        }
    }
}