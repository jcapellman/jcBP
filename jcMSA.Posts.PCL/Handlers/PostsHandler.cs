using System.Collections.Generic;
using System.Threading.Tasks;

using jcMSA.Common.PCL;
using jcMSA.Common.PCL.Enums;
using jcMSA.Common.PCL.PlatformAbstractions;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.PCL.Handlers {
    public class PostsHandler : BaseHandler {
        public PostsHandler(string webAPIURL, IBaseCachePa cacheInterface) : base(webAPIURL, "Posts", cacheInterface) { }

        public async Task<ReturnSet<List<PostListingResponseItem>>> GetMainListing() { return await GET<ReturnSet<List<PostListingResponseItem>>>(string.Empty, CacheItems.POSTS_MAINLISTING); }

        public async Task<ReturnSet<PostResponseItem>> GetPost(int id) => await GET<ReturnSet<PostResponseItem>>($"id={id}", CacheItems.POSTS_SINGLE);

        public async Task<ReturnSet<PostResponseItem>> GetPost(int year, int month, int day, string postname) => await GET<ReturnSet<PostResponseItem>>($"year={year}&month={month}&day={day}&postname={postname}", CacheItems.POSTS_SINGLE);

        public async Task<ReturnSet<bool>> CreatePost(PostCreationRequestItem requestItem) => await PUT<PostCreationRequestItem, ReturnSet<bool>>(requestItem);
    }
}