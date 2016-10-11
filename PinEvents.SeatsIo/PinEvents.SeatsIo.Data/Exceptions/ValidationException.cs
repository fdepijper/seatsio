using System;
using System.Runtime.Serialization;

namespace PinEvents.SeatsIo.Exceptions
{
    [Serializable]
    public class ValidationException : Exception, ISerializable
    {
        public String[] Parameter { get; set; }

        public ValidationException()
        {
        }
        
        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValidationException(string message, String[] parameters) : base(message)
        {
            this.Parameter = parameters;
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
