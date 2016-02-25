using System.Threading.Tasks;

using jcMSA.Common.PCL;
using jcMSA.Common.PCL.Enums;
using jcMSA.Common.PCL.PlatformAbstractions;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Posts.PCL.Transports;

namespace jcMSA.Posts.PCL.Handlers {
    public class ContentPostHandler :BaseHandler {
        public ContentPostHandler(string webAPIURL, IBaseCachePa cacheInterface) : base(webAPIURL, "ContentPost", cacheInterface) { }

        public async Task<ReturnSet<ContentResponseItem>> GetContentPost(string postname) => await GET<ReturnSet<ContentResponseItem>>($"postname={postname}", CacheItems.CONTENTPOST_SINGLE);
    }
}