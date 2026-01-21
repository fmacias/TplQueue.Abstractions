using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fmacias.TplQueue.Contracts
{
    public interface ITaskRunnerInfo
    {
        Guid Id { get; }
        string Name { get; }
        bool IsCompleted { get; }
        DateTime ExecutionStart { get; }
        TimeSpan ExecutionTime { get; }
        DateTime ExecutionEnd { get; }
        TaskStatus Status { get; }

        IReadOnlyCollection<ITaskRunnerInfo> Dependencies { get; }

        ITaskRunnerInfo[] GetInfoDependencies();

        /// <summary>
        /// Returns an immutable snapshot of this runner's info.
        /// </summary>
        ITaskRunnerInfo CopyInfo();
        ISerializedPayload PayloadSerializedData { get; }
    }
}
