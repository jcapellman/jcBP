﻿using System.Data.Entity;
using System.Threading.Tasks;

using jcMSA.Auth.DataLayer.Entities;
using jcMSA.Auth.PCL.Transports;
using jcMSA.Common.PCL.Enums;
using jcMSA.Common.PCL.Transports.Container;
using jcMSA.Common.PCL.Transports.Internal;
using jcMSA.Common.WebAPI;

namespace jcMSA.Auth.BusinessLogic.Managers {
    public class AuthenticationManager : BaseManager {
        public async Task<ReturnSet<AuthenticationResponseItem>> AttemptLogin(AuthenticationRequestItem requestItem) {
            using (var eFactory = new EFModel()) {
                var result =
                    await eFactory.Users.AnyAsync(
                        a => a.Username == requestItem.Username && a.Password == requestItem.Password);

                if (!result) {
                    return new ReturnSet<AuthenticationResponseItem>(ErrorCodes.AUTH_FAILED_USERNAME_OR_PASSWORD);
                }

                return new ReturnSet<AuthenticationResponseItem>(new AuthenticationResponseItem());
            }
        }

        public AuthenticationManager(APIRequestWrapper requestWrapper) : base(requestWrapper) { }
    }
}