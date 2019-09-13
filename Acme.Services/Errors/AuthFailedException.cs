using Acme.Errors;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Acme.Services.Errors
{
    [Serializable]
    public class AuthFailedException : BaseException
    {
        public AuthFailedException() { }
        public AuthFailedException(string message) : base(message) { }
        public AuthFailedException(string message, Exception innerException) : base(message, innerException) { }
        protected AuthFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
