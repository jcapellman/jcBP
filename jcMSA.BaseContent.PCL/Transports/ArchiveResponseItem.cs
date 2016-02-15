using System.Runtime.Serialization;

using jcMSA.Common.PCL.Transports.Common;

namespace jcMSA.BaseContent.PCL.Transports {
    [DataContract]
    public class ArchiveResponseItem : BaseResponse {
        [DataMember]
        public string DisplayText { get; set; }

        [DataMember]
        public string URL { get; set; }
    }
}