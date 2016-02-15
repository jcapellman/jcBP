using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

using jcMSA.Client.MVC.Enums;
using jcMSA.Client.MVC.Helpers;
using jcMSA.Client.MVC.Managers;
using jcMSA.Posts.PCL.Handlers;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Client.MVC.Controllers {
    public class HomeController : BaseController {
        public async Task<ActionResult> Index() {
            if (CacheManager.CheckIfExists(CacheItems.POSTS_MAINLISTING)) {
                return View(CacheManager.Get<List<PostListingResponseItem>>(CacheItems.POSTS_MAINLISTING).ReturnValue);
            }

            var postHandler = new PostsHandler(SiteConfig.POSTS_WEBAPI);

            var result = await postHandler.GetMainListing();

            if (!result.HasValue) {
                throw new Exception(result.Exception);
            }
            
            CacheManager.Add(CacheItems.POSTS_MAINLISTING, result.ReturnValue);

            return View(result.ReturnValue);
        }
    }
}