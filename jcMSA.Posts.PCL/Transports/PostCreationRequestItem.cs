using System.Runtime.Serialization;

namespace jcMSA.Posts.PCL.Transports {
    [DataContract]
    public class PostCreationRequestItem {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Body { get; set; } 
    }
}