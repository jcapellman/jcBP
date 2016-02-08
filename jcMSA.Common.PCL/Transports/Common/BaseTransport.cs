using System;
using System.Runtime.Serialization;

namespace jcMSA.Common.PCL.Transports.Common {
    [DataContract]
    public class BaseTransport {
        [DataMember]
        public Guid TransactionID { get; set; }
    }
}
