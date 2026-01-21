using System;
using System.Runtime.Serialization;

namespace Fmacias.TplQueue.Exceptions
{
    /// <summary>
    /// Exception indicating an inconsistency or recoverable business/workflow error.
    /// It should be logged as a WARNING and does not require dispatcher finalization.
    /// </summary>
    [Serializable]
    public sealed class TplQueueWarningException: Exception
    {
        public TplQueueWarningException()
        {
        }

        public TplQueueWarningException(string message)
            : base(message)
        {
        }

        public TplQueueWarningException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private TplQueueWarningException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
