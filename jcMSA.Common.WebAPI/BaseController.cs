using System;
using System.Threading.Tasks;
using System.Web.Http;

using jcMSA.Common.PCL.Transports.Common;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Common.PCL.Transports.Internal;

namespace jcMSA.Common.WebAPI {
    public class BaseController : ApiController {
        private Guid GenerateTransactionID => Guid.NewGuid();

        public APIRequestWrapper APIWrapper => new APIRequestWrapper();

        public async Task<T> Return<T>(T value) where T : Task<ReturnSet<BaseResponse>> {
            var result = await value;

            result.ReturnValue.TransactionID = GenerateTransactionID;

            return value;
        }
    }
}