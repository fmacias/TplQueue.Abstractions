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
        /// Inmutable DTO(Data Transfer Object) related with the <see cref="IJob"/>
        /// </summary>
        IJobInfo JobDTO { get; }
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
