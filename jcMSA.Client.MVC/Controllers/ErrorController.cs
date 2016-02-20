using System.Web;
using System.Web.Mvc;

namespace jcMSA.Client.MVC.Controllers {
    [RoutePrefix("Error")] 
    [Route("{action = Index}")] 
    public class ErrorController : Controller {
        [Route("Error/{errorString}")]
        public ActionResult Index(string errorString) {
            var result = HttpServerUtility.UrlTokenDecode(errorString);
            
            return View(Helpers.Encryption.Decrypt(result));
        }
    }
}