using System.Collections.Generic;
using System.Web.Mvc;

using jcMSA.Client.MVC.Helpers;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Client.MVC.Controllers {
    public class HomeController : BaseController {
        public ActionResult Index() {
            ViewBag.Title = SiteConfig.SITE_NAME;

            var model = new List<PostListingResponseItem>();
            
            return View(model);
        }
    }
}