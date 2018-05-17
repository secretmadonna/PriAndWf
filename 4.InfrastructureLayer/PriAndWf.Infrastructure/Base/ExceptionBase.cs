using System;
using System.Runtime.Serialization;

namespace PriAndWf.Infrastructure.Base
{
    [Serializable]
    public class ExceptionBase : Exception
    {
        public ExceptionBase() { }
        public ExceptionBase(string message) : base(message) { }
        public ExceptionBase(string message, Exception innerException) : base(message, innerException) { }
        public ExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
