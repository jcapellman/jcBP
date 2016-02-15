using System.Runtime.Serialization;

using jcMSA.Common.PCL.Transports.Common;

namespace jcMSA.BaseContent.PCL.Transports {
    [DataContract]
    public class ArchiveResponseItem : BaseResponse {
        [DataMember]
        public int PostCount { get; set; }

        [DataMember]
        public int Month { get; set; }

        [DataMember]
        public int Year { get; set; }
    }
}