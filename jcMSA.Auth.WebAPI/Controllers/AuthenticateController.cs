using System.Threading.Tasks;

using jcMSA.Auth.BusinessLogic.Managers;
using jcMSA.Auth.PCL.Transports;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Common.WebAPI;

namespace jcMSA.Auth.WebAPI.Controllers {
    public class AuthenticateController : BaseController {
        public async Task<ReturnSet<AuthenticationResponseItem>> GET(AuthenticationRequestItem requestItem) {
            return await new AuthenticationManager().AttemptLogin(requestItem);
        }
    }
}