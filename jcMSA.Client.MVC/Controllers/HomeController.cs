using System.Collections.Generic;
using System.Web.Mvc;

using jcMSA.Client.MVC.Helpers;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Client.MVC.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Title = RazorHelper.SITE_NAME;

            var model = new List<PostListingResponseItem>();
            
            return View(model);
        }
    }
}