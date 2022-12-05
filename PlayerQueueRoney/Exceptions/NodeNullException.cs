using System.Runtime.Serialization;

namespace PlayerQueueRoney.Exceptions
{
    [Serializable]
    public class NodeNullException : Exception
    {
        public NodeNullException()
        {
        }

        public NodeNullException(string? message) : base(message)
        {
        }

        public NodeNullException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NodeNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
