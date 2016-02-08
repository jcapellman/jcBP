using System;
using System.Runtime.Serialization;

using jcMSA.Common.PCL.Transports.Common;

namespace jcMSA.Common.PCL.Transports.Container {
    [DataContract]
    public class ReturnSet<T> where T : BaseTransport {
        [DataMember]
        public T ReturnValue { get; set; }
        
        public bool HasValue => ReturnValue != null;

        [DataMember]
        public string Exception { get; set; }

        public ReturnSet(T value) : this(value, string.Empty) { }

        public ReturnSet(T value, Exception exception) : this(value, exception.ToString()) { }

        public ReturnSet(T value, string exception) {
            ReturnValue = value;
            Exception = exception;
        } 
    }
}