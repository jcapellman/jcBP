using System.Runtime.Serialization;

namespace jcMSA.Posts.PCL.Transports {
    [DataContract]
    public class TagResponseItem {
        [DataMember]
        public string SafeName { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}