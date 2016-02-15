using System.Collections.Generic;
using System.Runtime.Serialization;

using jcMSA.Common.PCL.Transports.Common;

namespace jcMSA.BaseContent.PCL.Transports {
    [DataContract]
    public class GlobalContentResponseItem : BaseResponse {
        [DataMember]
        public List<TagCloudResponseItem> TagCloud { get; set; }

        [DataMember]
        public List<LinkResponseItem> Links { get; set; }

        [DataMember]
        public List<ArchiveResponseItem> ArchiveList { get; set; }

        public GlobalContentResponseItem() {
            TagCloud = new List<TagCloudResponseItem>();
            Links = new List<LinkResponseItem>();
            ArchiveList = new List<ArchiveResponseItem>();
        } 
    }
}