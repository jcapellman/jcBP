using System;
using System.Runtime.Serialization;

using jcMSA.Common.PCL.Transports.Common;

namespace jcMSA.Auth.PCL.Transports {
    [DataContract]
    public class AuthenticationResponseItem : BaseResponse {
        [DataMember]
        public Guid Token { get; set; }
    }
}