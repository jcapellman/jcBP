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
        public ReturnSet<List<PostListingResponseItem>> GET(int pageSize, int? pageNumber = null) => new PostListingManager().GetPostListing(pageSize, pageNumber);        
        
        [HttpGet]
        public ReturnSet<PostResponseItem> GET(int year, int month, int day, string posturl) => new PostManager().GetPost(year, month, day, posturl);

        [HttpPut]
        public ReturnSet<bool> PUT(PostCreationRequestItem requestItem) => new PostManager().AddPost(requestItem);
    }
}