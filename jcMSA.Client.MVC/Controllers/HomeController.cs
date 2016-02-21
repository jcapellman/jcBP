using System.Threading.Tasks;
using System.Web.Mvc;

using jcMSA.Client.MVC.CustomFilters;
using jcMSA.Client.MVC.Helpers;
using jcMSA.Posts.PCL.Handlers;

namespace jcMSA.Client.MVC.Controllers {
    [CustomError]
    public class HomeController : BaseController {
        public async Task<ActionResult> Index() {
            var postHandler = new PostsHandler(SiteConfig.POSTS_WEBAPI_ADDRESS, _webCache);

            var result = await postHandler.GetMainListing();

            if (!result.HasValue) {
                throw new jcBPWebException(result.Exception, result.ErrorCode);
            }

            return View(result.ReturnValue);
        }

        public async Task<ActionResult> SinglePost(int year, int month, int day, string postname) {
            var postHandler = new PostsHandler(SiteConfig.POSTS_WEBAPI_ADDRESS, _webCache);

            var result = await postHandler.GetPost(0);

            if (!result.HasValue) {
                throw new jcBPWebException(result.Exception, result.ErrorCode);
            }

            return View(result.ReturnValue);
        }
    }
}