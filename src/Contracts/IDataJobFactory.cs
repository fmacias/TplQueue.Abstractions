using System;

namespace Fmacias.TplQueue.Contracts
{
    /// <summary>
    /// Factory used to create and rehydrate payload-aware task runners.
    /// </summary>
    public interface IDataJobFactory
    {
        IDataJob<T> DataJob<T>(
            T payload,
            string name = "") where T : IPayload;
        
        IDataJob<T> DataJob<T>(
            Guid id,
            T payload,
            string name = "") where T : IPayload;

        IDataJob DataJob(
            IJobNodeDto dto,
            IPayload payload);

        IDataJobRoot<T> DataJobRoot<T>(
            T payload,
            string name = "") where T : IPayload;

        IDataJobRoot<T> DataJobRoot<T>(
            T payload,
            Func<IRetryPolicy> policy,
            string name = "") where T : IPayload;

        IDataJobRoot<T> DataJobRoot<T>(
            T payload,
            IRetryPolicyDescriptor retryPolicyDescriptor,
            string name = "") where T : IPayload;

        IDataJobRoot<T> DataJobRoot<T>(
            Guid id,
            T payload,
            string name = "") where T : IPayload;

        IDataJobRoot<T> DataJobRoot<T>(
            Guid id,
            T payload,
            IRetryPolicyDescriptor retryPolicyDescriptor,
            string name = "") where T : IPayload;

        IDataJobRoot DataJobRoot(
            IJobNodeDto dto,
            IPayload payload);

        IDataJobRoot<T> DataJobRoot<T>(
            Guid jobId,
            T payload,
            Func<IRetryPolicy> policy,
            string name = "") where T : IPayload;
    }
}
