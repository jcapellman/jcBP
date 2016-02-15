using System.Threading.Tasks;

using jcMSA.BaseContent.PCL.Transports;
using jcMSA.Common.PCL;
using jcMSA.Common.PCL.Transports.Container;

namespace jcMSA.BaseContent.PCL.Handlers {
    public class GlobalContentHandler : BaseHandler {
        public GlobalContentHandler(string webAPIURL) : base(webAPIURL, "Content") { }

        public async Task<ReturnSet<GlobalContentResponseItem>> GetGlobalContent() {
            return await GET<ReturnSet<GlobalContentResponseItem>>(string.Empty);
        } 
    }
}