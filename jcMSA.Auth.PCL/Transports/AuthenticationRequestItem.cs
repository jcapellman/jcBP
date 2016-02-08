using System.Runtime.Serialization;

using jcMSA.Common.PCL.Transports.Common;

namespace jcMSA.Auth.PCL.Transports {
    [DataContract]
    public class AuthenticationRequestItem : BaseRequest {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}