using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface IJobInfo
    {
        Guid Id { get; }
        string Name { get; }
        bool IsCompleted { get; }
        DateTime ExecutionStart { get; }
        TimeSpan ExecutionTime { get; }
        DateTime ExecutionEnd { get; }
        TaskStatus Status { get; }
        IReadOnlyCollection<IJobInfo> Dependencies { get; }
        /// <summary>
        /// Gets the dispatcher that first claimed this job instance for execution.
        /// <see cref="Guid.Empty"/> means the job has not been enqueued yet and can still
        /// be moved between roots during graph composition.
        /// </summary>
        Guid CrossQueueId { get; }
    }
}
