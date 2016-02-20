using System;

using jcMSA.Common.PCL.Enums;

namespace jcMSA.Client.MVC {
    public class jcBPWebException : Exception {
        public jcBPWebException(string message, ErrorCodes errorCode) : base(message) {
            this.ErrorCode = errorCode;            
        }

        public ErrorCodes ErrorCode { get; set; }
    }
}