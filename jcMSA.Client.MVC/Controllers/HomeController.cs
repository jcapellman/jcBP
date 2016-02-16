using System;
using System.Threading.Tasks;
using System.Web.Mvc;

using jcMSA.Client.MVC.Helpers;
using jcMSA.Client.MVC.PlatformImplementations;
using jcMSA.Posts.PCL.Handlers;

namespace jcMSA.Client.MVC.Controllers {
    public class HomeController : BaseController {
        public async Task<ActionResult> Index() {
            var postHandler = new PostsHandler(SiteConfig.POSTS_WEBAPI, new WebCachePI());

            var result = await postHandler.GetMainListing();

            if (!result.HasValue) {
                throw new Exception(result.Exception);
            }
            
            return View(result.ReturnValue);
        }
    }
}