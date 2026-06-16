using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory used to create and rehydrate payload-aware jobs.
    /// </summary>
    public interface IDataJobFactory
    {
        IDataJob<T> DataJob<T>(T payload, IHandler payloadHandler, string name = "") where T : IPayload;
        IDataJob<T> DataJob<T>(Guid id, T payload, IHandler payloadHandler, string name = "") where T : IPayload;
        IDataJob DataJob(IJobNodeRecord jobNodeRecord, IPayload payload, IHandler payloadHandler);
        IDataJobRoot<T> DataJobRoot<T>(T payload, IHandler payloadHandler, string name = "", Func<IRetryPolicy>? retryPolicy = null) where T : IPayload;
        IDataJobRoot<T> DataJobRoot<T>(Guid id, T payload, IHandler payloadHandler, string name = "",  Func<IRetryPolicy>? retryPolicy = null) where T : IPayload;
        IDataJobRoot DataJobRoot(Guid jobId, string name, IPayload payload, IHandler payloadHandler, Func<IRetryPolicy>? retryPolicy = null);
    }
}
