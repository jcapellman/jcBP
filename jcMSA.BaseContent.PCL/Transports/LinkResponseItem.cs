using System.Runtime.Serialization;

using jcMSA.Common.PCL.Transports.Common;

namespace jcMSA.BaseContent.PCL.Transports {
    [DataContract]
    public class LinkResponseItem : BaseResponse {
        [DataMember]
        public string DisplayText { get; set; }

        [DataMember]
        public string URL { get; set; }
    }
}