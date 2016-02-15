using System.Collections.Generic;
using System.Threading.Tasks;

using jcMSA.Common.PCL;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.PCL.Handlers {
    public class PostsHandler : BaseHandler {
        public PostsHandler(string webAPIURL) : base(webAPIURL, "Posts") { }

        public async Task<ReturnSet<List<PostListingResponseItem>>> GetMainListing() { return await GET<ReturnSet<List<PostListingResponseItem>>>(string.Empty); }
    }
}