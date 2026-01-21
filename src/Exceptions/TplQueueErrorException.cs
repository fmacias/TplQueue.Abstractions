using System;
using System.Runtime.Serialization;

namespace Fmacias.TplQueue.Exceptions
{
    /// <summary>
    /// Exception that represents a fatal, application-level error.
    /// When raised from inside the dispatcher, it should lead to dispatcher shutdown
    /// and typically to application termination decided by the host.
    /// </summary>
    [Serializable]
    public sealed class TplQueueErrorException : Exception
    {
        public TplQueueErrorException()
        {
        }

        public TplQueueErrorException(string message)
            : base(message)
        {
        }

        public TplQueueErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private TplQueueErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
