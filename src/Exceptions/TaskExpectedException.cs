using System;
using System.Runtime.Serialization;

namespace Fmacias.TplQueue.Exceptions
{
    /// <summary>
    /// Exception that is expected as part of a normal workflow.
    /// It does not represent an error condition and should typically be logged at DEBUG level only.
    /// </summary>
    [Serializable]
    public sealed class TaskExpectedException : Exception
    {
        public TaskExpectedException()
        {
        }

        public TaskExpectedException(string message)
            : base(message)
        {
        }

        public TaskExpectedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private TaskExpectedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
