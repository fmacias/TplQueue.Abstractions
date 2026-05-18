using System;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJobEvent
    {
        /// <summary>
        /// Execution status
        /// </summary>
        JobEventStatus Status { get; }
        /// <summary>
        /// Immutable metadata snapshot related to the <see cref="IJob"/> at publication time.
        /// Implementations are not required to expose payload ownership through this snapshot.
        /// </summary>
        IJobInfo JobInfo { get; }
        /// <summary>
        /// Exception thrown during execution
        /// </summary>
        Exception? Exception { get; }
        /// <summary>
        /// Event instantiation time
        /// </summary>
        DateTime Timestamp { get; }
        /// <summary>
        /// Number of retries
        /// </summary>
        int RetryCount { get; }
        string ToString();

    }
}
