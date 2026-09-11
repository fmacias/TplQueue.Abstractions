using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Non-generic carrier to allow heterogeneous queues to enforce “serializable-only”.
    /// </summary>
    public interface IDataJobNode : IJobNode, IDataJobInfo
    {
        object GetPayload();
        Type PayloadType { get; }
        IReadOnlyList<IDataJob> GetDependentDataJobs();
    }

    public interface IDataJob : IJob, IDataJobNode
    {
        /// <summary>
        /// Specifies that this data job must run after the given
        /// <paramref name="previousTasks"/>.
        /// </summary>
        /// <param name="previousTasks">Jobs that must complete before this data job can run.</param>
        new IDataJob After(params IJob[] previousTasks);
    }

    public interface IDataJob<T> : IDataJob where T : IPayload
    {
        T Payload { get; }
    }

    public interface IDataJobRoot : IJobRoot, IDataJobNode
    {
        /// <summary>
        /// Specifies that this data-job root must run after the given
        /// <paramref name="previousTasks"/>.
        /// </summary>
        /// <param name="previousTasks">Nodes that must complete before this root can run.</param>
        new IDataJobRoot After(params IJobNode[] previousTasks);
    }

    /// <summary>
    /// Strongly-typed root payload job.
    /// Extends the payload-carrying root and the base job-root contract.
    /// </summary>
    public interface IDataJobRoot<T> : IDataJobRoot
        where T : IPayload
    {
        T Payload { get; }
    }
}
