using System.Collections.Generic;
using System.Web.Mvc;

using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Posts.BusinessLogic.Managers;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.WebAPI.Controllers {
    public class PostsController : Controller {
        public ReturnSet<List<PostListingResponseItem>> GET() {
            return new PostListingManager().GetPostListing();
        }
    }
}