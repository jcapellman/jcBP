using System.Web.Http;

using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Common.WebAPI;
using jcMSA.Posts.BusinessLogic.Managers;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.WebAPI.Controllers {
    public class ContentPostController : BaseController {
        [HttpGet]
        public ReturnSet<ContentResponseItem> GET(string postname) => new ContentPostManager().GetContentPost(postname);
    }
}