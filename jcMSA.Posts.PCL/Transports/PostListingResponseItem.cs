using System;
using System.Runtime.Serialization;

using jcMSA.Common.PCL.Transports.Common;

namespace jcMSA.Posts.PCL.Transports {
    [DataContract]
    public class PostListingResponseItem : BaseResponse {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime PostDate { get; set; }

        [DataMember]
        public string URL { get; set; }
        
        [DataMember]
        public string Summary { get; set; }        
    }
}