using jcMSA.BaseContent.PCL.Transports;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Common.WebAPI;

namespace jcMSA.BaseContent.WebAPI.Controllers {
    public class ContentController : BaseController {
        public ReturnSet<GlobalContentResponseItem> GET() {
            return new ReturnSet<GlobalContentResponseItem>(null);
        }
    }
}