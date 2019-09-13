using Acme.Errors;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Acme.Services.Errors
{
    [Serializable]
    public class DuplicateEmailException : BaseException
    {
        public DuplicateEmailException() { }
        public DuplicateEmailException(string message) : base(message) { }
        public DuplicateEmailException(string message, Exception innerException) : base(message, innerException) { }
        protected DuplicateEmailException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
