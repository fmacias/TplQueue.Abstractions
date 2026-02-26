using System;
using System.Collections.Generic;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Non-generic carrier to allow heterogeneous queues to enforce “serializable-only”.
    /// </summary>
    public interface IDataJob: IJob, IDataJobInfo
    {
        object GetPayload();
        Type PayloadType { get; }
        IReadOnlyList<IDataJob> GetDependentDataJobs();
    }

    public interface IDataJob<T> : IDataJob, IJob where T : IPayload
    {
        T Payload { get; }
    }

    public interface IDataJobRoot : IDataJob, IJobRoot
    {
    }

    /// <summary>
    /// Strongly-typed root payload task runner.
    /// Extends the payload-carrying root and the base runner root contract.
    /// </summary>
    public interface IDataJobRoot<T> : IDataJob<T>, IDataJobRoot
        where T : IPayload
    {
    }
}
