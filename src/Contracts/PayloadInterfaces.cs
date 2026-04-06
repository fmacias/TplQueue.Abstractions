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
    }

    public interface IDataJob<T> : IDataJob where T : IPayload
    {
        T Payload { get; }
    }

    public interface IDataJobRoot : IJobRoot, IDataJobNode
    {
    }

    /// <summary>
    /// Strongly-typed root payload task runner.
    /// Extends the payload-carrying root and the base runner root contract.
    /// </summary>
    public interface IDataJobRoot<T> : IDataJobRoot
        where T : IPayload
    {
        T Payload { get; }
    }
}
