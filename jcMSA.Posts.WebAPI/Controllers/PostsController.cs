using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Posts.PCL.Transports;
using Microsoft.AspNet.Mvc;

namespace jcMSA.Posts.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        [HttpGet]
        public ReturnSet<List<PostListingResponseItem>> GET() {
            return null;
        }
    }
}
