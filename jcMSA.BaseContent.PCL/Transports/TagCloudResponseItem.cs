using System.Runtime.Serialization;

using jcMSA.Common.PCL.Transports.Common;

namespace jcMSA.BaseContent.PCL.Transports {
    [DataContract]
    public class TagCloudResponseItem : BaseResponse {
        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string SafeName { get; set; }
    }
}