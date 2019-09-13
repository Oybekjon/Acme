using Acme.Errors;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Acme.Services.Errors
{
    //PasswordMismatchException
    [Serializable]
    public class PasswordMismatchException : BaseException
    {
        public PasswordMismatchException() { }
        public PasswordMismatchException(string message) : base(message) { }
        public PasswordMismatchException(string message, Exception innerException) : base(message, innerException) { }
        protected PasswordMismatchException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
