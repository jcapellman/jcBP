using jcMSA.Common.PCL.Transports.Internal;

namespace jcMSA.Common.WebAPI {
    public class BaseManager {
        protected APIRequestWrapper RequestWrapper;

        public BaseManager(APIRequestWrapper requestWrapper) {
            RequestWrapper = requestWrapper;
        }
    }
}