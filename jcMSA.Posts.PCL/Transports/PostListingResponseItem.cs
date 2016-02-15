using System;
using System.Collections.Generic;
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
        public int ID { get; set; }

        [DataMember]
        public string Body { get; set; }

        [DataMember]
        public List<TagResponseItem> Tags { get; set; } 
    }
}