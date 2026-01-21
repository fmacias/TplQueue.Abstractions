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

        IJobInfo[] GetJobInfoDependencies();

        /// <summary>
        /// Returns an immutable snapshot of this runner's info.
        /// </summary>
        IJobInfo CopyInfo();
        ISerializedPayload PayloadSerializedData { get; }
    }
}
