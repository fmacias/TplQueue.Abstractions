using System;

namespace Fmaciasruano.TplQueue.Abstractions.Contracts
{
    public interface ITaskRunnerEvent
    {
        /// <summary>
        /// Execution status
        /// </summary>
        TaskRunnerEventStatus Status { get; }
        /// <summary>
        /// Inmutable DTO(Data Transfer Object) related with the <see cref="ITaskRunner"/>
        /// </summary>
        ITaskRunnerInfo RunnerDTO { get; }
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
