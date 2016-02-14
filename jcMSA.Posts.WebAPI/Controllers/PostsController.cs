using System.Collections.Generic;
using System.Web.Mvc;

using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Common.WebAPI;
using jcMSA.Posts.BusinessLogic.Managers;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.WebAPI.Controllers {
    [Route("api/[controller]")]
    public class PostsController : BaseController {
        [HttpGet]
        public ReturnSet<List<PostListingResponseItem>> GET() {
            return new PostListingManager().GetPostListing();
        }
    }
}