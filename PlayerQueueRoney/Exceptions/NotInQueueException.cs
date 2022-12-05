using System.Runtime.Serialization;

namespace PlayerQueueRoney.Exceptions
{
    [Serializable]
    public class NotInQueueException : Exception
    {
        public NotInQueueException()
        {
        }

        public NotInQueueException(string? message) : base(message)
        {
        }

        public NotInQueueException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotInQueueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}