using System.Web.Mvc;

using jcMSA.Common.WebAPI;

namespace jcMSA.BaseContent.WebAPI.Controllers {
    public class ContentController : BaseController {
        public ActionResult Index() {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}